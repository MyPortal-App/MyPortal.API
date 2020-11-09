using Flogging.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace CoreLogger
{
    public static class WebHelper
    {        
        public static void LogWebUsage(string application, string layer, string activityName, HttpContext context, Dictionary<string, object> additionalInfo = null)
        {
            var details = GetWebFlogDetail(application, layer, activityName, context, additionalInfo);
            Flogger.WriteUsage(details);
        }

        public static void LogWebDiagnostic(string application, string layer, string message, HttpContext context, Dictionary<string, object> additionalInfo = null)
        {
            var details = GetWebFlogDetail(application, layer, message, context, additionalInfo);
            Flogger.WriteDiagnostic(details);
        }

        public static void LogWebError(string application, string layer, Exception ex, HttpContext context)
        {
            var details = GetWebFlogDetail(application, layer, null, context);
            details.Exception = ex;
            Flogger.WriteError(details);
        }

        public static FlogDetail GetWebFlogDetail(string application, string layer, string activityName, HttpContext context, Dictionary<string, object> additionalInfo = null)
        {
            var detail = new FlogDetail
            {
                Application = application,
                Layer = layer,
                Message = activityName,
                Hostname = Environment.MachineName,
                CorrelationId = Activity.Current?.Id ?? context.TraceIdentifier,
                AdditionalInfo = additionalInfo ?? new Dictionary<string, object>()
            };

            GetUserData(detail);
            GetRequestDate(detail, context);

            // Session data??
            // Cookie data??

            return detail;
        }

        private static void GetRequestDate(FlogDetail detail, HttpContext context)
        {
            var requst = context.Request;
            if (requst != null)
            {
                detail.Location = requst.Path;

                detail.AdditionalInfo.Add("UserAgent", requst.Headers["User-Agent"]);
                detail.AdditionalInfo.Add("Languages", requst.Headers["Accept-Language"]);

                var qdict = Microsoft.AspNetCore.WebUtilities
                    .QueryHelpers.ParseQuery(requst.QueryString.ToString());
                foreach(var key in qdict.Keys)
                {
                    detail.AdditionalInfo.Add($"QueryString-{key}", qdict[key]);
                }
            }
        }

        private static void GetUserData(FlogDetail detail)
        {
            var userId = "";
            var userName = "";
            var user = ClaimsPrincipal.Current;
            if(user != null)
            {
                var i = 1; // i include in the disctinary key to ensure uniqueness
                foreach(var claim in user.Claims)
                {
                    if (claim.Type == ClaimTypes.NameIdentifier)
                        userId = claim.Value;
                    else if (claim.Type == ClaimTypes.Name)
                        userName = claim.Value;
                    else
                        //example dictinary key: UserClaim-4-role
                        detail.AdditionalInfo.Add(
                            string.Format("UserClaim-{0}-{1}", i++, claim.Type), claim.Value);
                }
            }
            detail.UserId = userId;
            detail.UserName = userName;
        }
    }
}

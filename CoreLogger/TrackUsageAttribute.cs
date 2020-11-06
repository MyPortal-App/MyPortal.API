using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace CoreLogger
{
    public class TrackUsageAttribute : ActionFilterAttribute
    {

        private string _application, _layer, _activityName;

        public TrackUsageAttribute(string application, string layer, string activityName)
        {
            _application = application;
            _layer = layer;
            _activityName = activityName;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var dict = new Dictionary<string, object>();
            foreach (var key in context.RouteData.Values?.Keys)
                dict.Add($"RouteData-{key}", (string)context.RouteData.Values[key]);

            WebHelper.LogWebUsage(_application, _layer, _activityName, context.HttpContext, dict);
        }
    }
}

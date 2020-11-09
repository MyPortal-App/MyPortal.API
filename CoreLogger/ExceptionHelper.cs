using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CoreLogger
{
    public static class ExceptionHelper
    {
        public static string ToBetterString(this Exception ex, string prepend = null)
        {
            if (ex == null || string.IsNullOrEmpty(prepend))
                return string.Empty;

            var exceptionMesage = new StringBuilder();

            exceptionMesage.Append("\n" + prepend + "Exception:" + ex.GetType());
            exceptionMesage.Append("\n" + prepend + "Message:" + ex.GetType());

            exceptionMesage.Append(GetOtherExecptionProperties(ex, "\n" + prepend));

            exceptionMesage.Append("\n" + prepend + "Source:" + ex.Source);
            exceptionMesage.Append("\n" + prepend + "StackTrace:" + ex.StackTrace);

            exceptionMesage.Append(GetExceptionDate("\n" + prepend, ex));

            if (ex.InnerException != null)
                exceptionMesage.Append("\n" + prepend + "InnerException: "
                    + ex.InnerException.ToBetterString(prepend + "\t"));

            return exceptionMesage.ToString();
        }

        private static string GetExceptionDate(string prependText, Exception exception)
        {
            var exData = new StringBuilder();
            foreach(var key in exception.Data.Keys.Cast<object>().Where(key => exception.Data[key] != null))
            {
                exData.Append(prependText + String.Format("DAT-{0}:{1}", key, exception.Data[key]));
            }

            return exData.ToString();
        }

        private static string GetOtherExecptionProperties(Exception exception, string s)
        {
            var allOtherProps = new StringBuilder();
            var exPorpList = exception.GetType().GetProperties();

            var propertiesAlreadyHandled = new List<string>
            {
                "StrackTrace", "Message", "InnerException", "Data", "HelpLink",
                "Source", "TargetSite" 
            };

            foreach(var prop in exPorpList
                .Where(prop => !propertiesAlreadyHandled.Contains(prop.Name)))
            {
                var propObject = exception.GetType().GetProperty(prop.Name)
                    .GetValue(exception, null);
                var propEnumerable = propObject as IEnumerable;

                if (propEnumerable == null || propObject is string)
                    allOtherProps.Append(s + String.Format("{0} : {1}",
                        prop.Name, propObject));
                else
                {
                    var eumerableSb = new StringBuilder();
                    foreach(var item in propEnumerable)
                    {
                        eumerableSb.Append(item + "|");
                    }
                    allOtherProps.Append(s + String.Format("{0} : {1}",
                        prop.Name, eumerableSb));
                }

            }

            return allOtherProps.ToString();
        }
    }
}

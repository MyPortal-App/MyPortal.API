using Microsoft.AspNetCore.Hosting.Internal;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flogging.Core
{
    public static class Flogger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static Flogger()
        {
            string strPath = "c:\\tests\\logs\\Flogger\\";
           
            _perfLogger = new LoggerConfiguration()
                //.WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_PERF"))
                .WriteTo.File(path: strPath + "perf.txt")
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                //.WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_USAGE"))
                .WriteTo.File(path: strPath + "usage.txt")                
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                //.WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_ERROR"))
                .WriteTo.File(path: strPath + "error.txt")                
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                //.WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_DIAG"))
                .WriteTo.File(path: strPath + "diagnosticLogger.txt")
                .CreateLogger();
        }

        public static void WritePerf(FlogDetail infoToLog)
        {
            _perfLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteUsage(FlogDetail infoToLog)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteError(FlogDetail infoToLog)
        {
            if(infoToLog.Exception != null)
            {
                var procName = FindProcName(infoToLog.Exception);
                infoToLog.Location = string.IsNullOrEmpty(procName) ? infoToLog.Location : procName;
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
            }
            _errorLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteDiagnostic(FlogDetail infoLog)
        {
            //var writeDiagnostic = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
            var writeDiagnostic = Convert.ToBoolean(ConfigurationManager.AppSettings["DefaultConnection"]);
            if (!writeDiagnostic)
                return;

            _diagnosticLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoLog);
        }

        private static string GetMessageFromException(Exception ex)
        {
            if (ex.InnerException != null)
                return GetMessageFromException(ex.InnerException);

            return ex.Message;
        }

        private static string FindProcName(Exception ex)
        {
            var sqlEx = ex as SqlException;
            if(sqlEx != null)
            {
                var procName = sqlEx.Procedure;
                if (!string.IsNullOrEmpty((string)ex.Data["Procedure"]))
                {
                    return (string)ex.Data["Procedure"];
                }

                if (ex.InnerException != null)
                    return FindProcName(ex.InnerException);
            }
            return null;
        }
    }
}

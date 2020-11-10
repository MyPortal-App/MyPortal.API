using CoreLogger;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        private static IConfiguration Configuration { get; }

        //private static SqlConnection DbConnection { get { return new SqlConnection(Configuration.GetConnectionString("DefaultConnection")); } }

        static Flogger()
        {            
            var connStr = @"Server=localhost;Database=MyPortal;Trusted_Connection=True;MultipleActiveResultSets=true";
                       
            _usageLogger = new LoggerConfiguration()                
                .WriteTo.MSSqlServer(connStr, "UsageLogs", autoCreateSqlTable: true, columnOptions: GetSqlColumnOptions(), batchPostingLimit: 1)                
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()                
                .WriteTo.MSSqlServer(connStr, "ErrorLogs", autoCreateSqlTable: true, columnOptions: GetSqlColumnOptions(), batchPostingLimit: 1)
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()                
                .WriteTo.MSSqlServer(connStr, "DiagnosticLog", autoCreateSqlTable: true, columnOptions: GetSqlColumnOptions(), batchPostingLimit: 1)
                .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
        }

        public static ColumnOptions GetSqlColumnOptions()
        {
            var colOptions = new ColumnOptions();
            colOptions.Store.Remove(StandardColumn.Properties);
            colOptions.Store.Remove(StandardColumn.MessageTemplate);
            colOptions.Store.Remove(StandardColumn.Message);
            colOptions.Store.Remove(StandardColumn.Exception);
            colOptions.Store.Remove(StandardColumn.TimeStamp);
            colOptions.Store.Remove(StandardColumn.Level);

            colOptions.AdditionalDataColumns = new Collection<DataColumn>
            {
                new DataColumn{DataType = typeof(DateTime), ColumnName = "Timestamp"},
                new DataColumn{DataType = typeof(string), ColumnName = "Application"},
                new DataColumn{DataType = typeof(string), ColumnName = "Layer"},
                new DataColumn{DataType = typeof(string), ColumnName = "Location"},
                new DataColumn{DataType = typeof(string), ColumnName = "Message"},
                new DataColumn{DataType = typeof(string), ColumnName = "Hostname"},
                new DataColumn{DataType = typeof(string), ColumnName = "UserId"},                
                new DataColumn{DataType = typeof(string), ColumnName = "UserName"},
                new DataColumn{DataType = typeof(int), ColumnName = "ElapsedMiliseconds"},
                new DataColumn{DataType = typeof(string), ColumnName = "CorrelationId"},
                new DataColumn{DataType = typeof(string), ColumnName = "CustomException"},
                new DataColumn{DataType = typeof(string), ColumnName = "AdditinalInfo"},
            };

            return colOptions;
        }

        public static void WritePerf(FlogDetail infoToLog)
        {
            //_perfLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
            _perfLogger.Write(LogEventLevel.Information,
            "{Timestamp}{Message}{Layer}{Location}{Product}" +
            "{ElapsedMiliseconds}{Excpetion}{Hostname}" +
            "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
            infoToLog.Timestamp, infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Application,
            infoToLog.EllapsedMilliseconds ?? 0,
            infoToLog.Exception?.ToBetterString(),
            infoToLog.Hostname, infoToLog.UserId,
            infoToLog.UserName, infoToLog.CorrelationId,
            infoToLog.AdditionalInfo);
        }

        public static void WriteUsage(FlogDetail infoToLog)
        {
            //_usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
            _usageLogger.Write(LogEventLevel.Information,
           "{Timestamp}{Message}{Layer}{Location}{Application}" +
           "{ElapsedMiliseconds}{Excpetion}{Hostname}" +
           "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
           infoToLog.Timestamp, infoToLog.Message,
           infoToLog.Layer, infoToLog.Location,
           infoToLog.Application,
           infoToLog.EllapsedMilliseconds ?? 0, 
           infoToLog.Exception?.ToBetterString(),
           infoToLog.Hostname, infoToLog.UserId,
           infoToLog.UserName, infoToLog.CorrelationId,
           infoToLog.AdditionalInfo);
        }

        public static void WriteError(FlogDetail infoToLog)
        {
            if (infoToLog.Exception != null)
            {
                var procName = FindProcName(infoToLog.Exception);
                infoToLog.Location = string.IsNullOrEmpty(procName) ? infoToLog.Location : procName;
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
            }
            //_errorLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);

            _errorLogger.Write(LogEventLevel.Information,
           "{Timestamp}{Message}{Layer}{Location}{Application}" +
           "{ElapsedMiliseconds}{Excpetion}{Hostname}" +
           "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
           infoToLog.Timestamp, infoToLog.Message,
           infoToLog.Layer, infoToLog.Location,
           infoToLog.Application,
           infoToLog.EllapsedMilliseconds ?? 0, 
           infoToLog.Exception?.ToBetterString(),
           infoToLog.Hostname, infoToLog.UserId,
           infoToLog.UserName, infoToLog.CorrelationId,
           infoToLog.AdditionalInfo);
        }

        public static void WriteDiagnostic(FlogDetail infoToLog)
        {
            ////var writeDiagnostic = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
            //var writeDiagnostic = Convert.ToBoolean(ConfigurationManager.AppSettings["DefaultConnection"]);
            //if (!writeDiagnostic)
            //    return;

            //_diagnosticLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoLog);

            _diagnosticLogger.Write(LogEventLevel.Information,
           "{Timestamp}{Message}{Layer}{Location}{Application}" +
           "{ElapsedMiliseconds}{Excpetion}{Hostname}" +
           "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
           infoToLog.Timestamp, infoToLog.Message,
           infoToLog.Layer, infoToLog.Location,
           infoToLog.Application,
           infoToLog.EllapsedMilliseconds ?? 0, 
           infoToLog.Exception?.ToBetterString(),
           infoToLog.Hostname, infoToLog.UserId,
           infoToLog.UserName, infoToLog.CorrelationId,
           infoToLog.AdditionalInfo);
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MyPortal.Services.Connetion
{
    public class ConfigurationBasedConnectionStringProvider : IConnectionStringProvider<string>
    {
        public string GetConnectionString(string context)
        {
            var result = ConfigurationManager.ConnectionStrings[context].ConnectionString;
            return result;
        }
    }
}

using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Data;

namespace MyPortal.DatabaseFactory
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IConfiguration Configuration { get; set; }

        public ConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IDbConnection DefaultConnection { get { return new MySqlConnection(Configuration.GetConnectionString("DefaultConnection")); } }
        
        public IDbConnection Log4NetDBConnection { get { return new MySqlConnection(Configuration.GetConnectionString("log4net")); } }

        public IDbConnection GetDatabaseConnectionByName(string ConnectionName)
        {
            if (string.IsNullOrEmpty(Configuration.GetConnectionString(ConnectionName))) throw new ArgumentException("Connection string name cannot be null");

            IDbConnection connection = new MySqlConnection(Configuration.GetConnectionString(ConnectionName));

            return connection;
        }        
    }
}

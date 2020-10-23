using System.Data.SqlClient;

namespace MyPortal.Services.Connetion
{
    public class GreedyConnectionManager : IConnectionManager<SqlConnection>
    {
        private readonly IConnectionStringProvider<string> connectionStringProvider;

        public GreedyConnectionManager(
            IConnectionStringProvider<string> connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = connectionStringProvider.GetConnectionString("DefaultConnection");
            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}

using System;
using System.Data;

namespace MyPortal.DatabaseFactory
{
    public interface IConnectionFactory
    {
        IDbConnection GetDatabaseConnectionByName(string ConnectionName);   
        IDbConnection Log4NetDBConnection { get; }
        IDbConnection DefaultConnection { get; }   
    }
}

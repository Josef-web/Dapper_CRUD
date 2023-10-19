using System.Data;
using System.Data.SqlClient;

namespace Dapper_CRUD.DataAccess;

public class Context
{
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlCon");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    
}
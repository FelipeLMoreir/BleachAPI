using Microsoft.Data.SqlClient;

namespace BleachAPI.DataBase
{
    public class SqliteConnection
    {
        private readonly string _connectionString;
        public SqliteConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
             return new SqlConnection(_connectionString);
        }
    }
}

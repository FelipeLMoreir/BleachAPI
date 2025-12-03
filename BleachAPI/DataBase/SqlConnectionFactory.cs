using Microsoft.Data.SqlClient;

namespace BleachAPI.DataBase
{
    public class SqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection missing");
        }

        public SqlConnection GetConnection() => new SqlConnection(_connectionString);
    }
}

using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace WebApp.Configuration
{
    public class DbConnectionFactory
    {
        private readonly IOptions<CustomConfiguration> _customConfiguration;

        public DbConnectionFactory(IOptions<CustomConfiguration> customConfiguration)
        {
            _customConfiguration = customConfiguration;
        }

        public virtual IDbConnection Create()
        {
            var connection = new NpgsqlConnection(_customConfiguration.Value.ConnectionString);
            connection.Open();

            return connection;
        }
    }
}
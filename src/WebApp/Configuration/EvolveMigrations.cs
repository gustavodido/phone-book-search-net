using System;

namespace WebApp.Configuration
{
    public class EvolveMigrations
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public EvolveMigrations(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Migrate()
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                var evolve = new Evolve.Evolve(connection, Console.WriteLine);
                evolve.Migrate();
            }
        }
    }
}
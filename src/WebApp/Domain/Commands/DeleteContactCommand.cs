using System;
using Dapper;
using Microsoft.Extensions.Options;
using WebApp.Configuration;

namespace WebApp.Domain.Commands
{
    public class DeleteContactCommand
    {
        private readonly IOptions<CustomConfiguration> _customConfiguration;
        private readonly DbConnectionFactory _dbConnectionFactory;

        public DeleteContactCommand(IOptions<CustomConfiguration> customConfiguration, DbConnectionFactory dbConnectionFactory)
        {
            _customConfiguration = customConfiguration;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public virtual void Run(Guid uuid)
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                connection.Execute(_customConfiguration.Value.DeleteCommand, new
                {
                    Uuid = uuid
                });
            }
        }
    }
}
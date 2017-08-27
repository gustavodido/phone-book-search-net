using System;
using Dapper;
using Microsoft.Extensions.Options;
using WebApp.Configuration;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Commands
{
    public class SaveContactCommand
    {
        private readonly IOptions<CustomConfiguration> _customConfiguration;
        private readonly DbConnectionFactory _dbConnectionFactory;

        public SaveContactCommand(IOptions<CustomConfiguration> customConfiguration, DbConnectionFactory dbConnectionFactory)
        {
            _customConfiguration = customConfiguration;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public virtual Guid Run(Contact contact)
        {
            var sqlCommand = _customConfiguration.Value.UpdateCommand;
            var contactGuid = contact.Uuid;

            if (contactGuid == Guid.Empty)
            {
                contactGuid = Guid.NewGuid();
                sqlCommand = _customConfiguration.Value.InsertCommand;
            }

            using (var connection = _dbConnectionFactory.Create())
            {
                connection.Execute(sqlCommand, new
                {
                    contact.FirstName,
                    contact.LastName,
                    contact.HomePhone,
                    contact.WorkPhone,
                    contact.MobilePhone,
                    Uuid = contactGuid
                });
            }

            return contactGuid;
        }
    }
}
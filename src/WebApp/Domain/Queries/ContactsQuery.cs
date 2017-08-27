using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;
using Dapper;
using Microsoft.Extensions.Options;
using WebApp.Configuration;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Queries
{
    public class ContactsQuery
    {
        private readonly IOptions<CustomConfiguration> _customConfiguration;
        private readonly DbConnectionFactory _dbConnectionFactory;

        public ContactsQuery(IOptions<CustomConfiguration> customConfiguration,
            DbConnectionFactory dbConnectionFactory)
        {
            _customConfiguration = customConfiguration;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public virtual IEnumerable<Contact> Run()
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                return connection
                    .Query<Contact>(_customConfiguration.Value.ContactsQuery)
                    .ToList();
            }
        }
    }
}
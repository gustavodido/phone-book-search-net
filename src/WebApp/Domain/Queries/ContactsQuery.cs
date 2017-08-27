using System.Collections.Generic;
using System.Linq;
using Npgsql;
using WebApp.Domain.Entity;
using Dapper;
using Microsoft.Extensions.Options;
using WebApp.Configuration;

namespace WebApp.Domain.Queries
{
    public class ContactsQuery
    {
        private readonly IOptions<CustomConfiguration> _customConfiguration;

        public ContactsQuery(IOptions<CustomConfiguration> customConfiguration)
        {
            _customConfiguration = customConfiguration;
        }

        public virtual IEnumerable<Contact> Run()
        {
            using(var connection = new NpgsqlConnection(_customConfiguration.Value.ConnectionString)) {  
                connection.Open();
                
                return connection.Query<Contact>(_customConfiguration.Value.ContactsQuery).ToList();
            }
        }
    }
}
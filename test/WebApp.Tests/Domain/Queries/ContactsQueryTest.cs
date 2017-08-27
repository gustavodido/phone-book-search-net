using System.Data;
using System.Data.Common;
using Dapper;
using FakeItEasy;
using Microsoft.Extensions.Options;
using WebApp.Configuration;
using WebApp.Domain.Queries;
using WebApp.Tests.Common;
using Xunit;

namespace WebApp.Tests.Domain.Queries
{
    public class ContactsQueryTest
    {
        private readonly IOptions<CustomConfiguration> _customConfiguration;
        private readonly DbConnectionFactory _dbConnectionFactory;

        private readonly ContactsQuery _contactsQuery;

        public ContactsQueryTest()
        {
            _dbConnectionFactory = A.Fake<DbConnectionFactory>();
            _customConfiguration = A.Fake<IOptions<CustomConfiguration>>();

            _contactsQuery = new ContactsQuery(_customConfiguration, _dbConnectionFactory);
        }

        [Fact]
        public void ShoulQueryDatabaseConnectionToGetTheContacts()
        {
//            var expectedContacts = new[] {Constants.Gustavo};
//
//            var fakeConnection = A.Fake<IDbConnection>();
//            
//            A.CallTo(() => _databaseConnection.Create()).Returns(fakeConnection);
//
//            A.CallTo(() => fakeConnection.Query<Contact>(A<string>.Ignored, null, null, true, null, null))
//                .Returns(expectedContacts);
//
//            var contacts = _contactsQuery.Run();
//            
//            Assert.Equal(contacts, expectedContacts);
        }
    }
}
using WebApp.Controllers;
using WebApp.Domain.Queries;
using Xunit;
using FakeItEasy;
using WebApp.Tests.Common;

namespace WebApp.Tests.Controllers
{
    public class ContactControllerTest
    {
        private readonly ContactsQuery _contactsQuery;
        private readonly ContactController _contactController;

        public ContactControllerTest()
        {
            _contactsQuery = A.Fake<ContactsQuery>();
            _contactController = new ContactController(_contactsQuery);
        }

        [Fact]
        public void ContactsShouldListAllContacts()
        {
            var expectedContacts = new [] { Constants.Gustavo, Constants.Tuany};
            
            A.CallTo(() => _contactsQuery.Run()).Returns(expectedContacts);

            Assert.Equal(_contactController.List(), expectedContacts);
        }
    }
}

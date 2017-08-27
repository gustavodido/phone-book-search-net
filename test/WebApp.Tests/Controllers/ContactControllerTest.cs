using WebApp.Controllers;
using WebApp.Domain.Queries;
using Xunit;
using FakeItEasy;
using WebApp.Domain.Commands;
using WebApp.Tests.Common;

namespace WebApp.Tests.Controllers
{
    public class ContactControllerTest
    {
        private readonly ContactsQuery _contactsQuery;
        private readonly SaveContactCommand _saveContactCommand;
        private readonly DeleteContactCommand _deleteContactCommand;
        
        private readonly ContactController _contactController;

        public ContactControllerTest()
        {
            _saveContactCommand = A.Fake<SaveContactCommand>();
            _contactsQuery = A.Fake<ContactsQuery>();
            _deleteContactCommand = A.Fake<DeleteContactCommand>();
            
            _contactController = new ContactController(_contactsQuery, _saveContactCommand, _deleteContactCommand);
        }

        [Fact]
        public void ContactsShouldListAllContacts()
        {
            var expectedContacts = new [] { Constants.Gustavo, Constants.Tuany};
            
            A.CallTo(() => _contactsQuery.Run()).Returns(expectedContacts);

            Assert.Equal(_contactController.List(), expectedContacts);

            A.CallTo(() => _contactsQuery.Run()).MustHaveHappened();
            
        }
        
        [Fact]
        public void ContactShouldBeAdded()
        {
            _contactController.Save(Constants.Gustavo);
            
            A.CallTo(() => _saveContactCommand.Run(Constants.Gustavo)).MustHaveHappened();
        }

        [Fact]
        public void ContactShouldBeRemoved()
        {
            A.CallTo(() => _deleteContactCommand.Run(Constants.Gustavo.Uuid)).DoesNothing();

            _contactController.Delete(Constants.Gustavo.Uuid);
            
            A.CallTo(() => _deleteContactCommand.Run(Constants.Gustavo.Uuid)).MustHaveHappened();
        }

    }
}

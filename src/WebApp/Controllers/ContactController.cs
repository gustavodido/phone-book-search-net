using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Commands;
using WebApp.Domain.Entity;
using WebApp.Domain.Queries;

namespace WebApp.Controllers
{
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        private readonly ContactsQuery _contactsQuery;
        private readonly SaveContactCommand _saveContactCommand;
        private readonly DeleteContactCommand _deleteContactCommand;

        public ContactController(ContactsQuery contactsQuery, 
            SaveContactCommand saveContactCommand, 
            DeleteContactCommand deleteContactCommand)
        {
            _contactsQuery = contactsQuery;
            _saveContactCommand = saveContactCommand;
            _deleteContactCommand = deleteContactCommand;
        }

        [HttpGet]
        public IEnumerable<Contact> List()
        {
            return _contactsQuery.Run();
        }

        [HttpPost]
        public void Save(Contact contact)
        {
            _saveContactCommand.Run(contact);
        }

        [HttpDelete("/{uuid}")]
        public void Delete(Guid uuid)
        {
            _deleteContactCommand.Run(uuid);
        } 
    }
}

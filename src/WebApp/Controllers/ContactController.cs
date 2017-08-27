using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Commands;
using WebApp.Domain.Entities;
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
        public void Save([FromBody] Contact newContact)
        {
            _saveContactCommand.Run(newContact);
        }

        [HttpDelete("{uuid}")]
        public void Delete([FromRoute] Guid uuid)
        {
            _deleteContactCommand.Run(uuid);
        } 
    }
}

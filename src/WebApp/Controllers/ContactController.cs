using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Entity;
using WebApp.Domain.Queries;

namespace WebApp.Controllers
{
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        private readonly ContactsQuery _contactsQuery;

        public ContactController(ContactsQuery contactsQuery)
        {
            _contactsQuery = contactsQuery;
        }

        [HttpGet]
        public IEnumerable<Contact> List()
        {
            return _contactsQuery.Run();
        }
    }
}

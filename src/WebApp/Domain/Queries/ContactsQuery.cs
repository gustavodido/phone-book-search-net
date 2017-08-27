using System;
using System.Collections.Generic;
using WebApp.Domain.Entity;

namespace WebApp.Domain.Queries
{
    public class ContactsQuery
    {
        public virtual IEnumerable<Contact> Run()
        {
            return new[]
            {
                new Contact(Guid.NewGuid(), "Gustavo", "Domenico", "123", "456", "789"),
                new Contact(Guid.NewGuid(), "Tuany", "Domenico", "123", "456", "789")
            };
        }
    }
}
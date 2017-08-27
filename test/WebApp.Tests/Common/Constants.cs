using System;
using WebApp.Domain.Entity;

namespace WebApp.Tests.Common
{
    public class Constants
    {
        private Constants()
        {
            // restrict instantiation    
        }
        
        public static readonly Contact Gustavo = new Contact(Guid.NewGuid(), "Gustavo", "Domenico", "123", "456", "789");
        public static readonly Contact NewContact = new Contact(Guid.NewGuid(), "Gustavo", "Domenico", "123", "456", "789");
        public static readonly Contact Tuany = new Contact(Guid.NewGuid(), "Tuany", "Muller", "987", "654", "321");
    }
}
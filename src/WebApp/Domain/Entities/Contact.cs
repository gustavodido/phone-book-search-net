using System;

namespace WebApp.Domain.Entity
{
    public class Contact
    {
        public Contact(Guid uuid, string firstName, string lastName, string homePhone, string workPhone, string mobilePhone)
        {
            Uuid = uuid;
            FirstName = firstName;
            LastName = lastName;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
        }

        public Guid Uuid { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public string HomePhone { get; }
        public string WorkPhone { get; }
        public string MobilePhone { get; }
        
        public string FullName => String.Format("{0} {1}", FirstName, LastName);
    }
}
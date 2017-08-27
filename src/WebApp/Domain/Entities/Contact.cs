using System;

namespace WebApp.Domain.Entities
{
    public class Contact
    {
        public Contact()
        {
            
        }
        
        public Contact(Guid uuid, string firstName, string lastName, string homePhone, string workPhone, string mobilePhone)
        {
            Uuid = uuid;
            FirstName = firstName;
            LastName = lastName;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
        }

        public Guid Uuid { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        
        public string FullName => String.Format("{0} {1}", FirstName, LastName);
    }
}
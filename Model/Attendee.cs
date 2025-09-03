using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Attendee : User, IContactable
    {
        public override UserRole Role => UserRole.Attendee;

        public Attendee(string name, string password, string contactnumber, string email, string gender)
            : base(name, password)
        {
            ContactNumbers = contactnumber;
            Email = email;
            Gender = gender;
        }

        // convenience overload (e.g., for session -> object)
        public Attendee(string name, string password) : base(name, password) { }

        // property names
        public string ContactNumbers { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public bool IsContactValid()
        {
            return !string.IsNullOrWhiteSpace(Email) && Email.Contains("@")
                   && !string.IsNullOrWhiteSpace(ContactNumbers);
        }
    }
}


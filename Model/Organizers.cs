using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Organizers : User, IContactable
    {
        public override UserRole Role => UserRole.Organizer;

        public Organizers(string name, string password, string contactnumber, string email, string gender)
            : base(name, password)
        {
            ContactNumbers = contactnumber;
            Email = email;
            Gender = gender;
        }

        public string ContactNumbers { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public bool IsContactValid()
        {
            return !string.IsNullOrWhiteSpace(Email) && Email.Contains("@")
                   && !string.IsNullOrWhiteSpace(ContactNumbers);
        }

        public override double ApplyDiscount(double subtotal) => subtotal * 0.90; // 10% off for Organizers
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    // Base abstract user for inheritance + polymorphism
    public abstract class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        // Forces subclasses to declare their role (enum)
        public abstract UserRole Role { get; }

        // Polymorphic hook default = no discount
        public virtual double ApplyDiscount(double subtotal) => subtotal;

        protected User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}

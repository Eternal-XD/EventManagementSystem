using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Admin : User
    {
        public override UserRole Role => UserRole.Admin;

        public Admin(string name, string password) : base(name, password) { }

        // Keep behavior unchanged (no discount)
        public override double ApplyDiscount(double subtotal) => subtotal;

        public string authenticateAdmin(Admin admin)
        {
            if (admin.Name == "admin" && admin.Password == "admin123")
                return "admin";
            return null;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    public static class UserFactory
    {
        // Builds a concrete User from Session state
        public static User FromSession()
        {
            var name = Session.Username ?? string.Empty;
            var pw = Session.Password ?? string.Empty;
            var type = (Session.UserType ?? string.Empty).ToLowerInvariant();

            switch (type)
            {
                case "organizer":
                case "organisers": // spelling safety
                    return new Organizers(name, pw, "", "", "");
                case "admin":
                    return new Admin(name, pw);
                default:
                    return new Attendee(name, pw);
            }
        }
    }
}


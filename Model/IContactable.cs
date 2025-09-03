using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    public interface IContactable
    {
        string ContactNumbers { get; set; }
        string Email { get; set; }

        bool IsContactValid();
    }
}


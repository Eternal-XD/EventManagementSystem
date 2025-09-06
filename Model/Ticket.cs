using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Ticket
    {
        public int Id { get; set; }
        public Events Event { get; set; }

        public string TicketType { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Available { get; set; }

        public Ticket(Events eventItem, string ticketType, double price, int quantity)
        {
            Event = eventItem;
            TicketType = ticketType;
            Price = price;
            Quantity = quantity;
            Available = true;
        }

    }
}

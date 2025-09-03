using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    class Purchase
    {
        public Purchase(int ticket_id, int quantity)
        {
            this.Ticket_id = ticket_id;
            this.Quantity = quantity;
            this.Attendee_id = Session.Id;

            this.Total = 0;


        }

        public int Id { get; set; }
        public int Ticket_id { get; set; }
        public int Quantity { get; set; }
        public int Attendee_id { get; set; }

        public double Total { get; set; }
    }
}

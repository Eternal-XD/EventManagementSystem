using EventManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagmentSystem.View
{
    public partial class DeleteEvent: Form
    {
        public DeleteEvent()
        {
            InitializeComponent();
        }

        private void DeleteEvent_Load(object sender, EventArgs e)
        {
            List<Events> events = new Controller.EventController().getEventsbyOrganizer(Session.Id);

            if (events.Count > 0)
            {
                comboBox1.DataSource = events;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No events found for the organizer.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int EventId = (int)comboBox1.SelectedValue;
            new Controller.EventController().deleteEvent(EventId);

            DeleteEvent_Load(sender, e);

            this.Hide();
        }
    }
}

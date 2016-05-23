using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logging logWindow = new Logging();
            logWindow.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Calendar calenderView = new Calendar();
            calenderView.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Customer_Details newCustomer = new Add_Customer_Details();
            newCustomer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Coach newCoach = new Add_Coach();
            newCoach.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TabbedMenu tb = new TabbedMenu();
            tb.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Interfaces.RemoveCoach removeCoach = new Interfaces.RemoveCoach();
            removeCoach.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Interfaces.DeleteCustomer deleteCustomer = new Interfaces.DeleteCustomer();
            deleteCustomer.Show();
        }
    }
}

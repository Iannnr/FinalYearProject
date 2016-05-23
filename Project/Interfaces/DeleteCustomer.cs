using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Models;
using System.Data.Entity.Infrastructure;
using Project.Details.Validation;

namespace Project.Interfaces
{
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void searchCustomer_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                RemoveCustomerList.Items.Clear();
                if (string.IsNullOrWhiteSpace(RemoveCustomerFirstName.Text) && string.IsNullOrEmpty(RemoveCustomerLastName.Text))
                {
                    List<string> p = db.Customers.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                    foreach (var c in p)
                    {
                        RemoveCustomerList.Items.Add(c);
                    }
                }
                try
                {
                    if (RemoveCustomerFirstName.Text != null || RemoveCustomerLastName.Text != null)
                    {
                        List<string> p = db.Players.Where(x => x.Firstname == (RemoveCustomerFirstName.Text) || x.Lastname == (RemoveCustomerLastName.Text)).Select(x => x.Firstname + " " + x.Lastname).ToList();
                        foreach (var c in p)
                        {
                            RemoveCustomerList.Items.Add(c);
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Please enter at least one value");
                }
            }
        }

        private void removeCustomerButton_Click(object sender, EventArgs e)
        {
            //set up as separate class and call class from button press
            using (var db = new DatabaseContext())
            {
                //split drop down menu into first name and last name
                string[] names = RemoveCustomerList.Text.ToString().Split(' ');

                string firstname = names[0].ToString();
                string lastname = names[1].ToString();

                try
                {
                    //remove rows in database related to the first name and last name of selected customer
                    var removePlayer = db.Players.FirstOrDefault(x => x.Firstname == firstname && x.Lastname == lastname);
                    var removeCustomer = db.Customers.FirstOrDefault(x => x.player.Firstname == firstname && x.player.Lastname == lastname);
                    var removeCoach = db.Coach.FirstOrDefault(x => x.player.Firstname == firstname && x.player.Lastname == lastname);
                    //var toRemove3 = db.Matches.FirstOrDefault(x => x.player.Firstname == firstname && x.player.Lastname == lastname); (for match removal)

                    try
                    {
                        db.Players.Remove(removePlayer);
                        db.Customers.Remove(removeCustomer);
                        db.Coach.Remove(removeCoach);
                    }
                    catch (ArgumentNullException)
                    {

                    }

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException d)
                    {
                        MessageBox.Show(d.ToString());
                    }
                }
                catch (NotSupportedException c)
                {
                    MessageBox.Show(c.ToString());
                }
            }
        }
    }
}

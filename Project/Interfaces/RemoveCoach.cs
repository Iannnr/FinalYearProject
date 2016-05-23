using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using Project.Details.Validation;

namespace Project.Interfaces
{
    public partial class RemoveCoach : Form
    {
        public RemoveCoach()
        {
            InitializeComponent();
            PopulateDropdownMenu();
        }

        private void removeCoachButton_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                //split drop down menu into first name and last name
                string[] names = RemoveCoachComboBox.Text.ToString().Split(' ');
                string firstname = names[0].ToString();
                string lastname = names[1].ToString();
                //
                try
                {
                    //remove rows in database related to the first name and last name of selected customer
                    var removePlayer = db.Players.FirstOrDefault(x => x.Firstname == firstname && x.Lastname == lastname);
                    var removeCoach = db.Coach.FirstOrDefault(x => x.player.Firstname == firstname && x.player.Lastname == lastname);
                    //var toRemove3 = db.Matches.FirstOrDefault(x => x.player.Firstname == firstname && x.player.Lastname == lastname); (for match removal)

                    db.Players.Remove(removePlayer);
                    db.Coach.Remove(removeCoach);

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

        private void PopulateDropdownMenu()
        {

            using (var db = new DatabaseContext())
            {
                List<string> coaches = db.Coach.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                foreach (var x in coaches)
                {
                    RemoveCoachComboBox.Items.Add(x);
                }
            }
        }
    }
}

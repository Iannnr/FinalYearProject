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

namespace Project
{
    public partial class Add_Coach : Form
    {

        //coach details
        string coachFirstname;
        string coachLastname;
        int[] RGBColour = new int[3];
        
        public Add_Coach()
            {
                InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            //firstname = addCoachFirstNameTextBox.Text.ToString();
            //lastname = addCoachLastNameTextBox.Text.ToString();
            //CoachColorHexValue = comboBox1.Text.ToString();

            //using (var db = new DatabaseContext())
            //{
            //    if (!checkIfColourTaken(CoachColorHexValue))
            //    {
            //        Coach c = new Coach();
            //        c.player = new Player();
            //        c.player.Firstname = firstname;
            //        c.player.Lastname = lastname;
            //        c.CoachColor = CoachColorHexValue;

            //        db.Coach.Add(c);
            //        db.SaveChanges();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Colour already taken!");
            //    }
            //}
            coachFirstname = addCoachFirstNameTextBox.Text;
            coachLastname = addCoachLastNameTextBox.Text;
            addCoachColour.Text.Split(' ');

            using (var db = new DatabaseContext())
            {
                Coach c = new Coach();
                c.player = new Player();
                c.player.Firstname = coachFirstname;
                c.player.Lastname = coachLastname;
                c.CoachRed = colorDialog1.Color.R;
                c.CoachGreen = colorDialog1.Color.G;
                c.CoachBlue = colorDialog1.Color.B;


                if (addCoachColour.Text == "")
                {
                    MessageBox.Show("Please select a colour");
                }

                db.Coach.Add(c);
                db.SaveChanges();
                MessageBox.Show("Coach successfully added");
            }
        }

        private bool checkIfColourTaken(string coachColour)
        {
            using (var db = new DatabaseContext())
            {
                if (db.Coach.Any(x => x.CoachColor == coachColour))
                {
                    return true;
                }
            }
            return false;
        }

        private void addCoachColour_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                RGBColour[0] = colorDialog1.Color.R;
                RGBColour[1] = colorDialog1.Color.G;
                RGBColour[2] = colorDialog1.Color.B;
                addCoachColour.Text = RGBColour[0] + " " + RGBColour[1] + " " + RGBColour[2].ToString();
                //set up RGB save
            }
        }
    }
}
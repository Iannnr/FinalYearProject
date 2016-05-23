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
using System.Data.Entity;


namespace Project
{
    public partial class Logging : Form
    {
        TimeManager TM = new TimeManager();
        public static Calendar form1;
        static string date;
        public Logging()
        {
            InitializeComponent();
            PopulateDropdownMenus();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //DateTimePicker dateTimePicker1 = new DateTimePicker();
            //string x = dateTimePicker1.Value.DayOfWeek.ToString();
            //label4.Text = dateTimePicker1.Value.ToString();
            //int y = dateTimePicker1.Value.Month;
            //string month;
            //switch (y)
            //    {
            //    case 1:
            //        month = "January";
            //        break;
            //    case 2:
            //        month = "February";
            //        break;
            //    case 3:
            //        month = "March";
            //        break;
            //    case 4:
            //        month = "April";
            //        break;
            //    case 5:
            //        month = "May";
            //        break;
            //    case 6:
            //        month = "June";
            //        break;
            //    case 7:
            //        month = "July";
            //        break;
            //    case 8:
            //        month = "August";
            //        break;
            //    case 9:
            //        month = "September";
            //        break;
            //    case 10:
            //        month = "October";
            //        break;
            //    case 11:
            //        month = "November";
            //        break;
            //    case 12:
            //        month = "December";
            //        break;
            //}
            ////This should be sending data to database
            //date = dateTimePicker1.Value.DayOfWeek + " " + dateTimePicker1.Value.ToLongDateString();

            //if (string.IsNullOrWhiteSpace(addMatchMember1.Text))
            //{
            //    MessageBox.Show("Invalid member name");
            //}
            //else
            //{

            //}
            //getDateFromDatabase(date);
            string firstNameThirdPlayer;
            string secondNameThirdPlayer;
            string firstNameFourthPlayer;
            string secondNameFourthPlayer;

            string[] firstPlayer = addMatchMember1.Text.ToString().Split(' ');
            string firstNameFirstPlayer = firstPlayer[0].ToString();
            string secondNameFirstPlayer = firstPlayer[1].ToString();

            string[] secondPlayer = addMatchMember2.Text.ToString().Split(' ');
            string firstNameSecondPlayer = secondPlayer[0].ToString();
            string secondNameSecondPlayer = secondPlayer[1].ToString();

            string[] thirdPlayer = addMatchMember3.Text.ToString().Split(' ');
            if (thirdPlayer[0] != "(None)")
            {
                firstNameThirdPlayer = thirdPlayer[0].ToString();
                secondNameThirdPlayer = thirdPlayer[1].ToString();
            }

            string[] fourthPlayer = addMatchMember4.Text.ToString().Split(' ');
            if (fourthPlayer[0] != "(None)")
            {
                firstNameFourthPlayer = fourthPlayer[0].ToString();
                secondNameFourthPlayer = fourthPlayer[1].ToString();
            }

            int _courtNumber;
            int.TryParse(addMatchCourt.Text, out _courtNumber);

            //TODO: Fix migrations
            //TODO: Find how to access Match information from Court class
            //TODO: Fix Entity Framework for Matches + Courts

            if (string.IsNullOrWhiteSpace(addMatchMember1.Text))
            {
                MessageBox.Show("Invalid member name");
            }
            if (string.IsNullOrWhiteSpace(addMatchCourt.Text))
            {
                MessageBox.Show("Invalid court ID");
            }
            List<Player> pList = new List<Player>();
            using (var db = new DatabaseContext())
            {

                if (!string.IsNullOrWhiteSpace(addMatchMember1.Text))
                {
                    //pList.Add(new Player() { Firstname = firstPlayer[0], Lastname = firstPlayer[1] });

                    pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameFirstPlayer && x.Lastname == secondNameFirstPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                }
                if (!string.IsNullOrWhiteSpace(addMatchMember2.Text))
                {
                    //pList.Add(new Player() { Firstname = secondPlayer[0], Lastname = secondPlayer[1] });
                    pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameSecondPlayer && x.Lastname == secondNameSecondPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                }
                if (!addMatchMember3.Text.Contains("None"))
                {
                    //pList.Add(new Player() { Firstname = thirdPlayer[0], Lastname = thirdPlayer[1] });
                    //pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameThirdPlayer && x.Lastname == secondNameThirdPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                }
                if (!addMatchMember4.Text.Contains("None"))
                {
                    //pList.Add(new Player() { Firstname = fourthPlayer[0], Lastname = fourthPlayer[1] });
                    //pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameThirdPlayer && x.Lastname == secondNameThirdPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                }


                Match match = new Match();
                match = TM.arrangeDate(dateTimePicker1.Value, addMatchTime.Text);
                match.PlayerList = new List<Player>(pList);

                List<Court> courts = db.Courts.ToList();
                match.Court = courts.FirstOrDefault(x => x.CourtNumber == _courtNumber);

                db.Matches.Add(match);

                //updates courts
                db.Courts.FirstOrDefault(x => x.CourtNumber == _courtNumber).Matches.Add(match);
                db.SaveChanges();

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void PopulateDropdownMenus()
        {
            using (var db = new DatabaseContext())
            {
                List<string> p = db.Customers.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                List<string> customers = db.Customers.Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                List<string> coaches = db.Coach.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();

                foreach (var x in coaches)
                {
                    addMatchMember1.Items.Add(x);
                }

                foreach (var c in customers)
                {
                    addMatchMember1.Items.Add(c);
                    addMatchMember2.Items.Add(c);
                    addMatchMember3.Items.Add(c);
                    addMatchMember4.Items.Add(c);
                }
                List<int> nn = db.Courts.Select(x => x.CourtNumber).ToList();
                foreach (var xn in nn)
                {
                    addMatchCourt.Items.Add(xn);
                }
            }

            List<string> timeOfDay = new List<string>();
            timeOfDay.Add("09:00");
            timeOfDay.Add("10:00");
            timeOfDay.Add("11:00");
            timeOfDay.Add("12:00");
            timeOfDay.Add("13:00");
            timeOfDay.Add("14:00");
            timeOfDay.Add("15:00");
            timeOfDay.Add("16:00");
            timeOfDay.Add("17:00");
            timeOfDay.Add("18:00");
            timeOfDay.Add("19:00");
            timeOfDay.Add("20:00");
            timeOfDay.Add("21:00");
            foreach (var p in timeOfDay)
            {
                addMatchTime.Items.Add(p);
            }
        }
    }
}

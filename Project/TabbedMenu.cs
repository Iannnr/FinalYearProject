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
    public partial class TabbedMenu : Form
    {
        //coach details
        string coachFirstname;
        string coachLastname;
        int[] RGBColour = new int[3];
        char[] disallowedCharacters = { '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '=', '+', ';', ':', '@', '#', '~',
            '/', '?', '.', '<', '>', ',', '\\', '|', '`', '¬', '{', '}', '[', ']', '½', '¼', '‗', 'Þ', '⌂', '°', '↓', 'Þ', '♠', '♦', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //customer details
        string customerFirstname;
        string customerLastname;
        string customerEmail;
        string[] customerEmailCharacters = new string[33] { "@", "aol", "att", "comcast", "facebook", "gmail",
            "googlemail", "google", "hotmail", "hotmail", "mac",
            "me", "mail", "msn", "live", "sbcglobal", "verizon", "yahoo", "yahoo", "btinternet", "virginmedia", "blueyonder", "freeserve", "live",
            "ntlworld", "o2", "orange", "sky", "talktalk", "tiscali", "virgin", "wanadoo", "bt"};

        ChangeScreenSize CSS = new ChangeScreenSize();
        TimeManager TM = new TimeManager();


        public TabbedMenu()
        {
            InitializeComponent();
            populateDropDownMenus();
            Calendar calendar = new Calendar();
            calendar.Show();
            addCustomerSource();

            //for (int i = 0; i < j.Length; i++)
            //{
            //    source2.AddRange(j);
            //}
        }


        void addCustomerSource()
        {
            var source = new AutoCompleteStringCollection();
            var source2 = new AutoCompleteStringCollection();
            var source3 = new AutoCompleteStringCollection();
            using (var db = new DatabaseContext())
            {
                string[] p = db.Customers.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname).ToArray();
                string[] j = db.Customers.Where(x => x.player.Lastname != "").Select(x => x.player.Lastname).ToArray();
                string[] customersList = db.Customers.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToArray();
                for (int i = 0; i < p.Length; i++)
                {
                    source.AddRange(p);
                    source2.AddRange(j);
                    source3.AddRange(customersList);
                }
                RemoveCustomerFirstName.AutoCompleteCustomSource = source;
                RemoveCustomerLastName.AutoCompleteCustomSource = source2;
                textBox1.AutoCompleteCustomSource = source3;
            }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            var checkCustomerFirstName = txtCustomerFirstName.Text.IndexOfAny(disallowedCharacters) != -1;
            var checkCustomerLastName = txtCustomerLastName.Text.IndexOfAny(disallowedCharacters) != -1;
            if (checkCustomerFirstName != true && checkCustomerLastName != true)
            {
                if (txtCustomerFirstName.TextLength > 1)
                {
                    customerFirstname = txtCustomerFirstName.Text;
                }
                if (txtCustomerLastName.TextLength > 1)
                {
                    customerLastname = txtCustomerLastName.Text;
                }
                for (int i = 0; i < customerEmailCharacters.Length; i++)
                {
                    customerEmail = customerEmailAddress.Text;
                }

                if (txtCustomerFirstName.TextLength > 1)
                {
                    if (txtCustomerLastName.TextLength > 1)
                    {
                        ValidationCustomer vc = new ValidationCustomer()
                        {
                            MobileNumber = customerPrimaryContactText.Text,
                            LandlineNumber = CustomerSecondaryContactText.Text,
                            EmailAddress = customerEmailAddress.Text,
                            Firstname = txtCustomerFirstName.Text,
                            Lastname = txtCustomerLastName.Text
                        };

                        vc = Validation.validateCustomerDetails(vc);
                        //sending data (after validation checks) to the database
                        using (var db = new DatabaseContext())
                        {
                            if (!Validation.checkIfDoubleEntryEmail(vc.EmailAddress))
                            {
                                if (!Validation.checkIfDoubleEntryPrimaryPhone(vc.MobileNumber))
                                {
                                    if (customerAddress.Text.Length > 0)
                                    {
                                        Customer c = new Customer();
                                        c.player = new Player();
                                        c.player.Firstname = vc.Firstname;
                                        c.player.Lastname = vc.Lastname;
                                        c.DayOfBirth = comboBox1.SelectedItem.ToString();
                                        c.MonthofBirth = comboBox2.SelectedItem.ToString();
                                        c.YearOfBirth = comboBox3.SelectedItem.ToString();
                                        c.Address = customerAddress.Text;
                                        c.EmailAddress = vc.EmailAddress;
                                        c.MobileNumber = vc.MobileNumber;
                                        c.LandlineNumber = vc.LandlineNumber;

                                        if (c.MobileNumber.Length >= 11 && c.MobileNumber.Length <= 13)
                                        {
                                            if (c.LandlineNumber.Length >= 11 && c.LandlineNumber.Length <= 13)
                                            {
                                                db.Customers.Add(c);
                                                db.SaveChanges();
                                                MessageBox.Show("Customer successfully added");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Mobile number already found in database!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email Address already found in database!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer last name not enough characters");
                    }
                }
                else
                {
                    MessageBox.Show("Customer first name not enough characters");
                }
            }
            else
            {
                MessageBox.Show("Invalid symbol in name field");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sizeX, sizeY;
            int index = tabControl1.SelectedIndex;
            CSS.ScreenSize(index);

            sizeX = CSS.x[0];
            sizeY = CSS.x[1];

            Size = new Size(sizeX, sizeY);


        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            string index = tabControl1.SelectedIndex.ToString();

            for (int i = 1; i < tabControl1.TabCount; i++)
            {
                foreach (Control control in tabControl1.Controls[i].Controls)
                {
                    if (control is TextBox || control is ComboBox)
                    {
                        if (!(control.Name == "addCoachColour"))
                        {
                            control.Text = "";
                        }
                    }
                }
            }
        }


        private void addCoachButton_Click(object sender, EventArgs e)
        {
            coachFirstname = addCoachFirstNameTextBox.Text;
            coachLastname = addCoachLastNameTextBox.Text;
            addCoachColour.Text.Split(' ');

            var checkCharFirstName = addCoachFirstNameTextBox.Text.IndexOfAny(disallowedCharacters) != -1;
            var checkCharLastName = addCoachLastNameTextBox.Text.IndexOfAny(disallowedCharacters) != -1;
            if (checkCharFirstName != true && checkCharLastName != true)
            {
                if (coachFirstname.Length > 1 && coachLastname.Length > 1)
                {
                    using (var db = new DatabaseContext())
                    {
                        Coach c = new Coach();
                        c.player = new Player();
                        c.player.Firstname = coachFirstname;
                        c.player.Lastname = coachLastname;
                        c.CoachRed = colorDialog1.Color.R;
                        c.CoachGreen = colorDialog1.Color.G;
                        c.CoachBlue = colorDialog1.Color.B;


                        if (addCoachColour.Text == "(Click this box)" || addCoachColour.Text == "255 255 255")
                        {
                            MessageBox.Show("Please select a valid colour (white not allowed)");
                        }
                        else
                        {
                            db.Coach.Add(c);
                            db.SaveChanges();
                            MessageBox.Show("Coach successfully added");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect name length");
                }
            }
            else
            {
                MessageBox.Show("Invalid character in coach names");
            }
            populateDropDownMenus();
            addCustomerSource();
            //if (addCoachFirstNameTextBox.Text.Contains(disallowedCharacters.Any(x => x == disallowedCharacters[i])))
        }

        private void addMatchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string firstNameThirdPlayer = null;
                string secondNameThirdPlayer = null;
                string firstNameFourthPlayer = null;
                string secondNameFourthPlayer = null;

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

                if (string.IsNullOrWhiteSpace(addMatchMember1.Text))
                {
                    MessageBox.Show("Invalid member name");
                }
                if (string.IsNullOrWhiteSpace(addMatchCourt.Text))
                {
                    MessageBox.Show("Invalid court ID");
                }
                List<Player> pList = new List<Player>();
                Coach coachInMatch = null;
                using (var db = new DatabaseContext())
                {

                    if (!string.IsNullOrWhiteSpace(addMatchMember1.Text))
                    {
                        if (db.Coach.Any(x => x.player.Firstname == firstNameFirstPlayer && x.player.Lastname == secondNameFirstPlayer))
                        {
                            coachInMatch = db.Coach.FirstOrDefault(x => x.player.Firstname == firstNameFirstPlayer && x.player.Lastname == secondNameFirstPlayer);
                        }
                        else
                        {
                            pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameFirstPlayer && x.Lastname == secondNameFirstPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(addMatchMember2.Text))
                    {
                        pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameSecondPlayer && x.Lastname == secondNameSecondPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                    }
                    if (!addMatchMember3.Text.Contains("None"))
                    {
                        //pList.Add(new Player() { Firstname = thirdPlayer[0], Lastname = thirdPlayer[1] });
                        pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameThirdPlayer && x.Lastname == secondNameThirdPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                    }
                    if (!addMatchMember4.Text.Contains("None"))
                    {
                        //pList.Add(new Player() { Firstname = fourthPlayer[0], Lastname = fourthPlayer[1] });
                        pList.Add(db.Players.FirstOrDefault(x => x.Firstname == firstNameFourthPlayer && x.Lastname == secondNameFourthPlayer));//.Select(x => x.Firstname + " " + x.Lastname));// && x.Lastname == firstPlayer[1]));
                    }

                    Match match = new Match();
                    match = TM.arrangeDate(dateTimePicker1.Value, addMatchTime.Text);
                    match.PlayerList = new List<Player>(pList);
                    if (coachInMatch != null)
                    {
                        match.CoachInMatch = coachInMatch;
                    }

                    List<Court> courts = db.Courts.ToList();
                    match.Court = courts.FirstOrDefault(x => x.CourtNumber == _courtNumber);

                    db.Matches.Add(match);

                    //updates courts
                    db.Courts.FirstOrDefault(x => x.CourtNumber == _courtNumber).Matches.Add(match);
                    db.SaveChanges();
                }
                populateDropDownMenus();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Player not found in system");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Incorrect court value");
            }
        }

        //TODO: needs fixing to delete empty registries
        private void removeCustomerButton_Click(object sender, EventArgs e)
        {
            //set up as separate class and call class from button press
            using (var db = new DatabaseContext())
            {
                try
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
                            MessageBox.Show("Customer Removed");
                            RemoveCustomerList.Text = "";
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
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Player not found in system");
                }
            }
            populateDropDownMenus();
        }

        private void searchCustomer_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                RemoveCustomerList.Text = "";
                RemoveCustomerList.Items.Clear();
                if (string.IsNullOrWhiteSpace(RemoveCustomerFirstName.Text) && string.IsNullOrEmpty(RemoveCustomerLastName.Text))
                {
                    List<string> p = db.Customers.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                    foreach (var c in p)
                    {
                        RemoveCustomerList.Text = p[0].ToString();
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
                            RemoveCustomerList.Text = p[0].ToString();
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

        private void removeCoachButton_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                //split drop down menu into first name and last name
                if (RemoveCoachComboBox.Text != "")
                {
                    if (RemoveCoachComboBox.Text != " ")
                    {
                        try
                        {
                            string[] names = RemoveCoachComboBox.Text.ToString().Split(' ');
                            string firstname = names[0].ToString();
                            string lastname = names[1].ToString();
                            //
                            try
                            {
                                //remove rows in database related to the first name and last name of selected customer
                                var removePlayer = db.Players.FirstOrDefault(x => x.Firstname == firstname && x.Lastname == lastname);
                                var removeCoach = db.Coach.FirstOrDefault(x => x.player.Firstname == firstname && x.player.Lastname == lastname);

                                var result = MessageBox.Show("Are you sure you want to delete this coach?", "Form Closing", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {

                                    db.Players.Remove(removePlayer);
                                    db.Coach.Remove(removeCoach);
                                    try
                                    {
                                        db.SaveChanges();
                                        MessageBox.Show("Coach Removed");
                                        RemoveCoachComboBox.Text = "";
                                    }
                                    catch (DbUpdateException d)
                                    {
                                        Console.WriteLine(d);
                                        MessageBox.Show(d.ToString());
                                    }
                                }
                            }
                            catch (NotSupportedException c)
                            {
                                Console.WriteLine(c);
                                MessageBox.Show(c.ToString());
                            }
                            catch (ArgumentNullException)
                            {
                                MessageBox.Show("Coach not found in system");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            MessageBox.Show("Coach not found in system");
                        }
                    }
                }
            }
            populateDropDownMenus();
        }

        private void populateDropDownMenus()
        {
            RemoveCoachComboBox.Items.Clear();
            RemoveCustomerList.Items.Clear();
            addMatchMember1.Items.Clear();
            addMatchMember2.Items.Clear();
            addMatchMember3.Items.Clear();
            addMatchMember4.Items.Clear();
            addMatchTime.Items.Clear();
            addMatchCourt.Items.Clear();
            RemoveMatchMember1.Items.Clear();
            RemoveMatchMember2.Items.Clear();
            RemoveMatchCourtID.Items.Clear();
            addMatchCourt.Items.Clear();

            using (var db = new DatabaseContext())
            {
                List<string> p = db.Customers.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                List<string> customers = db.Customers.Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();
                List<string> coaches = db.Coach.Where(x => x.player.Firstname != "").Select(x => x.player.Firstname + " " + x.player.Lastname).ToList();

                foreach (var x in coaches)
                {
                    RemoveCoachComboBox.Items.Add(x);
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //set up RGB save
                RGBColour[0] = colorDialog1.Color.R;
                RGBColour[1] = colorDialog1.Color.G;
                RGBColour[2] = colorDialog1.Color.B;

                //addCoachColour.Text = RGBColour[0] + " " + RGBColour[1] + " " + RGBColour[2].ToString();
                if (colorDialog1.Color.ToKnownColor().ToString() != "0")
                {
                    addCoachColour.Text = colorDialog1.Color.ToKnownColor().ToString();
                }
                else
                {
                    addCoachColour.Text = "";
                }
                addCoachColour.BackColor = Color.FromArgb(RGBColour[0], RGBColour[1], RGBColour[2]);
                //addCoachColour.ForeColor = Color.FromArgb(RGBColour[0], RGBColour[1], RGBColour[2]);
            }
        }

        private void RemoveMatchDatePicker_ValueChanged(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                string day = dateTimePicker1.Value.DayOfWeek.ToString();

                var listOfPlayerLists = db.Matches.Where(z => z.dayOfWeek == day).Select(d => d.PlayerList).ToList();


                foreach (var playerList in listOfPlayerLists)
                {
                    if (playerList.Count >= 1)
                    {
                        RemoveMatchMember1.Items.Add(playerList[0].Firstname + " " + playerList[0].Lastname);
                    }
                }
            }
        }

        private void removeMatchButton_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string customerFirstName = "";
            string customerLastname = "";

            customerFirstName = textBox1.Text.Split(' ')[0];
            if (textBox1.Text != "")
                if (textBox1.Text.Split(' ')[1] != null)
                {
                    {
                        customerLastname = textBox1.Text.Split(' ')[1];
                    }
                    using (var db = new DatabaseContext())
                    {
                        List<string> names = db.Customers.Where(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Select(y => y.player.Firstname + " " + y.player.Lastname).ToList();
                        if (names.Count != 0)
                        {
                            textBox2.Text = names[0];
                            List<string> dateofbirth = db.Customers.Where(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Select(y => y.DayOfBirth + " " + y.MonthofBirth + " " + y.YearOfBirth).ToList();
                            textBox3.Text = dateofbirth[0];
                            List<string> address = db.Customers.Where(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Select(y => y.Address).ToList();
                            textBox4.Text = address[0];
                            List<string> emailAddress = db.Customers.Where(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Select(y => y.EmailAddress).ToList();
                            textBox5.Text = emailAddress[0];
                            List<string> mobileNumber = db.Customers.Where(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Select(y => y.MobileNumber).ToList();
                            textBox6.Text = mobileNumber[0];
                            List<string> landlineNumber = db.Customers.Where(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Select(y => y.LandlineNumber).ToList();
                            textBox7.Text = landlineNumber[0];
                        }
                        else
                        {
                            MessageBox.Show("Customer not found");
                        }
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string customerFirstName = textBox1.Text.Split(' ')[0];
            string customerLastname = textBox1.Text.Split(' ')[1];
            //using (var db = new DatabaseContext())
            //{
            //   var oldFirstname = db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).player.Firstname;
            //   db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).player.Firstname = textBox2.Text.Split(' ')[1];
            //   db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).DayOfBirth = textBox3.Text.Split(' ')[0] + " " + textBox3.Text.Split(' ')[1] + " " + textBox3.Text.Split(' ')[2];
            //   db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).Address = textBox4.Text;
            //   db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).player.Firstname = textBox5.Text;
            //   db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).player.Firstname = textBox6.Text;
            //   db.Customers.FirstOrDefault(x => x.player.Firstname == customerFirstName && x.player.Lastname == customerLastname).player.Firstname = textBox7.Text;
            //   db.SaveChanges();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control control in tabControl1.Controls[6].Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    control.Text = "";
                }
            }
        }
    }
}

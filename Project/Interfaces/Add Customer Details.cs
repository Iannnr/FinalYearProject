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
    public partial class Add_Customer_Details : Form
    {
        string customerFirstname;
        string customerLastname;
        string customerEmail;
        string customerPrimaryContact;
        string customerCorrectPrimaryContact;
        string customerSecondaryContact;
        string customerCorrectSecondaryContact;
        string[] customerEmailCharacters = new string[33] { "@", "aol", "att", "comcast", "facebook", "gmail",
            "googlemail", "google", "hotmail", "hotmail", "mac",
            "me", "mail", "msn", "live", "sbcglobal", "verizon", "yahoo", "yahoo", "btinternet", "virginmedia", "blueyonder", "freeserve", "live",
            "ntlworld", "o2", "orange", "sky", "talktalk", "tiscali", "virgin", "wanadoo", "bt"};


        public Add_Customer_Details()
        {
            InitializeComponent();
            
        }

        private void Add_Customer_Details_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (txtCustomerFirstName.TextLength > 1)
            //{
            //    firstname = txtCustomerFirstName.Text.ToString();
            //}
            //if (txtCustomerLastName.TextLength > 1)
            //{
            //    lastname = txtCustomerLastName.Text.ToString();
            //}
            //for (int i = 0; i < emailCharacters.Length; i++)
            //{
            //    //set values of textbox3 to email and then check if it contains email characters?
            //    //if (textBox3.Contains(emailCharacters[i]))
            //    //{
            //        email = customerEmailAddress.Text.ToString();
            //    //}
            //}
            //validatePrimaryContactDetails(customerPrimaryContactText.Text.ToString());
            //validateSecondaryContactDetails(CustomerSecondaryContactText.Text.ToString());

            ////variables to be added to database
            //label6.Text = (firstname + " " + lastname + " " + email + " " + correctPrimaryContact + " " + correctSecondaryContact);

            ////sending data (after validation checks) to the database
            //using (var db = new DatabaseContext())
            //{
            //    if (!checkIfDoubleEntryEmail(email))
            //    {
            //        if (!checkIfDoubleEntryPrimaryPhone(primaryContact))
            //        {
            //            if (!checkIfDoubleEntryPrimaryPhone(secondaryContact))
            //            {
            //                Customer c = new Customer();
            //                c.player = new Player();
            //                c.player.Firstname = firstname;
            //                c.player.Lastname = lastname;
            //                c.EmailAddress = email;
            //                c.primaryContact = correctPrimaryContact;
            //                c.secondaryContact = correctSecondaryContact;

            //                db.Customers.Add(c);
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Email Address, primary contact or secondary contact already found in database!");
            //    }
            //}
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
                        if (!Validation.checkIfDoubleEntryPrimaryPhone(vc.LandlineNumber))
                        {
                            Customer c = new Customer();
                            c.player = new Player();
                            c.player.Firstname = vc.Firstname;
                            c.player.Lastname = vc.Lastname;
                            c.EmailAddress = vc.EmailAddress;
                            c.MobileNumber = vc.MobileNumber;
                            c.LandlineNumber = vc.LandlineNumber;

                            db.Customers.Add(c);
                            db.SaveChanges();
                            MessageBox.Show("Customer successfully added");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Email Address, primary contact or secondary contact already found in database!");
                }
            }

        }

        //function to check if contact details are valid
        //private string validatePrimaryContactDetails(string contactDetail)
        //{
        //    bool correctNumber = false;
        //    customerPrimaryContactText.Text.Replace(" ", string.Empty);
        //    if (customerPrimaryContactText.TextLength == 11 && contactDetail.StartsWith("07"))
        //    {
        //        correctPrimaryContact = customerPrimaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (customerPrimaryContactText.TextLength == 11 && contactDetail.StartsWith("01"))
        //    {
        //        correctPrimaryContact = customerPrimaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (customerPrimaryContactText.TextLength == 11 && contactDetail.StartsWith("02"))
        //    {
        //        correctPrimaryContact = customerPrimaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (customerPrimaryContactText.TextLength == 13 && contactDetail.StartsWith("+44"))
        //    {
        //        correctPrimaryContact = customerPrimaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (customerPrimaryContactText.TextLength != 13 && customerPrimaryContactText.TextLength != 11)
        //    {
        //        MessageBox.Show("Incorrect contact number format in primary contact details");
        //    }
        //    if (!contactDetail.StartsWith("+44")  && !contactDetail.StartsWith("07") && !contactDetail.StartsWith("01") && !contactDetail.StartsWith("02"))
        //    {
        //        MessageBox.Show("Incorrect contact number format in primary contact details");
        //    }
        //    if (correctNumber == true)
        //    {
        //            return correctPrimaryContact;
                
        //    }
        //    return null;
        //}

        //private string validateSecondaryContactDetails(string contactDetail)
        //{
        //    bool correctNumber = false;
        //    CustomerSecondaryContactText.Text.Trim();
        //    if (CustomerSecondaryContactText.TextLength == 11 && contactDetail.StartsWith("07"))
        //    {
        //        correctSecondaryContact = CustomerSecondaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (CustomerSecondaryContactText.TextLength == 11 && contactDetail.StartsWith("01"))
        //    {
        //        correctSecondaryContact = CustomerSecondaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (CustomerSecondaryContactText.TextLength == 11 && contactDetail.StartsWith("02"))
        //    {
        //        correctSecondaryContact = CustomerSecondaryContactText.Text;
        //        correctNumber = true;
        //    }
        //    if (CustomerSecondaryContactText.TextLength == 13 && contactDetail.StartsWith("+44"))
        //    {
        //        correctSecondaryContact = CustomerSecondaryContactText.Text;
        //        correctNumber = true;
        //    }

        //    //stop it from sending to database if format is incorrect
        //    if (CustomerSecondaryContactText.TextLength != 13 && CustomerSecondaryContactText.TextLength != 11)
        //    {
        //        MessageBox.Show("Incorrect contact number format in backup contact detail");
        //    }
        //    if (!contactDetail.StartsWith("+44") && !contactDetail.StartsWith("07") && !contactDetail.StartsWith("01") && !contactDetail.StartsWith("02"))
        //    {
        //        MessageBox.Show("Incorrect contact number format in backup contact detail");
        //    }
        //    if (correctNumber == true)
        //    {
        //            return correctSecondaryContact;
        //    }
        //    return null;
        //}

        //private bool checkIfDoubleEntryEmail(string email)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        if(db.Customers.Any(x=> x.EmailAddress == email))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //private bool checkIfDoubleEntryPrimaryPhone(string phone)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        if (db.Customers.Any(x => x.primaryContact == phone))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private bool checkIfDoubleEntrySecondaryPhone(string phone)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        if (db.Customers.Any(x => x.secondaryContact == phone))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        

    }
}

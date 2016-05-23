using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Details.Validation
{
    class Validation
    {
        char[] disallowedCharacters = { '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '=', ';', ':', '@', '#', '~',
            '/', '?', '.', '<', '>', ',', '\\', '|', '`', '¬', '{', '}', '[', ']', '½', '¼', '‗', 'Þ', '⌂', '°', '↓', 'Þ', '♠', '♦', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j' };
        public static bool checkIfColourTaken(string coachColour)
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

        public static bool checkIfDoubleEntrySecondaryPhone(string phone)
        {
            using (var db = new DatabaseContext())
            {
                if (db.Customers.Any(x => x.LandlineNumber == phone))
                {
                    return true;
                }
            }
            return false;
        }

        private static string validatePrimaryContactDetails(string contactDetail, int textlength)
        {
            string c = null;
            //if (contactDetail.Contains())
            if(textlength == 11)
            {
                if(contactDetail.StartsWith("07"))
                {
                    c = contactDetail;
                }
                if (contactDetail.StartsWith("01"))
                {
                    c = contactDetail;
                }
                if (contactDetail.StartsWith("02"))
                {
                    c = contactDetail;
                }
            }
            if (textlength == 12)
            {
                c = contactDetail.Replace(" ", "");
            }

            if (textlength == 13 && contactDetail.StartsWith("+44"))
            {
                c = contactDetail;
            }
            if (textlength == 13 && !contactDetail.StartsWith("+44"))
            {
                c = "Incorrect contact number length in primary contact details";

                MessageBox.Show(c);
            }
            if (textlength != 13 && textlength != 11 && textlength != 12)
            {
                c = "Incorrect contact number format in primary contact details";
                MessageBox.Show(c);
            }
            if (!contactDetail.StartsWith("+44") && !contactDetail.StartsWith("07") && !contactDetail.StartsWith("01") && !contactDetail.StartsWith("02"))
            {
                c = "Incorrect contact number format in primary contact details";
                MessageBox.Show(c);
            }
            return c;
        }

        private static string validateSecondaryContactDetails(string contactDetail, int textLength)
        {
            //CustomerSecondaryContactText.Text.Trim();
            string c = null;
            if(textLength == 11)
            {
                if(contactDetail.StartsWith("07"))
                {
                    c = contactDetail;
                }
                if (contactDetail.StartsWith("01"))
                {
                    c = contactDetail;
                }
                if (contactDetail.StartsWith("02"))
                {
                    c = contactDetail;
                }
            }
            else if (textLength == 13 && contactDetail.StartsWith("+44"))
            {
                c = contactDetail;
            }

            if (textLength == 12)
            {
                c = contactDetail.Replace(" ", "");
            }

            //stop it from sending to database if format is incorrect
            if (textLength != 13 && textLength != 12 && textLength != 11)
            {
                c = "Incorrect contact number format in secondary contact details";
                MessageBox.Show(c);
            }
            if (!contactDetail.StartsWith("+44") && !contactDetail.StartsWith("07") && !contactDetail.StartsWith("01") && !contactDetail.StartsWith("02"))
            {
                c = "Incorrect contact number format in secondary contact details";
                MessageBox.Show(c);
            }
            return c;
        }

        public static ValidationCustomer validateCustomerDetails(ValidationCustomer c)
        {
            c.MobileNumber = validatePrimaryContactDetails(c.MobileNumber, c.MobileNumber.Length);
            if(c.LandlineNumber.Length > 0)
            {
                c.LandlineNumber = validateSecondaryContactDetails(c.LandlineNumber, c.LandlineNumber.Length);
            }
            c.EmailAddress = c.EmailAddress;
            return c;
        }

        public static bool checkIfDoubleEntryEmail(string email)
        {
            using (var db = new DatabaseContext())
            {
                if (db.Customers.Any(x => x.EmailAddress == email))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkIfDoubleEntryPrimaryPhone(string phone)
        {
            using (var db = new DatabaseContext())
            {
                if (db.Customers.Any(x => x.MobileNumber == phone))
                {
                    return true;
                }
            }
            return false;
        }

        public static string returnMessageLength(int textLength)
        {
            string message = "";


            return message;
        }

        public static string returnMessageStartsWith(bool startsWith)
        {
            string message = "";


            return message;
        }
    }
}

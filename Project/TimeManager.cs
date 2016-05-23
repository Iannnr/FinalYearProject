using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project
{
    class TimeManager
    {
        public string stringMonth;
        
        public string monthToString(int month)
        {
            switch (month)
            {
                case 1:
                    stringMonth = "January";
                    break;
                case 2:
                    stringMonth = "February";
                    break;
                case 3:
                    stringMonth = "March";
                    break;
                case 4:
                    stringMonth = "April";
                    break;
                case 5:
                    stringMonth = "May";
                    break;
                case 6:
                    stringMonth = "June";
                    break;
                case 7:
                    stringMonth = "July";
                    break;
                case 8:
                    stringMonth = "August";
                    break;
                case 9:
                    stringMonth = "September";
                    break;
                case 10:
                    stringMonth = "October";
                    break;
                case 11:
                    stringMonth = "November";
                    break;
                case 12:
                    stringMonth = "December";
                    break;
                default:
                    stringMonth = "N/A";
                    break;
            }
            return stringMonth;
        }

        public Match arrangeDate(DateTime dt, string time)
        {
            Match m = new Match();
            m.dayOfWeek = dt.DayOfWeek.ToString();
            m.dateOfMonth = dt.Day;
            m.monthOfYear = monthToString(dt.Month);
            m.Year = dt.Year;

            char[] split = { ':' };
            int hourOfDay;
            string[] plsWork = time.Split(split);
            int.TryParse(plsWork[0], out hourOfDay);
            m.TimeOfDay = hourOfDay;

            return m;
        }

    }
}

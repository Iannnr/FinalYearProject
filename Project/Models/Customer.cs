using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string DayOfBirth { get; set; }
        public string MonthofBirth { get; set; }
        public string YearOfBirth { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string LandlineNumber { get; set; }
        public Player player { get; set; }
    }
}

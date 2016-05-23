using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Details.Validation
{
    class ValidationCustomer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber  { get; set; }
        public string LandlineNumber { get; set; }
        public List<string> errorList { get; set; }
    }
}

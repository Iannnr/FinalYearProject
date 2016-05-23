using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Match
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchID { get; set; }
        public string dayOfWeek { get; set; }
        public Coach CoachInMatch { get; set; }
        public int dateOfMonth { get; set; }
        public string monthOfYear { get; set; }
        public int Year { get; set; }
        public int TimeOfDay { get; set; }
        public List<Player> PlayerList { get; set; }
        public Court Court { get; set; }
        public string AdditionalInformation { get; set; }
        
    }
}

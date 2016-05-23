using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Coach
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachID { get; set; }
        public Player player { get; set; }
        public string CoachColor { get; set; }
        public int CoachRed { get; set; }
        public int CoachGreen { get; set; }
        public int CoachBlue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Court
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourtNumber { get; set; }
        public List<Match> Matches { get; set; }
    }
}

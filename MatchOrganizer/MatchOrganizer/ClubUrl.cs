using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MatchOrganizer
{   
    public class ClubUrl
    {
        [Key]
        public string ClubUrlAddress { get; set; }
        public string ClubName { get; set; }

    }
}

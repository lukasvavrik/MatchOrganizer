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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchOrganizer
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string StisUrl { get; set; }
        public List<Match> SelectedToMatches { get; set; }

        public Player()
        {
            SelectedToMatches = new List<Match>();
        }
        public Player(string name, string stisUrl)
        {
            SelectedToMatches = new List<Match>();
            PlayerName = name;
            StisUrl = stisUrl;
        }
    }
}
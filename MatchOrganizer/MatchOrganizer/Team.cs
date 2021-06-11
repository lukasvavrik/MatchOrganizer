using System.Collections.Generic;
using MatchOrganizer.Scraping;

namespace MatchOrganizer
{
    public class Team
    {
        public string Name { get; set; }
        public string StisUrl { get; set; }
        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }
        
        public Team(string name, string stisUrl)
        {
            Name = name;
            StisUrl = stisUrl;
            Players = Stis.GetPlayers(StisUrl);
            Matches = Stis.GetMatches(StisUrl);
        }
    }
}
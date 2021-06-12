using System.Collections.Generic;
using MatchOrganizer.Scraping;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MatchOrganizer.Database;
using Microsoft.EntityFrameworkCore;


namespace MatchOrganizer
{
    public class Team
    {   
        public string TeamName { get; set; }
        [Key]
        public string StisUrl { get; set; }
        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }
        
        public Team() {}
        public Team(string name, string stisUrl)
        {
            TeamName = name;
            StisUrl = stisUrl;
            Players = Stis.GetPlayers(StisUrl);
            using var db = new OrganizerDbContext();

            foreach (var pl in Players)
            {
                if (db.Players.Count(player1 => player1.StisUrl.Equals(pl.StisUrl)) == 0)
                {
                    db.Players.Add(pl);
                }
                else
                {
                    pl.Id = db.Players.First(player => player.StisUrl == pl.StisUrl).Id;
                    pl.SelectedToMatches = db.Players.Include(player => player.SelectedToMatches).First(player => player.StisUrl == pl.StisUrl)
                        .SelectedToMatches;
                }
            }

            Matches = Stis.GetMatches(StisUrl);
            foreach (var match in Matches)
            {
                //match.ThisTeam = stisUrl;
                if (db.Matches.Count(match1 =>
                    (match1.Date == match.Date) && (match1.GuestsTeamName == match.GuestsTeamName) && (match.HomeTeamName == match1.HomeTeamName)) == 0)
                {
                    db.Matches.Add(match);
                }
               
            }
        }
    }
}
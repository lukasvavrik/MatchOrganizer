using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MatchOrganizer.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MatchOrganizer
{
    public class Match
    {
        public int Id { get; set; }
        public string Round { get; set; }
        public DateTime Date { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamUrl { get; set; }
        public string GuestsTeamName { get; set; }
        public string GuestsTeamUrl { get; set; }
        public string Result { get; set; }

        public Match() {}
        
        public Match(string round, DateTime date, string home, string homeTeamUrl, string guests, string guestsTeamUrl, string result)
        {
            Round = round;
            Date = date;
            HomeTeamName = home;
            GuestsTeamName = guests;
            HomeTeamUrl = homeTeamUrl;
            GuestsTeamUrl = guestsTeamUrl;
            Result = result;
        }

        public List<Player> GetAvailablePlayers()
        {
            using var db = new OrganizerDbContext();
            var players = db.Teams.First(team => team.Matches.Count(match => match.Id == Id) > 0).Players.ToList();
            var availablePlayers = new List<Player>();
            foreach (var pl in players)
            {
                if (ClubManager.IsAvailable(pl, this))
                {
                    availablePlayers.Add(pl);
                }
            }
            return availablePlayers;

        }


    }
}
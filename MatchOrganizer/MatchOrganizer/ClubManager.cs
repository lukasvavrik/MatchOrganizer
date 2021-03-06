using System;
using System.Collections.Generic;
using System.Linq;
using MatchOrganizer.Database;
using MatchOrganizer.Scraping;

namespace MatchOrganizer
{
    public static class ClubManager
    {
        public static string ClubName { get; set; }
        public static string ClubStisUrl { get; set; }
        public static List<Team> Teams { get; set; }

        public static void SetClub()
        {
            SetClub(GetClubName(), GetClubUrl());
        }
        public static void SetClub(string name, string clubUrl)
        {
            ClubName = name;
            ClubStisUrl = ClubStisUrl;
            using var db = new OrganizerDbContext();
     
            Teams = Stis.GetTeams(clubUrl);
            if (!db.ClubUrl.Any())
            {
                var clubUrlDb = new ClubUrl();
                clubUrlDb.ClubUrlAddress = clubUrl;
                db.ClubUrl.Add(clubUrlDb);
            }
           
            foreach (var team in Teams.Where(team => db.Teams.Count(team1 => team1.TeamName == team.TeamName) == 0))
            {
                db.Teams.Add(team);
            }
            db.SaveChanges();
        }

        public static bool IsAvailable(Player player, Match match)
        {
            if (player.SelectedToMatches.Contains(match))
            {
                return false;
            }

            return player.SelectedToMatches.All(m => !(Math.Abs((m.Date - match.Date).TotalHours) < 3));
        }
        
        public static void AddPlayerToMatch(Player player, Match match)
        {
            if (!IsAvailable(player, match))
            {
                return;
            }

            using var db = new OrganizerDbContext();
            match.Id = 0;
            player.SelectedToMatches.Add(match);
            db.Players
                .Where(player1 => player1.StisUrl == player.StisUrl)
                .ToList()
                .ForEach(player1 => player1.SelectedToMatches.Add(match));
            db.SaveChanges();
        }

        public static void DeletePlayerFromMatch(Player player, Match match)
        {
            using var db = new OrganizerDbContext();
            var matches = player.SelectedToMatches;
            var matchesToDelete = matches
                .Where(m => m.Date == match.Date && m.HomeTeamName == match.HomeTeamName && m.GuestsTeamName == match.GuestsTeamName)
                .ToList();
            foreach (var m in matchesToDelete)
            {
                player.SelectedToMatches.Remove(m);
                db.Matches.Remove(m);
            }
            db.SaveChanges();
        }

        public static bool IsClubSelected()
        {
            using var db = new OrganizerDbContext();
            return db.ClubUrl.Any();
        }

        private static string GetClubUrl()
        {
            using var db = new OrganizerDbContext();
            return db.ClubUrl.First().ClubUrlAddress;
        }

        private static string GetClubName()
        {
            using var db = new OrganizerDbContext();
            return db.ClubUrl.First().ClubName;
        }
    }
}
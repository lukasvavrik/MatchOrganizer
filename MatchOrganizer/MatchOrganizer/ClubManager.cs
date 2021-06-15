using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MatchOrganizer.Database;
using MatchOrganizer.Scraping;
using Microsoft.EntityFrameworkCore;

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
           
            foreach (var team in Teams)
            {
                if (db.Teams.Count(team1 => team1.TeamName == team.TeamName) == 0)
                {
                    db.Teams.Add(team);
                }
            }
            db.SaveChanges();
        }

        public static bool IsAvailable(Player player, Match match)
        {
            if (player.SelectedToMatches.Contains(match))
            {
                return false;
            }

            //if (match.Date < DateTime.Now)
            //{
            //    return false;
            //}

            foreach (var m in player.SelectedToMatches)
            {
                var a = Math.Abs((m.Date - match.Date).TotalHours);
                if (Math.Abs((m.Date - match.Date).TotalHours) < 3)
                {
                    return false;
                }
            }

            return true;
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
            var matchesToDelete = new List<Match>();
            foreach (var m in matches)
            {
                if (m.Date == match.Date && m.HomeTeamName == match.HomeTeamName &&
                    m.GuestsTeamName == match.GuestsTeamName)
                {
                    matchesToDelete.Add(m);
                }
            }
            foreach (var m in matchesToDelete)
            {
                player.SelectedToMatches.Remove(m);
                db.Matches.Remove(m);
                //db.Players
                //    .Where(player1 => player1.StisUrl == player.StisUrl)
                //    .ToList()
                //    .ForEach(player1 => player1.SelectedToMatches.Remove(m));

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
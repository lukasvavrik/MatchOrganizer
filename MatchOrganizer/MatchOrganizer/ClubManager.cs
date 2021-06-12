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

        public static void SetClub(string name, string clubUrl)
        {
            ClubName = name;
            ClubStisUrl = ClubStisUrl;
            using var db = new OrganizerDbContext();
     
            Teams = Stis.GetTeams(clubUrl);
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
                if (Math.Abs((m.Date.Date - match.Date.Date).Hours) < 3)
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
            player.SelectedToMatches.Add(match);
            db.Players
                .Where(player1 => player1.StisUrl == player.StisUrl)
                .ToList()
                .ForEach(player1 => player1.SelectedToMatches.Add(match));
            db.SaveChanges();
        }
    }
}
using System;
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
            Matches = Stis.GetMatches(StisUrl);
            using var db = new OrganizerDbContext();
            DeleteRedundantPlayers(db);
            DeleteRedundantMatches(db);
            SetPlayers(db);
            SetMatches(db);
        }

        private void SetPlayers(OrganizerDbContext db)
        {
            foreach (var pl in Players)
            {
                if (db.Players.Count(player1 => player1.StisUrl.Equals(pl.StisUrl)) == 0)
                {
                    db.Players.Add(pl);
                }
                else
                {
                    pl.Id = db.Players
                        .First(player => player.StisUrl == pl.StisUrl)
                        .Id;
                    pl.SelectedToMatches = db.Players
                        .Include(player => player.SelectedToMatches)
                        .First(player => player.StisUrl == pl.StisUrl)
                        .SelectedToMatches;
                }
            }
        }

       /// <summary>
       /// Method deletes from database all players which are not already in squad for this team
       /// </summary>
       /// <param name="db"></param>
        private void DeleteRedundantPlayers(OrganizerDbContext db)
        {
            try
            {
                var oldPlayers = db.Teams.Include(team => team.Players)
                    .First(team => team.StisUrl == StisUrl)
                    .Players
                    .ToList();
                foreach (var oldPlayer in oldPlayers
                    .Where(oldPlayer => Players.Count(player => player.Id == oldPlayer.Id) == 0))
                {
                    db.Remove(oldPlayer);
                }
            }
            catch (InvalidOperationException) {}
        }

        private void SetMatches(OrganizerDbContext db)
        {
            foreach (var match in Matches)
            {
                match.MyTeamName = TeamName;
                if (db.Matches.Count(match1 =>
                    match1.Round == match.Round &&
                    match1.GuestsTeamName == match.GuestsTeamName &&
                    match.HomeTeamName == match1.HomeTeamName) == 0)
                {
                    db.Matches.Add(match);
                }
                else
                {
                    var oldMatch = db.Matches.First(match1 =>
                        match1.Round == match.Round &&
                        match1.GuestsTeamName == match.GuestsTeamName &&
                        match.HomeTeamName == match1.HomeTeamName);
                    oldMatch.Date = match.Date;
                    oldMatch.Result = match.Result;
                }
            }
        }

        /// <summary>
        /// Method deletes from database all matches which are not already planned for this team.
        /// This happens typically at the start of new season.
        /// </summary>
        /// <param name="db"></param>
        private void DeleteRedundantMatches(OrganizerDbContext db)
        {
            try
            {
                var oldMatches = db.Teams
                    .Include(team => team.Matches)
                    .First(team => team.StisUrl == StisUrl)
                    .Matches
                    .ToList();

                foreach (var oldMatch in oldMatches
                    .Where(oldMatch => Matches
                        .Count(match => match.Round == oldMatch.Round &&
                                        match.GuestsTeamName == oldMatch.GuestsTeamName &&
                                        match.HomeTeamName == oldMatch.GuestsTeamName) == 0))
                {
                    db.Remove(oldMatch);
                }
            } catch (InvalidOperationException) {}
        }
    }
}
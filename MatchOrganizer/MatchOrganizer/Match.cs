using System;
using System.Collections.Generic;
using System.Linq;
using MatchOrganizer.Database;
using MatchOrganizer.Scraping;
using Microsoft.EntityFrameworkCore;

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
        public string MyTeamName { private get; set; }

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

        private List<Player> GetAllPlayers()
        {
            using var db = new OrganizerDbContext();

            var matches = db.Teams
                .Include(team => team.Players)
                .Where(team => team.Matches
                    .Any(match => match.Date == Date &&
                                  match.HomeTeamName == HomeTeamName &&
                                  match.GuestsTeamName == GuestsTeamName))
                .ToList();

            var players = new List<Player>();
            matches.ForEach(team => players.AddRange(team.Players));

            var allPlayers = db.Players
                .Include(player => player.SelectedToMatches)
                .ToList();

            var playersUrl = players
                .Select(player => player.StisUrl)
                .Intersect(allPlayers.Select(player => player.StisUrl))
                .ToList();

            return SelectCorrectPlayers(playersUrl, allPlayers);
        }

        /// <summary>
        /// Method returns all players which are selected for this match
        /// </summary>
        /// <returns></returns>
        public List<Player> GetSelectedPlayers()
        {
            var listPlayers = GetAllPlayers();
            var selectedPlayers = new HashSet<Player>();
            foreach (var pl in listPlayers
                .Where(pl => pl.SelectedToMatches.Any(match => match.HomeTeamName == HomeTeamName &&
                                                               match.GuestsTeamName == GuestsTeamName && 
                                                               match.Date == Date)))
            {
                selectedPlayers.Add(pl);
            }

            return selectedPlayers.ToList();
        }

        /// <summary>
        /// Method returns all players which can be selected for this match
        /// </summary>
        /// <returns></returns>
        public List<Player> GetAvailablePlayers()
        {
            var listPlayers = GetAllPlayers();
            return listPlayers
                .Where(pl => ClubManager.IsAvailable(pl, this))
                .ToList();
        }

        public List<Player> GetOpponentsPlayers()
        {
            var opponentUrl = MyTeamName == HomeTeamName ? GuestsTeamUrl : HomeTeamUrl;
            return Stis.GetPlayers(opponentUrl);
        }

        private static List<Player> SelectCorrectPlayers(List<string> playersUrl, List<Player> allPlayers)
        {
            var listPlayers = new List<Player>();

            foreach (var pl in allPlayers)
            {
                if (!playersUrl.Contains(pl.StisUrl))
                {
                    continue;
                }
                var url = pl.StisUrl.Split("/")
                    .SkipLast(1)
                    .Aggregate("", (s, s1) => s += "/" + s1)
                    .Remove(0, 1)
                    .ToString();
                allPlayers.Where(player => player.StisUrl.Contains(url))
                    .ToList()
                    .ForEach(player => pl.SelectedToMatches.AddRange(player.SelectedToMatches));
                listPlayers.Add(pl);
            }
            return listPlayers;
        }

    }
}
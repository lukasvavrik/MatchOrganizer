using System;
using System.Collections.Generic;
using System.Linq;
using MatchOrganizer.Scraping;

namespace MatchOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //var searchResult = Stis.SearchClubs("tj Žďár nad Sázavou");
            //ClubManager.SetClub(searchResult.First().Key, searchResult.First().Value);
            //ClubManager.AddPlayerToMatch(ClubManager.Teams.First().Players.First(), ClubManager.Teams.First().Matches.First());
            //ClubManager.AddPlayerToMatch(ClubManager.Teams.First().Players.First(), ClubManager.Teams.First().Matches.ToList()[1]);
            //ClubManager.AddPlayerToMatch(ClubManager.Teams.First().Players.ToList()[1], ClubManager.Teams.First().Matches.First());
            //var avPlayers = ClubManager.Teams.First().Matches.First().GetAvailablePlayers();
            //var selPlayers = ClubManager.Teams.First().Matches.First().GetSelectedPlayers();

            //foreach (var team in ClubManager.Teams)
            //{   
            //    Console.WriteLine(team.TeamName + "\n");
            //    Console.WriteLine("Players: \n");
            //    foreach (var players in team.Players)
            //    {
            //        Console.WriteLine("    " +players.PlayerName + "\n");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine("Matches: \n");
            //    foreach (var match in team.Matches)
            //    {
            //        Console.WriteLine("    " + match.Round + ": " + match.Date + "\n    " + match.HomeTeamName + ": " + match.GuestsTeamName + "\n");
            //        Console.WriteLine("\n");
            //    }
                
            //    Console.WriteLine("-----------------------------------------------------------------------------------\n");
            //}
            //Console.WriteLine("\n");
            //Console.WriteLine("Stats Vavřík vs Sáblík:\n");
            //var tuple = Elost.GetWinningsStatistics("https://stis.ping-pong.cz/hrac-52828/svaz-420000/rocnik-2020", "Sáblík");
            //Console.WriteLine("    Wins: " + tuple.Item1 + "\n");
            //Console.WriteLine("    Losses: " + tuple.Item2 + "\n");
        }
    }
}
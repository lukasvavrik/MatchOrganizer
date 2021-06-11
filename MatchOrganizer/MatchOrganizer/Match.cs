using System;
using System.Collections.Generic;

namespace MatchOrganizer
{
    public class Match
    {
        public int Round { get; set; }
        public DateTime Date { get; set; }
        public string Home { get; set; }
        public string Guests { get; set; }
        public string Result { get; set; }
        
        public List<Player> SelectedPlayers { get; set; }
        
        public Match(int round, DateTime date, string home, string guests, string result)
        {
            Round = round;
            Date = date;
            Home = home;
            Guests = guests;
            Result = result;
        }
    }
}
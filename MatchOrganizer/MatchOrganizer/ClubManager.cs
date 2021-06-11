using System.Collections.Generic;
using MatchOrganizer.Scraping;

namespace MatchOrganizer
{
    public static class ClubManager
    {
        public static string Name { get; set; }
        public static string ClubStisUrl { get; set; }
        public static List<Team> Teams { get; set; }

        public static void SetClub(string name, string clubUrl)
        {
            Name = name;
            ClubStisUrl = ClubStisUrl;
            Teams = Stis.GetTeams(clubUrl);
        }
    }
}
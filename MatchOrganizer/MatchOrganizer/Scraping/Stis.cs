using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace MatchOrganizer.Scraping
{
    public static class Stis
    {
        private static readonly HtmlWeb website = new HtmlWeb();
        
        public static Dictionary<string, string> SearchClubs(string name)
        {
            var document = website.Load(Constants.StisSearchUrl + name);
            if (document
                .DocumentNode
                .SelectNodes("//div[@class = 'table-box']//h1[1]//span")
                .Any(node => !node.InnerText.Contains(Constants.ClubsStringToContain)))
            {
                return new Dictionary<string, string>();
            }
            
            return document
                .DocumentNode
                .SelectNodes("//div[@class = 'table-box']//a")
                .Where(node => node.GetAttributeValue("href", "").Contains("/oddil"))
                .ToDictionary(node => node.InnerText, node => Constants.StisBaseUrl + node.GetAttributeValue("href", ""));
        }

        public static List<Team> GetTeams(string clubUrl)
        {
            var document = new HtmlDocument();
            var urlResponse = UrlRequest(clubUrl);
            document.LoadHtml(urlResponse);
            var nodes = document
                .DocumentNode
                .SelectNodes("//div[@class = 'card-body pl-0 pr-0']/div//a")
                .Where(element => element.GetAttributeValue("href", "").Contains(Constants.TeamsStringToContain))
                .ToList();
            var teams = new List<Team>();
            nodes.ForEach(element => teams.Add(new Team(element.InnerText, Constants.StisBaseUrl + element.GetAttributeValue("href", ""))));
            return teams;
        }
        
        public static List<Match> GetMatches(string teamUrl)
        {
            var document = website.Load(GetMatchesUrl(teamUrl));
            var list = new List<Match>();
            try
            {
                var matches = document
                    .DocumentNode
                    .SelectNodes("//table[contains(@class,'table los')]/tbody//tr//td")
                    .ToList();
                for (var i = 0; i < (matches.Count) / 7; i++)
                {
                    var round = matches[i * 7].InnerText.Trim();
                    round = round.Remove(round.Length - 1);
                    var date =  matches[i * 7 + 1].InnerText.Trim();
                    var home = matches[i * 7 + 2].InnerText.Trim();
                    var homeUrl = Constants.StisBaseUrl + matches[i * 7 + 2].ChildNodes.ToList()[1].GetAttributeValue("href", "");
                    var guests = matches[i * 7 + 3].InnerText.Trim();
                    var guestsUrl = Constants.StisBaseUrl + matches[i * 7 + 3].ChildNodes.ToList()[1].GetAttributeValue("href", "");
                    var result = matches[i * 7 + 4].InnerText.Trim();
                    list.Add(new Match(round, ProcessDateTime(date), home, homeUrl,  guests, guestsUrl, result));
                }
                return list;
            }
            catch (ArgumentNullException)
            {
                return list;
            }
        }

        public static List<Player> GetPlayers(string teamUrl)
        {
            var document = website.Load(teamUrl);

            var webElements = document
                .DocumentNode
                .SelectNodes("//div[@class = 'card mt-2 col-sm-6 col-xs-12']/div[@class = 'card-body']/a")
                .Where(node => node.GetAttributeValue("href", "").StartsWith(Constants.PlayersStringToContain))
                .ToList();

            var players = new List<Player>();
            webElements.ForEach(node => players.Add(new Player(node.InnerText, Constants.StisBaseUrl + node.GetAttributeValue("href", ""))));
            return players;
        }

        private static string GetMatchesUrl(string teamUrl)
        {   
            var document = website.Load(teamUrl);
            return Constants.StisBaseUrl + document
                .DocumentNode
                .SelectNodes("//div[@class = 'btn-group mb-3']/a[1]")
                .First()
                .GetAttributeValue("href", "");
        }

        /// <summary>
        /// Method parses given string to DateTime format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static DateTime ProcessDateTime(string date)
        {
            var tmpDate = date.Split(" ").ToList();
            tmpDate.RemoveAt(0);

            var timeParts = tmpDate[1].Split(":");
            for (var i = 0; i < timeParts.Length; i++)
            {
                timeParts[i] = Regex.Replace(timeParts[i], Constants.RegexTimeParsing, "");
            }
            var dateParts = tmpDate[0].Split(".");
            return new DateTime(int.Parse(dateParts[2]),
                int.Parse(dateParts[1]),
                int.Parse(dateParts[0]),
                int.Parse(timeParts[0]),
                int.Parse(timeParts[1]),
                0);
        }
        
        private static string UrlRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = Constants.RequestMethod;
            request.Timeout = Constants.RequestTimeout;
            request.UserAgent = Constants.UserAgent;

            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();
            using var streamReader = new StreamReader(stream);
            var responseContent = streamReader.ReadToEnd();
            return (responseContent);
        }
    }
}
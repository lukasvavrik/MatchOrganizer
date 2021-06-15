using System;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MatchOrganizer.Scraping
{
    public static class Elost
    {
        private static HtmlWeb website = new HtmlWeb();

        public static async Task<Tuple<int, int>> GetWinningsStatistics(string playerStisUrl, string opponentName)
        {
            var c = GetEloUrl(playerStisUrl);
            var a = GetEloUrl(playerStisUrl) + Constants.EloFiltr + opponentName;
            var document = await website.LoadFromWebAsync(GetEloUrl(playerStisUrl) + Constants.EloFiltr + opponentName);
            var wins = 0;
            var loss = 0;
            var winStats = new Tuple<int, int>(0,0);
            document.DocumentNode.SelectNodes("//table[@class = 'rank']//tr//td[@class = 'numeric']")
                .Where(node => node.InnerText.Contains(":") && !node.InnerText.Contains("%"))
                .ToList()
                .ForEach(node =>
                {
                    if (node.InnerText.Trim().StartsWith("3"))
                    {
                        wins++;
                    }
                    else
                    {
                        loss++;
                    }
                });
            return new Tuple<int, int>(wins, loss);
        }

        private static string GetEloUrl(string playerStisUrl)
        {   
            var document = website.Load(playerStisUrl);
            return document.DocumentNode.SelectNodes("//a[@title = 'Elo statistiky']").First().GetAttributeValue("href", "");
        }
    }
}
namespace MatchOrganizer
{
    public class Player
    {
        public string Name { get; set; }
        public string StisUrl { get; set; }

        public Player(string name, string stisUrl)
        {
            Name = name;
            StisUrl = stisUrl;
        }
    }
}
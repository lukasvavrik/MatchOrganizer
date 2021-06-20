namespace MatchOrganizer
{
    public static class Constants
    {
        public const string StisSearchUrl = "https://stis.ping-pong.cz/hledat?s=";
        public const string StisBaseUrl = "https://stis.ping-pong.cz/";

        public const string EloFiltr =
            "?filtr_i_vyhry=ano&filtr_i_prohry=ano&filtr_od_sezony=2011&filtr_zapasy_search=";

        public const string StatsButtonText = "Stats";
        public const string SelectSquadButtonText = "Select squad";


        public const string UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)";
        public const int RequestTimeout = 6000;
        public const string RequestMethod = "GET";

        public const string RegexTimeParsing = "[^.0-9]";

        public const string ClubsStringToContain = "Oddíly";
        public const string TeamsStringToContain = "druzstvo";
        public const string PlayersStringToContain = "/hrac";


    }
}
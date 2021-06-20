using System;
using System.Windows.Forms;
using MatchOrganizer;

namespace MatchOrganizerFront
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (ClubManager.IsClubSelected())
            {   
                Application.Run(new MatchOrganizer());
            }
            else
            {
                Application.Run(new SearchClub());
            }
        }
    }
}

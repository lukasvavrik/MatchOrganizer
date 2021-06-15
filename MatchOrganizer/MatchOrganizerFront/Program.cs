using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                ClubManager.SetClub();
                Application.Run(new MatchOrganizer());
            }
            else
            {
                Application.Run(new SearchClub());
            }
        }
    }
}

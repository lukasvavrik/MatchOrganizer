using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchOrganizer;
using MatchOrganizerFront;


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
                Application.Run(new MatchOrganizerFron.MatchOrganizer());
            }
            else
            {
                Application.Run(new SearchClub());
            }
        }
    }
}

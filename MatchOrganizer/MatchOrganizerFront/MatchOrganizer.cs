using System;
using System.Threading;
using System.Windows.Forms;
using MatchOrganizer;

namespace MatchOrganizerFront
{
    public partial class MatchOrganizer : Form
    {
        private Team selectedTeam;

        private LoadingScreen loadingScreen;

        public MatchOrganizer(string name, string clubUrl)
        {
            var t = new Thread(StartForm);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            ClubManager.SetClub(name, clubUrl);
            loadingScreen?.BeginInvoke(new Action((() => loadingScreen.Close())));
            InitializeComponent();
            t.Interrupt();
            SetInitValues();
        }

        public MatchOrganizer()
        {
            var t = new Thread(StartForm);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            ClubManager.SetClub();
            loadingScreen?.BeginInvoke(new Action((() => loadingScreen.Close())));
            InitializeComponent();
            t.Interrupt();
            SetInitValues();
        }

        private void SetInitValues()
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Maximized;
            foreach (var team in ClubManager.Teams)
            {
                TeamsDataGrid.Rows.Add(team.TeamName);
            }

            if (ClubManager.Teams.Count == 0)
            {
                return;
            }

            selectedTeam = ClubManager.Teams[0];
            dataGridPlayers.Rows.Clear();
            foreach (var player in selectedTeam.Players)
            {
                dataGridPlayers.Rows.Add(player.PlayerName);
            }
            foreach (var match in selectedTeam.Matches)
            {
                dataGridMatches.Rows.Add(match.Round, 
                    match.Date, match.HomeTeamName, 
                    match.GuestsTeamName,
                    match.Result, 
                    Constants.SelectSquadButtonText);
            }
        }

        public void StartForm()
        {
            loadingScreen = new LoadingScreen();
            Application.Run(loadingScreen);
        }

        private void TeamsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedTeam = ClubManager.Teams[e.RowIndex];
            dataGridPlayers.Rows.Clear();
            foreach (var player in selectedTeam.Players)
            {
                dataGridPlayers.Rows.Add(player.PlayerName);
            }
            dataGridMatches.Rows.Clear();
            foreach (var match in selectedTeam.Matches)
            {
                dataGridMatches.Rows.Add(match.Round, match.Date, match.HomeTeamName, match.GuestsTeamName, match.Result, "Select squad");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var selectSquad = new SelectSquad(selectedTeam.Matches[e.RowIndex]);
            selectSquad.Show();

        }

        private void SelectNewClub_Click(object sender, EventArgs e)
        {
            Hide();
            var formSearchClub = new SearchClub();
            formSearchClub.Closed += (s, args) => this.Close();
            formSearchClub.Show();
        }

    }
}

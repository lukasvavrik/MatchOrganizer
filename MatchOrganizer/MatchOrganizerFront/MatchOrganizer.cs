using System;
using System.Threading;
using System.Windows.Forms;
using MatchOrganizer;
using MatchOrganizerFront;

namespace MatchOrganizerFron
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
            if (loadingScreen != null)
            {
                loadingScreen.BeginInvoke(new Action((() => loadingScreen.Close())));

            }
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
            if (loadingScreen != null)
            {
                loadingScreen.BeginInvoke(new Action((() => loadingScreen.Close())));

            }
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
            if (ClubManager.Teams.Count > 0)
            {
                selectedTeam = ClubManager.Teams[0];
                dataGridPlayers.Rows.Clear();
                foreach (var player in selectedTeam.Players)
                {
                    dataGridPlayers.Rows.Add(player.PlayerName);
                }
                foreach (var match in selectedTeam.Matches)
                {
                    dataGridMatches.Rows.Add(match.Round, match.Date, match.HomeTeamName, match.GuestsTeamName, match.Result, "Select squad");
                }
            }
        }

        public void StartForm()
        {
            loadingScreen = new LoadingScreen();
            Application.Run(loadingScreen);
        }

        private void TeamsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var teamName = TeamsDataGrid.Rows[rowIndex].Cells[0].FormattedValue.ToString();
            selectedTeam = ClubManager.Teams[rowIndex];
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MatchOrganizer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var selectSquad = new SelectSquad(selectedTeam.Matches[e.RowIndex]);
            selectSquad.Show();

        }

        private void SelectNewClub_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formSearchClub = new SearchClub();
            formSearchClub.Closed += (s, args) => this.Close();
            formSearchClub.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

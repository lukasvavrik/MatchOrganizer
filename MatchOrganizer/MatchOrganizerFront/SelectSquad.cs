using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchOrganizer;
using MatchOrganizer.Scraping;

namespace MatchOrganizerFront
{
    public partial class SelectSquad : Form
    {
        private readonly Match match;
        private readonly List<Player> selectedPlayers;
        private List<Player> availablePlayers;
        private readonly List<Player> opponentPlayers;
        private readonly Player[] currentSelectedPlayers = new Player[5];
        public SelectSquad(Match match)
        {
            this.match = match;
            InitializeComponent();
            Title1.Text = match.HomeTeamName + " vs " + match.GuestsTeamName + " - " + match.Date;
            selectedPlayers = match.GetSelectedPlayers();
            availablePlayers = match.GetAvailablePlayers();
            opponentPlayers = match.GetOpponentsPlayers();
            dataGridSquad1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridSquad1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
        }

        private void SelectSquad_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 5; i++)
            {
                var values = new DataGridViewComboBoxCell();
                var list = new List<string>();
                availablePlayers.ForEach(player => list.Add(player.PlayerName));
                values.DataSource = list;
                dataGridSquad1.Rows.Add();
                dataGridSquad1.Rows[i].Cells[0] = values;
                dataGridSquad1.Rows[i].Cells[1].Value = Constants.StatsButtonText;

                if (selectedPlayers.Count <= i)
                {
                    continue;
                }
                dataGridSquad1.Rows[i].DefaultCellStyle.NullValue = selectedPlayers[i].PlayerName;
                currentSelectedPlayers[i] = selectedPlayers[i];
            }
        }

        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridSquad1.IsCurrentCellDirty)
            {
                dataGridSquad1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridSquad1.Rows[e.RowIndex].Cells[0];
            if (cb.Value == null)
            {
                return;
            }
            var items = cb.Items;
            var position = 0;
            for (var i = 0; i < items.Count; i++)
            {
                if (!items[i].Equals(cb.Value))
                {
                    continue;
                }
                position = i;
                break;
            }
            currentSelectedPlayers[cb.RowIndex] = availablePlayers[position];
            availablePlayers = availablePlayers.Except(currentSelectedPlayers).ToList();

            for (var i = 0; i < 5; i++)
            {
                var values = new DataGridViewComboBoxCell();
                var list = new List<string>();
                availablePlayers.ForEach(player => list.Add(player.PlayerName));
                values.DataSource = list;
                dataGridSquad1.Rows[i].Cells[0] = values;
                if (currentSelectedPlayers[i] != null)
                {
                    dataGridSquad1.Rows[i].DefaultCellStyle.NullValue = currentSelectedPlayers[i].PlayerName;
                }
            }
        }

        private async Task<string> GetStats(int rowIndex, IProgress<ProgressReport> progress)
        {
            var stats = new StringBuilder();
            var progressReport = new ProgressReport();
            if (currentSelectedPlayers[rowIndex] != null)
            {
                var count = 1;
                foreach (var opPlayer in opponentPlayers)
                {
                    var winningsStatistics = await Elost.GetWinningsStatistics(currentSelectedPlayers[rowIndex].StisUrl, opPlayer.PlayerName);
                    stats.AppendLine(currentSelectedPlayers[rowIndex].PlayerName + " vs " + opPlayer.PlayerName + ": " +
                                     winningsStatistics.Item1 + " : " + winningsStatistics.Item2);

                    progressReport.PercentComplete = count * 100 / opponentPlayers.Count;
                    progress.Report(progressReport);
                    count++;
                }
            }
            progressReport.PercentComplete = 0;
            progress.Report(progressReport);
            return stats.ToString();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var progress = new Progress<ProgressReport>();
            progress.ProgressChanged += (o, report) =>
            {
                progressBarStats.Value = report.PercentComplete;
                progressBarStats.Update();
            };

            textBoxStats.Text = await GetStats(e.RowIndex, progress);
        }

        private void SaveChanges_Click_1(object sender, EventArgs e)
        {

            foreach (var player in selectedPlayers)
            {
                ClubManager.DeletePlayerFromMatch(player, match);
            }

;           foreach (var player in currentSelectedPlayers)
            {
                if (player != null)
                {
                    ClubManager.AddPlayerToMatch(player, match);
                }
            }
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MatchOrganizer.Database;
using MatchOrganizer.Scraping;


namespace MatchOrganizerFront
{
    public partial class SearchClub : Form
    {   
        public Dictionary<string, string> SearchClubResults { get; set; }

        public SearchClub()
        {   

            SearchClubResults = new Dictionary<string, string>();
            new OrganizerDbContext().DeleteDatabase();
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {

            SearchClubResults = Stis.SearchClubs(ClubSearchTextBox.Text);
            foreach (var r in SearchClubResults)
            {
                SearchResults.Rows.Add(r.Key);
            }
        }

        private void SearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var name = SearchResults.Rows[rowIndex].Cells[0].FormattedValue.ToString();
            var url = SearchClubResults[name];
            Hide();
            var formMatchOrganizer = new MatchOrganizer(name, url);
            formMatchOrganizer.Closed += (s, args) => this.Close();
            formMatchOrganizer.Show();
        }

    }
}

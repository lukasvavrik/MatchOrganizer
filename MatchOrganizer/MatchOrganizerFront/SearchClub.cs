using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchOrganizer;
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

        private void label1_Click(object sender, EventArgs e)
        {
            
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
            this.Hide();
            var formMatchOrganizer = new MatchOrganizerFron.MatchOrganizer(name, url);
            formMatchOrganizer.Closed += (s, args) => this.Close();
            formMatchOrganizer.Show();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClubSearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


namespace MatchOrganizerFron
{
    partial class MatchOrganizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TeamsDataGrid = new System.Windows.Forms.DataGridView();
            this.Teams = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridPlayers = new System.Windows.Forms.DataGridView();
            this.AllPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridMatches = new System.Windows.Forms.DataGridView();
            this.Round = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectSquad = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SelectNewClub = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatches)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamsDataGrid
            // 
            this.TeamsDataGrid.AllowUserToAddRows = false;
            this.TeamsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeamsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TeamsDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.TeamsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamsDataGrid.ColumnHeadersVisible = false;
            this.TeamsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Teams});
            this.TeamsDataGrid.Location = new System.Drawing.Point(3, 3);
            this.TeamsDataGrid.Name = "TeamsDataGrid";
            this.TeamsDataGrid.RowHeadersVisible = false;
            this.TeamsDataGrid.RowHeadersWidth = 51;
            this.TeamsDataGrid.RowTemplate.Height = 29;
            this.TeamsDataGrid.Size = new System.Drawing.Size(208, 513);
            this.TeamsDataGrid.TabIndex = 0;
            this.TeamsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TeamsDataGrid_CellContentClick);
            // 
            // Teams
            // 
            this.Teams.HeaderText = "Teams";
            this.Teams.MinimumWidth = 6;
            this.Teams.Name = "Teams";
            // 
            // dataGridPlayers
            // 
            this.dataGridPlayers.AllowUserToAddRows = false;
            this.dataGridPlayers.AllowUserToDeleteRows = false;
            this.dataGridPlayers.AllowUserToResizeColumns = false;
            this.dataGridPlayers.AllowUserToResizeRows = false;
            this.dataGridPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AllPlayers});
            this.dataGridPlayers.Location = new System.Drawing.Point(217, 3);
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.RowHeadersVisible = false;
            this.dataGridPlayers.RowHeadersWidth = 51;
            this.dataGridPlayers.RowTemplate.Height = 29;
            this.dataGridPlayers.Size = new System.Drawing.Size(315, 513);
            this.dataGridPlayers.TabIndex = 1;
            this.dataGridPlayers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AllPlayers
            // 
            this.AllPlayers.HeaderText = "Players";
            this.AllPlayers.MinimumWidth = 6;
            this.AllPlayers.Name = "AllPlayers";
            // 
            // dataGridMatches
            // 
            this.dataGridMatches.AllowUserToAddRows = false;
            this.dataGridMatches.AllowUserToDeleteRows = false;
            this.dataGridMatches.AllowUserToResizeColumns = false;
            this.dataGridMatches.AllowUserToResizeRows = false;
            this.dataGridMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Round,
            this.Date,
            this.AwayTeam,
            this.HomeTeam,
            this.Result,
            this.SelectSquad});
            this.dataGridMatches.Location = new System.Drawing.Point(538, 3);
            this.dataGridMatches.Name = "dataGridMatches";
            this.dataGridMatches.RowHeadersVisible = false;
            this.dataGridMatches.RowHeadersWidth = 51;
            this.dataGridMatches.RowTemplate.Height = 29;
            this.dataGridMatches.Size = new System.Drawing.Size(532, 513);
            this.dataGridMatches.TabIndex = 2;
            this.dataGridMatches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Round
            // 
            this.Round.HeaderText = "Round";
            this.Round.MinimumWidth = 6;
            this.Round.Name = "Round";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            // 
            // AwayTeam
            // 
            this.AwayTeam.HeaderText = "Away team";
            this.AwayTeam.MinimumWidth = 6;
            this.AwayTeam.Name = "AwayTeam";
            // 
            // HomeTeam
            // 
            this.HomeTeam.HeaderText = "Home Team";
            this.HomeTeam.MinimumWidth = 6;
            this.HomeTeam.Name = "HomeTeam";
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.MinimumWidth = 6;
            this.Result.Name = "Result";
            // 
            // SelectSquad
            // 
            this.SelectSquad.HeaderText = "Select squad";
            this.SelectSquad.MinimumWidth = 6;
            this.SelectSquad.Name = "SelectSquad";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TeamsDataGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridPlayers, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridMatches, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 491F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 519);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // SelectNewClub
            // 
            this.SelectNewClub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectNewClub.Location = new System.Drawing.Point(3, 528);
            this.SelectNewClub.Name = "SelectNewClub";
            this.SelectNewClub.Size = new System.Drawing.Size(1073, 22);
            this.SelectNewClub.TabIndex = 4;
            this.SelectNewClub.Text = "Select different club";
            this.SelectNewClub.UseVisualStyleBackColor = true;
            this.SelectNewClub.Click += new System.EventHandler(this.SelectNewClub_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SelectNewClub, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1079, 553);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // MatchOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 577);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "MatchOrganizer";
            this.Text = "MatchOrganizer";
            this.Load += new System.EventHandler(this.MatchOrganizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatches)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TeamsDataGrid;
        private System.Windows.Forms.DataGridViewButtonColumn Teams;
        private System.Windows.Forms.DataGridView dataGridPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllPlayers;
        private System.Windows.Forms.DataGridView dataGridMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn Round;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewButtonColumn SelectSquad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SelectNewClub;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
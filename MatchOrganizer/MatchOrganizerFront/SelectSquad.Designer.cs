
namespace MatchOrganizerFront
{
    partial class SelectSquad
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
            this.dataGridSquad1 = new System.Windows.Forms.DataGridView();
            this.Player = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ShowStats = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Title1 = new System.Windows.Forms.Label();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.textBoxStats = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarStats = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSquad1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridSquad1
            // 
            this.dataGridSquad1.AllowUserToAddRows = false;
            this.dataGridSquad1.AllowUserToDeleteRows = false;
            this.dataGridSquad1.AllowUserToResizeColumns = false;
            this.dataGridSquad1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSquad1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSquad1.ColumnHeadersHeight = 29;
            this.dataGridSquad1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Player,
            this.ShowStats});
            this.dataGridSquad1.Location = new System.Drawing.Point(3, 3);
            this.dataGridSquad1.Name = "dataGridSquad1";
            this.dataGridSquad1.RowHeadersVisible = false;
            this.dataGridSquad1.RowHeadersWidth = 51;
            this.dataGridSquad1.RowTemplate.Height = 29;
            this.dataGridSquad1.Size = new System.Drawing.Size(435, 411);
            this.dataGridSquad1.TabIndex = 0;
            this.dataGridSquad1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Player
            // 
            this.Player.FillWeight = 146.5241F;
            this.Player.HeaderText = "Player";
            this.Player.MinimumWidth = 6;
            this.Player.Name = "Player";
            this.Player.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Player.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ShowStats
            // 
            this.ShowStats.FillWeight = 53.47594F;
            this.ShowStats.HeaderText = "ShowStats";
            this.ShowStats.MinimumWidth = 6;
            this.ShowStats.Name = "ShowStats";
            this.ShowStats.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShowStats.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Title1
            // 
            this.Title1.AutoSize = true;
            this.Title1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title1.Location = new System.Drawing.Point(12, 9);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(65, 28);
            this.Title1.TabIndex = 1;
            this.Title1.Text = "label1";
            // 
            // SaveChanges
            // 
            this.SaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveChanges.Location = new System.Drawing.Point(783, 480);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(98, 29);
            this.SaveChanges.TabIndex = 2;
            this.SaveChanges.Text = "Save";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click_1);
            // 
            // textBoxStats
            // 
            this.textBoxStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStats.Location = new System.Drawing.Point(444, 3);
            this.textBoxStats.Multiline = true;
            this.textBoxStats.Name = "textBoxStats";
            this.textBoxStats.Size = new System.Drawing.Size(422, 411);
            this.textBoxStats.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.2F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridSquad1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxStats, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 417F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 417);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // progressBarStats
            // 
            this.progressBarStats.Location = new System.Drawing.Point(147, 480);
            this.progressBarStats.Name = "progressBarStats";
            this.progressBarStats.Size = new System.Drawing.Size(624, 29);
            this.progressBarStats.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Loading statistics:";
            // 
            // SelectSquad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 511);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarStats);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.Title1);
            this.Name = "SelectSquad";
            this.Text = "SelectSquad";
            this.Load += new System.EventHandler(this.SelectSquad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSquad1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSquad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Player;
        private System.Windows.Forms.DataGridViewButtonColumn ShowStats;
        private System.Windows.Forms.Button saveChanges;
        public System.Windows.Forms.DataGridView dataGridSquad1;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.TextBox textBoxStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBarStats;
        private System.Windows.Forms.Label label1;
    }
}
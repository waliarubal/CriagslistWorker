namespace CriagslistWorker
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListings = new System.Windows.Forms.DataGridView();
            this.chkUseTor = new System.Windows.Forms.CheckBox();
            this.chkHideBrowser = new System.Windows.Forms.CheckBox();
            this.chkHideConsole = new System.Windows.Forms.CheckBox();
            this.btnHarvest = new System.Windows.Forms.Button();
            this.lblListings = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListings
            // 
            this.dgvListings.AllowUserToAddRows = false;
            this.dgvListings.AllowUserToDeleteRows = false;
            this.dgvListings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle,
            this.colLocation,
            this.colEmail,
            this.colUrl});
            this.dgvListings.Location = new System.Drawing.Point(12, 41);
            this.dgvListings.MultiSelect = false;
            this.dgvListings.Name = "dgvListings";
            this.dgvListings.ReadOnly = true;
            this.dgvListings.RowHeadersVisible = false;
            this.dgvListings.RowTemplate.Height = 25;
            this.dgvListings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListings.Size = new System.Drawing.Size(760, 508);
            this.dgvListings.TabIndex = 0;
            // 
            // chkUseTor
            // 
            this.chkUseTor.AutoSize = true;
            this.chkUseTor.Checked = true;
            this.chkUseTor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseTor.Location = new System.Drawing.Point(12, 13);
            this.chkUseTor.Name = "chkUseTor";
            this.chkUseTor.Size = new System.Drawing.Size(117, 19);
            this.chkUseTor.TabIndex = 1;
            this.chkUseTor.Text = "Use TOR Network";
            this.chkUseTor.UseVisualStyleBackColor = true;
            // 
            // chkHideBrowser
            // 
            this.chkHideBrowser.AutoSize = true;
            this.chkHideBrowser.Location = new System.Drawing.Point(238, 12);
            this.chkHideBrowser.Name = "chkHideBrowser";
            this.chkHideBrowser.Size = new System.Drawing.Size(96, 19);
            this.chkHideBrowser.TabIndex = 2;
            this.chkHideBrowser.Text = "Hide Browser";
            this.chkHideBrowser.UseVisualStyleBackColor = true;
            // 
            // chkHideConsole
            // 
            this.chkHideConsole.AutoSize = true;
            this.chkHideConsole.Checked = true;
            this.chkHideConsole.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideConsole.Location = new System.Drawing.Point(135, 13);
            this.chkHideConsole.Name = "chkHideConsole";
            this.chkHideConsole.Size = new System.Drawing.Size(97, 19);
            this.chkHideConsole.TabIndex = 3;
            this.chkHideConsole.Text = "Hide Console";
            this.chkHideConsole.UseVisualStyleBackColor = true;
            // 
            // btnHarvest
            // 
            this.btnHarvest.Location = new System.Drawing.Point(340, 12);
            this.btnHarvest.Name = "btnHarvest";
            this.btnHarvest.Size = new System.Drawing.Size(80, 23);
            this.btnHarvest.TabIndex = 4;
            this.btnHarvest.Text = "Harvest";
            this.btnHarvest.UseVisualStyleBackColor = true;
            this.btnHarvest.Click += new System.EventHandler(this.btnHarvest_Click);
            // 
            // lblListings
            // 
            this.lblListings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListings.Location = new System.Drawing.Point(512, 10);
            this.lblListings.Name = "lblListings";
            this.lblListings.Size = new System.Drawing.Size(260, 23);
            this.lblListings.TabIndex = 5;
            this.lblListings.Text = "Listings Extracted: 0";
            this.lblListings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(426, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colUrl
            // 
            this.colUrl.HeaderText = "URL";
            this.colUrl.Name = "colUrl";
            this.colUrl.ReadOnly = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblListings);
            this.Controls.Add(this.btnHarvest);
            this.Controls.Add(this.chkHideConsole);
            this.Controls.Add(this.chkHideBrowser);
            this.Controls.Add(this.chkUseTor);
            this.Controls.Add(this.dgvListings);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criagslist Worker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvListings;
        private CheckBox chkUseTor;
        private CheckBox chkHideBrowser;
        private CheckBox chkHideConsole;
        private Button btnHarvest;
        private Label lblListings;
        private Button btnCancel;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewLinkColumn colUrl;
    }
}
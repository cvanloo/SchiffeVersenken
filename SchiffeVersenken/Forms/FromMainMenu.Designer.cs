namespace SchiffeVersenken
{
    partial class FormMainMenu
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnHost = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnOffline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(82, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your name:";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(172, 40);
            this.tbPlayerName.MaxLength = 20;
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(176, 20);
            this.tbPlayerName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbPlayerName, "1 to 20 letters and numbers");
            this.tbPlayerName.TextChanged += new System.EventHandler(this.tbPlayerName_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 20;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 20;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 4;
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetSettings.ForeColor = System.Drawing.Color.White;
            this.btnResetSettings.Image = global::SchiffeVersenken.Properties.Resources.Command_Reset;
            this.btnResetSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetSettings.Location = new System.Drawing.Point(277, 136);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(105, 25);
            this.btnResetSettings.TabIndex = 7;
            this.btnResetSettings.Text = "     Reset Settings";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.DimGray;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::SchiffeVersenken.Properties.Resources.Settings_01;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(169, 136);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(105, 25);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.DimGray;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.Image = global::SchiffeVersenken.Properties.Resources.Data_certificate_WF;
            this.btnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.Location = new System.Drawing.Point(61, 136);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(105, 25);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnHost
            // 
            this.btnHost.BackColor = System.Drawing.Color.DimGray;
            this.btnHost.Enabled = false;
            this.btnHost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnHost.ForeColor = System.Drawing.Color.White;
            this.btnHost.Image = global::SchiffeVersenken.Properties.Resources.Plug_reverse;
            this.btnHost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHost.Location = new System.Drawing.Point(277, 107);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(105, 25);
            this.btnHost.TabIndex = 4;
            this.btnHost.Text = "Host game";
            this.btnHost.UseVisualStyleBackColor = false;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.DimGray;
            this.btnJoin.Enabled = false;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnJoin.ForeColor = System.Drawing.Color.White;
            this.btnJoin.Image = global::SchiffeVersenken.Properties.Resources.Plug;
            this.btnJoin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJoin.Location = new System.Drawing.Point(169, 107);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(105, 25);
            this.btnJoin.TabIndex = 3;
            this.btnJoin.Text = "Join game";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnOffline
            // 
            this.btnOffline.BackColor = System.Drawing.Color.DimGray;
            this.btnOffline.Enabled = false;
            this.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOffline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnOffline.ForeColor = System.Drawing.Color.White;
            this.btnOffline.Image = global::SchiffeVersenken.Properties.Resources.Work_offline_WF;
            this.btnOffline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOffline.Location = new System.Drawing.Point(61, 107);
            this.btnOffline.Name = "btnOffline";
            this.btnOffline.Size = new System.Drawing.Size(105, 25);
            this.btnOffline.TabIndex = 2;
            this.btnOffline.Text = "Play offline";
            this.btnOffline.UseVisualStyleBackColor = false;
            this.btnOffline.Click += new System.EventHandler(this.btnOffline_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(439, 193);
            this.Controls.Add(this.btnResetSettings);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnHost);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnOffline);
            this.Controls.Add(this.tbPlayerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMainMenu";
            this.Text = "Main Menu";
            this.Click += new System.EventHandler(this.FormMainMenu_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.Button btnOffline;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnResetSettings;
    }
}


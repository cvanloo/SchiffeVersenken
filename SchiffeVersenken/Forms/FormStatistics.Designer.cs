namespace SchiffeVersenken.Forms
{
    partial class FormStatistics
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelWins = new System.Windows.Forms.Label();
            this.labelLoses = new System.Windows.Forms.Label();
            this.labelLosesCount = new System.Windows.Forms.Label();
            this.labelWinsCount = new System.Windows.Forms.Label();
            this.labelGamesPlayedCount = new System.Windows.Forms.Label();
            this.labelGamesPlayed = new System.Windows.Forms.Label();
            this.labelFastestLoseCount = new System.Windows.Forms.Label();
            this.labelFastestWinCount = new System.Windows.Forms.Label();
            this.labelFastestLose = new System.Windows.Forms.Label();
            this.labelFastetsWin = new System.Windows.Forms.Label();
            this.labelWorstLoseCount = new System.Windows.Forms.Label();
            this.labelBestWinCount = new System.Windows.Forms.Label();
            this.labelWorstLose = new System.Windows.Forms.Label();
            this.labelBestWin = new System.Windows.Forms.Label();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(194, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(102, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "- Statistics -";
            // 
            // labelWins
            // 
            this.labelWins.AutoSize = true;
            this.labelWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWins.ForeColor = System.Drawing.Color.White;
            this.labelWins.Location = new System.Drawing.Point(46, 119);
            this.labelWins.Name = "labelWins";
            this.labelWins.Size = new System.Drawing.Size(62, 24);
            this.labelWins.TabIndex = 1;
            this.labelWins.Text = "Wins: ";
            // 
            // labelLoses
            // 
            this.labelLoses.AutoSize = true;
            this.labelLoses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoses.ForeColor = System.Drawing.Color.White;
            this.labelLoses.Location = new System.Drawing.Point(46, 160);
            this.labelLoses.Name = "labelLoses";
            this.labelLoses.Size = new System.Drawing.Size(70, 24);
            this.labelLoses.TabIndex = 2;
            this.labelLoses.Text = "Loses: ";
            // 
            // labelLosesCount
            // 
            this.labelLosesCount.AutoSize = true;
            this.labelLosesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLosesCount.ForeColor = System.Drawing.Color.White;
            this.labelLosesCount.Location = new System.Drawing.Point(370, 160);
            this.labelLosesCount.Name = "labelLosesCount";
            this.labelLosesCount.Size = new System.Drawing.Size(20, 24);
            this.labelLosesCount.TabIndex = 4;
            this.labelLosesCount.Text = "0";
            // 
            // labelWinsCount
            // 
            this.labelWinsCount.AutoSize = true;
            this.labelWinsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinsCount.ForeColor = System.Drawing.Color.White;
            this.labelWinsCount.Location = new System.Drawing.Point(370, 119);
            this.labelWinsCount.Name = "labelWinsCount";
            this.labelWinsCount.Size = new System.Drawing.Size(20, 24);
            this.labelWinsCount.TabIndex = 3;
            this.labelWinsCount.Text = "0";
            // 
            // labelGamesPlayedCount
            // 
            this.labelGamesPlayedCount.AutoSize = true;
            this.labelGamesPlayedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGamesPlayedCount.ForeColor = System.Drawing.Color.White;
            this.labelGamesPlayedCount.Location = new System.Drawing.Point(370, 80);
            this.labelGamesPlayedCount.Name = "labelGamesPlayedCount";
            this.labelGamesPlayedCount.Size = new System.Drawing.Size(20, 24);
            this.labelGamesPlayedCount.TabIndex = 6;
            this.labelGamesPlayedCount.Text = "0";
            // 
            // labelGamesPlayed
            // 
            this.labelGamesPlayed.AutoSize = true;
            this.labelGamesPlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGamesPlayed.ForeColor = System.Drawing.Color.White;
            this.labelGamesPlayed.Location = new System.Drawing.Point(46, 80);
            this.labelGamesPlayed.Name = "labelGamesPlayed";
            this.labelGamesPlayed.Size = new System.Drawing.Size(141, 24);
            this.labelGamesPlayed.TabIndex = 5;
            this.labelGamesPlayed.Text = "Games played: ";
            // 
            // labelFastestLoseCount
            // 
            this.labelFastestLoseCount.AutoSize = true;
            this.labelFastestLoseCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFastestLoseCount.ForeColor = System.Drawing.Color.White;
            this.labelFastestLoseCount.Location = new System.Drawing.Point(370, 246);
            this.labelFastestLoseCount.Name = "labelFastestLoseCount";
            this.labelFastestLoseCount.Size = new System.Drawing.Size(20, 24);
            this.labelFastestLoseCount.TabIndex = 10;
            this.labelFastestLoseCount.Text = "0";
            // 
            // labelFastestWinCount
            // 
            this.labelFastestWinCount.AutoSize = true;
            this.labelFastestWinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFastestWinCount.ForeColor = System.Drawing.Color.White;
            this.labelFastestWinCount.Location = new System.Drawing.Point(370, 204);
            this.labelFastestWinCount.Name = "labelFastestWinCount";
            this.labelFastestWinCount.Size = new System.Drawing.Size(20, 24);
            this.labelFastestWinCount.TabIndex = 9;
            this.labelFastestWinCount.Text = "0";
            // 
            // labelFastestLose
            // 
            this.labelFastestLose.AutoSize = true;
            this.labelFastestLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFastestLose.ForeColor = System.Drawing.Color.White;
            this.labelFastestLose.Location = new System.Drawing.Point(46, 246);
            this.labelFastestLose.Name = "labelFastestLose";
            this.labelFastestLose.Size = new System.Drawing.Size(125, 24);
            this.labelFastestLose.TabIndex = 8;
            this.labelFastestLose.Text = "Fastest Lose: ";
            // 
            // labelFastetsWin
            // 
            this.labelFastetsWin.AutoSize = true;
            this.labelFastetsWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFastetsWin.ForeColor = System.Drawing.Color.White;
            this.labelFastetsWin.Location = new System.Drawing.Point(46, 204);
            this.labelFastetsWin.Name = "labelFastetsWin";
            this.labelFastetsWin.Size = new System.Drawing.Size(117, 24);
            this.labelFastetsWin.TabIndex = 7;
            this.labelFastetsWin.Text = "Fastest Win: ";
            // 
            // labelWorstLoseCount
            // 
            this.labelWorstLoseCount.AutoSize = true;
            this.labelWorstLoseCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorstLoseCount.ForeColor = System.Drawing.Color.White;
            this.labelWorstLoseCount.Location = new System.Drawing.Point(370, 328);
            this.labelWorstLoseCount.Name = "labelWorstLoseCount";
            this.labelWorstLoseCount.Size = new System.Drawing.Size(20, 24);
            this.labelWorstLoseCount.TabIndex = 14;
            this.labelWorstLoseCount.Text = "0";
            // 
            // labelBestWinCount
            // 
            this.labelBestWinCount.AutoSize = true;
            this.labelBestWinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestWinCount.ForeColor = System.Drawing.Color.White;
            this.labelBestWinCount.Location = new System.Drawing.Point(370, 286);
            this.labelBestWinCount.Name = "labelBestWinCount";
            this.labelBestWinCount.Size = new System.Drawing.Size(20, 24);
            this.labelBestWinCount.TabIndex = 13;
            this.labelBestWinCount.Text = "0";
            // 
            // labelWorstLose
            // 
            this.labelWorstLose.AutoSize = true;
            this.labelWorstLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorstLose.ForeColor = System.Drawing.Color.White;
            this.labelWorstLose.Location = new System.Drawing.Point(46, 328);
            this.labelWorstLose.Name = "labelWorstLose";
            this.labelWorstLose.Size = new System.Drawing.Size(114, 24);
            this.labelWorstLose.TabIndex = 12;
            this.labelWorstLose.Text = "Worst Lose: ";
            // 
            // labelBestWin
            // 
            this.labelBestWin.AutoSize = true;
            this.labelBestWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestWin.ForeColor = System.Drawing.Color.White;
            this.labelBestWin.Location = new System.Drawing.Point(46, 286);
            this.labelBestWin.Name = "labelBestWin";
            this.labelBestWin.Size = new System.Drawing.Size(94, 24);
            this.labelBestWin.TabIndex = 11;
            this.labelBestWin.Text = "Best Win: ";
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetSettings.ForeColor = System.Drawing.Color.White;
            this.btnResetSettings.Image = global::SchiffeVersenken.Properties.Resources.Command_Reset;
            this.btnResetSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetSettings.Location = new System.Drawing.Point(182, 370);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(145, 23);
            this.btnResetSettings.TabIndex = 15;
            this.btnResetSettings.Text = "Reset Settings";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(494, 425);
            this.Controls.Add(this.btnResetSettings);
            this.Controls.Add(this.labelWorstLoseCount);
            this.Controls.Add(this.labelBestWinCount);
            this.Controls.Add(this.labelWorstLose);
            this.Controls.Add(this.labelBestWin);
            this.Controls.Add(this.labelFastestLoseCount);
            this.Controls.Add(this.labelFastestWinCount);
            this.Controls.Add(this.labelFastestLose);
            this.Controls.Add(this.labelFastetsWin);
            this.Controls.Add(this.labelGamesPlayedCount);
            this.Controls.Add(this.labelGamesPlayed);
            this.Controls.Add(this.labelLosesCount);
            this.Controls.Add(this.labelWinsCount);
            this.Controls.Add(this.labelLoses);
            this.Controls.Add(this.labelWins);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormStatistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            this.Click += new System.EventHandler(this.FormStatistics_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelWins;
        private System.Windows.Forms.Label labelLoses;
        private System.Windows.Forms.Label labelLosesCount;
        private System.Windows.Forms.Label labelWinsCount;
        private System.Windows.Forms.Label labelGamesPlayedCount;
        private System.Windows.Forms.Label labelGamesPlayed;
        private System.Windows.Forms.Label labelFastestLoseCount;
        private System.Windows.Forms.Label labelFastestWinCount;
        private System.Windows.Forms.Label labelFastestLose;
        private System.Windows.Forms.Label labelFastetsWin;
        private System.Windows.Forms.Label labelWorstLoseCount;
        private System.Windows.Forms.Label labelBestWinCount;
        private System.Windows.Forms.Label labelWorstLose;
        private System.Windows.Forms.Label labelBestWin;
        private System.Windows.Forms.Button btnResetSettings;
    }
}
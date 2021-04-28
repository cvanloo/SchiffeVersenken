namespace SchiffeVersenken.Forms
{
    partial class FormGame
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
            this.labelHits = new System.Windows.Forms.Label();
            this.labelShipsAlive = new System.Windows.Forms.Label();
            this.labelShipsFoundered = new System.Windows.Forms.Label();
            this.labelShipsFounderedEnemy = new System.Windows.Forms.Label();
            this.labelShipsAliveEnemy = new System.Windows.Forms.Label();
            this.labelHitsEnemy = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelEnemy = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelShotsEnemy = new System.Windows.Forms.Label();
            this.labelShots = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnShowRules = new System.Windows.Forms.Button();
            this.btnOpenChat = new System.Windows.Forms.Button();
            this.pbFieldEnemy = new System.Windows.Forms.PictureBox();
            this.pbFieldPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFieldEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFieldPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHits
            // 
            this.labelHits.AutoSize = true;
            this.labelHits.ForeColor = System.Drawing.Color.White;
            this.labelHits.Location = new System.Drawing.Point(30, 614);
            this.labelHits.Name = "labelHits";
            this.labelHits.Size = new System.Drawing.Size(62, 13);
            this.labelHits.TabIndex = 5;
            this.labelHits.Text = "Total hits: 0";
            // 
            // labelShipsAlive
            // 
            this.labelShipsAlive.AutoSize = true;
            this.labelShipsAlive.ForeColor = System.Drawing.Color.White;
            this.labelShipsAlive.Location = new System.Drawing.Point(30, 630);
            this.labelShipsAlive.Name = "labelShipsAlive";
            this.labelShipsAlive.Size = new System.Drawing.Size(70, 13);
            this.labelShipsAlive.TabIndex = 6;
            this.labelShipsAlive.Text = "Ships alive: 0";
            // 
            // labelShipsFoundered
            // 
            this.labelShipsFoundered.AutoSize = true;
            this.labelShipsFoundered.ForeColor = System.Drawing.Color.White;
            this.labelShipsFoundered.Location = new System.Drawing.Point(30, 647);
            this.labelShipsFoundered.Name = "labelShipsFoundered";
            this.labelShipsFoundered.Size = new System.Drawing.Size(96, 13);
            this.labelShipsFoundered.TabIndex = 7;
            this.labelShipsFoundered.Text = "Ships foundered: 0";
            // 
            // labelShipsFounderedEnemy
            // 
            this.labelShipsFounderedEnemy.AutoSize = true;
            this.labelShipsFounderedEnemy.ForeColor = System.Drawing.Color.White;
            this.labelShipsFounderedEnemy.Location = new System.Drawing.Point(565, 647);
            this.labelShipsFounderedEnemy.Name = "labelShipsFounderedEnemy";
            this.labelShipsFounderedEnemy.Size = new System.Drawing.Size(15, 13);
            this.labelShipsFounderedEnemy.TabIndex = 10;
            this.labelShipsFounderedEnemy.Text = "id";
            // 
            // labelShipsAliveEnemy
            // 
            this.labelShipsAliveEnemy.AutoSize = true;
            this.labelShipsAliveEnemy.ForeColor = System.Drawing.Color.White;
            this.labelShipsAliveEnemy.Location = new System.Drawing.Point(565, 630);
            this.labelShipsAliveEnemy.Name = "labelShipsAliveEnemy";
            this.labelShipsAliveEnemy.Size = new System.Drawing.Size(70, 13);
            this.labelShipsAliveEnemy.TabIndex = 9;
            this.labelShipsAliveEnemy.Text = "Ships alive: 0";
            // 
            // labelHitsEnemy
            // 
            this.labelHitsEnemy.AutoSize = true;
            this.labelHitsEnemy.ForeColor = System.Drawing.Color.White;
            this.labelHitsEnemy.Location = new System.Drawing.Point(565, 614);
            this.labelHitsEnemy.Name = "labelHitsEnemy";
            this.labelHitsEnemy.Size = new System.Drawing.Size(62, 13);
            this.labelHitsEnemy.TabIndex = 8;
            this.labelHitsEnemy.Text = "Total hits: 0";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(240, 48);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(51, 25);
            this.labelUser.TabIndex = 11;
            this.labelUser.Text = "You";
            // 
            // labelEnemy
            // 
            this.labelEnemy.AutoSize = true;
            this.labelEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnemy.ForeColor = System.Drawing.Color.White;
            this.labelEnemy.Location = new System.Drawing.Point(775, 48);
            this.labelEnemy.Name = "labelEnemy";
            this.labelEnemy.Size = new System.Drawing.Size(78, 25);
            this.labelEnemy.TabIndex = 12;
            this.labelEnemy.Text = "Enemy";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(494, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 20);
            this.labelInfo.TabIndex = 14;
            // 
            // labelShotsEnemy
            // 
            this.labelShotsEnemy.AutoSize = true;
            this.labelShotsEnemy.ForeColor = System.Drawing.Color.White;
            this.labelShotsEnemy.Location = new System.Drawing.Point(565, 598);
            this.labelShotsEnemy.Name = "labelShotsEnemy";
            this.labelShotsEnemy.Size = new System.Drawing.Size(71, 13);
            this.labelShotsEnemy.TabIndex = 16;
            this.labelShotsEnemy.Text = "Total shots: 0";
            // 
            // labelShots
            // 
            this.labelShots.AutoSize = true;
            this.labelShots.ForeColor = System.Drawing.Color.White;
            this.labelShots.Location = new System.Drawing.Point(30, 598);
            this.labelShots.Name = "labelShots";
            this.labelShots.Size = new System.Drawing.Size(71, 13);
            this.labelShots.TabIndex = 15;
            this.labelShots.Text = "Total shots: 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(545, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(8, 546);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnShowRules
            // 
            this.btnShowRules.BackColor = System.Drawing.Color.DimGray;
            this.btnShowRules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowRules.ForeColor = System.Drawing.Color.White;
            this.btnShowRules.Image = global::SchiffeVersenken.Properties.Resources.Warning__WF_32;
            this.btnShowRules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowRules.Location = new System.Drawing.Point(970, 656);
            this.btnShowRules.Name = "btnShowRules";
            this.btnShowRules.Size = new System.Drawing.Size(98, 34);
            this.btnShowRules.TabIndex = 4;
            this.btnShowRules.Text = "Rules";
            this.btnShowRules.UseVisualStyleBackColor = false;
            this.btnShowRules.Click += new System.EventHandler(this.btnShowRules_Click);
            // 
            // btnOpenChat
            // 
            this.btnOpenChat.BackColor = System.Drawing.Color.DimGray;
            this.btnOpenChat.Enabled = false;
            this.btnOpenChat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenChat.ForeColor = System.Drawing.Color.White;
            this.btnOpenChat.Image = global::SchiffeVersenken.Properties.Resources.Chat___03;
            this.btnOpenChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenChat.Location = new System.Drawing.Point(852, 656);
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new System.Drawing.Size(98, 34);
            this.btnOpenChat.TabIndex = 3;
            this.btnOpenChat.Text = "Chat";
            this.btnOpenChat.UseVisualStyleBackColor = false;
            this.btnOpenChat.Click += new System.EventHandler(this.btnOpenChat_Click);
            // 
            // pbFieldEnemy
            // 
            this.pbFieldEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFieldEnemy.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbFieldEnemy.Location = new System.Drawing.Point(568, 94);
            this.pbFieldEnemy.Name = "pbFieldEnemy";
            this.pbFieldEnemy.Size = new System.Drawing.Size(500, 500);
            this.pbFieldEnemy.TabIndex = 2;
            this.pbFieldEnemy.TabStop = false;
            this.pbFieldEnemy.Click += new System.EventHandler(this.pbFieldEnemy_Click);
            // 
            // pbFieldPlayer
            // 
            this.pbFieldPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFieldPlayer.Location = new System.Drawing.Point(30, 94);
            this.pbFieldPlayer.Name = "pbFieldPlayer";
            this.pbFieldPlayer.Size = new System.Drawing.Size(500, 500);
            this.pbFieldPlayer.TabIndex = 1;
            this.pbFieldPlayer.TabStop = false;
            this.pbFieldPlayer.Click += new System.EventHandler(this.pbFieldPlayer_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1098, 715);
            this.Controls.Add(this.labelShotsEnemy);
            this.Controls.Add(this.labelShots);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelEnemy);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelShipsFounderedEnemy);
            this.Controls.Add(this.labelShipsAliveEnemy);
            this.Controls.Add(this.labelHitsEnemy);
            this.Controls.Add(this.labelShipsFoundered);
            this.Controls.Add(this.labelShipsAlive);
            this.Controls.Add(this.labelHits);
            this.Controls.Add(this.btnShowRules);
            this.Controls.Add(this.btnOpenChat);
            this.Controls.Add(this.pbFieldEnemy);
            this.Controls.Add(this.pbFieldPlayer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGame";
            this.Text = "Schiffe Versenken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.Load += new System.EventHandler(this.FormGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFieldEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFieldPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFieldPlayer;
        private System.Windows.Forms.PictureBox pbFieldEnemy;
        private System.Windows.Forms.Button btnOpenChat;
        private System.Windows.Forms.Button btnShowRules;
        private System.Windows.Forms.Label labelHits;
        private System.Windows.Forms.Label labelShipsAlive;
        private System.Windows.Forms.Label labelShipsFoundered;
        private System.Windows.Forms.Label labelShipsFounderedEnemy;
        private System.Windows.Forms.Label labelShipsAliveEnemy;
        private System.Windows.Forms.Label labelHitsEnemy;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelShotsEnemy;
        private System.Windows.Forms.Label labelShots;
        private System.Windows.Forms.Label labelInfo;
    }
}
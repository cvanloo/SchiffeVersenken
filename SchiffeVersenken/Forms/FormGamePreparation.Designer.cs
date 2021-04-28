namespace SchiffeVersenken.Forms
{
    partial class FormGamePreparation
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
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnShowShips = new System.Windows.Forms.Button();
            this.btnShowMines = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnReady = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.pbField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.DimGray;
            this.btnShowAll.Enabled = false;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(11, 518);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(55, 55);
            this.btnShowAll.TabIndex = 9;
            this.btnShowAll.Text = "All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Visible = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnShowShips
            // 
            this.btnShowShips.BackColor = System.Drawing.Color.DimGray;
            this.btnShowShips.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowShips.ForeColor = System.Drawing.Color.White;
            this.btnShowShips.Location = new System.Drawing.Point(72, 518);
            this.btnShowShips.Name = "btnShowShips";
            this.btnShowShips.Size = new System.Drawing.Size(55, 55);
            this.btnShowShips.TabIndex = 7;
            this.btnShowShips.Text = "Ships";
            this.btnShowShips.UseVisualStyleBackColor = false;
            this.btnShowShips.Visible = false;
            this.btnShowShips.Click += new System.EventHandler(this.btnShowShips_Click);
            // 
            // btnShowMines
            // 
            this.btnShowMines.BackColor = System.Drawing.Color.DimGray;
            this.btnShowMines.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowMines.ForeColor = System.Drawing.Color.White;
            this.btnShowMines.Location = new System.Drawing.Point(133, 518);
            this.btnShowMines.Name = "btnShowMines";
            this.btnShowMines.Size = new System.Drawing.Size(55, 55);
            this.btnShowMines.TabIndex = 8;
            this.btnShowMines.Text = "Mines";
            this.btnShowMines.UseVisualStyleBackColor = false;
            this.btnShowMines.Visible = false;
            this.btnShowMines.Click += new System.EventHandler(this.btnShowMines_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.DimGray;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Image = global::SchiffeVersenken.Properties.Resources.Help___01;
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(518, 46);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(141, 28);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.DimGray;
            this.btnChat.Enabled = false;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Image = global::SchiffeVersenken.Properties.Resources.Chat___03;
            this.btnChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.Location = new System.Drawing.Point(518, 420);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(141, 35);
            this.btnChat.TabIndex = 5;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = false;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.DimGray;
            this.btnReady.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReady.Enabled = false;
            this.btnReady.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.White;
            this.btnReady.Image = global::SchiffeVersenken.Properties.Resources.Submit_01;
            this.btnReady.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReady.Location = new System.Drawing.Point(518, 461);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(141, 51);
            this.btnReady.TabIndex = 4;
            this.btnReady.Text = "  Ready";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DimGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::SchiffeVersenken.Properties.Resources.Command_Reset;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(518, 114);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(141, 28);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.BackColor = System.Drawing.Color.DimGray;
            this.btnRandomize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRandomize.ForeColor = System.Drawing.Color.White;
            this.btnRandomize.Image = global::SchiffeVersenken.Properties.Resources.Shuffle_New;
            this.btnRandomize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandomize.Location = new System.Drawing.Point(518, 80);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(141, 28);
            this.btnRandomize.TabIndex = 2;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = false;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.Color.DimGray;
            this.btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRules.ForeColor = System.Drawing.Color.White;
            this.btnRules.Image = global::SchiffeVersenken.Properties.Resources.Warning__WF;
            this.btnRules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRules.Location = new System.Drawing.Point(518, 12);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(141, 28);
            this.btnRules.TabIndex = 1;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // pbField
            // 
            this.pbField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbField.Location = new System.Drawing.Point(12, 12);
            this.pbField.Name = "pbField";
            this.pbField.Size = new System.Drawing.Size(500, 500);
            this.pbField.TabIndex = 0;
            this.pbField.TabStop = false;
            this.pbField.Click += new System.EventHandler(this.pbField_Click);
            // 
            // FormGamePreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(665, 760);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnShowMines);
            this.Controls.Add(this.btnShowShips);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.pbField);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGamePreparation";
            this.Text = "Game Preparation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGamePreparation_FormClosing);
            this.Load += new System.EventHandler(this.FormGamePreparation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbField;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnShowShips;
        private System.Windows.Forms.Button btnShowMines;
        private System.Windows.Forms.Button btnHelp;
    }
}
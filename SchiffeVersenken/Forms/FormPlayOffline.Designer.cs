namespace SchiffeVersenken.Forms
{
    partial class FormPlayOffline
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnHard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select difficulty";
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.DimGray;
            this.btnHard.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnHard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHard.ForeColor = System.Drawing.Color.White;
            this.btnHard.Image = global::SchiffeVersenken.Properties.Resources.rank_3;
            this.btnHard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHard.Location = new System.Drawing.Point(133, 108);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(138, 23);
            this.btnHard.TabIndex = 3;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(133, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 1);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.DimGray;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = global::SchiffeVersenken.Properties.Resources.Exit_02_WF;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(133, 141);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(138, 23);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.DimGray;
            this.btnMedium.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMedium.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMedium.ForeColor = System.Drawing.Color.White;
            this.btnMedium.Image = global::SchiffeVersenken.Properties.Resources.rank_2;
            this.btnMedium.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedium.Location = new System.Drawing.Point(133, 79);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(138, 23);
            this.btnMedium.TabIndex = 2;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.DimGray;
            this.btnEasy.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEasy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEasy.ForeColor = System.Drawing.Color.White;
            this.btnEasy.Image = global::SchiffeVersenken.Properties.Resources.rank_1;
            this.btnEasy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEasy.Location = new System.Drawing.Point(133, 50);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(138, 23);
            this.btnEasy.TabIndex = 1;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // FormPlayOffline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(407, 189);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPlayOffline";
            this.Text = "Play Offline";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
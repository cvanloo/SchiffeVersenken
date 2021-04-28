namespace SchiffeVersenken.Forms
{
    partial class FormWin
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
            this.labelTitleText = new System.Windows.Forms.Label();
            this.labelWins = new System.Windows.Forms.Label();
            this.labelLoses = new System.Windows.Forms.Label();
            this.labelNumberOfLoses = new System.Windows.Forms.Label();
            this.labelNumberOfWins = new System.Windows.Forms.Label();
            this.labelGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitleText
            // 
            this.labelTitleText.AutoSize = true;
            this.labelTitleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleText.Location = new System.Drawing.Point(152, 9);
            this.labelTitleText.Name = "labelTitleText";
            this.labelTitleText.Size = new System.Drawing.Size(208, 55);
            this.labelTitleText.TabIndex = 0;
            this.labelTitleText.Text = "You win!";
            // 
            // labelWins
            // 
            this.labelWins.AutoSize = true;
            this.labelWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWins.Location = new System.Drawing.Point(38, 128);
            this.labelWins.Name = "labelWins";
            this.labelWins.Size = new System.Drawing.Size(115, 25);
            this.labelWins.TabIndex = 1;
            this.labelWins.Text = "Total wins:";
            // 
            // labelLoses
            // 
            this.labelLoses.AutoSize = true;
            this.labelLoses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoses.Location = new System.Drawing.Point(38, 182);
            this.labelLoses.Name = "labelLoses";
            this.labelLoses.Size = new System.Drawing.Size(123, 25);
            this.labelLoses.TabIndex = 2;
            this.labelLoses.Text = "Total loses:";
            // 
            // labelNumberOfLoses
            // 
            this.labelNumberOfLoses.AutoSize = true;
            this.labelNumberOfLoses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfLoses.Location = new System.Drawing.Point(371, 182);
            this.labelNumberOfLoses.Name = "labelNumberOfLoses";
            this.labelNumberOfLoses.Size = new System.Drawing.Size(36, 25);
            this.labelNumberOfLoses.TabIndex = 4;
            this.labelNumberOfLoses.Text = "#0";
            // 
            // labelNumberOfWins
            // 
            this.labelNumberOfWins.AutoSize = true;
            this.labelNumberOfWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfWins.Location = new System.Drawing.Point(371, 128);
            this.labelNumberOfWins.Name = "labelNumberOfWins";
            this.labelNumberOfWins.Size = new System.Drawing.Size(36, 25);
            this.labelNumberOfWins.TabIndex = 3;
            this.labelNumberOfWins.Text = "#0";
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGame.Location = new System.Drawing.Point(167, 64);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(172, 25);
            this.labelGame.TabIndex = 5;
            this.labelGame.Text = "Enemy 0 - 0 You";
            // 
            // FormWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(512, 227);
            this.Controls.Add(this.labelGame);
            this.Controls.Add(this.labelNumberOfLoses);
            this.Controls.Add(this.labelNumberOfWins);
            this.Controls.Add(this.labelLoses);
            this.Controls.Add(this.labelWins);
            this.Controls.Add(this.labelTitleText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Win";
            this.Load += new System.EventHandler(this.FormWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleText;
        private System.Windows.Forms.Label labelWins;
        private System.Windows.Forms.Label labelLoses;
        private System.Windows.Forms.Label labelNumberOfLoses;
        private System.Windows.Forms.Label labelNumberOfWins;
        private System.Windows.Forms.Label labelGame;
    }
}
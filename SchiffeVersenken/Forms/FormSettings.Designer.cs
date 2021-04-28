
namespace SchiffeVersenken.Forms
{
    partial class FormSettings
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
            this.cbMine = new System.Windows.Forms.CheckBox();
            this.nudMine = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudMine)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(141, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(98, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "- Settings -";
            // 
            // cbMine
            // 
            this.cbMine.AutoSize = true;
            this.cbMine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMine.ForeColor = System.Drawing.Color.White;
            this.cbMine.Location = new System.Drawing.Point(70, 79);
            this.cbMine.Name = "cbMine";
            this.cbMine.Size = new System.Drawing.Size(80, 28);
            this.cbMine.TabIndex = 1;
            this.cbMine.Text = "Mines";
            this.cbMine.UseVisualStyleBackColor = true;
            this.cbMine.CheckedChanged += new System.EventHandler(this.cbMine_CheckedChanged);
            // 
            // nudMine
            // 
            this.nudMine.Location = new System.Drawing.Point(199, 86);
            this.nudMine.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudMine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMine.Name = "nudMine";
            this.nudMine.Size = new System.Drawing.Size(64, 20);
            this.nudMine.TabIndex = 2;
            this.nudMine.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudMine.ValueChanged += new System.EventHandler(this.nudMine_ValueChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(364, 461);
            this.Controls.Add(this.nudMine);
            this.Controls.Add(this.cbMine);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            ((System.ComponentModel.ISupportInitialize)(this.nudMine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.CheckBox cbMine;
        private System.Windows.Forms.NumericUpDown nudMine;
    }
}
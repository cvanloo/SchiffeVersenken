namespace SchiffeVersenken.Forms
{
    partial class FormHelpDialogue
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
            this.rtbDialogue = new System.Windows.Forms.RichTextBox();
            this.cBMessage = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbDialogue
            // 
            this.rtbDialogue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.rtbDialogue.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDialogue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rtbDialogue.Location = new System.Drawing.Point(13, 13);
            this.rtbDialogue.Name = "rtbDialogue";
            this.rtbDialogue.ReadOnly = true;
            this.rtbDialogue.Size = new System.Drawing.Size(525, 176);
            this.rtbDialogue.TabIndex = 0;
            this.rtbDialogue.Text = "";
            // 
            // cBMessage
            // 
            this.cBMessage.AutoSize = true;
            this.cBMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBMessage.ForeColor = System.Drawing.Color.White;
            this.cBMessage.Location = new System.Drawing.Point(34, 198);
            this.cBMessage.Name = "cBMessage";
            this.cBMessage.Size = new System.Drawing.Size(93, 20);
            this.cBMessage.TabIndex = 1;
            this.cBMessage.Text = "checkBox1";
            this.cBMessage.UseVisualStyleBackColor = true;
            this.cBMessage.CheckStateChanged += new System.EventHandler(this.cBMessage_CheckStateChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DimGray;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::SchiffeVersenken.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(442, 232);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // FormHelpDialogue
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(550, 267);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cBMessage);
            this.Controls.Add(this.rtbDialogue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHelpDialogue";
            this.Text = "Help Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbDialogue;
        private System.Windows.Forms.CheckBox cBMessage;
        private System.Windows.Forms.Button btnClose;
    }
}
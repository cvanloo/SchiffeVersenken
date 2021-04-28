namespace SchiffeVersenken.Forms
{
    partial class FormChat
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
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.rtbWriteMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChat.ForeColor = System.Drawing.Color.White;
            this.rtbChat.Location = new System.Drawing.Point(13, 13);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(285, 466);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            this.rtbChat.TextChanged += new System.EventHandler(this.rtbChat_TextChanged);
            // 
            // rtbWriteMessage
            // 
            this.rtbWriteMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.rtbWriteMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbWriteMessage.ForeColor = System.Drawing.Color.White;
            this.rtbWriteMessage.Location = new System.Drawing.Point(13, 486);
            this.rtbWriteMessage.Name = "rtbWriteMessage";
            this.rtbWriteMessage.Size = new System.Drawing.Size(285, 40);
            this.rtbWriteMessage.TabIndex = 0;
            this.rtbWriteMessage.Text = "";
            this.rtbWriteMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbWriteMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DimGray;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(13, 532);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(285, 32);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send Message";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(310, 576);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbWriteMessage);
            this.Controls.Add(this.rtbChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormChat";
            this.Text = "Chat";
            this.Activated += new System.EventHandler(this.FormChat_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.RichTextBox rtbWriteMessage;
        private System.Windows.Forms.Button btnSend;
    }
}
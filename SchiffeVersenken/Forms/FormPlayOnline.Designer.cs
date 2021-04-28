namespace SchiffeVersenken.Forms
{
    partial class FormPlayOnline
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
            this.labelIP = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.ForeColor = System.Drawing.Color.White;
            this.labelIP.Location = new System.Drawing.Point(40, 28);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(73, 18);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "Enter IP:";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(119, 28);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(196, 20);
            this.tbIPAddress.TabIndex = 1;
            this.tbIPAddress.TextChanged += new System.EventHandler(this.tbIPAddress_TextChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(164, 97);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(28, 13);
            this.labelInfo.TabIndex = 5;
            this.labelInfo.Text = "Text";
            this.labelInfo.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.DimGray;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Image = global::SchiffeVersenken.Properties.Resources.Copy_01;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(321, 28);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(65, 20);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "     Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.DimGray;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = global::SchiffeVersenken.Properties.Resources.Exit_02_WF;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(12, 173);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(88, 23);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.DimGray;
            this.btnConnect.Enabled = false;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Image = global::SchiffeVersenken.Properties.Resources.Link___03;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(333, 173);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "  Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // FormPlayOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(433, 208);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.labelIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPlayOnline";
            this.Text = "Play Online";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlayOnline_FormClosing);
            this.Shown += new System.EventHandler(this.FormPlayOnline_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Button btnQuit;
        public System.Windows.Forms.Label labelInfo;
        public System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.Button btnCopy;
    }
}
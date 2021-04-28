using SchiffeVersenken.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SchiffeVersenken.Enums;
using SchiffeVersenken.Extensions;
using System;

namespace SchiffeVersenken.Forms
{
    public partial class FormChat : Form
    {
        /* Member/Fields */

        private Queue<ChatMessage> messages = new Queue<ChatMessage>();
        private EnemyNetwork enemy;

        /* Constructors */

        public FormChat(EnemyNetwork enemy)
        {
            InitializeComponent();

            this.enemy = enemy;

            UpdateChat();
        }

        /* Getter/Setter */

        public Queue<ChatMessage> Messages
        {
            get { return messages; }
        }

        /* Methods */

        /// <summary>
        /// Update the chat
        /// </summary>
        public void UpdateChat()
        {

            if (!this.IsHandleCreated) return;

            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateChat()));
            }
            else
            {
                while (messages.Count > 0)
                {
                    ChatMessage cm = messages.Dequeue();

                    switch (cm.Sender)
                    {
                        case SenderType.User:
                            rtbChat.AppendText(cm.Sender.ToString() + ": ", Color.LightBlue);
                            rtbChat.AppendText(cm.Message + "\n");
                            break;
                        case SenderType.Enemy:
                            rtbChat.AppendText(cm.Sender.ToString() + ": ", Color.Orange);
                            rtbChat.AppendText(cm.Message + "\n");
                            break;
                        case SenderType.Info:
                            rtbChat.AppendText(cm.Sender.ToString() + ": ", Color.Gray, 10f);
                            rtbChat.AppendText(cm.Message + "\n", 10f);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, System.EventArgs e)
        {
            rtbWriteMessage.Text = rtbWriteMessage.Text.Trim();

            if (rtbWriteMessage.Text.Length > 0)
            {
                ChatMessage cm = new ChatMessage(rtbWriteMessage.Text, SenderType.Enemy);
                enemy.SendMessage(cm);

                messages.Enqueue(new ChatMessage(rtbWriteMessage.Text, SenderType.User));

                rtbWriteMessage.Text = "";

                UpdateChat();
            }
        }

        /// <summary>
        /// Send message, if ENTER is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbWriteMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter is pressed
                btnSend_Click(sender, e);
            }
        }

        /// <summary>
        /// Occurs when the form is activated (when the form gets the focus)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChat_Activated(object sender, System.EventArgs e)
        {
            UpdateChat();
        }

        /// <summary>
        /// Occurs when the form is being closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dont close, just hide
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// Autoscroll to end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbChat_TextChanged(object sender, System.EventArgs e)
        {
            // Set cursor to end and scroll to cursor
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();
        }
    }
}

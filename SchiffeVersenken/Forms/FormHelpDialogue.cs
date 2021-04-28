using System;
using System.Windows.Forms;

namespace SchiffeVersenken.Forms
{
    public partial class FormHelpDialogue : Form
    {
        /* Member/Fields */

        private bool checkState = false;

        /* Constructors */

        public FormHelpDialogue(string message)
        {
            InitializeComponent();

            rtbDialogue.Text = message;

            // Hide checkbox and close-button, textbox fills whole window
            cBMessage.Visible = false;
            btnClose.Visible = false;
            rtbDialogue.Dock = DockStyle.Fill;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The message shown in the textbox</param>
        /// <param name="checkBoxMessage">The message shown besides the checkbox</param>
        public FormHelpDialogue(string message, string checkBoxMessage) : this(message)
        {
            cBMessage.Text = checkBoxMessage;

            // Show checkbox and close-button
            rtbDialogue.Dock = DockStyle.None;
            cBMessage.Visible = true;
            btnClose.Visible = true;
        }

        /* Getter/Setter */

        public bool CheckState
        {
            get { return checkState; }
        }

        /* Methods */

        /// <summary>
        /// Occurs when the checkbox was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBMessage_CheckStateChanged(object sender, EventArgs e)
        {
            checkState = ((CheckBox)sender).Checked;
        }
    }
}

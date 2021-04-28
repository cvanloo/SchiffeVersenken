using Newtonsoft.Json;
using SchiffeVersenken.Helpers;
using SchiffeVersenken.Models;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchiffeVersenken.Forms
{
    public partial class FormPlayOnline : Form
    {
        /* Member/Fields */

        private IPAddress ipAddress = null;
        private string userName;

        /* Constructors */

        public FormPlayOnline()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for Join
        /// </summary>
        /// <param name="userName">Name of the user</param>
        public FormPlayOnline(string userName) : this()
        {
            this.Text = "Join Game";
            this.userName = userName;

            btnCopy.Text = "     Paste";
            btnCopy.Click += btnPaste_Click;
        }

        /// <summary>
        /// Constructor for Host
        /// </summary>
        /// <param name="userName">Name of the player</param>
        /// <param name="ipAddress">Local IPv4 address of the user</param>
        public FormPlayOnline(string userName, IPAddress ipAddress) : this()
        {
            this.userName = userName;
            this.ipAddress = ipAddress;
            tbIPAddress.Text = ipAddress.ToString();
            tbIPAddress.Enabled = false;
            labelIP.Text = "Your IP:";
            btnConnect.Text = "Start";
            btnConnect.Enabled = false;
            this.Text = "Host Game";
            btnCopy.Click += btnCopy_Click;
        }

        /* Getter/Setter */

        public EnemyNetwork Network { get; private set; }

        /* Methods */

        /// <summary>
        /// If host, listen for incoming connections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FormPlayOnline_Shown(object sender, EventArgs e)
        {
            if (ipAddress != null)
            {
                /* Host */

                ChangeTextAndCenter.CenterTextIn(labelInfo, "Waiting for connection...");
                labelInfo.Visible = true;

                Network = new EnemyNetwork();

                /* The await keyword allows enemyNetwork.Host() to finish without
                 * blocking the UI-Thread.
                 */
                bool success = await Task.Run(() => Network.Host(ipAddress, userName));

                if (success)
                {
                    ChangeTextAndCenter.CenterTextIn(labelInfo, Network.Username + " connected. Press start.");
                    btnConnect.Enabled = true;
                }
                else
                {
                    this.Close();
                }
            }
            // Else: /* Join */ (Nothing to do here)
        }

        /// <summary>
        /// Check if a valid ip address was entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbIPAddress_TextChanged(object sender, EventArgs e)
        {
            // Pattern of an IPv4 address
            //string pattern = @"^([01]?[1-9]?[1-9]|2[0-4][0-9]|25[0-5])\.([01]?[1-9]?[1-9]|2[0-4][0-9]|25[0-5])\.([01]?[1-9]?[1-9]|2[0-4][0-9]|25[0-5])\.([01]?[1-9]?[1-9]|2[0-4][0-9]|25[0-5])$";
            string pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(tbIPAddress.Text) && this.Visible)
            {
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
            }
        }

        /// <summary>
        /// Connect to another player/Start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (ipAddress == null)
            {
                /* Join */

                // Connect
                ChangeTextAndCenter.CenterTextIn(labelInfo, "Connecting to host...");
                labelInfo.Visible = true;

                IPAddress remoteIP = IPAddress.Parse(tbIPAddress.Text);
                Network = new EnemyNetwork();

                /* The await keyword allows to wait for enemyNetwork.Join() to finish, without
                 * blocking the UI-Thread.
                 */
                bool success = false;
                await Task.Run(() => success = Network.Join(remoteIP, userName));

                if (success)
                {
                    btnConnect.Enabled = false;

                    ChangeTextAndCenter.CenterTextIn(labelInfo, "Waiting for " + Network.Username + " to start.");

                    // Wait until host starts the game
                    String start;
                    await Task.Run(() => start = JsonConvert.DeserializeObject<string>(Network.GetMessage()));

                    this.DialogResult = DialogResult.OK; // Because of the async threads, the DialogResult has to be set manually.
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel; // Because of the async threads, the DialogResult has to be set manually.
                }

                this.Close();
            }
            else
            {
                /* Host */

                // Send start message
                Network.SendMessage("start");
                this.DialogResult = DialogResult.OK; // Because of the async threads, the DialogResult has to be set manually.
                this.Close();
            }
        }

        /// <summary>
        /// Occurs when the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPlayOnline_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                // Clean-up
                if (Network != null)
                {
                    Network.StopListener();
                }
            }

            LogOutput.Output("Finished clean-up - closing now.", LogOutput.LogType.Info);
        }

        private async void btnCopy_Click(object sender, EventArgs args)
        {
            Clipboard.SetText(tbIPAddress.Text);
            btnCopy.BackColor = System.Drawing.Color.Green;

            await Task.Run(() => Thread.Sleep(200));
            btnCopy.BackColor = System.Drawing.Color.DimGray;
        }

        private void btnPaste_Click(object sender, EventArgs args)
        {
            tbIPAddress.Text = Clipboard.GetText();
        }
    }
}

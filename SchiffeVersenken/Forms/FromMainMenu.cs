using SchiffeVersenken.Models;
using SchiffeVersenken.Enums;
using SchiffeVersenken.Forms;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SchiffeVersenken
{
    public partial class FormMainMenu : Form
    {
        /* Member/Fields */

        private string playerName;

        /* Constructors */

        public FormMainMenu()
        {
            InitializeComponent();
        }

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Gamemode Offline selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOffline_Click(object sender, EventArgs e)
        {
            using (FormPlayOffline fpo = new FormPlayOffline())
            {
                this.Hide();

                if (DialogResult.OK == fpo.ShowDialog())
                {
                    ComputerDifficulty difficulty = fpo.Difficulty;
                    EnemyComputer enemy = new EnemyComputer(difficulty, 50);
                    Player user = new Player(playerName);

                    FormGamePreparation formGamePreparation = new FormGamePreparation(this, GameMode.Offline, user, enemy);
                    formGamePreparation.Show();
                }
                else
                {
                    this.Show();
                }
            }
        }

        /// <summary>
        /// Gamemode Join selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            using (FormPlayOnline fpo = new FormPlayOnline(playerName))
            {
                this.Hide();

                if (DialogResult.OK == fpo.ShowDialog())
                {
                    EnemyNetwork enemy = fpo.Network;

                    // Receive Settings from enemy
                    Properties.Settings.Default.s_Mine = JsonConvert.DeserializeObject<bool>(enemy.GetMessage());
                    Properties.Settings.Default.s_MineNum = JsonConvert.DeserializeObject<int>(enemy.GetMessage());

                    Player user = new Player(playerName);
                    FormGamePreparation formGamePreparation = new FormGamePreparation(this, GameMode.Join, user, enemy);
                    formGamePreparation.Show();
                }
                else
                {
                    this.Show();
                }
            }
        }

        /// <summary>
        /// Gamemode Host selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHost_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = null;
            try
            {
                ipAddress = GetLocalIPAddress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (FormPlayOnline fpo = new FormPlayOnline(playerName, ipAddress))
            {
                this.Hide();

                if (DialogResult.OK == fpo.ShowDialog())
                {
                    EnemyNetwork enemy = fpo.Network;

                    // Send settings to enemy
                    enemy.SendMessage(Properties.Settings.Default.s_Mine);
                    enemy.SendMessage(Properties.Settings.Default.s_MineNum);

                    Player user = new Player(playerName);
                    FormGamePreparation formGamePreparation = new FormGamePreparation(this, GameMode.Host, user, enemy);
                    formGamePreparation.Show();
                }
                else
                {
                    this.Show();
                }
            }
        }

        /// <summary>
        /// Get local IPv4 address
        /// </summary>
        /// <returns>Local IPv4 address</returns>
        private IPAddress GetLocalIPAddress()
        {
            // Check if connected to a network
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Search for local IPv4 address
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip;
                    }
                }
            }
            throw new Exception("No network adapters with a local IPv4 address found.");
        }

        /// <summary>
        /// Check if playername matches regex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void tbPlayerName_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[0-9A-Za-z]{1,20}$"; // Match 1 to 20 occurences of a number or character
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(tbPlayerName.Text))
            {
                // Regex matches, set playername
                playerName = tbPlayerName.Text;
                btnOffline.Enabled = true;
                btnJoin.Enabled = true;
                btnHost.Enabled = true;
            }
            else
            {
                btnOffline.Enabled = false;
                btnJoin.Enabled = false;
                btnHost.Enabled = false;
            }
        }

        /// <summary>
        /// Show statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            using (FormStatistics formStatistics = new FormStatistics())
            {
                formStatistics.ShowDialog();
            }
        }

        /// <summary>
        /// Show settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings formSettings = new FormSettings())
            {                
                formSettings.ShowDialog();
            }
        }

        /// <summary>
        /// Reset settings to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnResetSettings_Click(object sender, EventArgs e)
        {
            if ("Click again" != btnResetSettings.Text)
            {
                btnResetSettings.Text = "Click again";
                btnResetSettings.BackColor = System.Drawing.Color.FromArgb(252, 71, 35);
                return;
            }

            Properties.Settings.Default.Reset(); // Is automatically saved, no need to call Settings.Default.Save()
            
            btnResetSettings.Text = "Reseted!";
            btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            btnResetSettings.Enabled = false;

            await Task.Run(() => Thread.Sleep(1000));
            btnResetSettings.Text = "     Reset Settings";
            btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            btnResetSettings.Enabled = true;
        }

        /// <summary>
        /// Reset the Reset Settings-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMainMenu_Click(object sender, EventArgs e)
        {
            btnResetSettings.Text = "     Reset Settings";
            btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            btnResetSettings.Enabled = true;
        }
    }
}

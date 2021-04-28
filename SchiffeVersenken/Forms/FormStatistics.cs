using SchiffeVersenken.Properties;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchiffeVersenken.Forms
{
    public partial class FormStatistics : Form
    {
        /* Member/Fields */

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        public FormStatistics()
        {
            InitializeComponent();
        }

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Occurs when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStatistics_Load(object sender, EventArgs e)
        {
            InitializeSettings();
        }

        /// <summary>
        /// Initialze form with correct values
        /// </summary>
        private void InitializeSettings()
        {
            labelGamesPlayedCount.Text = Settings.Default.GamesPlayed.ToString();
            labelWinsCount.Text = Settings.Default.Wins.ToString();
            labelLosesCount.Text = Settings.Default.Loses.ToString();

            string text = "n/a";
            if (Settings.Default.FastestWin != -1) text = Settings.Default.FastestWin.ToString();
            labelFastestWinCount.Text = text;

            text = "n/a";
            if (Settings.Default.FastestLost != -1) text = Settings.Default.FastestLost.ToString();
            labelFastestLoseCount.Text = text;

            text = "n/a";
            if (Settings.Default.BestWin != -1) text = Settings.Default.BestWin.ToString() + " - 10";
            labelBestWinCount.Text = text;

            text = "n/a";
            if (Settings.Default.WorstLose != -1) text = "10 - " + Settings.Default.WorstLose.ToString();
            labelWorstLoseCount.Text = text;
        }

        /// <summary>
        /// Reset settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnResetSettings_Click(object sender, EventArgs e)
        {
            if (btnResetSettings.Text != "     Click again to confirm")
            {
                btnResetSettings.Text = "     Click again to confirm";
                btnResetSettings.BackColor = System.Drawing.Color.FromArgb(252, 71, 35);
                return;
            }

            Settings.Default.Reset(); // Is automatically saved, no need to call Settings.Default.Save()
            InitializeSettings();

            btnResetSettings.Text = "Reseted!";
            btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            btnResetSettings.Enabled = false;

            // Reset button to default colors and text after 1 second
            await Task.Run(() => Thread.Sleep(1000));
            btnResetSettings.Text = "Reset Settings";
            btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            btnResetSettings.Enabled = true;
        }

        private void FormStatistics_Click(object sender, EventArgs e)
        {
            btnResetSettings.Text = "Reset Settings";
            btnResetSettings.BackColor = System.Drawing.Color.DimGray;
            btnResetSettings.Enabled = true;
        }
    }
}

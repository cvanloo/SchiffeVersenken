using SchiffeVersenken.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchiffeVersenken.Forms
{
    public partial class FormWin : Form
    {
        /* Member/Fields */

        /* Constructors */

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isWin">True if the user won</param>
        /// <param name="enemySunken">Number of enemy's sunken ships</param>
        /// <param name="userSunken">Number of user's sunken ships</param>
        public FormWin(bool isWin, int enemySunken, int userSunken)
        {
            InitializeComponent();

            if (isWin)
            {
                this.Text = "Win";
                this.labelTitleText.Text = "You win!";
                this.BackColor = Color.Goldenrod;
            }
            else
            {
                this.Text = "Lose";
                this.labelTitleText.Text = "You lose!";
                this.BackColor = Color.Red;
            }

            labelGame.Text = "Enemy " + userSunken + " - " + enemySunken + " You";
        }

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Load statistical information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormWin_Load(object sender, EventArgs e)
        {
            labelNumberOfWins.Text = Settings.Default.Wins.ToString();
            labelNumberOfLoses.Text = Settings.Default.Loses.ToString();
        }
    }
}

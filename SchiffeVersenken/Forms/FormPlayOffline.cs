using SchiffeVersenken.Enums;
using System;
using System.Windows.Forms;

namespace SchiffeVersenken.Forms
{
    public partial class FormPlayOffline : Form
    {
        /* Member/Fields */

        /* Constructors */

        public FormPlayOffline()
        {
            InitializeComponent();
        }

        /* Getter/Setter */

        public ComputerDifficulty Difficulty { get; private set; }

        /* Methods */

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Difficulty = ComputerDifficulty.Easy;
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Difficulty = ComputerDifficulty.Medium;
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Difficulty = ComputerDifficulty.Hard;
        }
    }
}

using System;
using System.Windows.Forms;
using SchiffeVersenken.Properties; 

namespace SchiffeVersenken.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings() 
        {
            InitializeComponent();

            cbMine.Checked = Settings.Default.s_Mine;
            nudMine.Value = Settings.Default.s_MineNum;
            nudMine.Enabled = Settings.Default.s_Mine;
        }

        private void cbMine_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.s_Mine = cbMine.Checked;
            Settings.Default.Save();
            nudMine.Enabled = cbMine.Checked;
        }

        private void nudMine_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.s_MineNum = (int)nudMine.Value;
            Settings.Default.Save();
        }
    }
}

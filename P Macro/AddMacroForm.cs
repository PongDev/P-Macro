using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Macro
{
    partial class AddMacroForm : Form
    {
        public bool[] keyboardState = new bool[256];
        public string Command = "";
        public bool hideCmd;

        public AddMacroForm()
        {
            InitializeComponent();
        }

        private void AddMacroForm_Shown(object sender, EventArgs e)
        {
            lbMacroKey.Text += " " + KeyboardState.KeyboardStateToText(keyboardState);
        }

        private void btnAddMacro_Click(object sender, EventArgs e)
        {
            Command = tbMacroCommand.Text;
            hideCmd = cbHideCmd.Checked;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openExeFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbMacroCommand.Text = openExeFileDialog.FileName;
            }
        }
    }
}

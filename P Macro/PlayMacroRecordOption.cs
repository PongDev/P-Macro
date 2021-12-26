using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Macro
{
    partial class PlayMacroRecordOption : Form
    {
        public KeyboardState.recordOptionClass option = new KeyboardState.recordOptionClass();

        public PlayMacroRecordOption(KeyboardState.recordOptionClass option)
        {
            this.option = option;
            InitializeComponent();
            tbDelayBeforeActivate.Text = Convert.ToString(this.option.delayBeforeActivate);
            tbLoopAmount.Text = Convert.ToString(this.option.loopAmount);
            lbBreakKey.Text = "Break Key: " + KeyboardState.KeyboardStateToText(this.option.breakKeyboardState);
            cbLoopUntilBreakKeyPress.Checked = this.option.isLoopUntilBreakKeyPress;
            bgWorkerKeyPress.RunWorkerAsync();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                option.delayBeforeActivate = Convert.ToInt32(tbDelayBeforeActivate.Text);
            }
            catch
            {
                MessageBox.Show("[Error] Invalid Delay Before Activate","Error");
                return;
            }
            if (cbLoopUntilBreakKeyPress.Checked)
            {
                if (!option.breakKeyboardState.Contains(true))
                {
                    MessageBox.Show("[Error] Break Key Not Set", "Error");
                    return;
                }
            }
            else
            {
                try
                {
                    option.loopAmount = Convert.ToInt32(tbLoopAmount.Text);
                }
                catch
                {
                    MessageBox.Show("[Error] Invalid Loop Amount", "Error");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbLoopUntilBreakKeyPress_CheckedChanged(object sender, EventArgs e)
        {
            option.isLoopUntilBreakKeyPress = cbLoopUntilBreakKeyPress.Checked;
            if (cbLoopUntilBreakKeyPress.Checked)
            {
                tbLoopAmount.Text = "";
                tbLoopAmount.Enabled = false;
                btnSetBreakKey.Enabled = true;
            }
            else
            {
                btnSetBreakKey.Enabled = false;
                for (int c = 0; c < 256; c++)
                    option.breakKeyboardState[c] = false;
                lbBreakKey.Text = "Break Key: ";
                tbLoopAmount.Text = "1";
                tbLoopAmount.Enabled = true;
            }
        }

        private void bgWorkerKeyPress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (cbLoopUntilBreakKeyPress.Checked)
                lbKeyPress.Text = "Key Press: " + KeyboardState.vkKeyboardStateToText();
            else
                lbKeyPress.Text = "Key Press: ";
        }

        private void bgWorkerKeyPress_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bgWorkerKeyPress.ReportProgress(0);
                Thread.Sleep(50);
            }
        }

        private void btnSetBreakKey_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < 256; c++)
                option.breakKeyboardState[c] = KeyboardState.getvkKeyboardState(c);
            lbBreakKey.Text = "Break Key: " + KeyboardState.KeyboardStateToText(option.breakKeyboardState);
        }
    }
}

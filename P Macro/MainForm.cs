using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Macro
{
    public partial class MainForm : Form
    {
        private List<KeyboardMacro> keyboardMacroList = new List<KeyboardMacro>();
        private bool updatelbKeyPress = true;
        private int listBoxMacroListPreviousIndex = -1;
        private bool run = true;

        public MainForm(string[] args)
        {
            InitializeComponent();
            this.Text += " " + SystemConfig.Version;
            KeyboardState.SetvkSkipKeyboardState(KeyboardState.vkSkipKeyboardState_Define.Mouse|KeyboardState.vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU|KeyboardState.vkSkipKeyboardState_Define.KEY255);
            KeyboardState.Init();
            KeyboardState.SetKeyboardStateCallback(KeyboardStateCallbackFunction);
            btnLoadMacro_Click(null,null);
            cbRunOnStartup.Checked = runOnStartup();
            if (args.Contains("-bg"))
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyboardState.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (run)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void KeyboardStateCallbackFunction()
        {
            string strKeyPress = "Key Press: " + KeyboardState.vkKeyboardStateToText();

            if (updatelbKeyPress)
            {
                if (lbKeyPress.InvokeRequired)
                    lbKeyPress.Invoke((MethodInvoker)delegate ()
                    {
                        lbKeyPress.Text = strKeyPress;
                    });
                else lbKeyPress.Text = strKeyPress;
            }

            foreach(KeyboardMacro macro in keyboardMacroList)
            {
                macro.updatevkKeyboardState();
                if (KeyboardState.isNovkKeyPress()&&macro.releasevkKeyboardState)
                    macro.executeCommand();
            }
        }

        private void btnAddMacro_Click(object sender, EventArgs e)
        {
            updatelbKeyPress = false;
            AddMacroForm addMacroForm = new AddMacroForm();

            for (int c = 0; c < 256; c++)
                addMacroForm.keyboardState[c] = KeyboardState.getvkKeyboardState(c);
            if (addMacroForm.ShowDialog() == DialogResult.OK)
            {
                keyboardMacroList.Add(new KeyboardMacro(addMacroForm.keyboardState,addMacroForm.Command,addMacroForm.hideCmd));
                updateListBoxMacroList();
            }
            addMacroForm.Dispose();
            updatelbKeyPress = true;
        }

        private void updateListBoxMacroList()
        {
            listBoxMacroList.Items.Clear();
            foreach(KeyboardMacro macro in keyboardMacroList)
                listBoxMacroList.Items.Add(KeyboardState.KeyboardStateToText(macro.vkKeyboardState));
        }

        private void listBoxMacroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMacroList.SelectedIndex == listBoxMacroListPreviousIndex)
            {
                clearMacroProperty();
                listBoxMacroList.SelectedIndex = -1;
            }
            else if (listBoxMacroList.SelectedIndex != -1)
            {
                cbMacroPropertyHideCmd.Checked = keyboardMacroList[listBoxMacroList.SelectedIndex].hideCmd;
                tbMacroPropertyCommand.Text = keyboardMacroList[listBoxMacroList.SelectedIndex].Command;
            }
            listBoxMacroListPreviousIndex = listBoxMacroList.SelectedIndex;
        }

        private void clearMacroProperty()
        {
            cbMacroPropertyHideCmd.Checked = false;
            tbMacroPropertyCommand.Text = "";
        }

        private void btnMacroPropertyUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxMacroList.SelectedIndex != -1)
            {
                keyboardMacroList[listBoxMacroList.SelectedIndex].hideCmd = cbMacroPropertyHideCmd.Checked;
                keyboardMacroList[listBoxMacroList.SelectedIndex].Command = tbMacroPropertyCommand.Text;
            }
        }

        private void btnMacroPropertyRemove_Click(object sender, EventArgs e)
        {
            if (listBoxMacroList.SelectedIndex != -1)
            {
                keyboardMacroList.RemoveAt(listBoxMacroList.SelectedIndex);
                listBoxMacroList.Items.RemoveAt(listBoxMacroList.SelectedIndex);
                clearMacroProperty();
            }
        }

        private void btnSaveMacro_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Open(SystemConfig.MacroSavePath, FileMode.Create);

            foreach(KeyboardMacro macro in keyboardMacroList)
            {
                byte[] bytearray = macro.ToByteArray();

                fs.Write(bytearray, 0, bytearray.Length);
            }
            fs.Close();
        }

        private void btnLoadMacro_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SystemConfig.MacroSavePath)) return;

            keyboardMacroList.Clear();
            byte[] bytearray = File.ReadAllBytes(SystemConfig.MacroSavePath);
            int index = 0;

            while (index < bytearray.Length)
            {
                int dataLength = BitConverter.ToInt32(bytearray,index);

                byte[] macrobytedata = new byte[4 + dataLength];

                Array.Copy(bytearray, index, macrobytedata, 0, 4 + dataLength);
                keyboardMacroList.Add(new KeyboardMacro(macrobytedata));
                index += 4 + dataLength;
            }
            updateListBoxMacroList();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run = false;
            this.Close();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }
        }

        private bool runOnStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            return ((string)rk.GetValue("P Macro") == ("\"" + Application.ExecutablePath + "\" " + SystemConfig.OnStartupArgs)) ? true : false;
        }

        private void runOnStartup(bool runOnStartup)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (runOnStartup)
            {
                rk.SetValue("P Macro", "\"" + Application.ExecutablePath + "\" " + SystemConfig.OnStartupArgs);
            }
            else
            {
                rk.DeleteValue("P Macro", false);
            }
        }

        private void cbRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                runOnStartup(true);
            else
                runOnStartup(false);
        }
    }
}

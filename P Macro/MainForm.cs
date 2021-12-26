using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Macro
{
    public partial class MainForm : Form
    {
        private List<KeyboardMacro> keyboardMacroList = new List<KeyboardMacro>();
        private List<KeyboardState.recordStateStruct> recordMacroList = new List<KeyboardState.recordStateStruct>();
        private bool updatelbKeyPress = true;
        private int listBoxMacroListPreviousIndex = -1;
        private int listBoxMacroRecordDataPreviousIndex = -1;
        private bool run = true;

        public MainForm(string[] args)
        {
            InitializeComponent();
            this.Text += " " + SystemConfig.Version;
            KeyboardState.SetvkSkipKeyboardState(KeyboardState.vkSkipKeyboardState_Define.Mouse | KeyboardState.vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU | KeyboardState.vkSkipKeyboardState_Define.KEY255);
            KeyboardState.Init();
            KeyboardState.SetKeyboardStateCallback(KeyboardStateCallbackFunction);
            btnLoadMacro_Click(null, null);
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

            foreach (KeyboardMacro macro in keyboardMacroList)
            {
                macro.updatevkKeyboardState();
                if (KeyboardState.isNovkKeyPress() && macro.releasevkKeyboardState)
                    macro.executeCommand();
            }
        }

        private void btnAddMacro_Click(object sender, EventArgs e)
        {
            updatelbKeyPress = false;
            AddMacroForm addMacroForm = new AddMacroForm();

            bool isKeydown = false, showAddMacroFormDialog = true;

            for (int c = 0; c < 256; c++)
            {
                addMacroForm.keyboardState[c] = KeyboardState.getvkKeyboardState(c);
                if (addMacroForm.keyboardState[c])
                    isKeydown = true;
            }
            if (!isKeydown)
            {
                DialogResult result = MessageBox.Show("[Warning] Add Macro To No Key Press?", "Warning", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    showAddMacroFormDialog = false;
            }
            if (showAddMacroFormDialog && addMacroForm.ShowDialog() == DialogResult.OK)
            {
                keyboardMacroList.Add(new KeyboardMacro(addMacroForm.keyboardState, addMacroForm.Command, addMacroForm.hideCmd));
                updateListBoxMacroList();
            }

            addMacroForm.Dispose();
            updatelbKeyPress = true;
        }

        private void updateListBoxMacroList()
        {
            listBoxMacroList.Items.Clear();
            foreach (KeyboardMacro macro in keyboardMacroList)
                listBoxMacroList.Items.Add(KeyboardState.KeyboardStateToText(macro.vkKeyboardState));
        }

        private void listBoxMacroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMacroList.SelectedIndex == listBoxMacroListPreviousIndex)
            {
                clearMacroProperty();
                cbMacroPropertyHideCmd.Enabled = false;
                tbMacroPropertyCommand.Enabled = false;
                btnMacroPropertyUpdate.Enabled = false;
                btnMacroPropertyRemove.Enabled = false;
                listBoxMacroList.SelectedIndex = -1;
            }
            else if (listBoxMacroList.SelectedIndex != -1)
            {
                cbMacroPropertyHideCmd.Enabled = true;
                tbMacroPropertyCommand.Enabled = true;
                btnMacroPropertyUpdate.Enabled = true;
                btnMacroPropertyRemove.Enabled = true;
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

            foreach (KeyboardMacro macro in keyboardMacroList)
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
                int dataLength = BitConverter.ToInt32(bytearray, index);

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

        List<string> macroRecordListTostringList(List<KeyboardState.recordStateStruct> list)
        {
            #region Record State Define
            const int RECORD_TYPE_DELAY = 0;
            const int RECORD_TYPE_KEYBOARD = 1;
            const int RECORD_TYPE_MOUSE = 2;

            const int RECORD_MODE_KEYDOWN = 0;
            const int RECORD_MODE_KEYUP = 1;

            const int RECORD_MODE_LKEYDOWN = 0;
            const int RECORD_MODE_LKEYUP = 1;
            const int RECORD_MODE_RKEYDOWN = 2;
            const int RECORD_MODE_RKEYUP = 3;
            const int RECORD_MODE_MOUSEMOVE = 4;
            const int RECORD_MODE_MOUSEWHEEL = 5;
            const int RECORD_MODE_MOUSEHWHEEL = 6;
            #endregion

            List<string> stringList = new List<string>();

            foreach (KeyboardState.recordStateStruct listdata in list)
            {
                string listdatastring = "";

                switch (listdata.type)
                {
                    case RECORD_TYPE_DELAY:
                        listdatastring = "Delay " + listdata.value;
                        break;
                    case RECORD_TYPE_KEYBOARD:
                        listdatastring = "Keyboard ";
                        switch (listdata.mode)
                        {
                            case RECORD_MODE_KEYDOWN:
                                listdatastring += (Keys)listdata.vkCode + " DOWN";
                                break;
                            case RECORD_MODE_KEYUP:
                                listdatastring += (Keys)listdata.vkCode + " UP";
                                break;
                        }
                        break;
                    case RECORD_TYPE_MOUSE:
                        listdatastring = "MOUSE ";
                        switch (listdata.mode)
                        {
                            case RECORD_MODE_LKEYDOWN:
                                listdatastring += "LKEYDOWN";
                                break;
                            case RECORD_MODE_LKEYUP:
                                listdatastring += "LKEYUP";
                                break;
                            case RECORD_MODE_RKEYDOWN:
                                listdatastring += "RKEYDOWN";
                                break;
                            case RECORD_MODE_RKEYUP:
                                listdatastring += "RKEYUP";
                                break;
                            case RECORD_MODE_MOUSEMOVE:
                                listdatastring += "MOVE X:" + listdata.x + " Y:" + listdata.y;
                                break;
                            case RECORD_MODE_MOUSEWHEEL:
                                listdatastring += "MOUSE WHEEL " + listdata.value;
                                break;
                            case RECORD_MODE_MOUSEHWHEEL:
                                listdatastring += "MOUSEHWHEEL " + listdata.value;
                                break;
                        }
                        break;
                }
                stringList.Add(listdatastring);
            }
            return stringList;
        }

        private void btnStartMacroRecord_Click(object sender, EventArgs e)
        {
            KeyboardState.resetRecord();
            listBoxMacroRecordData.Items.Clear();
            KeyboardState.startRecord();

            btnStartMacroRecord.Enabled = false;
            btnStopMacroRecord.Enabled = true;
        }

        private void btnStopMacroRecord_Click(object sender, EventArgs e)
        {
            KeyboardState.stopRecord();
            listBoxMacroRecordData.Items.Clear();
            recordMacroList = KeyboardState.getRecord();
            listBoxMacroRecordData.Items.AddRange(macroRecordListTostringList(recordMacroList).ToArray());

            btnStopMacroRecord.Enabled = false;
            btnStartMacroRecord.Enabled = true;
        }

        private void btnPlayMacroRecord_Click(object sender, EventArgs e)
        {
            Thread playMacroRecordThread = new Thread(() => KeyboardState.playMacroRecord(recordMacroList));

            playMacroRecordThread.Start();
        }

        private void listBoxMacroRecordData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMacroRecordData.SelectedIndex == listBoxMacroRecordDataPreviousIndex)
            {
                clearRecordMacroProperty();
                btnRemoveMacroRecordData.Enabled = false;
                listBoxMacroRecordData.SelectedIndex = -1;
            }
            else if (listBoxMacroRecordData.SelectedIndex != -1)
            {
                btnRemoveMacroRecordData.Enabled = true;
            }
            listBoxMacroRecordDataPreviousIndex = listBoxMacroRecordData.SelectedIndex;
        }

        private void clearRecordMacroProperty()
        {

        }

        private void btnRemoveMacroRecordData_Click(object sender, EventArgs e)
        {
            if (listBoxMacroRecordData.SelectedIndex != -1)
            {
                recordMacroList.RemoveAt(listBoxMacroRecordData.SelectedIndex);
                listBoxMacroRecordData.Items.RemoveAt(listBoxMacroRecordData.SelectedIndex);
                clearRecordMacroProperty();
            }
        }

        private void btnSaveRecordMacro_Click(object sender, EventArgs e)
        {

        }
    }
}

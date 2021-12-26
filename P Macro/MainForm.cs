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
        private List<KeyboardState.recordStateClass> recordMacroList = new List<KeyboardState.recordStateClass>();
        private KeyboardState.recordOptionClass recordOption = new KeyboardState.recordOptionClass();
        private bool updatelbKeyPress = true;
        private int listBoxMacroListPreviousIndex = -1;
        private int listBoxMacroRecordDataPreviousIndex = -1;
        private int listBoxMacroRecordListPreviousIndex = -1;
        private bool run = true;
        private KeyboardMacro playMacroRecordThreadBreakMacro;
        private Thread playMacroRecordThread;

        public MainForm(string[] args)
        {
            InitializeComponent();
            this.Text += " " + SystemConfig.Version;
            KeyboardState.SetvkSkipKeyboardState(KeyboardState.vkSkipKeyboardState_Define.Mouse | KeyboardState.vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU | KeyboardState.vkSkipKeyboardState_Define.KEY255);
            KeyboardState.Init();
            KeyboardState.SetKeyboardStateCallback(KeyboardStateCallbackFunction);
            bgWorkerUpdateMousePosition.RunWorkerAsync();
            btnLoadMacro_Click(null, null);
            btnLoadMacroRecordList_Click(null, null);
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

            if (recordOption.isLoopUntilBreakKeyPress && playMacroRecordThread != null && playMacroRecordThread.IsAlive && playMacroRecordThreadBreakMacro != null)
            {
                playMacroRecordThreadBreakMacro.updatevkKeyboardState();
                if (KeyboardState.isNovkKeyPress() && playMacroRecordThreadBreakMacro.releasevkKeyboardState)
                    playMacroRecordThread.Abort();
            }
        }

        private void btnAddMacro_Click(object sender, EventArgs e)
        {
            updatelbKeyPress = false;
            AddMacroForm addMacroForm = new AddMacroForm();

            bool isKeydown = false, showAddMacroFormDialog = true, isExist = false;

            for (int c = 0; c < 256; c++)
            {
                addMacroForm.keyboardState[c] = KeyboardState.getvkKeyboardState(c);
                if (addMacroForm.keyboardState[c])
                    isKeydown = true;
            }
            foreach (KeyboardMacro keyboardMacro in keyboardMacroList)
            {
                if (addMacroForm.keyboardState.SequenceEqual(keyboardMacro.vkKeyboardState))
                {
                    isExist = true;
                    MessageBox.Show("[Error] Shortcut Macro Exist", "Error");
                    break;
                }
            }
            if (!isExist && !isKeydown)
            {
                DialogResult result = MessageBox.Show("[Warning] Add Macro To No Key Press?", "Warning", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    showAddMacroFormDialog = false;
            }
            if (!isExist && showAddMacroFormDialog && addMacroForm.ShowDialog() == DialogResult.OK)
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
                cbMacroPropertyHideCmd.Enabled = false;
                tbMacroPropertyCommand.Enabled = false;
                btnMacroPropertyUpdate.Enabled = false;
                btnMacroPropertyRemove.Enabled = false;
            }
        }

        private void btnSaveMacro_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SystemConfig.MacroShortcutSavePath))
                Directory.CreateDirectory(SystemConfig.MacroShortcutSavePath);

            DirectoryInfo directoryInfo = new DirectoryInfo(SystemConfig.MacroShortcutSavePath);

            foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
                subDirectory.Delete(true);
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                fileInfo.Delete();

            foreach (KeyboardMacro macro in keyboardMacroList)
            {
                FileStream fs = File.Open(SystemConfig.MacroShortcutSavePath + KeyboardState.KeyboardStateToText(macro.vkKeyboardState) + SystemConfig.FileExt, FileMode.Create);
                byte[] bytearray = macro.ToByteArray();

                fs.Write(bytearray, 0, bytearray.Length);
                fs.Close();
            }
        }

        private void btnLoadMacro_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SystemConfig.MacroShortcutSavePath))
            {
                keyboardMacroList.Clear();
                updateListBoxMacroList();
                return;
            }

            keyboardMacroList.Clear();
            foreach (string saveFilePath in Directory.GetFiles(SystemConfig.MacroShortcutSavePath))
            {
                if (Path.GetExtension(saveFilePath) == SystemConfig.FileExt)
                {
                    byte[] bytearray = File.ReadAllBytes(saveFilePath);

                    try { keyboardMacroList.Add(new KeyboardMacro(bytearray)); }
                    catch { }
                }
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

        List<string> macroRecordListTostringList(List<KeyboardState.recordStateClass> list)
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
            const int RECORD_MODE_MBUTTONDOWN = 7;
            const int RECORD_MODE_MBUTTONUP = 8;
            #endregion

            List<string> stringList = new List<string>();

            foreach (KeyboardState.recordStateClass listdata in list)
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
                            case RECORD_MODE_MBUTTONDOWN:
                                listdatastring += "MIDDLEDOWN";
                                break;
                            case RECORD_MODE_MBUTTONUP:
                                listdatastring += "MIDDLEUP";
                                break;
                        }
                        break;
                }
                stringList.Add(listdatastring);
            }
            return stringList;
        }

        private void updateListBoxMacroRecordData()
        {
            listBoxMacroRecordData.Items.Clear();
            listBoxMacroRecordData.Items.AddRange(macroRecordListTostringList(recordMacroList).ToArray());
        }

        private void btnStartMacroRecord_Click(object sender, EventArgs e)
        {
            KeyboardState.resetRecord();
            listBoxMacroRecordData.Items.Clear();
            KeyboardState.configRecord(cbRecordKeyboard.Checked, cbRecordMouse.Checked);
            KeyboardState.startRecord();

            btnStartMacroRecord.Enabled = false;
            btnStopMacroRecord.Enabled = true;
        }

        private void btnStopMacroRecord_Click(object sender, EventArgs e)
        {
            KeyboardState.stopRecord();
            recordMacroList = KeyboardState.getRecord();
            updateListBoxMacroRecordData();

            btnStopMacroRecord.Enabled = false;
            btnStartMacroRecord.Enabled = true;
        }

        private void btnPlayMacroRecord_Click(object sender, EventArgs e)
        {
            //Thread playMacroRecordThread = new Thread(() => KeyboardState.playMacroRecord(recordMacroList));
            //Thread playMacroRecordThread = new Thread(() => KeyboardState.playMacroRecord(recordMacroList, recordOption));
            playMacroRecordThread = new Thread(() => KeyboardState.playMacroRecord(recordMacroList, recordOption));

            if (recordOption.isLoopUntilBreakKeyPress)
                playMacroRecordThreadBreakMacro = new KeyboardMacro(recordOption.breakKeyboardState, "", false);
            playMacroRecordThread.Start();
        }

        private void btnPlayMacroRecordOption_Click(object sender, EventArgs e)
        {
            PlayMacroRecordOption playMacroRecordOption = new PlayMacroRecordOption(recordOption);

            if (playMacroRecordOption.ShowDialog() == DialogResult.OK)
                recordOption = playMacroRecordOption.option;
            playMacroRecordOption.Dispose();
        }

        private void listBoxMacroRecordData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMacroRecordData.SelectedIndex == listBoxMacroRecordDataPreviousIndex)
            {
                setMacroRecordDataButtonEnabled(false);
                listBoxMacroRecordData.SelectedIndex = -1;
            }
            else if (listBoxMacroRecordData.SelectedIndex != -1)
            {
                setMacroRecordDataButtonEnabled(true);
            }
            listBoxMacroRecordDataPreviousIndex = listBoxMacroRecordData.SelectedIndex;
        }

        private void setMacroRecordDataButtonEnabled(bool enabledState)
        {
            btnEditMacroRecordData.Enabled = enabledState;
            btnRemoveMacroRecordData.Enabled = enabledState;
        }

        private void btnInsertMacroRecordData_Click(object sender, EventArgs e)
        {
            MacroRecordDataForm macroRecordData = new MacroRecordDataForm(new KeyboardState.recordStateClass());

            if (macroRecordData.ShowDialog() == DialogResult.OK)
            {
                int insertIndex = listBoxMacroRecordData.SelectedIndex + 1;

                recordMacroList.Insert(insertIndex, macroRecordData.recordData);
                updateListBoxMacroRecordData();
                listBoxMacroRecordData.SelectedIndex = insertIndex;
            }
            macroRecordData.Dispose();
        }

        private void btnEditMacroRecordData_Click(object sender, EventArgs e)
        {
            if (listBoxMacroRecordData.SelectedIndex != -1)
            {
                MacroRecordDataForm macroRecordData = new MacroRecordDataForm(recordMacroList[listBoxMacroRecordData.SelectedIndex]);

                if (macroRecordData.ShowDialog() == DialogResult.OK)
                {
                    recordMacroList[listBoxMacroRecordData.SelectedIndex] = macroRecordData.recordData;
                    updateListBoxMacroRecordData();
                }
                macroRecordData.Dispose();
            }
        }

        private void btnRemoveMacroRecordData_Click(object sender, EventArgs e)
        {
            if (listBoxMacroRecordData.SelectedIndex != -1)
            {
                int remSelectedIndex = listBoxMacroRecordData.SelectedIndex;

                recordMacroList.RemoveAt(listBoxMacroRecordData.SelectedIndex);
                listBoxMacroRecordData.Items.RemoveAt(listBoxMacroRecordData.SelectedIndex);

                if (remSelectedIndex < listBoxMacroRecordData.Items.Count)
                    listBoxMacroRecordData.SelectedIndex = remSelectedIndex;
                else
                    setMacroRecordDataButtonEnabled(false);
            }
        }

        private void btnSaveRecordMacro_Click(object sender, EventArgs e)
        {
            SaveRecordMacroForm saveRecordMacroForm = new SaveRecordMacroForm();

            if (saveRecordMacroForm.ShowDialog() == DialogResult.OK)
            {
                bool isSave = true;

                if (saveRecordMacroForm.saveName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    MessageBox.Show("[Error] Invalid File Name", "Error");
                    isSave = false;
                }
                if (isSave && !Directory.Exists(SystemConfig.MacroRecordSavePath))
                    Directory.CreateDirectory(SystemConfig.MacroRecordSavePath);
                if (isSave && File.Exists(SystemConfig.MacroRecordSavePath + saveRecordMacroForm.saveName + SystemConfig.FileExt))
                {
                    if (MessageBox.Show("File Name Exist, Overwrite?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        isSave = false;
                }
                if (isSave)
                {
                    FileStream fs = File.Open(SystemConfig.MacroRecordSavePath + saveRecordMacroForm.saveName + SystemConfig.FileExt, FileMode.Create);

                    {
                        byte[] bytearray = recordOption.ToByteArray();

                        fs.Write(bytearray, 0, bytearray.Length);
                    }
                    foreach (KeyboardState.recordStateClass data in recordMacroList)
                    {
                        byte[] bytearray = data.ToByteArray();

                        fs.Write(bytearray, 0, bytearray.Length);
                    }
                    fs.Close();
                    btnLoadMacroRecordList_Click(null, null);
                }
            }
            saveRecordMacroForm.Dispose();
        }

        private void btnRemoveRecordMacro_Click(object sender, EventArgs e)
        {
            if (listBoxMacroRecordList.SelectedIndex != -1)
            {
                if (!File.Exists(SystemConfig.MacroRecordSavePath + listBoxMacroRecordList.Items[listBoxMacroRecordList.SelectedIndex] + SystemConfig.FileExt))
                {
                    MessageBox.Show("[Warning] Record Not Found", "Warning");
                    listBoxMacroRecordList.Items.RemoveAt(listBoxMacroRecordList.SelectedIndex);
                    recordMacroList.Clear();
                    updateListBoxMacroRecordData();
                }
                else
                {
                    File.Delete(SystemConfig.MacroRecordSavePath + listBoxMacroRecordList.Items[listBoxMacroRecordList.SelectedIndex] + SystemConfig.FileExt);
                    listBoxMacroRecordList.Items.RemoveAt(listBoxMacroRecordList.SelectedIndex);
                }
                btnRemoveRecordMacro.Enabled = false;
            }
        }

        private void btnLoadMacroRecordList_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SystemConfig.MacroRecordSavePath))
            {
                listBoxMacroRecordList.Items.Clear();
                return;
            }

            listBoxMacroRecordList.Items.Clear();
            foreach (string saveFileName in Directory.GetFiles(SystemConfig.MacroRecordSavePath).Select(Path.GetFileNameWithoutExtension))
            {
                listBoxMacroRecordList.Items.Add(saveFileName);
            }
        }

        private void listBoxMacroRecordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMacroRecordList.SelectedIndex == listBoxMacroRecordListPreviousIndex)
            {
                btnRemoveRecordMacro.Enabled = false;
                listBoxMacroRecordList.SelectedIndex = -1;
            }
            else if (listBoxMacroRecordList.SelectedIndex != -1)
            {
                if (!File.Exists(SystemConfig.MacroRecordSavePath + listBoxMacroRecordList.Items[listBoxMacroRecordList.SelectedIndex] + SystemConfig.FileExt))
                {
                    MessageBox.Show("[Error] Record Not Found", "Error");
                    listBoxMacroRecordList.Items.RemoveAt(listBoxMacroRecordList.SelectedIndex);
                    recordMacroList.Clear();
                }
                else
                {
                    byte[] bytearray = File.ReadAllBytes(SystemConfig.MacroRecordSavePath + listBoxMacroRecordList.Items[listBoxMacroRecordList.SelectedIndex] + SystemConfig.FileExt);
                    int index = 0;

                    recordMacroList.Clear();
                    try
                    {
                        {
                            int dataSize = BitConverter.ToInt32(bytearray, index);
                            byte[] data = new byte[sizeof(int) + dataSize];

                            Array.Copy(bytearray, index, data, 0, data.Length);
                            recordOption.FromByteArray(data);
                            index += sizeof(int) + dataSize;
                        }
                        while (index < bytearray.Length)
                        {
                            int dataSize = BitConverter.ToInt32(bytearray, index);
                            byte[] data = new byte[sizeof(int) + dataSize];

                            Array.Copy(bytearray, index, data, 0, data.Length);
                            recordMacroList.Add(new KeyboardState.recordStateClass(data));
                            index += sizeof(int) + dataSize;
                        }
                        btnRemoveRecordMacro.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("[Error] Invalid Record", "Error");
                        recordMacroList.Clear();
                        File.Delete(SystemConfig.MacroRecordSavePath + listBoxMacroRecordList.Items[listBoxMacroRecordList.SelectedIndex] + SystemConfig.FileExt);
                        listBoxMacroRecordList.Items.RemoveAt(listBoxMacroRecordList.SelectedIndex);
                    }
                }
                updateListBoxMacroRecordData();
            }
            listBoxMacroRecordListPreviousIndex = listBoxMacroRecordList.SelectedIndex;
        }

        private void bgWorkerUpdateMousePosition_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbMousePositionX.Text = "X: " + Cursor.Position.X;
            lbMousePositionY.Text = "Y: " + Cursor.Position.Y;
        }

        private void bgWorkerUpdateMousePosition_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bgWorkerUpdateMousePosition.ReportProgress(0);
                Thread.Sleep(50);
            }
        }
    }
}

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
    public partial class MainForm : Form
    {
        private List<KeyboardMacro> macroList = new List<KeyboardMacro>();

        public MainForm()
        {
            InitializeComponent();
            this.Text += " Version: " + SystemConfig.Version;
            KeyboardStatus.SetHook();
            //KeyboardStatus.startUpdateKeyStateThread();
            KeyboardStatus.setKeyboardEventCallback(KeyboardCallbackFunc);
            if (!bgWorkerKeyPress.IsBusy)
                bgWorkerKeyPress.RunWorkerAsync();
            KeyboardMacro tmp = new KeyboardMacro();
            tmp.KeyboardState[65] = true;
            tmp.macroCommand = "help&pause";
            macroList.Add(tmp);
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyboardStatus.UnHook();
            //KeyboardStatus.stopUpdateKeyStateThread();
            if (bgWorkerKeyPress.IsBusy)
                bgWorkerKeyPress.CancelAsync();
        }

        private void bgWorkerKeyPress_DoWork(object sender, DoWorkEventArgs e)
        {
            while(!bgWorkerKeyPress.CancellationPending)
            {
                string KeyState="Key Press: ";

                KeyboardStatus.updateKeyState();
                for (int c=0; c<KeyboardStatus.vkKeyboard.Length; c++)
                {
                    if (KeyboardStatus.vkKeyboard[c])
                    {
                        if (KeyState.Length != 11) KeyState += " + ";
                        KeyState += (Keys)c;
                        KeyState += "[" + c.ToString() + "]";
                    }
                }
                bgWorkerKeyPress.ReportProgress(0,KeyState);
                Thread.Sleep(50);
            }
        }

        private void bgWorkerKeyPress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbKeyPress.Text = e.UserState.ToString();
        }

        private void KeyboardCallbackFunc()
        {
            foreach(KeyboardMacro macro in macroList)
            {
                if (macro.KeyboardState.SequenceEqual(KeyboardStatus.vkKeyboard))
                    System.Diagnostics.Process.Start("cmd.exe", "/c " + macro.macroCommand);
            }
        }
    }
}

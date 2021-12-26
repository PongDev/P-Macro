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
    public partial class MainForm : Form
    {
        private List<KeyboardMacro> keyboardMacroList = new List<KeyboardMacro>();

        public MainForm()
        {
            InitializeComponent();
            KeyboardState.SetvkSkipKeyboardState(KeyboardState.vkSkipKeyboardState_Define.Mouse|KeyboardState.vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU);
            KeyboardState.Init();
            KeyboardState.SetKeyboardStateCallback(KeyboardStateCallbackFunction);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyboardState.Exit();
        }

        private void KeyboardStateCallbackFunction()
        {
            string strKeyPress = "Key Press: ";

            for(int c=0; c<256; c++)
            {
                if (KeyboardState.getvkKeyboardState(c))
                {
                    if (strKeyPress.Length != 11)
                        strKeyPress += " + ";
                    strKeyPress += (Keys)c;
                }
            }
            if (lbKeyPress.InvokeRequired)
                lbKeyPress.Invoke((MethodInvoker)delegate ()
                {
                    lbKeyPress.Text = strKeyPress;
                });
            else lbKeyPress.Text = strKeyPress;

            foreach(KeyboardMacro macro in keyboardMacroList)
            {
                macro.updatevkKeyboardState();
                if (macro.previousvkKeyboardStateDown && macro.vkKeyboardStateDown == false)
                    macro.executeCommand();
            }
        }
    }
}

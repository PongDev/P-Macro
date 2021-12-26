using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Macro
{
    class KeyboardMacro
    {
        public bool[] vkKeyboardState = new bool[256];
        public bool previousvkKeyboardStateDown = false;
        public bool vkKeyboardStateDown = false;
        public bool[] scanKeyboardState = new bool[256];
        public string Command = "";

        public bool isvkKeyboardStateEqual()
        {
            bool Equal = true;

            for(int c=0; c<256; c++)
            {
                if (KeyboardState.getvkKeyboardState(c) != vkKeyboardState[c])
                {
                    Equal = false;
                    break;
                }
            }
            return Equal;
        }

        public void updatevkKeyboardState()
        {
            previousvkKeyboardStateDown = vkKeyboardStateDown;
            if (isvkKeyboardStateEqual())
                vkKeyboardStateDown = true;
            else
                vkKeyboardStateDown = false;
        }

        public void executeCommand()
        {
            Process.Start("cmd.exe", "/c " + Command);
        }
    }
}

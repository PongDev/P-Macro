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
        public bool releasevkKeyboardState = false;
        public bool lockreleasevkKeyboardState = true;
        public bool[] scanKeyboardState = new bool[256];
        public string Command = "";
        public bool hideCmd = false;

        public KeyboardMacro(bool[] vkKeyboardStateInput,string CommandInput,bool hideCmdInput)
        {
            for (int c = 0; c < 256; c++)
                vkKeyboardState[c] = vkKeyboardStateInput[c];
            Command = CommandInput;
            hideCmd = hideCmdInput;
        }

        public KeyboardMacro(byte[] bytearray)
        {
            FromByteArray(bytearray);
        }

        public bool isvkKeyboardStateEqual()
        {
            bool Equal = true;

            for(int c=0; c<256; c++)
            {
                if (KeyboardState.getvkKeyboardState(c) && !vkKeyboardState[c])
                    releasevkKeyboardState = false;
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
            {
                vkKeyboardStateDown = true;
                if (!lockreleasevkKeyboardState)
                {
                    releasevkKeyboardState = true;
                    lockreleasevkKeyboardState = true;
                }
            }
            else
            {
                vkKeyboardStateDown = false;
            }
            if (KeyboardState.isNovkKeyPress())
                lockreleasevkKeyboardState = false;
        }

        public void executeCommand()
        {
            releasevkKeyboardState = false;
            if (hideCmd)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c " + Command;
                process.StartInfo = startInfo;
                process.Start();
            }
            else
            {
                Process.Start("cmd.exe", "/c " + Command);
            }
        }

        public byte[] ToByteArray()
        {
            List<byte> bytelist = new List<byte>();

            for (int c = 0; c < 256; c++)
                bytelist.AddRange(BitConverter.GetBytes(vkKeyboardState[c]));
            bytelist.AddRange(BitConverter.GetBytes(previousvkKeyboardStateDown));
            bytelist.AddRange(BitConverter.GetBytes(vkKeyboardStateDown));
            bytelist.AddRange(BitConverter.GetBytes(releasevkKeyboardState));
            bytelist.AddRange(BitConverter.GetBytes(lockreleasevkKeyboardState));
            for (int c = 0; c < 256; c++)
                bytelist.AddRange(BitConverter.GetBytes(scanKeyboardState[c]));
            bytelist.AddRange(BitConverter.GetBytes(Encoding.Unicode.GetByteCount(Command)));
            bytelist.AddRange(Encoding.Unicode.GetBytes(Command));
            bytelist.AddRange(BitConverter.GetBytes(hideCmd));
            bytelist.InsertRange(0,BitConverter.GetBytes(bytelist.Count));
            return bytelist.ToArray();
        }

        public void FromByteArray(byte[] bytearray)
        {
            int index = 4, commandByteLen;

            for (int c = 0; c < 256; c++)
                vkKeyboardState[c] = BitConverter.ToBoolean(bytearray,index++);
            previousvkKeyboardStateDown = BitConverter.ToBoolean(bytearray, index++);
            vkKeyboardStateDown = BitConverter.ToBoolean(bytearray, index++);
            releasevkKeyboardState = BitConverter.ToBoolean(bytearray, index++);
            lockreleasevkKeyboardState = BitConverter.ToBoolean(bytearray, index++);
            for (int c = 0; c < 256; c++)
                scanKeyboardState[c] = BitConverter.ToBoolean(bytearray, index++);
            commandByteLen = BitConverter.ToInt32(bytearray, index);
            index += 4;
            Command = Encoding.Unicode.GetString(bytearray, index, commandByteLen);
            index += commandByteLen;
            hideCmd = BitConverter.ToBoolean(bytearray, index++);
        }
    }
}

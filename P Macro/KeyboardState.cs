using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_Macro
{
    class KeyboardState
    {
        #region Define
            #region idHook
            private const int WH_MSGFILTER = -1;
            private const int WH_JOURNALRECORD = 0;
            private const int WH_JOURNALPLAYBACK = 1;
            private const int WH_KEYBOARD = 2;
            private const int WH_GETMESSAGE = 3;
            private const int WH_CALLWNDPROC = 4;
            private const int WH_CBT = 5;
            private const int WH_SYSMSGFILTER = 6;
            private const int WH_MOUSE = 7;
            private const int WH_DEBUG = 9;
            private const int WH_SHELL = 10;
            private const int WH_FOREGROUNDIDLE = 11;
            private const int WH_CALLWNDPROCRET = 12;
            private const int WH_KEYBOARD_LL = 13;
            private const int WH_MOUSE_LL = 14;
            #endregion

            #region uMapType
            private const uint MAPVK_VK_TO_VSC = 0;
            private const uint MAPVK_VSC_TO_VK = 1;
            private const uint MAPVK_VK_TO_CHAR = 2;
            private const uint MAPVK_VSC_TO_VK_EX = 3;
        #endregion

            #region nCode
            private const int HC_ACTION = 0;
        #endregion

            #region Keyboard Input Notifications
            private const int WM_KEYDOWN = 0x0100;
            private const int WM_KEYUP = 0x0101;
            private const int WM_SYSKEYDDOWN = 0x0104;
            private const int WM_SYSKEYUP = 0x0105;
            #endregion
        #endregion

        #region DllImport
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hmod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern short GetAsyncKeyState(int vkey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        #endregion

        #region Delegate Function
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void KeyboardStateCallbackFunction();
        #endregion

        #region Variable Declaration
        private static bool workState = false;
        private static bool[] vkKeyboardState = new bool[256];
        private static bool[] vkSkipKeyboardState = new bool[256];
        private static bool[] scanKeyboardState = new bool[256];
        private static Thread KeyboardStateThreadHandle = new Thread(KeyboardStateThread);
        private static KeyboardStateCallbackFunction KeyboardStateCallback;
        #endregion

        #region Configuration
        private enum Configuration_Define
        {
            UPDATE_BY_GetAsyncKeyState,
            UPDATE_BY_HookKeyboardState
        }

        public enum vkSkipKeyboardState_Define
        {
            Reset = 0,
            Mouse = 1,
            LRSHIFTCONTROLMENU = 2
        }

        private static Configuration_Define Mode = Configuration_Define.UPDATE_BY_GetAsyncKeyState;
        private static int KeyboardStateThreadDelay = 50;
        #endregion

        #region Private Method Region
        private static void KeyboardStateThread()
        {
            while(workState)
            {
                if (Mode==Configuration_Define.UPDATE_BY_GetAsyncKeyState)
                {
                    updateKeyStateByGetAsyncKeyState();
                    KeyboardStateCallback?.Invoke();
                }
                Thread.Sleep(KeyboardStateThreadDelay);
            }
        }

        private static void updateKeyStateByGetAsyncKeyState()
        {
            for(int c=0; c<256; c++)
            {
                bool keyboardState = ((GetAsyncKeyState(c) & (1 << 15)) == (1 << 15));

                vkKeyboardState[c] = (vkSkipKeyboardState[c]?false:keyboardState);
                scanKeyboardState[MapVirtualKey((uint)c, MAPVK_VK_TO_VSC)] = keyboardState;
            }
        }
        #endregion

        #region Public Method Region
        public static void Init()
        {
            workState = true;
            KeyboardStateThreadHandle.Start();
        }

        public static void Exit()
        {
            workState = false;
            KeyboardStateThreadHandle.Abort();
        }

        public static void SetKeyboardStateCallback(KeyboardStateCallbackFunction CallbackFunction)
        {
            KeyboardStateCallback = CallbackFunction;
        }

        public static void SetvkSkipKeyboardState(vkSkipKeyboardState_Define key)
        {
            if (key == vkSkipKeyboardState_Define.Reset)
            {
                #region Reset
                for (int c = 0; c < 256; c++)
                    vkSkipKeyboardState[c] = false;
                #endregion
            }
            else
            {
                #region Skip Mouse
                if ((key&vkSkipKeyboardState_Define.Mouse)==vkSkipKeyboardState_Define.Mouse)
                {
                    vkSkipKeyboardState[0x01] = true;
                    vkSkipKeyboardState[0x02] = true;
                    vkSkipKeyboardState[0x04] = true;
                    vkSkipKeyboardState[0x05] = true;
                    vkSkipKeyboardState[0x06] = true;
                }
                #endregion

                #region Skip LRSHIFTCONTROLMENU
                if ((key&vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU)==vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU)
                {
                    vkSkipKeyboardState[0xA0] = true;
                    vkSkipKeyboardState[0xA1] = true;
                    vkSkipKeyboardState[0xA2] = true;
                    vkSkipKeyboardState[0xA3] = true;
                    vkSkipKeyboardState[0xA4] = true;
                    vkSkipKeyboardState[0xA5] = true;
                }
                #endregion
            }
        }

        public static bool getvkKeyboardState(int idx)
        {
            return vkKeyboardState[idx];
        }
        #endregion
    }
}

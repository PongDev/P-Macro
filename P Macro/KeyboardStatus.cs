using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_Macro
{
    class KeyboardStatus
    {
        #region Import Dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        #endregion

        #region Delegate Function
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void KeyboardEventCallback();
        #endregion

        #region Constant Variable
        private const int HC_ACTION = 0;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WH_KEYBOARD_LL = 13;
        private const int MAPVK_VK_TO_VSC = 0;
        private const int MAPVK_VSC_TO_VK = 1;
        #endregion

        private static LowLevelKeyboardProc proc = HookCallBack;
        private static KeyboardEventCallback keyboardEventCallback;
        private static bool[] vkKeyboardState = new bool[256];
        private static bool[] scanKeyboardState = new bool[256];
        private static IntPtr HookID = IntPtr.Zero;
        private static Thread updateKeyStateThreadControl = new Thread(updateKeyStateThread);
        private static int updateKeyStateThreadDelay = 100;
        private static bool[] SkipKey = new bool[256];

        static KeyboardStatus()
        {
            #region SkipKey Initialize
            SkipKey[1] = true;
            SkipKey[2] = true;
            SkipKey[3] = true;
            SkipKey[4] = true;
            SkipKey[5] = true;
            SkipKey[6] = true;
            SkipKey[16] = true;
            SkipKey[17] = true;
            SkipKey[18] = true;
            #endregion
        }

        public static void setKeyboardEventCallback(KeyboardEventCallback func)
        {
            keyboardEventCallback = (KeyboardEventCallback)func;
        }

        public static void SetHook()
        {
            HookID = SetWindowsHookEx(WH_KEYBOARD_LL, proc, IntPtr.Zero, 0);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(HookID);
        }

        private static IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            #region Template Code
            //int vkCode, scanCode;

            //if (nCode == HC_ACTION)
            //{
            //    vkCode = Marshal.ReadInt32(lParam);
            //    scanCode = Marshal.ReadInt32(lParam, sizeof(Int32));
            //    switch ((int)wParam)
            //    {
            //        case WM_KEYDOWN:
            //            vkKeyboardState[vkCode] = true;
            //            scanKeyboardState[scanCode] = true;
            //            break;
            //        case WM_KEYUP:
            //            vkKeyboardState[vkCode] = false;
            //            scanKeyboardState[scanCode] = false;
            //            break;
            //        case WM_SYSKEYDOWN:
            //            vkKeyboardState[vkCode] = true;
            //            scanKeyboardState[scanCode] = true;
            //            break;
            //        case WM_SYSKEYUP:
            //            vkKeyboardState[vkCode] = false;
            //            scanKeyboardState[scanCode] = false;
            //            break;
            //    }
            //}
            #endregion

            int vkCode, scanCode;

            if (nCode == HC_ACTION)
            {
                vkCode = Marshal.ReadInt32(lParam);
                scanCode = Marshal.ReadInt32(lParam, sizeof(Int32));
                switch ((int)wParam)
                {
                    case WM_KEYDOWN:
                        vkKeyboardState[vkCode] = true;
                        scanKeyboardState[scanCode] = true;
                        break;
                    case WM_KEYUP:
                        vkKeyboardState[vkCode] = false;
                        scanKeyboardState[scanCode] = false;
                        break;
                    case WM_SYSKEYDOWN:
                        vkKeyboardState[vkCode] = true;
                        scanKeyboardState[scanCode] = true;
                        break;
                    case WM_SYSKEYUP:
                        vkKeyboardState[vkCode] = false;
                        scanKeyboardState[scanCode] = false;
                        break;
                }
                keyboardEventCallback();
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public static void startUpdateKeyStateThread()
        {
            updateKeyStateThreadControl.Start();
        }

        public static void stopUpdateKeyStateThread()
        {
            updateKeyStateThreadControl.Abort();
        }

        private static void updateKeyStateThread()
        {
            while(true)
            {
                updateKeyState();
                Thread.Sleep(updateKeyStateThreadDelay);
            }
        }

        public static void updateKeyState()
        {
            return;
            for(int c=0; c<256; c++)
            {
                if (SkipKey[c]) continue;
                if ((GetAsyncKeyState(c) & (1 << 15))>0)
                {
                    vkKeyboardState[c] = true;
                    scanKeyboard[MapVirtualKey((uint)c,MAPVK_VK_TO_VSC)] = true;
                }
                else
                {
                    vkKeyboardState[c] = false;
                    scanKeyboard[MapVirtualKey((uint)c, MAPVK_VK_TO_VSC)] = false;
                }
            }
        }

        public static bool[] vkKeyboard
        {
            get
            {
                return vkKeyboardState;
            }
        }

        public static bool[] scanKeyboard
        {
            get
            {
                return scanKeyboardState;
            }
        }

        public static int updateDelay
        {
            get
            {
                return updateKeyStateThreadDelay;
            }
            set
            {
                if (value > 0)
                    updateKeyStateThreadDelay = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        #endregion

        #region Mouse Input Notifications
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_MOUSEHWHEEL = 0x020E;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        #endregion

        #region kbd_event dwFlags
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;
        #endregion

        #region mouse_event dwFlags
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_WHEEL = 0x0800;
        private const int MOUSEEVENTF_HWHEEL = 0x01000;
        private const int MOUSEEVENTF_XDOWN = 0x0080;
        private const int MOUSEEVENTF_XUP = 0x0100;
        #endregion

        #region Record State Define
        private const int RECORD_TYPE_DELAY = 0;
        private const int RECORD_TYPE_KEYBOARD = 1;
        private const int RECORD_TYPE_MOUSE = 2;

        private const int RECORD_MODE_KEYDOWN = 0;
        private const int RECORD_MODE_KEYUP = 1;

        private const int RECORD_MODE_LKEYDOWN = 0;
        private const int RECORD_MODE_LKEYUP = 1;
        private const int RECORD_MODE_RKEYDOWN = 2;
        private const int RECORD_MODE_RKEYUP = 3;
        private const int RECORD_MODE_MOUSEMOVE = 4;
        private const int RECORD_MODE_MOUSEWHEEL = 5;
        private const int RECORD_MODE_MOUSEHWHEEL = 6;
        #endregion
        #endregion

        #region Struct
        private struct POINT
        {
            public int x, y;
        }

        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        public struct recordStateStruct
        {
            public int type, x, y, value, mode;
            public uint vkCode, scanCode;
        }
        #endregion

        #region DllImport
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hmod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hmod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern short GetAsyncKeyState(int vkey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);
        #endregion

        #region Delegate Function
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void KeyboardStateCallbackFunction();
        #endregion

        #region Variable Declaration
        private static bool workState = false;
        private static bool[] vkKeyboardState = new bool[256];
        private static bool[] vkSkipKeyboardState = new bool[256];
        private static bool[] scanKeyboardState = new bool[256];
        private static Thread KeyboardStateThreadHandle = new Thread(KeyboardStateThread);
        private static KeyboardStateCallbackFunction KeyboardStateCallback;
        private static IntPtr KeyboardHookId = IntPtr.Zero;
        private static IntPtr MouseHookId = IntPtr.Zero;
        private static IntPtr RecordKeyboardHookId = IntPtr.Zero;
        private static IntPtr RecordMouseHookId = IntPtr.Zero;
        private static Stopwatch recordTimeStamp = new Stopwatch();
        private static List<recordStateStruct> recordState = new List<recordStateStruct>();
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
            LRSHIFTCONTROLMENU = 2,
            KEY255 = 4
        }

        private static Configuration_Define Mode = Configuration_Define.UPDATE_BY_GetAsyncKeyState;
        private static int KeyboardStateThreadDelay = 50;
        #endregion

        #region Private Method Region
        private static void KeyboardStateThread()
        {
            while (workState)
            {
                if (Mode == Configuration_Define.UPDATE_BY_GetAsyncKeyState)
                {
                    updateKeyStateByGetAsyncKeyState();
                    KeyboardStateCallback?.Invoke();
                }
                Thread.Sleep(KeyboardStateThreadDelay);
            }
        }

        private static void updateKeyStateByGetAsyncKeyState()
        {
            for (int c = 0; c < 256; c++)
            {
                bool keyboardState = ((GetAsyncKeyState(c) & (1 << 15)) == (1 << 15));

                vkKeyboardState[c] = (vkSkipKeyboardState[c] ? false : keyboardState);
                scanKeyboardState[MapVirtualKey((uint)c, MAPVK_VK_TO_VSC)] = keyboardState;
            }
        }
        #region Record
        private static IntPtr RecordKeyboardHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                recordStateStruct recordData;
                KBDLLHOOKSTRUCT keyboardHookData = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

                recordData = new recordStateStruct();
                recordData.type = RECORD_TYPE_DELAY;
                recordData.value = (int)recordTimeStamp.ElapsedMilliseconds;
                recordState.Add(recordData);
                recordTimeStamp.Restart();

                recordData = new recordStateStruct();
                recordData.type = RECORD_TYPE_KEYBOARD;
                switch ((int)wParam)
                {
                    case WM_KEYDOWN:
                        recordData.mode = RECORD_MODE_KEYDOWN;
                        break;
                    case WM_KEYUP:
                        recordData.mode = RECORD_MODE_KEYUP;
                        break;
                    case WM_SYSKEYDOWN:
                        recordData.mode = RECORD_MODE_KEYDOWN;
                        break;
                    case WM_SYSKEYUP:
                        recordData.mode = RECORD_MODE_KEYUP;
                        break;
                }
                recordData.vkCode = keyboardHookData.vkCode;
                recordData.scanCode = keyboardHookData.scanCode;
                recordState.Add(recordData);
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr RecordMouseHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                recordStateStruct recordData;
                MSLLHOOKSTRUCT mouseHookData = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                recordData = new recordStateStruct();
                recordData.type = RECORD_TYPE_DELAY;
                recordData.value = (int)recordTimeStamp.ElapsedMilliseconds;
                recordState.Add(recordData);
                recordTimeStamp.Restart();

                recordData = new recordStateStruct();
                recordData.type = RECORD_TYPE_MOUSE;
                switch ((int)wParam)
                {
                    case WM_LBUTTONDOWN:
                        recordData.mode = RECORD_MODE_LKEYDOWN;
                        break;
                    case WM_LBUTTONUP:
                        recordData.mode = RECORD_MODE_LKEYUP;
                        break;
                    case WM_RBUTTONDOWN:
                        recordData.mode = RECORD_MODE_RKEYDOWN;
                        break;
                    case WM_RBUTTONUP:
                        recordData.mode = RECORD_MODE_RKEYUP;
                        break;
                    case WM_MOUSEMOVE:
                        recordData.mode = RECORD_MODE_MOUSEMOVE;
                        recordData.x = mouseHookData.pt.x;
                        recordData.y = mouseHookData.pt.y;
                        break;
                    case WM_MOUSEWHEEL:
                        recordData.mode = RECORD_MODE_MOUSEWHEEL;
                        recordData.value = (int)(mouseHookData.mouseData >> 16);
                        break;
                    case WM_MOUSEHWHEEL:
                        recordData.mode = RECORD_MODE_MOUSEHWHEEL;
                        recordData.value = (int)(mouseHookData.mouseData >> 16);
                        break;
                }
                recordState.Add(recordData);
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        #endregion
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
                if ((key & vkSkipKeyboardState_Define.Mouse) == vkSkipKeyboardState_Define.Mouse)
                {
                    vkSkipKeyboardState[0x01] = true;
                    vkSkipKeyboardState[0x02] = true;
                    vkSkipKeyboardState[0x04] = true;
                    vkSkipKeyboardState[0x05] = true;
                    vkSkipKeyboardState[0x06] = true;
                }
                #endregion

                #region Skip LRSHIFTCONTROLMENU
                if ((key & vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU) == vkSkipKeyboardState_Define.LRSHIFTCONTROLMENU)
                {
                    vkSkipKeyboardState[0xA0] = true;
                    vkSkipKeyboardState[0xA1] = true;
                    vkSkipKeyboardState[0xA2] = true;
                    vkSkipKeyboardState[0xA3] = true;
                    vkSkipKeyboardState[0xA4] = true;
                    vkSkipKeyboardState[0xA5] = true;
                }
                #endregion

                #region Skip KEY255
                if ((key & vkSkipKeyboardState_Define.KEY255) == vkSkipKeyboardState_Define.KEY255)
                {
                    vkSkipKeyboardState[0xFF] = true;
                }
                #endregion
            }
        }

        public static bool getvkKeyboardState(int idx)
        {
            return vkKeyboardState[idx];
        }

        public static string KeyboardStateToText(bool[] keyboardState)
        {
            string strKeyboardState = "";

            for (int c = 0; c < 256; c++)
            {
                if (keyboardState[c])
                {
                    if (strKeyboardState.Length != 0)
                        strKeyboardState += " + ";
                    strKeyboardState += (Keys)c;
                }
            }
            return strKeyboardState;
        }

        public static string vkKeyboardStateToText()
        {
            return KeyboardStateToText(vkKeyboardState);
        }

        public static bool isNovkKeyPress()
        {
            bool noKeyPress = true;

            for (int c = 0; c < 256; c++)
            {
                if (vkKeyboardState[c])
                {
                    noKeyPress = false;
                    break;
                }
            }
            return noKeyPress;
        }

        #region Keyboard Hook Template
        //public static IntPtr KeyboardHookFunction(int nCode, IntPtr wParam, IntPtr lParam)
        //{
        //    if (nCode >= 0)
        //    {
        //        switch((int)wParam)
        //        {
        //            case WM_KEYDOWN:
        //                break;
        //            case WM_KEYUP:
        //                break;
        //            case WM_SYSKEYDOWN:
        //                break;
        //            case WM_SYSKEYUP:
        //                break;
        //        }
        //    }
        //    return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        //}
        #endregion

        #region Mouse Hook Template
        //public static IntPtr MouseHookFunction(int nCode, IntPtr wParam, IntPtr lParam)
        //{
        //    if (nCode >= 0)
        //    {
        //        MSLLHOOKSTRUCT mouseHookData = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

        //        switch ((int)wParam)
        //        {
        //            case WM_LBUTTONDOWN:
        //                break;
        //            case WM_LBUTTONUP:
        //                break;
        //            case WM_RBUTTONDOWN:
        //                break;
        //            case WM_RBUTTONUP:
        //                break;
        //            case WM_MOUSEMOVE:
        //                break;
        //            case WM_MOUSEWHEEL:
        //                break;
        //            case WM_MOUSEHWHEEL:
        //                break;
        //        }
        //    }
        //    return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        //}
        #endregion

        public static void SetKeyboardHook(LowLevelKeyboardProc hookFunc)
        {
            KeyboardHookId = SetWindowsHookEx(WH_KEYBOARD_LL, hookFunc, IntPtr.Zero, 0);
        }

        public static void UnhookKeyboardHook()
        {
            if (KeyboardHookId != IntPtr.Zero)
                UnhookWindowsHookEx(KeyboardHookId);
        }

        public static void SetMouseHook(LowLevelMouseProc hookFunc)
        {
            MouseHookId = SetWindowsHookEx(WH_MOUSE_LL, hookFunc, IntPtr.Zero, 0);
        }

        public static void UnhookMouseHook()
        {
            if (MouseHookId != IntPtr.Zero)
                UnhookWindowsHookEx(MouseHookId);

        }

        #region Record
        public static void resetRecord()
        {
            recordTimeStamp.Reset();
            recordState.Clear();
        }

        public static void startRecord()
        {
            stopRecord();
            recordTimeStamp.Start();
            RecordKeyboardHookId = SetWindowsHookEx(WH_KEYBOARD_LL, (LowLevelKeyboardProc)RecordKeyboardHook, IntPtr.Zero, 0);
            RecordMouseHookId = SetWindowsHookEx(WH_MOUSE_LL, (LowLevelMouseProc)RecordMouseHook, IntPtr.Zero, 0);
        }

        public static void stopRecord()
        {
            UnhookWindowsHookEx(RecordKeyboardHookId);
            UnhookWindowsHookEx(RecordMouseHookId);
            recordTimeStamp.Stop();
        }

        public static List<recordStateStruct> getRecord()
        {
            return recordState;
        }

        public static void playMacroRecord(List<recordStateStruct> recordList)
        {
            foreach (recordStateStruct recordData in recordList)
            {
                uint dwFlags = 0;

                switch(recordData.type)
                {
                    case RECORD_TYPE_DELAY:
                        Thread.Sleep(recordData.value);
                        break;
                    case RECORD_TYPE_KEYBOARD:
                        switch(recordData.mode)
                        {
                            case RECORD_MODE_KEYDOWN:
                                dwFlags = KEYEVENTF_KEYDOWN;
                                break;
                            case RECORD_MODE_KEYUP:
                                dwFlags = KEYEVENTF_KEYUP;
                                break;
                        }
                        keybd_event((byte)recordData.vkCode, (byte)recordData.scanCode, dwFlags, UIntPtr.Zero);
                        break;
                    case RECORD_TYPE_MOUSE:
                        switch(recordData.mode)
                        {
                            case RECORD_MODE_LKEYDOWN:
                                dwFlags = MOUSEEVENTF_LEFTDOWN;
                                break;
                            case RECORD_MODE_LKEYUP:
                                dwFlags = MOUSEEVENTF_LEFTUP;
                                break;
                            case RECORD_MODE_RKEYDOWN:
                                dwFlags = MOUSEEVENTF_RIGHTDOWN;
                                break;
                            case RECORD_MODE_RKEYUP:
                                dwFlags = MOUSEEVENTF_RIGHTUP;
                                break;
                            case RECORD_MODE_MOUSEMOVE:
                                dwFlags = MOUSEEVENTF_MOVE;
                                break;
                            case RECORD_MODE_MOUSEWHEEL:
                                dwFlags = MOUSEEVENTF_WHEEL;
                                break;
                            case RECORD_MODE_MOUSEHWHEEL:
                                dwFlags = MOUSEEVENTF_HWHEEL;
                                break;
                        }
                        if (dwFlags == MOUSEEVENTF_MOVE)
                            SetCursorPos(recordData.x, recordData.y);
                        else
                            mouse_event(dwFlags, (uint)recordData.x, (uint)recordData.y, (uint)recordData.value, UIntPtr.Zero);
                        break;
                }
            }
        }
        #endregion
        #endregion
    }
}

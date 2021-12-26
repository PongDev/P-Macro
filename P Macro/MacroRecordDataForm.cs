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
    partial class MacroRecordDataForm : Form
    {
        public KeyboardState.recordStateClass recordData;

        #region Delay Variable
        private Label lbDelay;
        private TextBox tbDelay;
        private Label lbDelayMS;
        #endregion

        #region Keyboard Variable
        private Label lbKeyboardKey;
        private ComboBox KeyboardKey;
        private ComboBox KeyboardAction;
        private Label lbKeyboardAction;
        #endregion

        #region Mouse Variable
        private Label lbMouseWheelValue;
        private TextBox tbMouseWheelValue;
        private Label lbMouseX;
        private TextBox tbMouseX;
        private Label lbMouseY;
        private TextBox tbMouseY;
        private Label lbMouseAction;
        private ComboBox MouseAction;
        #endregion

        private Dictionary<int, int> allowKeyboardState = new Dictionary<int, int>();
        private Dictionary<int, int> VKCodeToKeyboardStateIndex = new Dictionary<int, int>();
        private Dictionary<int, int> allowKeyboardAction = new Dictionary<int, int>();
        private Dictionary<int, int> KeyboardModeToKeyboardActionIndex = new Dictionary<int, int>();
        private Dictionary<int, int> MouseModeToMouseActionIndex = new Dictionary<int, int>();
        private Dictionary<string, int> MouseActionToMouseMode = new Dictionary<string, int>();

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
        private const int RECORD_MODE_MBUTTONDOWN = 7;
        private const int RECORD_MODE_MBUTTONUP = 8;
        #endregion

        public void InitializeExtraComponent()
        {
            #region Delay
            this.lbDelay = new Label();
            this.tbDelay = new TextBox();
            this.lbDelayMS = new Label();

            // 
            // lbDelay
            // 
            this.lbDelay.AutoSize = true;
            this.lbDelay.Location = new System.Drawing.Point(12, 36);
            this.lbDelay.Name = "lbDelayValue";
            this.lbDelay.Size = new System.Drawing.Size(34, 13);
            this.lbDelay.TabIndex = 2;
            this.lbDelay.Text = "Delay";
            this.lbDelay.Visible = false;
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(49, 33);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(100, 20);
            this.tbDelay.TabIndex = 3;
            this.tbDelay.Visible = false;
            // 
            // lbDelayMS
            // 
            this.lbDelayMS.AutoSize = true;
            this.lbDelayMS.Location = new System.Drawing.Point(155, 36);
            this.lbDelayMS.Name = "lbMS";
            this.lbDelayMS.Size = new System.Drawing.Size(20, 13);
            this.lbDelayMS.TabIndex = 4;
            this.lbDelayMS.Text = "ms";
            this.lbDelayMS.Visible = false;

            this.Controls.Add(this.lbDelay);
            this.Controls.Add(this.tbDelay);
            this.Controls.Add(this.lbDelayMS);
            #endregion

            #region Keyboard
            this.lbKeyboardKey = new System.Windows.Forms.Label();
            this.KeyboardKey = new System.Windows.Forms.ComboBox();
            this.KeyboardAction = new System.Windows.Forms.ComboBox();
            this.lbKeyboardAction = new System.Windows.Forms.Label();

            // 
            // lbKeyboardKey
            // 
            this.lbKeyboardKey.AutoSize = true;
            this.lbKeyboardKey.Location = new System.Drawing.Point(12, 36);
            this.lbKeyboardKey.Name = "lbKeyboardKey";
            this.lbKeyboardKey.Size = new System.Drawing.Size(25, 13);
            this.lbKeyboardKey.TabIndex = 4;
            this.lbKeyboardKey.Text = "Key";
            this.lbKeyboardKey.Visible = false;
            // 
            // KeyboardKey
            // 
            this.KeyboardKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyboardKey.FormattingEnabled = true;
            this.KeyboardKey.Location = new System.Drawing.Point(49, 33);
            this.KeyboardKey.Name = "KeyboardKey";
            this.KeyboardKey.Size = new System.Drawing.Size(126, 21);
            this.KeyboardKey.TabIndex = 5;
            this.KeyboardKey.Visible = false;
            // 
            // KeyboardAction
            // 
            this.KeyboardAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyboardAction.FormattingEnabled = true;
            this.KeyboardAction.Items.AddRange(new object[] {
            "Keydown",
            //"Extended Key",
            "Keyup"});
            this.KeyboardAction.Location = new System.Drawing.Point(49, 61);
            this.KeyboardAction.Name = "KeyboardAction";
            this.KeyboardAction.Size = new System.Drawing.Size(126, 21);
            this.KeyboardAction.TabIndex = 6;
            this.KeyboardAction.Visible = false;
            // 
            // lbKeyboardAction
            // 
            this.lbKeyboardAction.AutoSize = true;
            this.lbKeyboardAction.Location = new System.Drawing.Point(12, 64);
            this.lbKeyboardAction.Name = "lbKeyboardAction";
            this.lbKeyboardAction.Size = new System.Drawing.Size(37, 13);
            this.lbKeyboardAction.TabIndex = 7;
            this.lbKeyboardAction.Text = "Action";
            this.lbKeyboardAction.Visible = false;

            this.Controls.Add(this.lbKeyboardAction);
            this.Controls.Add(this.KeyboardAction);
            this.Controls.Add(this.KeyboardKey);
            this.Controls.Add(this.lbKeyboardKey);
            #endregion

            #region Mouse
            this.lbMouseWheelValue = new System.Windows.Forms.Label();
            this.tbMouseWheelValue = new System.Windows.Forms.TextBox();
            this.lbMouseX = new System.Windows.Forms.Label();
            this.tbMouseX = new System.Windows.Forms.TextBox();
            this.lbMouseY = new System.Windows.Forms.Label();
            this.tbMouseY = new System.Windows.Forms.TextBox();
            this.lbMouseAction = new System.Windows.Forms.Label();
            this.MouseAction = new System.Windows.Forms.ComboBox();

            // 
            // lbMouseWheelValue
            // 
            this.lbMouseWheelValue.AutoSize = true;
            this.lbMouseWheelValue.Location = new System.Drawing.Point(12, 63);
            this.lbMouseWheelValue.Name = "lbMouseWheelValue";
            this.lbMouseWheelValue.Size = new System.Drawing.Size(34, 13);
            this.lbMouseWheelValue.TabIndex = 6;
            this.lbMouseWheelValue.Text = "Value";
            this.lbMouseWheelValue.Visible = false;
            // 
            // tbMouseWheelValue
            // 
            this.tbMouseWheelValue.Location = new System.Drawing.Point(49, 60);
            this.tbMouseWheelValue.Name = "tbMouseWheelValue";
            this.tbMouseWheelValue.Size = new System.Drawing.Size(126, 20);
            this.tbMouseWheelValue.TabIndex = 7;
            this.tbMouseWheelValue.Visible = false;
            // 
            // lbMouseX
            // 
            this.lbMouseX.AutoSize = true;
            this.lbMouseX.Location = new System.Drawing.Point(29, 63);
            this.lbMouseX.Name = "lbMouseX";
            this.lbMouseX.Size = new System.Drawing.Size(14, 13);
            this.lbMouseX.TabIndex = 6;
            this.lbMouseX.Text = "X";
            this.lbMouseX.Visible = false;
            // 
            // tbMouseX
            // 
            this.tbMouseX.Location = new System.Drawing.Point(49, 60);
            this.tbMouseX.Name = "tbMouseX";
            this.tbMouseX.Size = new System.Drawing.Size(126, 20);
            this.tbMouseX.TabIndex = 7;
            this.tbMouseX.Visible = false;
            // 
            // lbMouseY
            // 
            this.lbMouseY.AutoSize = true;
            this.lbMouseY.Location = new System.Drawing.Point(29, 89);
            this.lbMouseY.Name = "lbMouseY";
            this.lbMouseY.Size = new System.Drawing.Size(14, 13);
            this.lbMouseY.TabIndex = 8;
            this.lbMouseY.Text = "Y";
            this.lbMouseY.Visible = false;
            // 
            // tbMouseY
            // 
            this.tbMouseY.Location = new System.Drawing.Point(49, 86);
            this.tbMouseY.Name = "tbMouseY";
            this.tbMouseY.Size = new System.Drawing.Size(126, 20);
            this.tbMouseY.TabIndex = 9;
            this.tbMouseY.Visible = false;
            // 
            // lbMouseAction
            // 
            this.lbMouseAction.AutoSize = true;
            this.lbMouseAction.Location = new System.Drawing.Point(12, 36);
            this.lbMouseAction.Name = "lbMouseAction";
            this.lbMouseAction.Size = new System.Drawing.Size(37, 13);
            this.lbMouseAction.TabIndex = 4;
            this.lbMouseAction.Text = "Action";
            this.lbMouseAction.Visible = false;
            // 
            // MouseAction
            // 
            this.MouseAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MouseAction.FormattingEnabled = true;
            this.MouseAction.Items.AddRange(new object[] {
            "LKEYDOWN",
            "LKEYUP",
            "RKEYDOWN",
            "RKEYUP",
            "MOVE",
            "MOUSE WHEEL",
            "MOUSEHWHEEL",
            "MIDDLEDOWN",
            "MIDDLEUP"});
            this.MouseAction.Location = new System.Drawing.Point(49, 33);
            this.MouseAction.Name = "MouseAction";
            this.MouseAction.Size = new System.Drawing.Size(126, 21);
            this.MouseAction.TabIndex = 5;
            this.MouseAction.SelectedIndexChanged += new System.EventHandler(this.MouseAction_SelectedIndexChanged);
            this.MouseAction.Visible = false;

            this.Controls.Add(this.tbMouseWheelValue);
            this.Controls.Add(this.lbMouseWheelValue);
            this.Controls.Add(this.lbMouseX);
            this.Controls.Add(this.tbMouseX);
            this.Controls.Add(this.lbMouseY);
            this.Controls.Add(this.tbMouseY);
            this.Controls.Add(this.MouseAction);
            this.Controls.Add(this.lbMouseAction);
            #endregion

            for (int c = 0; c < 256; c++)
               if (!KeyboardState.GetvkSkipKeyboardState(c))
                {
                    VKCodeToKeyboardStateIndex.Add(c, allowKeyboardState.Count);
                    allowKeyboardState.Add(allowKeyboardState.Count, c);
                    KeyboardKey.Items.Add((Keys)c);
                }
            /*
            //FULL SET

            allowKeyboardAction.Add(0,KEYEVENTF_KEYDOWN);
            allowKeyboardAction.Add(1,KEYEVENTF_EXTENDEDKEY);
            allowKeyboardAction.Add(2,KEYEVENTF_KEYUP);
            */
            allowKeyboardAction.Add(0, KEYEVENTF_KEYDOWN);
            allowKeyboardAction.Add(1, KEYEVENTF_KEYUP);
            KeyboardModeToKeyboardActionIndex.Add(RECORD_MODE_KEYDOWN, 0);
            KeyboardModeToKeyboardActionIndex.Add(RECORD_MODE_KEYUP, 1);

            MouseModeToMouseActionIndex.Add(RECORD_MODE_LKEYDOWN, 0);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_LKEYUP, 1);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_RKEYDOWN, 2);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_RKEYUP, 3);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_MOUSEMOVE, 4);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_MOUSEWHEEL, 5);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_MOUSEHWHEEL, 6);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_MBUTTONDOWN, 7);
            MouseModeToMouseActionIndex.Add(RECORD_MODE_MBUTTONUP, 8);
            MouseActionToMouseMode.Add("LKEYDOWN", RECORD_MODE_LKEYDOWN);
            MouseActionToMouseMode.Add("LKEYUP", RECORD_MODE_LKEYUP);
            MouseActionToMouseMode.Add("RKEYDOWN", RECORD_MODE_RKEYDOWN);
            MouseActionToMouseMode.Add("RKEYUP", RECORD_MODE_RKEYUP);
            MouseActionToMouseMode.Add("MOVE", RECORD_MODE_MOUSEMOVE);
            MouseActionToMouseMode.Add("MOUSE WHEEL", RECORD_MODE_MOUSEWHEEL);
            MouseActionToMouseMode.Add("MOUSEHWHEEL", RECORD_MODE_MOUSEHWHEEL);
            MouseActionToMouseMode.Add("MIDDLEDOWN", RECORD_MODE_MBUTTONDOWN);
            MouseActionToMouseMode.Add("MIDDLEUP", RECORD_MODE_MBUTTONUP);
        }

        public MacroRecordDataForm(KeyboardState.recordStateClass recordDataInput)
        {
            recordData = recordDataInput;
            InitializeComponent();
            InitializeExtraComponent();
            recordType.SelectedIndex = recordData.type;
            switch(recordData.type)
            {
                case 0:
                    tbDelay.Text = recordData.value.ToString();
                    break;
                case 1:
                    KeyboardKey.SelectedIndex = VKCodeToKeyboardStateIndex[(int)recordData.vkCode];
                    KeyboardAction.SelectedIndex = KeyboardModeToKeyboardActionIndex[recordData.mode];
                    break;
                case 2:
                    MouseAction.SelectedIndex = MouseModeToMouseActionIndex[recordData.mode];
                    break;
            }
        }

        private void recordType_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Clear All Setting
            lbDelay.Visible = false;
            tbDelay.Visible = false;
            tbDelay.Text = "";
            lbDelayMS.Visible = false;
            lbKeyboardKey.Visible = false;
            KeyboardKey.Visible = false;
            KeyboardAction.Visible = false;
            lbKeyboardAction.Visible = false;
            KeyboardKey.SelectedIndex = -1;
            KeyboardAction.SelectedIndex = -1;
            lbMouseAction.Visible = false;
            MouseAction.Visible = false;
            MouseAction.SelectedIndex = -1;
            #endregion

            switch (recordType.Text)
            {
                case "Delay":
                    lbDelay.Visible = true;
                    tbDelay.Visible = true;
                    lbDelayMS.Visible = true;
                    break;
                case "Keyboard":
                    lbKeyboardKey.Visible = true;
                    KeyboardKey.Visible = true;
                    KeyboardAction.Visible = true;
                    lbKeyboardAction.Visible = true;
                    break;
                case "Mouse":
                    lbMouseAction.Visible = true;
                    MouseAction.Visible = true;
                    if (recordData.mode == RECORD_MODE_MOUSEMOVE)
                    {
                        tbMouseX.Text = recordData.x.ToString();
                        tbMouseY.Text = recordData.y.ToString();
                    }
                    if (recordData.mode == RECORD_MODE_MOUSEWHEEL || recordData.mode == RECORD_MODE_MOUSEHWHEEL)
                        tbMouseWheelValue.Text = recordData.value.ToString();
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch(recordType.Text)
            {
                case "Delay":
                    try
                    {
                        recordData.type = RECORD_TYPE_DELAY;
                        recordData.value = Convert.ToInt32(tbDelay.Text);
                        if (recordData.value < 0)
                            throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show("[Error] Invalid Delay Format", "Error");
                        return;
                    }
                    break;
                case "Keyboard":
                    try
                    {
                        if (KeyboardKey.SelectedIndex < 0 || KeyboardAction.SelectedIndex < 0)
                            throw new Exception();
                        recordData.type = RECORD_TYPE_KEYBOARD;
                        recordData.vkCode = (uint)allowKeyboardState[KeyboardKey.SelectedIndex];
                        recordData.scanCode = KeyboardState.VKtoVSC(recordData.vkCode);
                        recordData.mode = KeyboardAction.SelectedIndex;
                    }
                    catch
                    {
                        MessageBox.Show("[Error] Invalid Keyboard Format","Error");
                        return;
                    }
                    break;
                case "Mouse":
                    recordData.type = RECORD_TYPE_MOUSE;
                    try
                    {
                        recordData.mode = MouseActionToMouseMode[MouseAction.Text];
                    }
                    catch
                    {
                        MessageBox.Show("[Error] Invalid Mouse Action Format", "Error");
                        return;
                    }
                    switch(MouseAction.Text)
                    {
                        case "MOVE":
                            try
                            {
                                recordData.x = Convert.ToInt32(tbMouseX.Text);
                                recordData.y = Convert.ToInt32(tbMouseY.Text);
                            }
                            catch
                            {
                                MessageBox.Show("[Error] Invalid Mouse Move Format","Error");
                                return;
                            }
                            break;
                        case "MOUSE WHEEL":
                            try
                            {
                                recordData.value = Convert.ToInt32(tbMouseWheelValue.Text);
                            }
                            catch
                            {
                                MessageBox.Show("[Error] Invalid Mouse Wheel Value Format","Error");
                                return;
                            }
                            break;
                        case "MOUSEHWHEEL":
                            try
                            {
                                recordData.value = Convert.ToInt32(tbMouseWheelValue.Text);
                            }
                            catch
                            {
                                MessageBox.Show("[Error] Invalid MOUSEHWHEEL Value Format", "Error");
                                return;
                            }
                            break;
                    }
                    break;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void MouseAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isMouseActionEqualMOVE = MouseAction.Text == "MOVE";
            bool isMouseActionEqualMOUSEWHEEL = MouseAction.Text == "MOUSE WHEEL" || MouseAction.Text == "MOUSEHWHEEL";
            //bool isMouseActionEqualMOUSEHWHEEL = MouseAction.Text == "MOUSEHWHEEL";

            lbMouseX.Visible = isMouseActionEqualMOVE;
            tbMouseX.Visible = isMouseActionEqualMOVE;
            lbMouseY.Visible = isMouseActionEqualMOVE;
            tbMouseY.Visible = isMouseActionEqualMOVE;
            lbMouseWheelValue.Visible = isMouseActionEqualMOUSEWHEEL;
            tbMouseWheelValue.Visible = isMouseActionEqualMOUSEWHEEL;
        }
    }
}

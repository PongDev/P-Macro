namespace P_Macro
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMacroRecord = new System.Windows.Forms.TabPage();
            this.btnLoadMacroRecordList = new System.Windows.Forms.Button();
            this.btnSaveRecordMacro = new System.Windows.Forms.Button();
            this.btnRemoveMacroRecordData = new System.Windows.Forms.Button();
            this.btnPlayMacroRecord = new System.Windows.Forms.Button();
            this.lbMacroRecordData = new System.Windows.Forms.Label();
            this.listBoxMacroRecordData = new System.Windows.Forms.ListBox();
            this.btnStopMacroRecord = new System.Windows.Forms.Button();
            this.btnStartMacroRecord = new System.Windows.Forms.Button();
            this.lbMacroRecordList = new System.Windows.Forms.Label();
            this.listBoxMacroRecordList = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabShortcutMacro = new System.Windows.Forms.TabPage();
            this.cbRunOnStartup = new System.Windows.Forms.CheckBox();
            this.btnLoadMacro = new System.Windows.Forms.Button();
            this.btnSaveMacro = new System.Windows.Forms.Button();
            this.btnMacroPropertyRemove = new System.Windows.Forms.Button();
            this.btnMacroPropertyUpdate = new System.Windows.Forms.Button();
            this.lbMacroPropertyCommand = new System.Windows.Forms.Label();
            this.tbMacroPropertyCommand = new System.Windows.Forms.TextBox();
            this.cbMacroPropertyHideCmd = new System.Windows.Forms.CheckBox();
            this.lbMacroProperty = new System.Windows.Forms.Label();
            this.lbMacroList = new System.Windows.Forms.Label();
            this.listBoxMacroList = new System.Windows.Forms.ListBox();
            this.btnAddMacro = new System.Windows.Forms.Button();
            this.lbKeyPress = new System.Windows.Forms.Label();
            this.btnRemoveRecordMacro = new System.Windows.Forms.Button();
            this.cbRecordMouse = new System.Windows.Forms.CheckBox();
            this.cbRecordKeyboard = new System.Windows.Forms.CheckBox();
            this.btnInsertMacroRecordData = new System.Windows.Forms.Button();
            this.btnEditMacroRecordData = new System.Windows.Forms.Button();
            this.notifyMenu.SuspendLayout();
            this.tabMacroRecord.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabShortcutMacro.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "P Macro";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabMacroRecord
            // 
            this.tabMacroRecord.Controls.Add(this.btnEditMacroRecordData);
            this.tabMacroRecord.Controls.Add(this.btnInsertMacroRecordData);
            this.tabMacroRecord.Controls.Add(this.cbRecordKeyboard);
            this.tabMacroRecord.Controls.Add(this.cbRecordMouse);
            this.tabMacroRecord.Controls.Add(this.btnRemoveRecordMacro);
            this.tabMacroRecord.Controls.Add(this.btnLoadMacroRecordList);
            this.tabMacroRecord.Controls.Add(this.btnSaveRecordMacro);
            this.tabMacroRecord.Controls.Add(this.btnRemoveMacroRecordData);
            this.tabMacroRecord.Controls.Add(this.btnPlayMacroRecord);
            this.tabMacroRecord.Controls.Add(this.lbMacroRecordData);
            this.tabMacroRecord.Controls.Add(this.listBoxMacroRecordData);
            this.tabMacroRecord.Controls.Add(this.btnStopMacroRecord);
            this.tabMacroRecord.Controls.Add(this.btnStartMacroRecord);
            this.tabMacroRecord.Controls.Add(this.lbMacroRecordList);
            this.tabMacroRecord.Controls.Add(this.listBoxMacroRecordList);
            this.tabMacroRecord.Location = new System.Drawing.Point(4, 22);
            this.tabMacroRecord.Name = "tabMacroRecord";
            this.tabMacroRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tabMacroRecord.Size = new System.Drawing.Size(676, 239);
            this.tabMacroRecord.TabIndex = 2;
            this.tabMacroRecord.Text = "Macro Record";
            this.tabMacroRecord.UseVisualStyleBackColor = true;
            // 
            // btnLoadMacroRecordList
            // 
            this.btnLoadMacroRecordList.Location = new System.Drawing.Point(8, 203);
            this.btnLoadMacroRecordList.Name = "btnLoadMacroRecordList";
            this.btnLoadMacroRecordList.Size = new System.Drawing.Size(120, 23);
            this.btnLoadMacroRecordList.TabIndex = 9;
            this.btnLoadMacroRecordList.Text = "Load Record List";
            this.btnLoadMacroRecordList.UseVisualStyleBackColor = true;
            this.btnLoadMacroRecordList.Click += new System.EventHandler(this.btnLoadMacroRecordList_Click);
            // 
            // btnSaveRecordMacro
            // 
            this.btnSaveRecordMacro.Location = new System.Drawing.Point(575, 174);
            this.btnSaveRecordMacro.Name = "btnSaveRecordMacro";
            this.btnSaveRecordMacro.Size = new System.Drawing.Size(95, 23);
            this.btnSaveRecordMacro.TabIndex = 8;
            this.btnSaveRecordMacro.Text = "Save Record";
            this.btnSaveRecordMacro.UseVisualStyleBackColor = true;
            this.btnSaveRecordMacro.Click += new System.EventHandler(this.btnSaveRecordMacro_Click);
            // 
            // btnRemoveMacroRecordData
            // 
            this.btnRemoveMacroRecordData.Enabled = false;
            this.btnRemoveMacroRecordData.Location = new System.Drawing.Point(575, 86);
            this.btnRemoveMacroRecordData.Name = "btnRemoveMacroRecordData";
            this.btnRemoveMacroRecordData.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveMacroRecordData.TabIndex = 7;
            this.btnRemoveMacroRecordData.Text = "Remove Data";
            this.btnRemoveMacroRecordData.UseVisualStyleBackColor = true;
            this.btnRemoveMacroRecordData.Click += new System.EventHandler(this.btnRemoveMacroRecordData_Click);
            // 
            // btnPlayMacroRecord
            // 
            this.btnPlayMacroRecord.Location = new System.Drawing.Point(575, 203);
            this.btnPlayMacroRecord.Name = "btnPlayMacroRecord";
            this.btnPlayMacroRecord.Size = new System.Drawing.Size(95, 23);
            this.btnPlayMacroRecord.TabIndex = 6;
            this.btnPlayMacroRecord.Text = "Play Record";
            this.btnPlayMacroRecord.UseVisualStyleBackColor = true;
            this.btnPlayMacroRecord.Click += new System.EventHandler(this.btnPlayMacroRecord_Click);
            // 
            // lbMacroRecordData
            // 
            this.lbMacroRecordData.AutoSize = true;
            this.lbMacroRecordData.Location = new System.Drawing.Point(135, 7);
            this.lbMacroRecordData.Name = "lbMacroRecordData";
            this.lbMacroRecordData.Size = new System.Drawing.Size(101, 13);
            this.lbMacroRecordData.TabIndex = 5;
            this.lbMacroRecordData.Text = "Macro Record Data";
            // 
            // listBoxMacroRecordData
            // 
            this.listBoxMacroRecordData.FormattingEnabled = true;
            this.listBoxMacroRecordData.Location = new System.Drawing.Point(135, 28);
            this.listBoxMacroRecordData.Name = "listBoxMacroRecordData";
            this.listBoxMacroRecordData.Size = new System.Drawing.Size(434, 173);
            this.listBoxMacroRecordData.TabIndex = 4;
            this.listBoxMacroRecordData.SelectedIndexChanged += new System.EventHandler(this.listBoxMacroRecordData_SelectedIndexChanged);
            // 
            // btnStopMacroRecord
            // 
            this.btnStopMacroRecord.Enabled = false;
            this.btnStopMacroRecord.Location = new System.Drawing.Point(216, 203);
            this.btnStopMacroRecord.Name = "btnStopMacroRecord";
            this.btnStopMacroRecord.Size = new System.Drawing.Size(75, 23);
            this.btnStopMacroRecord.TabIndex = 3;
            this.btnStopMacroRecord.Text = "Stop Record";
            this.btnStopMacroRecord.UseVisualStyleBackColor = true;
            this.btnStopMacroRecord.Click += new System.EventHandler(this.btnStopMacroRecord_Click);
            // 
            // btnStartMacroRecord
            // 
            this.btnStartMacroRecord.Location = new System.Drawing.Point(135, 203);
            this.btnStartMacroRecord.Name = "btnStartMacroRecord";
            this.btnStartMacroRecord.Size = new System.Drawing.Size(75, 23);
            this.btnStartMacroRecord.TabIndex = 2;
            this.btnStartMacroRecord.Text = "Start Record";
            this.btnStartMacroRecord.UseVisualStyleBackColor = true;
            this.btnStartMacroRecord.Click += new System.EventHandler(this.btnStartMacroRecord_Click);
            // 
            // lbMacroRecordList
            // 
            this.lbMacroRecordList.AutoSize = true;
            this.lbMacroRecordList.Location = new System.Drawing.Point(7, 7);
            this.lbMacroRecordList.Name = "lbMacroRecordList";
            this.lbMacroRecordList.Size = new System.Drawing.Size(94, 13);
            this.lbMacroRecordList.TabIndex = 1;
            this.lbMacroRecordList.Text = "Macro Record List";
            // 
            // listBoxMacroRecordList
            // 
            this.listBoxMacroRecordList.FormattingEnabled = true;
            this.listBoxMacroRecordList.Location = new System.Drawing.Point(8, 28);
            this.listBoxMacroRecordList.Name = "listBoxMacroRecordList";
            this.listBoxMacroRecordList.Size = new System.Drawing.Size(120, 173);
            this.listBoxMacroRecordList.TabIndex = 0;
            this.listBoxMacroRecordList.SelectedIndexChanged += new System.EventHandler(this.listBoxMacroRecordList_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMacroRecord);
            this.tabControl.Controls.Add(this.tabShortcutMacro);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(684, 265);
            this.tabControl.TabIndex = 1;
            // 
            // tabShortcutMacro
            // 
            this.tabShortcutMacro.Controls.Add(this.cbRunOnStartup);
            this.tabShortcutMacro.Controls.Add(this.btnLoadMacro);
            this.tabShortcutMacro.Controls.Add(this.btnSaveMacro);
            this.tabShortcutMacro.Controls.Add(this.btnMacroPropertyRemove);
            this.tabShortcutMacro.Controls.Add(this.btnMacroPropertyUpdate);
            this.tabShortcutMacro.Controls.Add(this.lbMacroPropertyCommand);
            this.tabShortcutMacro.Controls.Add(this.tbMacroPropertyCommand);
            this.tabShortcutMacro.Controls.Add(this.cbMacroPropertyHideCmd);
            this.tabShortcutMacro.Controls.Add(this.lbMacroProperty);
            this.tabShortcutMacro.Controls.Add(this.lbMacroList);
            this.tabShortcutMacro.Controls.Add(this.listBoxMacroList);
            this.tabShortcutMacro.Controls.Add(this.btnAddMacro);
            this.tabShortcutMacro.Controls.Add(this.lbKeyPress);
            this.tabShortcutMacro.Location = new System.Drawing.Point(4, 22);
            this.tabShortcutMacro.Name = "tabShortcutMacro";
            this.tabShortcutMacro.Padding = new System.Windows.Forms.Padding(3);
            this.tabShortcutMacro.Size = new System.Drawing.Size(676, 239);
            this.tabShortcutMacro.TabIndex = 3;
            this.tabShortcutMacro.Text = "Shortcut Macro";
            this.tabShortcutMacro.UseVisualStyleBackColor = true;
            // 
            // cbRunOnStartup
            // 
            this.cbRunOnStartup.AutoSize = true;
            this.cbRunOnStartup.Location = new System.Drawing.Point(566, 209);
            this.cbRunOnStartup.Name = "cbRunOnStartup";
            this.cbRunOnStartup.Size = new System.Drawing.Size(100, 17);
            this.cbRunOnStartup.TabIndex = 27;
            this.cbRunOnStartup.Text = "Run On Startup";
            this.cbRunOnStartup.UseVisualStyleBackColor = true;
            this.cbRunOnStartup.CheckedChanged += new System.EventHandler(this.cbRunOnStartup_CheckedChanged);
            // 
            // btnLoadMacro
            // 
            this.btnLoadMacro.Location = new System.Drawing.Point(92, 205);
            this.btnLoadMacro.Name = "btnLoadMacro";
            this.btnLoadMacro.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMacro.TabIndex = 26;
            this.btnLoadMacro.Text = "Load Macro";
            this.btnLoadMacro.UseVisualStyleBackColor = true;
            this.btnLoadMacro.Click += new System.EventHandler(this.btnLoadMacro_Click);
            // 
            // btnSaveMacro
            // 
            this.btnSaveMacro.Location = new System.Drawing.Point(10, 205);
            this.btnSaveMacro.Name = "btnSaveMacro";
            this.btnSaveMacro.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMacro.TabIndex = 25;
            this.btnSaveMacro.Text = "Save Macro";
            this.btnSaveMacro.UseVisualStyleBackColor = true;
            this.btnSaveMacro.Click += new System.EventHandler(this.btnSaveMacro_Click);
            // 
            // btnMacroPropertyRemove
            // 
            this.btnMacroPropertyRemove.Enabled = false;
            this.btnMacroPropertyRemove.Location = new System.Drawing.Point(351, 131);
            this.btnMacroPropertyRemove.Name = "btnMacroPropertyRemove";
            this.btnMacroPropertyRemove.Size = new System.Drawing.Size(75, 23);
            this.btnMacroPropertyRemove.TabIndex = 24;
            this.btnMacroPropertyRemove.Text = "Remove";
            this.btnMacroPropertyRemove.UseVisualStyleBackColor = true;
            this.btnMacroPropertyRemove.Click += new System.EventHandler(this.btnMacroPropertyRemove_Click);
            // 
            // btnMacroPropertyUpdate
            // 
            this.btnMacroPropertyUpdate.Enabled = false;
            this.btnMacroPropertyUpdate.Location = new System.Drawing.Point(270, 131);
            this.btnMacroPropertyUpdate.Name = "btnMacroPropertyUpdate";
            this.btnMacroPropertyUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnMacroPropertyUpdate.TabIndex = 23;
            this.btnMacroPropertyUpdate.Text = "Update";
            this.btnMacroPropertyUpdate.UseVisualStyleBackColor = true;
            this.btnMacroPropertyUpdate.Click += new System.EventHandler(this.btnMacroPropertyUpdate_Click);
            // 
            // lbMacroPropertyCommand
            // 
            this.lbMacroPropertyCommand.AutoSize = true;
            this.lbMacroPropertyCommand.Location = new System.Drawing.Point(267, 89);
            this.lbMacroPropertyCommand.Name = "lbMacroPropertyCommand";
            this.lbMacroPropertyCommand.Size = new System.Drawing.Size(57, 13);
            this.lbMacroPropertyCommand.TabIndex = 22;
            this.lbMacroPropertyCommand.Text = "Command:";
            // 
            // tbMacroPropertyCommand
            // 
            this.tbMacroPropertyCommand.Enabled = false;
            this.tbMacroPropertyCommand.Location = new System.Drawing.Point(270, 105);
            this.tbMacroPropertyCommand.Name = "tbMacroPropertyCommand";
            this.tbMacroPropertyCommand.Size = new System.Drawing.Size(396, 20);
            this.tbMacroPropertyCommand.TabIndex = 21;
            // 
            // cbMacroPropertyHideCmd
            // 
            this.cbMacroPropertyHideCmd.AutoSize = true;
            this.cbMacroPropertyHideCmd.Enabled = false;
            this.cbMacroPropertyHideCmd.Location = new System.Drawing.Point(270, 69);
            this.cbMacroPropertyHideCmd.Name = "cbMacroPropertyHideCmd";
            this.cbMacroPropertyHideCmd.Size = new System.Drawing.Size(72, 17);
            this.cbMacroPropertyHideCmd.TabIndex = 20;
            this.cbMacroPropertyHideCmd.Text = "Hide Cmd";
            this.cbMacroPropertyHideCmd.UseVisualStyleBackColor = true;
            // 
            // lbMacroProperty
            // 
            this.lbMacroProperty.AutoSize = true;
            this.lbMacroProperty.Location = new System.Drawing.Point(267, 48);
            this.lbMacroProperty.Name = "lbMacroProperty";
            this.lbMacroProperty.Size = new System.Drawing.Size(79, 13);
            this.lbMacroProperty.TabIndex = 19;
            this.lbMacroProperty.Text = "Macro Property";
            // 
            // lbMacroList
            // 
            this.lbMacroList.AutoSize = true;
            this.lbMacroList.Location = new System.Drawing.Point(10, 48);
            this.lbMacroList.Name = "lbMacroList";
            this.lbMacroList.Size = new System.Drawing.Size(56, 13);
            this.lbMacroList.TabIndex = 18;
            this.lbMacroList.Text = "Macro List";
            // 
            // listBoxMacroList
            // 
            this.listBoxMacroList.FormattingEnabled = true;
            this.listBoxMacroList.Location = new System.Drawing.Point(10, 64);
            this.listBoxMacroList.Name = "listBoxMacroList";
            this.listBoxMacroList.Size = new System.Drawing.Size(250, 134);
            this.listBoxMacroList.TabIndex = 17;
            this.listBoxMacroList.SelectedIndexChanged += new System.EventHandler(this.listBoxMacroList_SelectedIndexChanged);
            // 
            // btnAddMacro
            // 
            this.btnAddMacro.Location = new System.Drawing.Point(10, 18);
            this.btnAddMacro.Name = "btnAddMacro";
            this.btnAddMacro.Size = new System.Drawing.Size(75, 23);
            this.btnAddMacro.TabIndex = 16;
            this.btnAddMacro.Text = "Add Macro";
            this.btnAddMacro.UseVisualStyleBackColor = true;
            this.btnAddMacro.Click += new System.EventHandler(this.btnAddMacro_Click);
            // 
            // lbKeyPress
            // 
            this.lbKeyPress.AutoSize = true;
            this.lbKeyPress.Location = new System.Drawing.Point(11, 2);
            this.lbKeyPress.Name = "lbKeyPress";
            this.lbKeyPress.Size = new System.Drawing.Size(60, 13);
            this.lbKeyPress.TabIndex = 15;
            this.lbKeyPress.Text = "Key Press: ";
            // 
            // btnRemoveRecordMacro
            // 
            this.btnRemoveRecordMacro.Enabled = false;
            this.btnRemoveRecordMacro.Location = new System.Drawing.Point(575, 145);
            this.btnRemoveRecordMacro.Name = "btnRemoveRecordMacro";
            this.btnRemoveRecordMacro.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveRecordMacro.TabIndex = 10;
            this.btnRemoveRecordMacro.Text = "Remove Record";
            this.btnRemoveRecordMacro.UseVisualStyleBackColor = true;
            this.btnRemoveRecordMacro.Click += new System.EventHandler(this.btnRemoveRecordMacro_Click);
            // 
            // cbRecordMouse
            // 
            this.cbRecordMouse.AutoSize = true;
            this.cbRecordMouse.Checked = true;
            this.cbRecordMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecordMouse.Location = new System.Drawing.Point(412, 207);
            this.cbRecordMouse.Name = "cbRecordMouse";
            this.cbRecordMouse.Size = new System.Drawing.Size(96, 17);
            this.cbRecordMouse.TabIndex = 11;
            this.cbRecordMouse.Text = "Record Mouse";
            this.cbRecordMouse.UseVisualStyleBackColor = true;
            // 
            // cbRecordKeyboard
            // 
            this.cbRecordKeyboard.AutoSize = true;
            this.cbRecordKeyboard.Checked = true;
            this.cbRecordKeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecordKeyboard.Location = new System.Drawing.Point(297, 207);
            this.cbRecordKeyboard.Name = "cbRecordKeyboard";
            this.cbRecordKeyboard.Size = new System.Drawing.Size(109, 17);
            this.cbRecordKeyboard.TabIndex = 12;
            this.cbRecordKeyboard.Text = "Record Keyboard";
            this.cbRecordKeyboard.UseVisualStyleBackColor = true;
            // 
            // btnInsertMacroRecordData
            // 
            this.btnInsertMacroRecordData.Location = new System.Drawing.Point(575, 28);
            this.btnInsertMacroRecordData.Name = "btnInsertMacroRecordData";
            this.btnInsertMacroRecordData.Size = new System.Drawing.Size(95, 23);
            this.btnInsertMacroRecordData.TabIndex = 13;
            this.btnInsertMacroRecordData.Text = "Insert Data";
            this.btnInsertMacroRecordData.UseVisualStyleBackColor = true;
            this.btnInsertMacroRecordData.Click += new System.EventHandler(this.btnInsertMacroRecordData_Click);
            // 
            // btnEditMacroRecordData
            // 
            this.btnEditMacroRecordData.Enabled = false;
            this.btnEditMacroRecordData.Location = new System.Drawing.Point(575, 57);
            this.btnEditMacroRecordData.Name = "btnEditMacroRecordData";
            this.btnEditMacroRecordData.Size = new System.Drawing.Size(95, 23);
            this.btnEditMacroRecordData.TabIndex = 14;
            this.btnEditMacroRecordData.Text = "Edit Data";
            this.btnEditMacroRecordData.UseVisualStyleBackColor = true;
            this.btnEditMacroRecordData.Click += new System.EventHandler(this.btnEditMacroRecordData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 261);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P Macro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.notifyMenu.ResumeLayout(false);
            this.tabMacroRecord.ResumeLayout(false);
            this.tabMacroRecord.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabShortcutMacro.ResumeLayout(false);
            this.tabShortcutMacro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabMacroRecord;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabShortcutMacro;
        private System.Windows.Forms.CheckBox cbRunOnStartup;
        private System.Windows.Forms.Button btnLoadMacro;
        private System.Windows.Forms.Button btnSaveMacro;
        private System.Windows.Forms.Button btnMacroPropertyRemove;
        private System.Windows.Forms.Button btnMacroPropertyUpdate;
        private System.Windows.Forms.Label lbMacroPropertyCommand;
        private System.Windows.Forms.TextBox tbMacroPropertyCommand;
        private System.Windows.Forms.CheckBox cbMacroPropertyHideCmd;
        private System.Windows.Forms.Label lbMacroProperty;
        private System.Windows.Forms.Label lbMacroList;
        private System.Windows.Forms.ListBox listBoxMacroList;
        private System.Windows.Forms.Button btnAddMacro;
        private System.Windows.Forms.Label lbKeyPress;
        private System.Windows.Forms.Label lbMacroRecordList;
        private System.Windows.Forms.ListBox listBoxMacroRecordList;
        private System.Windows.Forms.Label lbMacroRecordData;
        private System.Windows.Forms.ListBox listBoxMacroRecordData;
        private System.Windows.Forms.Button btnStopMacroRecord;
        private System.Windows.Forms.Button btnStartMacroRecord;
        private System.Windows.Forms.Button btnPlayMacroRecord;
        private System.Windows.Forms.Button btnRemoveMacroRecordData;
        private System.Windows.Forms.Button btnSaveRecordMacro;
        private System.Windows.Forms.Button btnLoadMacroRecordList;
        private System.Windows.Forms.Button btnRemoveRecordMacro;
        private System.Windows.Forms.CheckBox cbRecordKeyboard;
        private System.Windows.Forms.CheckBox cbRecordMouse;
        private System.Windows.Forms.Button btnEditMacroRecordData;
        private System.Windows.Forms.Button btnInsertMacroRecordData;
    }
}


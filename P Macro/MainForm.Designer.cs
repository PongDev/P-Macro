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
            this.lbKeyPress = new System.Windows.Forms.Label();
            this.btnAddMacro = new System.Windows.Forms.Button();
            this.listBoxMacroList = new System.Windows.Forms.ListBox();
            this.lbMacroList = new System.Windows.Forms.Label();
            this.lbMacroProperty = new System.Windows.Forms.Label();
            this.cbMacroPropertyHideCmd = new System.Windows.Forms.CheckBox();
            this.tbMacroPropertyCommand = new System.Windows.Forms.TextBox();
            this.lbMacroPropertyCommand = new System.Windows.Forms.Label();
            this.btnMacroPropertyUpdate = new System.Windows.Forms.Button();
            this.btnMacroPropertyRemove = new System.Windows.Forms.Button();
            this.btnSaveMacro = new System.Windows.Forms.Button();
            this.btnLoadMacro = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRunOnStartup = new System.Windows.Forms.CheckBox();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbKeyPress
            // 
            this.lbKeyPress.AutoSize = true;
            this.lbKeyPress.Location = new System.Drawing.Point(13, 13);
            this.lbKeyPress.Name = "lbKeyPress";
            this.lbKeyPress.Size = new System.Drawing.Size(60, 13);
            this.lbKeyPress.TabIndex = 0;
            this.lbKeyPress.Text = "Key Press: ";
            // 
            // btnAddMacro
            // 
            this.btnAddMacro.Location = new System.Drawing.Point(12, 29);
            this.btnAddMacro.Name = "btnAddMacro";
            this.btnAddMacro.Size = new System.Drawing.Size(75, 23);
            this.btnAddMacro.TabIndex = 1;
            this.btnAddMacro.Text = "Add Macro";
            this.btnAddMacro.UseVisualStyleBackColor = true;
            this.btnAddMacro.Click += new System.EventHandler(this.btnAddMacro_Click);
            // 
            // listBoxMacroList
            // 
            this.listBoxMacroList.FormattingEnabled = true;
            this.listBoxMacroList.Location = new System.Drawing.Point(12, 75);
            this.listBoxMacroList.Name = "listBoxMacroList";
            this.listBoxMacroList.Size = new System.Drawing.Size(250, 95);
            this.listBoxMacroList.TabIndex = 2;
            this.listBoxMacroList.SelectedIndexChanged += new System.EventHandler(this.listBoxMacroList_SelectedIndexChanged);
            // 
            // lbMacroList
            // 
            this.lbMacroList.AutoSize = true;
            this.lbMacroList.Location = new System.Drawing.Point(12, 59);
            this.lbMacroList.Name = "lbMacroList";
            this.lbMacroList.Size = new System.Drawing.Size(56, 13);
            this.lbMacroList.TabIndex = 3;
            this.lbMacroList.Text = "Macro List";
            // 
            // lbMacroProperty
            // 
            this.lbMacroProperty.AutoSize = true;
            this.lbMacroProperty.Location = new System.Drawing.Point(269, 59);
            this.lbMacroProperty.Name = "lbMacroProperty";
            this.lbMacroProperty.Size = new System.Drawing.Size(79, 13);
            this.lbMacroProperty.TabIndex = 4;
            this.lbMacroProperty.Text = "Macro Property";
            // 
            // cbMacroPropertyHideCmd
            // 
            this.cbMacroPropertyHideCmd.AutoSize = true;
            this.cbMacroPropertyHideCmd.Location = new System.Drawing.Point(272, 80);
            this.cbMacroPropertyHideCmd.Name = "cbMacroPropertyHideCmd";
            this.cbMacroPropertyHideCmd.Size = new System.Drawing.Size(72, 17);
            this.cbMacroPropertyHideCmd.TabIndex = 5;
            this.cbMacroPropertyHideCmd.Text = "Hide Cmd";
            this.cbMacroPropertyHideCmd.UseVisualStyleBackColor = true;
            // 
            // tbMacroPropertyCommand
            // 
            this.tbMacroPropertyCommand.Location = new System.Drawing.Point(272, 116);
            this.tbMacroPropertyCommand.Name = "tbMacroPropertyCommand";
            this.tbMacroPropertyCommand.Size = new System.Drawing.Size(396, 20);
            this.tbMacroPropertyCommand.TabIndex = 6;
            // 
            // lbMacroPropertyCommand
            // 
            this.lbMacroPropertyCommand.AutoSize = true;
            this.lbMacroPropertyCommand.Location = new System.Drawing.Point(269, 100);
            this.lbMacroPropertyCommand.Name = "lbMacroPropertyCommand";
            this.lbMacroPropertyCommand.Size = new System.Drawing.Size(57, 13);
            this.lbMacroPropertyCommand.TabIndex = 7;
            this.lbMacroPropertyCommand.Text = "Command:";
            // 
            // btnMacroPropertyUpdate
            // 
            this.btnMacroPropertyUpdate.Location = new System.Drawing.Point(272, 142);
            this.btnMacroPropertyUpdate.Name = "btnMacroPropertyUpdate";
            this.btnMacroPropertyUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnMacroPropertyUpdate.TabIndex = 8;
            this.btnMacroPropertyUpdate.Text = "Update";
            this.btnMacroPropertyUpdate.UseVisualStyleBackColor = true;
            this.btnMacroPropertyUpdate.Click += new System.EventHandler(this.btnMacroPropertyUpdate_Click);
            // 
            // btnMacroPropertyRemove
            // 
            this.btnMacroPropertyRemove.Location = new System.Drawing.Point(353, 142);
            this.btnMacroPropertyRemove.Name = "btnMacroPropertyRemove";
            this.btnMacroPropertyRemove.Size = new System.Drawing.Size(75, 23);
            this.btnMacroPropertyRemove.TabIndex = 9;
            this.btnMacroPropertyRemove.Text = "Remove";
            this.btnMacroPropertyRemove.UseVisualStyleBackColor = true;
            this.btnMacroPropertyRemove.Click += new System.EventHandler(this.btnMacroPropertyRemove_Click);
            // 
            // btnSaveMacro
            // 
            this.btnSaveMacro.Location = new System.Drawing.Point(12, 177);
            this.btnSaveMacro.Name = "btnSaveMacro";
            this.btnSaveMacro.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMacro.TabIndex = 10;
            this.btnSaveMacro.Text = "Save Macro";
            this.btnSaveMacro.UseVisualStyleBackColor = true;
            this.btnSaveMacro.Click += new System.EventHandler(this.btnSaveMacro_Click);
            // 
            // btnLoadMacro
            // 
            this.btnLoadMacro.Location = new System.Drawing.Point(94, 177);
            this.btnLoadMacro.Name = "btnLoadMacro";
            this.btnLoadMacro.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMacro.TabIndex = 11;
            this.btnLoadMacro.Text = "Load Macro";
            this.btnLoadMacro.UseVisualStyleBackColor = true;
            this.btnLoadMacro.Click += new System.EventHandler(this.btnLoadMacro_Click);
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
            // cbRunOnStartup
            // 
            this.cbRunOnStartup.AutoSize = true;
            this.cbRunOnStartup.Location = new System.Drawing.Point(568, 181);
            this.cbRunOnStartup.Name = "cbRunOnStartup";
            this.cbRunOnStartup.Size = new System.Drawing.Size(100, 17);
            this.cbRunOnStartup.TabIndex = 14;
            this.cbRunOnStartup.Text = "Run On Startup";
            this.cbRunOnStartup.UseVisualStyleBackColor = true;
            this.cbRunOnStartup.CheckedChanged += new System.EventHandler(this.cbRunOnStartup_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 212);
            this.Controls.Add(this.cbRunOnStartup);
            this.Controls.Add(this.btnLoadMacro);
            this.Controls.Add(this.btnSaveMacro);
            this.Controls.Add(this.btnMacroPropertyRemove);
            this.Controls.Add(this.btnMacroPropertyUpdate);
            this.Controls.Add(this.lbMacroPropertyCommand);
            this.Controls.Add(this.tbMacroPropertyCommand);
            this.Controls.Add(this.cbMacroPropertyHideCmd);
            this.Controls.Add(this.lbMacroProperty);
            this.Controls.Add(this.lbMacroList);
            this.Controls.Add(this.listBoxMacroList);
            this.Controls.Add(this.btnAddMacro);
            this.Controls.Add(this.lbKeyPress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P Macro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbKeyPress;
        private System.Windows.Forms.Button btnAddMacro;
        private System.Windows.Forms.ListBox listBoxMacroList;
        private System.Windows.Forms.Label lbMacroList;
        private System.Windows.Forms.Label lbMacroProperty;
        private System.Windows.Forms.CheckBox cbMacroPropertyHideCmd;
        private System.Windows.Forms.TextBox tbMacroPropertyCommand;
        private System.Windows.Forms.Label lbMacroPropertyCommand;
        private System.Windows.Forms.Button btnMacroPropertyUpdate;
        private System.Windows.Forms.Button btnMacroPropertyRemove;
        private System.Windows.Forms.Button btnSaveMacro;
        private System.Windows.Forms.Button btnLoadMacro;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbRunOnStartup;
    }
}


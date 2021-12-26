namespace P_Macro
{
    partial class AddMacroForm
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
            this.lbMacroKey = new System.Windows.Forms.Label();
            this.lbMacroCommand = new System.Windows.Forms.Label();
            this.tbMacroCommand = new System.Windows.Forms.TextBox();
            this.btnAddMacro = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbHideCmd = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openExeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lbMacroKey
            // 
            this.lbMacroKey.AutoSize = true;
            this.lbMacroKey.Location = new System.Drawing.Point(13, 13);
            this.lbMacroKey.Name = "lbMacroKey";
            this.lbMacroKey.Size = new System.Drawing.Size(101, 13);
            this.lbMacroKey.TabIndex = 0;
            this.lbMacroKey.Text = "Add Macro For Key:";
            // 
            // lbMacroCommand
            // 
            this.lbMacroCommand.AutoSize = true;
            this.lbMacroCommand.Location = new System.Drawing.Point(13, 33);
            this.lbMacroCommand.Name = "lbMacroCommand";
            this.lbMacroCommand.Size = new System.Drawing.Size(57, 13);
            this.lbMacroCommand.TabIndex = 1;
            this.lbMacroCommand.Text = "Command:";
            // 
            // tbMacroCommand
            // 
            this.tbMacroCommand.Location = new System.Drawing.Point(76, 30);
            this.tbMacroCommand.Name = "tbMacroCommand";
            this.tbMacroCommand.Size = new System.Drawing.Size(315, 20);
            this.tbMacroCommand.TabIndex = 2;
            // 
            // btnAddMacro
            // 
            this.btnAddMacro.Location = new System.Drawing.Point(316, 56);
            this.btnAddMacro.Name = "btnAddMacro";
            this.btnAddMacro.Size = new System.Drawing.Size(75, 23);
            this.btnAddMacro.TabIndex = 3;
            this.btnAddMacro.Text = "Add Macro";
            this.btnAddMacro.UseVisualStyleBackColor = true;
            this.btnAddMacro.Click += new System.EventHandler(this.btnAddMacro_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbHideCmd
            // 
            this.cbHideCmd.AutoSize = true;
            this.cbHideCmd.Checked = true;
            this.cbHideCmd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideCmd.Location = new System.Drawing.Point(12, 60);
            this.cbHideCmd.Name = "cbHideCmd";
            this.cbHideCmd.Size = new System.Drawing.Size(72, 17);
            this.cbHideCmd.TabIndex = 5;
            this.cbHideCmd.Text = "Hide Cmd";
            this.cbHideCmd.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(397, 28);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse .exe";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openExeFileDialog
            // 
            this.openExeFileDialog.Filter = ".exe File|*.exe";
            this.openExeFileDialog.Title = "Select .exe File For Macro";
            // 
            // AddMacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 91);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.cbHideCmd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddMacro);
            this.Controls.Add(this.tbMacroCommand);
            this.Controls.Add(this.lbMacroCommand);
            this.Controls.Add(this.lbMacroKey);
            this.Name = "AddMacroForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Macro";
            this.Shown += new System.EventHandler(this.AddMacroForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMacroKey;
        private System.Windows.Forms.Label lbMacroCommand;
        private System.Windows.Forms.TextBox tbMacroCommand;
        private System.Windows.Forms.Button btnAddMacro;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbHideCmd;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openExeFileDialog;
    }
}
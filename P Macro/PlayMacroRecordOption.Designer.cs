namespace P_Macro
{
    partial class PlayMacroRecordOption
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbLoopAmount = new System.Windows.Forms.Label();
            this.tbLoopAmount = new System.Windows.Forms.TextBox();
            this.cbLoopUntilBreakKeyPress = new System.Windows.Forms.CheckBox();
            this.lbKeyPress = new System.Windows.Forms.Label();
            this.btnSetBreakKey = new System.Windows.Forms.Button();
            this.lbBreakKey = new System.Windows.Forms.Label();
            this.bgWorkerKeyPress = new System.ComponentModel.BackgroundWorker();
            this.lbDelayBeforeActivate = new System.Windows.Forms.Label();
            this.tbDelayBeforeActivate = new System.Windows.Forms.TextBox();
            this.lbDelayBeforeActivateMS = new System.Windows.Forms.Label();
            this.lbLoopAmountTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(197, 141);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbLoopAmount
            // 
            this.lbLoopAmount.AutoSize = true;
            this.lbLoopAmount.Location = new System.Drawing.Point(13, 43);
            this.lbLoopAmount.Name = "lbLoopAmount";
            this.lbLoopAmount.Size = new System.Drawing.Size(70, 13);
            this.lbLoopAmount.TabIndex = 5;
            this.lbLoopAmount.Text = "Loop Amount";
            // 
            // tbLoopAmount
            // 
            this.tbLoopAmount.Location = new System.Drawing.Point(129, 40);
            this.tbLoopAmount.Name = "tbLoopAmount";
            this.tbLoopAmount.Size = new System.Drawing.Size(107, 20);
            this.tbLoopAmount.TabIndex = 6;
            this.tbLoopAmount.Text = "1";
            // 
            // cbLoopUntilBreakKeyPress
            // 
            this.cbLoopUntilBreakKeyPress.AutoSize = true;
            this.cbLoopUntilBreakKeyPress.Location = new System.Drawing.Point(117, 112);
            this.cbLoopUntilBreakKeyPress.Name = "cbLoopUntilBreakKeyPress";
            this.cbLoopUntilBreakKeyPress.Size = new System.Drawing.Size(155, 17);
            this.cbLoopUntilBreakKeyPress.TabIndex = 11;
            this.cbLoopUntilBreakKeyPress.Text = "Loop Until Break Key Press";
            this.cbLoopUntilBreakKeyPress.UseVisualStyleBackColor = true;
            this.cbLoopUntilBreakKeyPress.CheckedChanged += new System.EventHandler(this.cbLoopUntilBreakKeyPress_CheckedChanged);
            // 
            // lbKeyPress
            // 
            this.lbKeyPress.AutoSize = true;
            this.lbKeyPress.Location = new System.Drawing.Point(13, 69);
            this.lbKeyPress.Name = "lbKeyPress";
            this.lbKeyPress.Size = new System.Drawing.Size(57, 13);
            this.lbKeyPress.TabIndex = 8;
            this.lbKeyPress.Text = "Key Press:";
            // 
            // btnSetBreakKey
            // 
            this.btnSetBreakKey.Enabled = false;
            this.btnSetBreakKey.Location = new System.Drawing.Point(187, 64);
            this.btnSetBreakKey.Name = "btnSetBreakKey";
            this.btnSetBreakKey.Size = new System.Drawing.Size(85, 23);
            this.btnSetBreakKey.TabIndex = 9;
            this.btnSetBreakKey.Text = "Set Break Key";
            this.btnSetBreakKey.UseVisualStyleBackColor = true;
            this.btnSetBreakKey.Click += new System.EventHandler(this.btnSetBreakKey_Click);
            // 
            // lbBreakKey
            // 
            this.lbBreakKey.AutoSize = true;
            this.lbBreakKey.Location = new System.Drawing.Point(13, 89);
            this.lbBreakKey.Name = "lbBreakKey";
            this.lbBreakKey.Size = new System.Drawing.Size(59, 13);
            this.lbBreakKey.TabIndex = 10;
            this.lbBreakKey.Text = "Break Key:";
            // 
            // bgWorkerKeyPress
            // 
            this.bgWorkerKeyPress.WorkerReportsProgress = true;
            this.bgWorkerKeyPress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerKeyPress_DoWork);
            this.bgWorkerKeyPress.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerKeyPress_ProgressChanged);
            // 
            // lbDelayBeforeActivate
            // 
            this.lbDelayBeforeActivate.AutoSize = true;
            this.lbDelayBeforeActivate.Location = new System.Drawing.Point(13, 17);
            this.lbDelayBeforeActivate.Name = "lbDelayBeforeActivate";
            this.lbDelayBeforeActivate.Size = new System.Drawing.Size(110, 13);
            this.lbDelayBeforeActivate.TabIndex = 2;
            this.lbDelayBeforeActivate.Text = "Delay Before Activate";
            // 
            // tbDelayBeforeActivate
            // 
            this.tbDelayBeforeActivate.Location = new System.Drawing.Point(129, 14);
            this.tbDelayBeforeActivate.Name = "tbDelayBeforeActivate";
            this.tbDelayBeforeActivate.Size = new System.Drawing.Size(107, 20);
            this.tbDelayBeforeActivate.TabIndex = 3;
            this.tbDelayBeforeActivate.Text = "0";
            // 
            // lbDelayBeforeActivateMS
            // 
            this.lbDelayBeforeActivateMS.AutoSize = true;
            this.lbDelayBeforeActivateMS.Location = new System.Drawing.Point(252, 17);
            this.lbDelayBeforeActivateMS.Name = "lbDelayBeforeActivateMS";
            this.lbDelayBeforeActivateMS.Size = new System.Drawing.Size(20, 13);
            this.lbDelayBeforeActivateMS.TabIndex = 4;
            this.lbDelayBeforeActivateMS.Text = "ms";
            // 
            // lbLoopAmountTime
            // 
            this.lbLoopAmountTime.AutoSize = true;
            this.lbLoopAmountTime.Location = new System.Drawing.Point(242, 43);
            this.lbLoopAmountTime.Name = "lbLoopAmountTime";
            this.lbLoopAmountTime.Size = new System.Drawing.Size(30, 13);
            this.lbLoopAmountTime.TabIndex = 7;
            this.lbLoopAmountTime.Text = "Time";
            // 
            // PlayMacroRecordOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 176);
            this.Controls.Add(this.lbLoopAmountTime);
            this.Controls.Add(this.lbDelayBeforeActivateMS);
            this.Controls.Add(this.tbDelayBeforeActivate);
            this.Controls.Add(this.lbDelayBeforeActivate);
            this.Controls.Add(this.lbBreakKey);
            this.Controls.Add(this.btnSetBreakKey);
            this.Controls.Add(this.lbKeyPress);
            this.Controls.Add(this.cbLoopUntilBreakKeyPress);
            this.Controls.Add(this.tbLoopAmount);
            this.Controls.Add(this.lbLoopAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlayMacroRecordOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Play Option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbLoopAmount;
        private System.Windows.Forms.TextBox tbLoopAmount;
        private System.Windows.Forms.CheckBox cbLoopUntilBreakKeyPress;
        private System.Windows.Forms.Label lbKeyPress;
        private System.Windows.Forms.Button btnSetBreakKey;
        private System.Windows.Forms.Label lbBreakKey;
        private System.ComponentModel.BackgroundWorker bgWorkerKeyPress;
        private System.Windows.Forms.Label lbDelayBeforeActivate;
        private System.Windows.Forms.TextBox tbDelayBeforeActivate;
        private System.Windows.Forms.Label lbDelayBeforeActivateMS;
        private System.Windows.Forms.Label lbLoopAmountTime;
    }
}
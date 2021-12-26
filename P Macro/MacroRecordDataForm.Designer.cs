namespace P_Macro
{
    partial class MacroRecordDataForm
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
            this.lbType = new System.Windows.Forms.Label();
            this.recordType = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(12, 9);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(31, 13);
            this.lbType.TabIndex = 0;
            this.lbType.Text = "Type";
            // 
            // recordType
            // 
            this.recordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recordType.FormattingEnabled = true;
            this.recordType.Items.AddRange(new object[] {
            "Delay",
            "Keyboard",
            "Mouse"});
            this.recordType.Location = new System.Drawing.Point(49, 6);
            this.recordType.Name = "recordType";
            this.recordType.Size = new System.Drawing.Size(126, 21);
            this.recordType.TabIndex = 1;
            this.recordType.SelectedIndexChanged += new System.EventHandler(this.recordType_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(100, 126);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MacroRecordDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 161);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.recordType);
            this.Controls.Add(this.lbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MacroRecordDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Macro Record Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ComboBox recordType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
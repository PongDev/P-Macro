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
            this.lbKeyPress = new System.Windows.Forms.Label();
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbKeyPress);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "P Macro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbKeyPress;
    }
}


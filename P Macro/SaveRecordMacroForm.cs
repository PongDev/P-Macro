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
    partial class SaveRecordMacroForm : Form
    {
        public string saveName;

        public SaveRecordMacroForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveName = tbSaveName.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}

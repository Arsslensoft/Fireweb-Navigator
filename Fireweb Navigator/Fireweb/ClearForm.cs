using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Fireweb
{
    public partial class ClearForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ClearForm()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Trace.Clear(checkBoxX2.Checked,checkBoxX4.Checked , checkBoxX1.Checked,checkBoxX3.Checked, checkBoxX5.Checked);
            this.Close();
        }
    }
}
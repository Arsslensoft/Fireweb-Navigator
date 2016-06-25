using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;
using System.Reflection;
using Gecko;

namespace Fireweb
{
    public partial class AboutFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        GeckoWebBrowser w;
        public AboutFrm(GeckoWebBrowser wb)
        {
            w = wb;
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
           w.Navigate("http://www.arsslensoft.tk/?q=donate");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutFrm_Load(object sender, EventArgs e)
        {
            Label4.Text = "9.0";
        }
    }
}
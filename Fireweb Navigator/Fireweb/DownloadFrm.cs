using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;

namespace Fireweb
{
    public partial class DownloadFrm : MetroForm
    {
        string file;
        string Url;
        string Mime;
        long size;
        public DownloadFrm(string filename,string url,string mime,long si)
        {
         
            Mime = mime;
            file = filename;
            Url = url;
            size = si;
            InitializeComponent();

            labelX1.Text = "Mime : " + mime;
            labelX2.Text = "Url : "+ url;
            labelX3.Text = "File : " + filename;
            saveFileDialog1.FileName = filename;
   
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Downloader d = new Downloader(saveFileDialog1.FileName, Url,size);
                    d.Show();
                  
                }
                this.Close();
            }
            catch
            {

            }

        }

    }
}

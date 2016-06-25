using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Net;
using System.Diagnostics;

namespace Fireweb
{
    public partial class Downloader : DevComponents.DotNetBar.Metro.MetroForm
    {
        WebClient wb;
        long size;
        Stopwatch sp = new Stopwatch();
        public Downloader(string filename, string url,long si)
        {
            size = si;
            wb = new WebClient();
          
            wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wb_DownloadProgressChanged);
            wb.DownloadFileCompleted += new AsyncCompletedEventHandler(wb_DownloadFileCompleted);
            InitializeComponent();
            labelX1.Text = "Downloading from " + url;
            wb.DownloadFileAsync(new Uri(url), filename);
            sp.Start();
            
        }
        long received = 0;
        long rectime = 0;
        TimeSpan lasttime = TimeSpan.FromSeconds(0);
        void wb_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if(e.Error != null)
                    this.Close();
            }
            catch
            {

            }
        }
        void wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                TimeSpan time = sp.Elapsed.Subtract(lasttime);
                lasttime = sp.Elapsed;
                rectime = e.BytesReceived - received;
                double speed = (double)(rectime / (time.TotalMilliseconds / 1000));
                labelX2.Text = "Downloaded : " + ((int)received).ToString() + "/" + ((int)size).ToString();
                labelX3.Text = "Speed : " + ((int)(speed / 1000)).ToString() + " kb/s";
                progressBarX1.Value = e.ProgressPercentage;

                double st = (double)(e.TotalBytesToReceive / speed);
                labelX4.Text = "Time Remaining : " + GetTime(TimeSpan.FromSeconds(st));

                received = e.BytesReceived;
                
            }
            catch
            {

            }
        }
        string GetTime(TimeSpan t)
        {
            string s = "";
            if (t.Days > 0)
                s += t.Days.ToString() + " Days ";

            if (t.Hours > 0)
                s += t.Hours.ToString() + " Hours ";
            if (t.Minutes > 0)
                s += t.Minutes.ToString() + " Minutes ";
            if (t.Seconds > 0)
                s += t.Seconds.ToString() + " Seconds ";
         

            return s;
        }
     
        private void Downloader_Shown(object sender, EventArgs e)
        {
  
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                wb.CancelAsync();
                this.Close();
            }
            catch
            {

            }
        }

        private void Downloader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Show();
            }
            catch
            {

            }
        }

        private void Downloader_Resize(object sender, EventArgs e)
        {
            try
            {

                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                    notifyIcon1.ShowBalloonTip(1000, "Fireweb Navigator Downloader", "Downloading...", ToolTipIcon.Info);
                }
            }
            catch
            {

            }
        }
    }
}
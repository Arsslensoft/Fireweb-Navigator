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
    public partial class Popupfrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        string URL;
        public Popupfrm(string url)
        {
            URL = url;
            InitializeComponent();
        }
        void UpdateBar()
        {
            try
            {
                ComboUrl.Width = (int)(0.63 * this.Width);
                refreshbtn.Location = new Point(ComboUrl.Width + ComboUrl.Location.X, refreshbtn.Location.Y);
             
            }
            catch
            {

            }
        }
        private void Popupfrm_Resize(object sender, EventArgs e)
        {
            UpdateBar();
        }

        private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Fireweb Navigator - " + webBrowser1.DocumentTitle;
            }
            catch
            {

            }
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("http://www.google.com/");
            }
            catch
            {

            }
        }
        private void backbtn_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.GoBack();
            }
            catch
            {

            }
        }
        private void forwardbtn_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.GoForward();
            }
            catch
            {

            }
        }
        private void refreshbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (refreshbtn.Tooltip == "Refresh")
                    webBrowser1.Reload();
                else
                {

                    webBrowser1.Stop();
                    refreshbtn.Tooltip = "Refresh";
                    refreshbtn.Image = Fireweb.Properties.Resources.reload;

                }
            }
            catch
            {

            }
        }

        private void webBrowser1_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            try
            {
                refreshbtn.Image = Fireweb.Properties.Resources._stop;
                refreshbtn.Tooltip = "Stop";

            }
            catch
            {

            }
        }
        private void webBrowser1_DocumentCompleted(object sender, EventArgs e)
        {
            try
            {
                refreshbtn.Image = Fireweb.Properties.Resources.reload;
                refreshbtn.Tooltip = "Refresh";
            }
            catch
            {

            }
        }
        private void webBrowser1_Navigated(object sender, Gecko.GeckoNavigatedEventArgs e)
        {
            try
            {
                Bitmap bm = Utils.GetFavicon(webBrowser1.Url);
                if (bm != null)
                    faviconbtn.Image = bm;
            }
            catch
            {

            }
        }
        private void faviconbtn_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.ShowPageProperties();
            }
            catch
            {

            }
        }
        private void Popupfrm_Shown(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(URL);
            }
            catch
            {

            }
        }
        
    }
}
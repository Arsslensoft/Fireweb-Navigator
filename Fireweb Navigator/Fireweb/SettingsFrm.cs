using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;

namespace Fireweb
{
    public partial class SettingsFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SettingsFrm()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            try
            {
                hometxt.Text = SettingsManager.Home;
                setxt.Text = SettingsManager.SE;

                fpcheck.Checked = SettingsManager.AllowFirewebPlugin;
                plcheck.Checked = SettingsManager.AllowPlugin;
                jscheck.Checked = SettingsManager.AllowJS;
                imgcheck.Checked = SettingsManager.AllowImage;
                metacheck.Checked = SettingsManager.AllowMeta;
                sframecheck.Checked = SettingsManager.AllowSubframe;
                dnscheck.Checked = SettingsManager.AllowDNS;
                bpopupcheck.Checked = SettingsManager.BlockPopup;
                autocheck.Checked = SettingsManager.AutoComplete;
                regdfcheck.Checked = SettingsManager.RegisterDefalut;
                checkBoxX1.Checked = SettingsManager.Turbo;
                checkBoxX2.Checked = SettingsManager.Glass;
            }
            catch
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsManager.Home = hometxt.Text;
                SettingsManager.SE = setxt.Text;

                SettingsManager.AllowFirewebPlugin = fpcheck.Checked;
                SettingsManager.AllowPlugin = plcheck.Checked;
                SettingsManager.AllowJS = jscheck.Checked;
                SettingsManager.AllowImage = imgcheck.Checked;
                SettingsManager.AllowMeta = metacheck.Checked;
                SettingsManager.AllowSubframe = sframecheck.Checked;
                SettingsManager.AllowDNS = dnscheck.Checked;
                SettingsManager.BlockPopup = bpopupcheck.Checked;
                SettingsManager.AutoComplete = autocheck.Checked;
                SettingsManager.RegisterDefalut = regdfcheck.Checked;
                SettingsManager.Turbo = checkBoxX1.Checked;
                SettingsManager.Glass = checkBoxX2.Checked;
                SettingsManager.Save();
                this.Close();
            }
            catch
            {

            }
        }
    }
}
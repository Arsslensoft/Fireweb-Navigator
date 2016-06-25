using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Gecko;
using DevComponents.AdvTree;

namespace Fireweb
{
    public partial class HistoryFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        GeckoWebBrowser wb;
        public HistoryFrm(GeckoWebBrowser _wb)
        {
            InitializeComponent();
            wb = _wb;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                wb.Navigate(textBoxX1.Text);
            }
            catch
            {

            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                wb.Navigate(textBoxX2.Text);
            }
            catch
            {

            }
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                wb.Navigate(textBoxX3.Text);
            }
            catch
            {

            }
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                wb.Navigate(textBoxX4.Text);
            }
            catch
            {

            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Control c = (Control)superTabControl1.SelectedPanel.Controls[0];
                AdvTree t = (AdvTree)c;
                if (t.SelectedNode != null)
                {
                    Trace.RemoveUrl((string)t.SelectedNode.Tag);
                    t.Nodes.Remove(t.SelectedNode);
                }
            }
            catch
            {

            }
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Trace.ClearHistory();
                advTree1.Nodes.Clear();
                advTree2.Nodes.Clear();
                advTree3.Nodes.Clear();
                advTree4.Nodes.Clear();
            }
            catch
            {

            }
        }

        private void HistoryFrm_Load(object sender, EventArgs e)
        {
            try
            {
                // Today
                int i = 0;
                foreach (FHistoryEntry he in Trace.GetUrlListByDate(DateTime.Now))
                {
                    Node nd = new Node();
                    nd.Name = "today"+i.ToString();
                    nd.Text = he.Title;
                    nd.Tag = he.Url;
                    advTree1.Nodes.Add(nd);
                    i++;
                }
                i = 0;
                // Yesterday
                foreach (FHistoryEntry he in Trace.GetUrlListByDate(DateTime.Now.Subtract(new TimeSpan(24,0,0))))
                {
                    Node nd = new Node();
                    nd.Name = "yesterday" + i.ToString();
                    nd.Text = he.Title;
                    nd.Tag = he.Url;
                    advTree2.Nodes.Add(nd);
                    i++;
                }
                i = 0;

                // This week
                for (int j = 0; j <= 7; j++)
                {
                    foreach (FHistoryEntry he in Trace.GetUrlListByDate(DateTime.Now.Subtract(new TimeSpan(24 * j,0,0))))
                    {
                        Node nd = new Node();
                        nd.Name = "week" + i.ToString();
                        nd.Text = he.Title;
                        nd.Tag = he.Url;
                        advTree3.Nodes.Add(nd);
                        i++;
                    }
                }
                i = 0;
                // All
                foreach (FHistoryEntry he in Trace.GetAll())
                {
                    Node nd = new Node();
                    nd.Name = "all" + i.ToString();
                    nd.Text = he.Title;
                    nd.Tag = he.Url;
                    advTree4.Nodes.Add(nd);
                    i++;
                }

            }
            catch
            {

            }
        }

        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                textBoxX1.Text = (string)advTree1.SelectedNode.Tag;
            }
            catch
            {

            }
        }
        private void advTree2_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                textBoxX2.Text = (string)advTree2.SelectedNode.Tag;
            }
            catch
            {

            }
        }
        private void advTree3_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                textBoxX3.Text = (string)advTree3.SelectedNode.Tag;
            }
            catch
            {

            }
        }
        private void advTree4_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                textBoxX4.Text = (string)advTree4.SelectedNode.Tag;
            }
            catch
            {

            }
        }
    }
}
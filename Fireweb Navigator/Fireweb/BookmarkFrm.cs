using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace Fireweb
{
    public partial class BookmarkFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public BookmarkFrm()
        {
            InitializeComponent();
        }

        private void BookmarkFrm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (string s in Trace.GetBookmarks())
                {
                    Node nd = new Node();
                    nd.Name = "s"+i.ToString();
                    nd.Text = s;
                    advTree1.Nodes.Add(nd);
                    i++;

                }
            }
            catch
            {

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (advTree1.SelectedNode != null)
                {
                    Trace.RemoveBookmark(advTree1.SelectedNode.Text);
                    advTree1.Nodes.Remove(advTree1.SelectedNode);
                }
            }
            catch
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
              
                    Trace.ClearBookmark();
                    advTree1.Nodes.Clear();
            
            }
            catch
            {

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using Gecko;
using DevComponents.AdvTree;

namespace Fireweb
{
    public partial class CookiesForm : MetroForm
    {
        public CookiesForm()
        {
            InitializeComponent();
        }
        public CookiesForm(string host)
        {
            InitializeComponent();
            textBoxX1.Text = host;
            try
            {
                advTree1.Nodes.Clear();
                if (CookieManager.CountCookiesFromHost(textBoxX1.Text) > 0)
                {
                    IEnumerator<Cookie> l = CookieManager.GetCookiesFromHost(textBoxX1.Text);
                   while(l.MoveNext())
                   {
                       Cookie c = l.Current;
                        Node nd = new Node();
                        nd.Name = c.Name;
                        nd.Text = c.Name;
                        nd.Tag = c;
                        Node ndc = new Node();
                        ndc.Name = c.Name + "c";
                        ndc.Text = c.Value;
                        nd.Nodes.Add(ndc);
                        advTree1.Nodes.Add(nd);
                    }
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
                advTree1.Nodes.Clear();
                if (CookieManager.CountCookiesFromHost(textBoxX1.Text) > 0)
                {
                    IEnumerator<Cookie> l = CookieManager.GetCookiesFromHost(textBoxX1.Text);
                    while (l.MoveNext())
                    {
                        Cookie c = l.Current;
                        Node nd = new Node();
                        nd.Name = c.Name;
                        nd.Text = c.Name;
                        nd.Tag = c;
                       Node ndc = new Node();
                     ndc.Name = c.Name+"c";
                        ndc.Text = c.Value;
                        nd.Nodes.Add(ndc);
                        advTree1.Nodes.Add(nd);
                    }
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
                Cookie c = (Cookie)e.Node.Tag;
                labelX2.Text = "Created : "+DateTime.FromFileTimeUtc(c.CreationTime).ToString();
                labelX3.Text = "Expires : " + DateTime.FromFileTimeUtc(c.Expiry).ToString();
                labelX4.Text = "Last Accessed : " + DateTime.FromFileTimeUtc(c.LastAccessed).ToString();
            }
            catch
            {

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Gecko.Plugins;
using DevComponents.AdvTree;

namespace Fireweb
{
    public partial class PluginFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public PluginFrm()
        {
            InitializeComponent();
        }

        private void PluginFrm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (PluginTag p in PluginHost.GetPluginTags())
                {
                    Node nd = new Node();
                    nd.Name = "p" + i.ToString();
                    nd.Text = p.Name;
                    Node d = new Node();
                    d.Name = "d" + i.ToString();
                    d.Text = "Description : "+p.Description;
                    Node v = new Node();
                    v.Name = "v" + i.ToString();
                    v.Text = "Version : "+p.Version;
                    Node f = new Node();
                    f.Name = "f" + i.ToString();
                    f.Text = "Location : " + p.Fullpath;
                    Node s = new Node();
                    s.Name = "s" + i.ToString();
                   s.Text = "Status : "+p.Disabled.ToString();
                   nd.Nodes.Add(d);
                   nd.Nodes.Add(v);
                   nd.Nodes.Add(f);
                   nd.Nodes.Add(s);

                   advTree1.Nodes.Add(nd);
                        i++;
                }
            }
            catch
            {

            }
        }
    }
}
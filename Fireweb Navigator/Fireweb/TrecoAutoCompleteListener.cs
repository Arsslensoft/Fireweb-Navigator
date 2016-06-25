using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Text;
using System.Windows.Forms;

namespace Fireweb
{

    public partial class FirewebAutoCompleteListener : ContextMenuStrip
    {
        public FirewebAutoCompleteListener()
        {
            InitializeComponent();
              }
        public FirewebAutoCompleteListener(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void AddString(string item)
        {
                 this.Items.Add(item);
        }
             
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gecko;
using Gecko.Plugins;
using System.Data.SQLite;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IntPtr[] suggestions;
        uint c;
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.AutoCompleteCalled += new Gecko.AutoCompleteEventHandler(webBrowser1_AutoCompleteCalled);
            webBrowser1.Navigate("http://www.google.com");
            GeckoPreferences.Default["extensions.blocklist.enabled"] = false;
         PluginTag[] el  = PluginHost.GetPluginTags();
        // mozISpellCheckingEngine m_instance = Xpcom.GetService<mozISpellCheckingEngine>("@mozilla.org/spellchecker/engine;1");
        // m_instance.SetDictionaryAttribute("en-US");
        ////MessageBox.Show(m_instance.Check("Hello").ToString());
        ////MessageBox.Show(m_instance.Check("mrabet").ToString());
          
        //    m_instance.Suggest("mrabet", ref suggestions, ref c);
        //MessageBox.Show(c.ToString());

        

        }
        void webBrowser1_AutoCompleteCalled(GeckoWebBrowser instance, string key, Point point, int width, GeckoElement el)
        {
            GeckoSessionHistory history = instance.History;
            for (int i = 0; i <= history.Count - 1; i++)
                MessageBox.Show(history[i].Title);

        }
        void Clear()
        {
     
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //nsICookieManager CookieMan;
            //CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
            //CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
            //CookieMan.RemoveAll();
           // SQLiteConnectionStringBuilder csb = new SQLiteConnectionStringBuilder();
           // csb.DataSource = @"D:\FN9\Bin\Data.sqlite";
           //// csb.Password = "df3.x9a3irh,gw9oè";
           // System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(csb.ConnectionString);
           // con.Open();

           // con.ChangePassword(Encoding.UTF8.GetBytes("df3.x9a3irh,gw9oè"));
           // //con.SetPassword(Encoding.UTF8.GetBytes("df3.x9a3irh,gw9oè"));
           // //con.
          

           // con.Close();
   //         nsINavHistoryService fav;
   //         fav = Xpcom.GetService<nsINavHistoryService>("@mozilla.org/browser/nav-history-service;1");
   //         fav = Xpcom.QueryInterface<nsINavHistoryService>(fav);
   // nsIURI uri =  IOService.CreateNsIUri(webBrowser1.Url.OriginalString);

	
	
   MessageBox.Show(webBrowser1.Docshellforpref().GetAllowDNSPrefetchAttribute().ToString());
   webBrowser1.Docshellforpref().SetAllowImagesAttribute(false);
   MessageBox.Show(webBrowser1.Docshellforpref().GetAllowDNSPrefetchAttribute().ToString());
            //CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
            //CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
            //CookieMan.RemoveAll();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.facebook.com");
        }
    }
}

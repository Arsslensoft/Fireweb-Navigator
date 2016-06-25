using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Gecko;
using Gecko.Events;
using System.IO;
using Gecko.DOM;
using System.Drawing.Drawing2D;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Fireweb
{
  
    public partial class Form1 : Office2007RibbonForm
    {
       internal SuperTabItem GetTab(GeckoWebBrowser wb)
        {
            foreach (BaseItem tab in superTabControl1.Tabs)
            {
               
                if (tab.Name == "tab" + wb.Name.Remove(0, 2))
                    return (SuperTabItem)tab;
            }
            return null;
        }
       internal GeckoWebBrowser GetBrowser(SuperTabItem tab)
       {
           return (tab.AttachedControl.Controls[0] as GeckoWebBrowser);
       }
       internal GeckoNode GetArrtributeByName(string name, GeckoElement el)
       {
           int i =0;
           bool found = false;
           while (i < el.Attributes.Count && !found)
           {
               if (el.Attributes[i].LocalName.ToUpper() == name.ToUpper())
                   found = true;
               i++;
           }
           if (found)
               return el.Attributes[i - 1];
           else
               return null;
       }
       int browsers = 0;
       bool autocompleteshown = false;
       Bitmap bmp;


        string taburi,imgsrc;
      bool ispopupblocked = false;
       Dictionary<string,string> ModifiedInput;
        public Form1()
        {
       
            InitializeComponent();
            try
            {
                ModifiedInput = new Dictionary<string, string>();
                Trace.Initialize();
                // Trace.Clear(false, false, true, true, true);
                SettingsManager.Initialize();
                //this.EnableGlass = SettingsManager.Glass;
             
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR CTOR 1");
            }
            try{
                
                   Xpcom.Initialize();
                   LauncherDialog.Download += new EventHandler<LauncherDialogEvent>(LauncherDialog_Download);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR CTOR 2");
            }
        }
        public void LauncherDialog_Download(object sender, LauncherDialogEvent e)
        {
            try
            {
                nsACString a = new nsACString();

                e.Mime.GetMIMETypeAttribute(a);

                DownloadFrm frm = new DownloadFrm(e.Filename, e.Url, a.ToString(), e.HelperAppLauncher.GetContentLengthAttribute());
                frm.ShowDialog();
            }
            catch
            {

            }
        }
        public ActiveInstance ActiveBrowser
        {
         
            get {
                try
                {
                    return new  ActiveInstance((superTabControl1.SelectedPanel.Controls[0] as Gecko.GeckoWebBrowser), superTabControl1.SelectedTab);
                }
                catch
                {
                    return new ActiveInstance(null,null);
                }
            }
        
        }

        void AddNewTab()
        {
            try
            {
                GeckoWebBrowser wb = new GeckoWebBrowser();
                SuperTabItem tab = new SuperTabItem();
                SuperTabControlPanel tabctrl = new SuperTabControlPanel();
                wb.Name = "wb" + browsers.ToString();
                wb.Dock = DockStyle.Fill;
                wb.Location = new Point(0, 0);
                // events
                wb.ProgressChanged += new EventHandler<GeckoProgressEventArgs>(wb_ProgressChanged);
                wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
                wb.DocumentCompleted += new EventHandler(wb_DocumentCompleted);
                wb.SecurityStateChanged += new EventHandler(wb_SecurityStateChanged);

                wb.ShowContextMenu += new EventHandler<GeckoContextMenuEventArgs>(wb_ShowContextMenu);
                wb.CreateWindow += new EventHandler<GeckoCreateWindowEventArgs>(wb_CreateWindow);
                wb.StatusTextChanged += new EventHandler(wb_StatusTextChanged);
                wb.Navigated += new EventHandler<GeckoNavigatedEventArgs>(wb_Navigated);
                wb.WindowClosed += new EventHandler(wb_WindowClosed);
                wb.Navigating += new EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(wb_Navigating);
                wb.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);
                wb.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
                wb.AutoCompleteCalled += new AutoCompleteEventHandler(wb_AutoCompleteCalled);
                
                wb.DomClick += new EventHandler<DomEventArgs>(wb_DomClick);

             
                wb.NoDefaultContextMenu = true;
                // tab
                tab.AttachedControl = tabctrl;
                tab.Name = "tab" + browsers.ToString();
                tab.Text = "New Tab";
                tab.GlobalItem = false;


                tabctrl.Dock = System.Windows.Forms.DockStyle.Fill;
                tabctrl.Location = new System.Drawing.Point(0, 30);
                tabctrl.Name = "tabcontr" + browsers.ToString();
                tabctrl.TabItem = tab;
                tabctrl.Controls.Add(wb);
                this.superTabControl1.Controls.Add(tabctrl);
                this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            tab});
                this.superTabControl1.SelectedTab = tab;

                wb.Docshellforpref().SetAllowDNSPrefetchAttribute(SettingsManager.AllowDNS);
                wb.Docshellforpref().SetAllowImagesAttribute(SettingsManager.AllowImage);
                wb.Docshellforpref().SetAllowJavascriptAttribute(SettingsManager.AllowDNS);
                wb.Docshellforpref().SetAllowDNSPrefetchAttribute(SettingsManager.AllowJS);
                wb.Docshellforpref().SetAllowMetaRedirectsAttribute(SettingsManager.AllowMeta);
                wb.Docshellforpref().SetAllowPluginsAttribute(SettingsManager.AllowPlugin);
                wb.Docshellforpref().SetAllowSubframesAttribute(SettingsManager.AllowSubframe);

                GeckoPreferences.Default["extensions.blocklist.enabled"] = !SettingsManager.AllowPlugin;
                string sUserAgent = "Mozilla/5.0 (Windows NT 5.1; en-US; rv:21.0; Treco:9.0) Firefox/21.0 (Geckofx/21.0) Fireweb Navigator/9.0";
               Gecko.GeckoPreferences.User["general.useragent.override"] = sUserAgent;
             
                GeckoPreferences.Default["network.http.phishy-userpass-length"]= 255;
               GeckoPreferences.Default["browser.xul.error_pages.enabled"]= true;
              GeckoPreferences.Default["browser.ssl_override_behavior"]= 2;
               GeckoPreferences.Default["browser.xul.error_pages.expert_bad_cert"]= true;
               if (SettingsManager.Turbo)
               {
                   GeckoPreferences.Default["network.http.pipelining.maxrequests"] = 5;
                   GeckoPreferences.Default["network.http.pipelining"] = true;
               }
                browsers++;
            }
            catch(Exception ex)
            {
                AntiCrash.Report(ex);
            }
        }
        void AddNewTab(string url)
        {
            try
            {
                GeckoWebBrowser wb = new GeckoWebBrowser();
                SuperTabItem tab = new SuperTabItem();
                SuperTabControlPanel tabctrl = new SuperTabControlPanel();
                wb.Name = "wb" + browsers.ToString();
                wb.Dock = DockStyle.Fill;
                wb.Location = new Point(0, 0);
                // events
                wb.ProgressChanged += new EventHandler<GeckoProgressEventArgs>(wb_ProgressChanged);
                wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
                wb.DocumentCompleted += new EventHandler(wb_DocumentCompleted);
                wb.SecurityStateChanged += new EventHandler(wb_SecurityStateChanged);

                wb.ShowContextMenu += new EventHandler<GeckoContextMenuEventArgs>(wb_ShowContextMenu);
                wb.CreateWindow += new EventHandler<GeckoCreateWindowEventArgs>(wb_CreateWindow);
                wb.StatusTextChanged += new EventHandler(wb_StatusTextChanged);
                wb.Navigated += new EventHandler<GeckoNavigatedEventArgs>(wb_Navigated);
                wb.WindowClosed += new EventHandler(wb_WindowClosed);
                wb.Navigating += new EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(wb_Navigating);
                wb.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);
                wb.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
                wb.AutoCompleteCalled += new AutoCompleteEventHandler(wb_AutoCompleteCalled);
                wb.DomClick += new EventHandler<DomEventArgs>(wb_DomClick);
                wb.DomMouseUp += new EventHandler<DomMouseEventArgs>(wb_DomMouseUp);

               
                wb.NoDefaultContextMenu = true;
                // tab
                tab.AttachedControl = tabctrl;
                tab.Name = "tab" + browsers.ToString();
                tab.Text = "New Tab";
                tab.GlobalItem = false;


                tabctrl.Dock = System.Windows.Forms.DockStyle.Fill;
                tabctrl.Location = new System.Drawing.Point(0, 30);
                tabctrl.Name = "tabcontr" + browsers.ToString();
                tabctrl.TabItem = tab;
                tabctrl.Controls.Add(wb);
                this.superTabControl1.Controls.Add(tabctrl);
                this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            tab});
                this.superTabControl1.SelectedTab = tab;
                wb.Navigate(url);
               
                wb.Docshellforpref().SetAllowDNSPrefetchAttribute(SettingsManager.AllowDNS);
                wb.Docshellforpref().SetAllowImagesAttribute(SettingsManager.AllowImage);
                wb.Docshellforpref().SetAllowJavascriptAttribute(SettingsManager.AllowDNS);
                wb.Docshellforpref().SetAllowDNSPrefetchAttribute(SettingsManager.AllowJS);
                wb.Docshellforpref().SetAllowMetaRedirectsAttribute(SettingsManager.AllowMeta);
                wb.Docshellforpref().SetAllowPluginsAttribute(SettingsManager.AllowPlugin);
                wb.Docshellforpref().SetAllowSubframesAttribute(SettingsManager.AllowSubframe);
                GeckoPreferences.Default["extensions.blocklist.enabled"] = !SettingsManager.AllowPlugin;
                string sUserAgent = "Mozilla/5.0 (Windows NT 5.1; en-US; rv:21.0; Treco:9.0) Firefox/21.0 (Geckofx/21.0) Fireweb Navigator/9.0";
                Gecko.GeckoPreferences.User["general.useragent.override"] = sUserAgent;
                GeckoPreferences.Default["network.http.phishy-userpass-length"] = 255;
                GeckoPreferences.Default["browser.xul.error_pages.enabled"] = true;
                GeckoPreferences.Default["browser.ssl_override_behavior"] = 2;
                GeckoPreferences.Default["browser.xul.error_pages.expert_bad_cert"] = true;

                if (SettingsManager.Turbo)
                {
                    GeckoPreferences.Default["network.http.pipelining.maxrequests"] = 5;
                    GeckoPreferences.Default["network.http.pipelining"] = true;
                }
                browsers++;
            }
            catch (Exception ex)
            {
                AntiCrash.Report(ex);
            }
        }

        #region Gecko browser events
        void wb_DomMouseUp(object sender, DomMouseEventArgs e)
        {

        }
        void wb_DomClick(object sender, DomEventArgs e)
        {
            try
            {

                if (ActiveBrowser.Browser.Document.ActiveElement.TagName == "INPUT")
                {
                    ActiveBrowser.Browser.Document.ActiveElement.SetAttribute("treco", "true");
                    if (!ModifiedInput.ContainsKey((ActiveBrowser.Browser.Document.ActiveElement as GeckoInputElement).Id))
                        ModifiedInput.Add((ActiveBrowser.Browser.Document.ActiveElement as GeckoInputElement).Id, ActiveBrowser.Browser.Url.Host);
                    
                    if ((ActiveBrowser.Browser.Document.ActiveElement as GeckoInputElement).GetAttribute("TACS") == "true")
                        autocompleteshown = true;
                    else
                        autocompleteshown = false;
            
                }
            }
            catch
            {

            }
        }
        void wb_AutoCompleteCalled(GeckoWebBrowser instance, string key, Point point, int width, GeckoElement ael)
        {
            if ((ael as GeckoInputElement).GetAttribute("autocomplete") == "off")
            {
                (ael as GeckoInputElement).SetAttribute("TACS", "true");
            }
            else if ((ael as GeckoInputElement).Value == string.Empty)
            {
                (ael as GeckoInputElement).SetAttribute("TACS", "false");
            }
            else if ((ael as GeckoInputElement).Type.ToLower() == "password")
            {
                (ael as GeckoInputElement).SetAttribute("TACS", "true");
            }
            else
            {
                FirewebAutoCompleteListener Listener = new FirewebAutoCompleteListener();
                Listener.Name = "FirewebAutoCompleteListener1";
                Listener.RenderMode = ToolStripRenderMode.System;
                Listener.ItemClicked += new ToolStripItemClickedEventHandler(Listener_ItemClicked);
                List<string> auto = Trace.GetAutoComplete(key, instance.Url.Host, (ael as GeckoInputElement).Name);
              
                foreach (string dt in auto)
                    Listener.AddString(dt);

                if (SettingsManager.AutoComplete == true && !autocompleteshown)
                {
                    Listener.Show(this, this.PointToClient(MousePosition), ToolStripDropDownDirection.BelowRight);
                    autocompleteshown = true;
                }
       
            }
        }
        private void Listener_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (ActiveBrowser.Browser.Document.ActiveElement.TagName == "INPUT")
                {
                    GeckoElement el = ActiveBrowser.Browser.Document.ActiveElement;
                    (el as GeckoInputElement).Value = e.ClickedItem.Text;
                    (el as GeckoInputElement).SetAttribute("TACS", "true");
                }
            
            }
            catch
            {

            }
        }
        void wb_ProgressChanged(object sender, GeckoProgressEventArgs e)
        {
            try
            {
                progress.Maximum = (int)e.MaximumProgress;
                progress.Value = (int)e.CurrentProgress;
            }
            catch
            {

            }
        }
        void wb_DocumentTitleChanged(object sender, EventArgs e)
        {
            try
            {

                SuperTabItem tab = GetTab( (GeckoWebBrowser)sender);
                if (tab != null)
                {
                    if (((GeckoWebBrowser)sender).DocumentTitle.Length > 18)
                    {
                        string title = ((GeckoWebBrowser)sender).DocumentTitle;
                        string titleone = title.Substring(0, 18).ToString() + "...";
                        tab.Text = titleone;
                    }
                    else
                        tab.Text = ((GeckoWebBrowser)sender).DocumentTitle;

                 
                }
           
                this.Text = ActiveBrowser.Browser.DocumentTitle + " - Fireweb Navigator";
            if(!Newincowin.Checked)
                Trace.AddUrl(((GeckoWebBrowser)sender).Url.OriginalString, ((GeckoWebBrowser)sender).DocumentTitle);
            }
            catch
            {

            }
        }
        void wb_DocumentCompleted(object sender, EventArgs e)
        {
                 progress.Visible = false;
                 refreshbtn.Image = Fireweb.Properties.Resources.reload;
                 refreshbtn.Tooltip = "Refresh"; 
        }
        void wb_SecurityStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (((GeckoWebBrowser)sender).SecurityState == GeckoSecurityState.Insecure)
                    stlb.Image = Fireweb.Properties.Resources.unlock;
                else if (((GeckoWebBrowser)sender).SecurityState == GeckoSecurityState.Broken)
                    stlb.Image = null;
                else
                    stlb.Image = Fireweb.Properties.Resources.lock_arrow;
            }
            catch
            {

            }
        }
        void wb_ShowContextMenu(object sender, GeckoContextMenuEventArgs e)
        {
            try
            {
                if (e.AssociatedLink != null)
                {
                    taburi = e.AssociatedLink;

                }
                else
                {
                    GeckoElement ge = (GeckoElement)e.TargetNode;
                    if (ge.ParentElement.TagName.ToUpper() == "A")
                    {
                        ge = ge.ParentElement;
                    }
                    if (ge.TagName.ToUpper() == "A")
                    {
                        taburi = "";
                      GeckoNode att = GetArrtributeByName("href", ge);
                        if(att != null)
                        {
                        if (att.TextContent[0] == '/' || att.TextContent[0] == '#')
                        {
                            taburi += "http://" + this.ActiveBrowser.Browser.Url.Host;


                            if (att.TextContent[0] != '/')
                                taburi += "/";
                      
                        }
                        taburi += att.TextContent;
                        }
                    }

                }

                if (e.ImageSrc != null)
                {
                    imgsrc = e.ImageSrc.ToString();
                }
                else
                {
                    GeckoElement fe = (GeckoElement)e.TargetNode;
                    if (fe.ParentElement.TagName.ToUpper() == "IMG")
                    {
                        fe = fe.ParentElement;
                    }
                    if (fe.TagName.ToUpper() == "IMG")
                    {
                        imgsrc = "";
                          GeckoNode att = GetArrtributeByName("src", fe);
                          if (att != null)
                          {
                              if (att.TextContent[0] == '/' || att.TextContent[0] == '#')
                              {
                                  imgsrc += "http://" + this.ActiveBrowser.Browser.Url.Host;


                                  if (att.TextContent[0] != '/')
                                  {
                                      imgsrc += "/";
                                  }
                              }
                              imgsrc += att.TextContent;
                          }
                    }

                }
                openintbcn.Visible = this.ActiveBrowser.Browser.CanCopyLinkLocation;
                savelnkcn.Visible = this.ActiveBrowser.Browser.CanCopyLinkLocation;
                savepictascn.Visible = this.ActiveBrowser.Browser.CanCopyImageContents;
                undocn.Visible = this.ActiveBrowser.Browser.CanUndo;
                redocn.Visible = this.ActiveBrowser.Browser.CanRedo;
                copycn.Visible = this.ActiveBrowser.Browser.CanCopySelection;
                cutcn.Visible = this.ActiveBrowser.Browser.CanCutSelection;
                pastecn.Visible = this.ActiveBrowser.Browser.CanPaste;
                Copyimgcntcn.Visible = this.ActiveBrowser.Browser.CanCopyImageContents;
                copyimglnktcn.Visible = this.ActiveBrowser.Browser.CanCopyImageLocation;
                copylnkcn.Visible = this.ActiveBrowser.Browser.CanCopyLinkLocation;
                selectallcn.Visible = this.ActiveBrowser.Browser.CanSelect;
                scanlnkcn.Visible = this.ActiveBrowser.Browser.CanCopyLinkLocation;
                bEditPopup.Displayed = false;
                bEditPopup.PopupMenu(PointToClient(MousePosition));
            }
            catch
            {

            }
       }
        void wb_CreateWindow(System.Object sender, GeckoCreateWindowEventArgs e)
        {

            try
            {

                if (SettingsManager.BlockPopup == true)
                {
                    e.WebBrowser = ActiveBrowser.Browser;
                    MessageBoxEx.Show("A popup window has been blocked", "Popup Blocker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ispopupblocked = true;

                }
                else
                {
                    Popupfrm frm = new Popupfrm(e.WebBrowser.Url.OriginalString);
                    e.WebBrowser = frm.webBrowser1;
                    frm.Show();
                }
            }
            catch (Exception Ex)
            {
                AntiCrash.Report(Ex);
            }
        }
        void wb_StatusTextChanged(object sender, EventArgs e)
        {
            try
            {
                stlb.Text = ActiveBrowser.Browser.StatusText;
            }
            catch
            {

            }
        }
        void wb_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            try
            {
                if (e.Uri.ToString().Contains("/Fireweb Navigator/WBCACHE/"))
                {
                    ComboUrl.Text = "FN:Cache";
                }
                else if (e.Uri.ToString().Contains("Fireweb Navigator/temp/welcome.html"))
                {
                    ComboUrl.Text = "FN:Welcome";
                }
                else if (e.Uri.ToString().Contains("about:blank"))
                {
                    stlb.Text = "BLANK";
                }
                else
                {
                    ComboUrl.Items.Add(ActiveBrowser.Browser.Url.OriginalString);
                    ComboUrl.Text = this.ActiveBrowser.Browser.Url.ToString();
                   
                }
              
                if (!(this.ActiveBrowser.Browser.Url == null || this.ActiveBrowser.Browser.Url.ToString() == "about:blank" || this.ActiveBrowser.Browser.Url.ToString().StartsWith("file:///")))
                {
                    Bitmap bm = Utils.GetFavicon(e.Uri);
                    if (bm != null)
                        faviconbtn.Image = bm;
                }
              ModifiedInput.Clear();
                autocompleteshown = false;
            }
            catch(Exception ex)
            {
                AntiCrash.Report(ex);
            }
        }
        void wb_WindowClosed(object sender, EventArgs e)
        {
            try
            {
                SuperTabItem tab = GetTab((GeckoWebBrowser)sender);
                this.superTabControl1.CloseTab(tab);
            }
            catch
            {

            }
        }
        void wb_Navigating(object sender, GeckoNavigatingEventArgs e)
        {
            try
            {
                refreshbtn.Image = Fireweb.Properties.Resources._stop;
                refreshbtn.Tooltip = "Stop"; 
                if (ispopupblocked == true)
                {
                    e.Cancel = true;
                    ispopupblocked = false;
                }
                else
                {
                    ispopupblocked = false;
                }
                progress.Visible = true;
                if (e.Uri.ToString().Contains(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Fireweb Navigator\\temp\\welcome.html"))
                {
                    ComboUrl.Text = "FN:Welcome";
                }
                else if (e.Uri.ToString().Contains("/Fireweb Navigator/WBCACHE/"))
                {
                    ComboUrl.Text = "FN:Cache";

                }

                if (SettingsManager.AutoComplete == true)
                    AddAutoComplete();

                autocompleteshown = false;

            }
            catch
            {

            }
        }
        void wb_CanGoBackChanged(object sender, EventArgs e)
        {
            backbtn.Enabled = (ActiveBrowser.Browser.CanGoBack);
        }
        void wb_CanGoForwardChanged(object sender, EventArgs e)
        {
            forwardbtn.Enabled = (ActiveBrowser.Browser.CanGoForward);
        }
        void AddAutoComplete()
        {
            try
            {
                if (ModifiedInput.Count > 0)
                {
                    foreach (KeyValuePair<string,string> lsti in ModifiedInput)
                    {
                        GeckoElement el = ActiveBrowser.Browser.Document.GetElementById(lsti.Key);
                        if ((el as GeckoInputElement).Type == "text")
                            Trace.AddAutoComplete((el as GeckoInputElement).Value,lsti.Value, (el as GeckoInputElement).Name);
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            try
            {
                SuperTabItem tab = (SuperTabItem)e.NewValue;
                GeckoWebBrowser wb = GetBrowser(tab);
                if (wb.Url == null)
                {
                    //if (Settingsreader.EnablePlugins == true)
                    //{
                    //    if (TrecoWebBrowser1() != null)
                    //    {
                    //        foreach (Treco.Types.AvailablePlugin pluginOn in TrecoWebBrowser1.Plugins)
                    //        {
                    //            pluginOn.Instance.TrecoWB = TrecoWebBrowser1();
                    //        }

                    //    }
                    //    else
                    //    {
                    //    }

                    //}
                    //else
                    //{
                    //}
                }
                else if (wb.Url.ToString().StartsWith("about:"))
                {
                    //if (Settingsreader.EnablePlugins == true)
                    //{
                    //    if (TrecoWebBrowser1() != null)
                    //    {
                    //        foreach (Treco.Types.AvailablePlugin pluginOn in TrecoWebBrowser1.Plugins)
                    //        {
                    //            pluginOn.Instance.TrecoWB = TrecoWebBrowser1();
                    //        }

                    //    }
                    //    else
                    //    {
                    //    }

                    //}
                    //else
                    //{
                    //}
                }
                else
                {
                    //if (Settingsreader.EnablePlugins == true)
                    //{
                    //    if (TrecoWebBrowser1() != null)
                    //    {
                    //        foreach (Treco.Types.AvailablePlugin pluginOn in TrecoWebBrowser1.Plugins)
                    //        {
                    //            pluginOn.Instance.TrecoWB = TrecoWebBrowser1();
                    //        }

                    //    }
                    //    else
                    //    {
                    //    }

                    //}
                    //else
                    //{
                    //}

                    stlb.Text = wb.StatusText;
                    this.Text = wb.DocumentTitle + " - Fireweb Navigator";

                    if (wb.Url.ToString().Contains("/Fireweb Navigator/WBCACHE/"))
                         ComboUrl.Text = "FN:Cache";
                    else if (wb.Url.ToString().Contains("Fireweb Navigator/temp/welcome.html"))
                        ComboUrl.Text = "FN:Welcome";
                    else if (wb.Url.ToString().Contains("about:blank"))
                        stlb.Text = "BLANK";
                    else
                        ComboUrl.Text = wb.Url.ToString();


                    if (wb.DocumentTitle.Length > 18)
                    {
                        string title = wb.DocumentTitle;
                        string titleone = title.Substring(0, 18).ToString() + "...";
                       tab.Text = titleone;
                    }
                    else
                        tab.Text = wb.DocumentTitle;

                    faviconbtn.Image = Utils.GetFavicon(wb.Url);
                    backbtn.Enabled = wb.CanGoBack;
                    forwardbtn.Enabled = wb.CanGoForward;
                    
                }

            }
            catch
            {

            }
            finally
            {
            }
        }
        private void superTabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            try
            {
                if (superTabControl1.Tabs.Count == 2)
                {
                    if (MessageBoxEx.Show("If you close this tab Fireweb Navigator will close", "Fireweb Navigator Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                        e.Cancel = true;
                    else
                        this.Close();
                }

            }
            catch
            {

            }
        }

        #region contextmenu
        private void entofr_Click(object sender, EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "en");
        }
        private void entocn_Click(object sender, EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "zh-CN");
        }
        private void entoit_Click(object sender, EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "it");
        }
        private void entoesp_Click(System.Object sender, System.EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser,"es");
        }
        private void entoar_Click(System.Object sender, System.EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "ar");
        }
        private void frtoen_Click(System.Object sender, System.EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "nl");
        }
        private void artoen_Click(System.Object sender, System.EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "fr");
        }
        private void itoen_Click(System.Object sender, System.EventArgs e)
        {
            Utils.TranslateDocument(ActiveBrowser.Browser, "de");
        }

        private void openintbcn_Click(object sender, EventArgs e)
        {
            AddNewTab(taburi);
        }
        private void scanlnkcn_Click(object sender, EventArgs e)
        {
            Uri url = new Uri(taburi);
            AddNewTab("http://www.avgthreatlabs.com/sitereports/domain/?domain=" + url.Host.ToString() + "&check=");
        }
        private void savelnkcn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           
            saveFileDialog1.Filter = "text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Fireweb Navigator Save Link";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, taburi);

        }
        private void saveascn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "htm files (*.htm)|*.htm|html files (*.html)|*.html|All files (*.*)|*.*";
                saveFileDialog1.Title = "Fireweb Navigator Save Page";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ActiveBrowser.Browser.SaveDocument(saveFileDialog1.FileName);
                }
            }
            catch(Exception ex)
            {
                AntiCrash.Report(ex);
            }
        }
        private void savepictascn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp|PNG files (*.png)|*.png|Gif files (*.gif)|*.gif|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.Net.WebClient webclient = new System.Net.WebClient();
                    System.IO.MemoryStream memorystream = new System.IO.MemoryStream(webclient.DownloadData(imgsrc));
                    Image image = Image.FromStream(memorystream);
                    image.Save(saveFileDialog1.FileName);
                }
            }
            catch(Exception ex)
            {
                AntiCrash.Report(ex);
            }
        }
        private void Copyimgcntcn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.CopyImageContents();
            }
            catch
            {

            }
        }
        private void copylnkcn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.CopyLinkLocation();
            }
            catch
            {

            }
        }
        private void copyimglnktcn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.CopyImageLocation();
            }
            catch
            {

            }
        }
        private void undocn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.Undo();
            }
            catch
            {

            }
        }
        private void redocn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.Redo();
            }
            catch
            {

            }
        }
        private void cutcn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.CutSelection();
            }
            catch
            {

            }
        }
        private void copycn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.CopySelection();
            }
            catch
            {

            }
        }
        private void pastecn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.Paste();
            }
            catch
            {

            }
        }
        private void selectallcn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.SelectAll();
            }
            catch
            {

            }
        }
        private void viewsourcecn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.ViewSource();
            }
            catch
            {

            }
        }
        private void propercn_Click(object sender, EventArgs e)
        {
             try
            {
                ActiveBrowser.Browser.ShowPageProperties();
            }
            catch
            {

            }
        }
        private void readcn_Click(object sender, EventArgs e)
        {

        }

        private void spellcheckmn_Click(object sender, EventArgs e)
        {

        }
# endregion

        internal void TakeScreenShot()
        {
            try
            {
        
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Fireweb Navigator";
                if (Directory.Exists(folder))
                {
                    GeckoWebBrowser frm = ActiveBrowser.Browser;
                    bmp = new Bitmap(frm.Width, frm.Height);
                   
                        frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                        bmp.Save(folder + "\\" + ActiveBrowser.Browser.Document.Domain + ".png");
              
                }
                else
                {
                    Directory.CreateDirectory(folder);
                    GeckoWebBrowser frm = ActiveBrowser.Browser;
                    bmp = new Bitmap(frm.Width, frm.Height);
                   
                        frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                        bmp.Save(folder + "\\" + ActiveBrowser.Browser.Document.Domain + ".png");
                  

                }

            }
            catch (Exception ex)
            {
                AntiCrash.Report(ex);
            }
            finally
            {
            }

        }
       
        #region Form events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                    ActiveBrowser.Browser.Navigate(SettingsManager.SE + searchbox.Text);
                else if (e.KeyCode == Keys.U && e.Control)
                    ActiveBrowser.Browser.Undo();
                else if (e.KeyCode == Keys.BrowserBack)
                    ActiveBrowser.Browser.GoBack();
                else if (e.KeyCode == Keys.F && e.Control)
                {
                    if (Toolbar.Visible == true)
                    {
                        Toolbar.Visible = false;
                        panelEx2.Height = 22;

                    }
                    else
                    {
                        Toolbar.Visible = true;
                        panelEx2.Height = 45;
                    }
                }
                else if (e.KeyCode == Keys.BrowserForward)
                    ActiveBrowser.Browser.GoForward();
                else if (e.KeyCode == Keys.BrowserRefresh)
                    ActiveBrowser.Browser.Refresh();
                else if (e.KeyCode == Keys.BrowserStop)
                    ActiveBrowser.Browser.Stop();
            }
            catch
            {

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AddNewTab(SettingsManager.Home);
                Toolbar.Visible = false;
                panelEx2.Height = 22;
            }
            catch(Exception ex)
            {
                AntiCrash.Report(ex);
            }
        }
        void UpdateBar()
        {
            try
            {
                ComboUrl.Width = (int)(0.675 * this.Width);
                refreshbtn.Location = new Point(ComboUrl.Width + ComboUrl.Location.X, refreshbtn.Location.Y);
                searchbox.Location = new Point(refreshbtn.Location.X + refreshbtn.Size.Width + 6, searchbox.Location.Y);
                searchbox.Size = new Size((int)(0.15 * this.Width), searchbox.Size.Height);
                searchbtn.Location = new Point(searchbox.Location.X + searchbox.Size.Width, searchbtn.Location.Y);
            }
            catch
            {

            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Width != 1141)
                UpdateBar();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               
            }
            catch
            {

            }
        }

        #endregion

        #region Navigate
        private void backbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.GoBack();
            }
            catch
            {

            }
        }
        private void forwardbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.GoForward();
            }
            catch
            {

            }
        }
        private void homebtn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.Navigate(SettingsManager.Home);
            }
            catch
            {

            }
        }
        private void faviconbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.ShowPageProperties();
            }
            catch
            {

            }
        }
        private void ComboUrl_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ActiveBrowser.Browser.Navigate(ComboUrl.Text);
                    ComboUrl.Items.Clear();

                }
                else
                {
                    

                    string[] l = Trace.GetUrlList(ComboUrl.Text, 10).ToArray();
                    foreach(string s in l)
                        if(!ComboUrl.Items.Contains(s))
                                 ComboUrl.Items.Add(s);   
                }
       //         e.Handled = true;
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
                    ActiveBrowser.Browser.Reload();
                else
                {

                    ActiveBrowser.Browser.Stop();
                    refreshbtn.Tooltip = "Refresh";
                    refreshbtn.Image = Fireweb.Properties.Resources.reload;

                }
            }
            catch
            {

            }
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.Navigate(SettingsManager.SE + searchbox.Text);
            }
            catch
            {

            }
        }
        private void searchbox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                ActiveBrowser.Browser.Navigate(SettingsManager.SE + searchbox.Text);

                e.Handled = true;
            }
            catch
            {

            }
        }
        #endregion

     
        private void certmgrmn_Click(object sender, EventArgs e)
        {    try{
            ChromeDialog frm = new ChromeDialog();
            frm.Name = "Chromefrm";
            frm.Text = "Chrome Manager";
            frm.Show();
            frm.WebBrowser.Navigate("chrome://pippki/content/certManager.xul");
                }
            catch{

            }
        }
        private void passmgrmn_Click(object sender, EventArgs e)
        {
            try{
            ChromeDialog frm = new ChromeDialog();
            frm.Name = "Chromefrm";
            frm.Text = "Chrome Manager";
            frm.Show();
            frm.WebBrowser.Navigate("chrome://passwordmgr/content/passwordManager.xul");
            }
            catch
            {

            }
        }
        private void addtb_Click(object sender, EventArgs e)
        {
            AddNewTab();
        }
        private void Newtbmn_Click(object sender, EventArgs e)
        {
            AddNewTab();
        }
        private void Newinmn_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 frm = new Form1();
                frm.Show();
            }
            catch
            {

            }
        }
        private void historymn_Click(object sender, EventArgs e)
        {
            try
            {
                HistoryFrm frm = new HistoryFrm(ActiveBrowser.Browser);
                frm.Show();
            }
            catch
            {

            }
        }
        private void bkmkmn_Click(object sender, EventArgs e)
        {
            try
            {
                BookmarkFrm frm = new BookmarkFrm();
                frm.Show();
            }
            catch
            {

            }
        }
       
        private void openmn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.InitialDirectory = @"c:\";
                      openFileDialog1.Filter = "htm files (*.htm)|*.htm|html files (*.html)|*.html|xhtml files (*.xhtml)|*.xhtml|aspx files (*.aspx)|*.aspx|All files (*.*)|*.*";
                   openFileDialog1.FilterIndex = 2;
                   openFileDialog1.RestoreDirectory = true;
                   openFileDialog1.Title = "FireWeb Navigator - File Opening";
                   if (openFileDialog1.ShowDialog() == DialogResult.OK)
                       ActiveBrowser.Browser.Navigate(openFileDialog1.FileName);

            }
            catch
            {

            }
        }
        private void savemn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog openFileDialog1 = new SaveFileDialog();
                openFileDialog1.InitialDirectory = @"c:\";
                openFileDialog1.Filter = "htm files (*.htm)|*.htm|html files (*.html)|*.html|xhtml files (*.xhtml)|*.xhtml|aspx files (*.aspx)|*.aspx|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = "FireWeb Navigator - File Saving";
             
                    ActiveBrowser.Browser.SaveDocument(openFileDialog1.FileName);

            }
            catch
            {

            }
        }
        private void wbconsolemn_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewTab("chrome://global/content/console.xul");
            }
            catch
            {

            }
        }
        private void zoomn_Click(object sender, EventArgs e)
        {
            zoomslider.Visible = zoomn.Checked;
        }
        private void findmn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Toolbar.Visible == true)
                {
                    Toolbar.Visible = false;
                    panelEx2.Height = 22;

                }
                else
                {
                    Toolbar.Visible = true;
                    panelEx2.Height = 45;
                }
            }
            catch
            {

            }
        }
        private void Find_Click(object sender, EventArgs e)
        {
            try
            {
                string jsurl = "javascript:window.find(" + "'" + Findbox.Text + "'" + ", false, false, true, false, true, false); void(0);";
               ActiveBrowser.Browser.Navigate(jsurl);
            }
            catch
            {

            }
        }
        private void takescrmn_Click(object sender, EventArgs e)
        {
            TakeScreenShot();
        }
        private void undomn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.Undo();
            }
            catch
            {

            }
        }
        private void redomn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.Redo();
            }
            catch
            {

            }
        }
        private void copymn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.CopySelection();
            }
            catch
            {

            }
        }
        private void Cutmn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.CutSelection();
            }
            catch
            {

            }
        }
       private void pastemn_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveBrowser.Browser.Paste();
            }
            catch
            {

            }
        }
       private void selectallmn_Click(object sender, EventArgs e)
       {
           try
            {
                ActiveBrowser.Browser.SelectAll();
            }
            catch
            {

            }
       }
       private void viewsrcmn_Click(object sender, EventArgs e)
       {
           try
            {
                ActiveBrowser.Browser.ViewSource();
            }
            catch
            {

            }
       }
       private void Restoremn_Click(object sender, EventArgs e)
       {
           try
           {
               CookiesForm frm = new CookiesForm();
               frm.Show();
           }
           catch
           {

           }
       }
       private void addonsmn_Click(object sender, EventArgs e)
       {
           try
           {
               PluginFrm frm = new PluginFrm();
               frm.Show();
           }
           catch
           {

           }
       }
       private void Cleanermn_Click(object sender, EventArgs e)
       {
           try
           {
               ClearForm frm = new ClearForm();
               frm.ShowDialog();
           }
           catch
           {

           }
       }
       private void settingsmn_Click(object sender, EventArgs e)
       {
           try
           {
               SettingsFrm frm = new SettingsFrm();
               frm.ShowDialog();
           }
           catch
           {

           }
       }
       private void Aboutmn_Click(object sender, EventArgs e)
       {
           try
           {
               AboutFrm frm = new AboutFrm(ActiveBrowser.Browser);
               frm.ShowDialog();
           }
           catch
           {

           }
       }
       private void Exitmn_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void zoomslider_ValueChanged(object sender, EventArgs e)
       {
           try
           {
               float c = ActiveBrowser.Browser.GetMarkupDocumentViewer().GetFullZoomAttribute();
               double z = double.Parse(zoomslider.Value.ToString()) / 100;
               float f = (float)z;
               ActiveBrowser.Browser.GetMarkupDocumentViewer().SetFullZoomAttribute(f);
           }
           catch
           {

           }
       }

       private void stlb_Click(object sender, EventArgs e)
       {
           try
           {
               if (ActiveBrowser.Browser.SecurityState != GeckoSecurityState.Broken && ActiveBrowser.Browser.SecurityState != GeckoSecurityState.Insecure)
               {
                   HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ActiveBrowser.Browser.Url.OriginalString);
                   request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                   request.Accept = "gzip, deflate";
                   HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                   response.Close();

                   //retrieve the ssl cert and assign it to an X509Certificate object
                   X509Certificate cert = request.ServicePoint.Certificate;

                   //convert the X509Certificate to an X509Certificate2 object by passing it into the constructor
                   X509Certificate2 cert2 = new X509Certificate2(cert);

                   //display the cert dialog box
                   X509Certificate2UI.DisplayCertificate(cert2);
               }
           }
           catch
           {

           }
       }

  
       

      
    }
}

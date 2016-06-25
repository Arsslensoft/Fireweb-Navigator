using Gecko;
namespace Fireweb
{
    partial class Popupfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popupfrm));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.refreshbtn = new DevComponents.DotNetBar.ButtonX();
            this.ComboUrl = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.faviconbtn = new DevComponents.DotNetBar.ButtonX();
            this.homebtn = new DevComponents.DotNetBar.ButtonX();
            this.forwardbtn = new DevComponents.DotNetBar.ButtonX();
            this.backbtn = new DevComponents.DotNetBar.ButtonX();
            this.webBrowser1 = new Gecko.GeckoWebBrowser();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.refreshbtn);
            this.panelEx1.Controls.Add(this.ComboUrl);
            this.panelEx1.Controls.Add(this.faviconbtn);
            this.panelEx1.Controls.Add(this.homebtn);
            this.panelEx1.Controls.Add(this.forwardbtn);
            this.panelEx1.Controls.Add(this.backbtn);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(455, 28);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // refreshbtn
            // 
            this.refreshbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.refreshbtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.refreshbtn.EnableMarkup = false;
            this.refreshbtn.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.refreshbtn.Image = global::Fireweb.Properties.Resources.reload;
            this.refreshbtn.Location = new System.Drawing.Point(417, 3);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(30, 22);
            this.refreshbtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.refreshbtn.TabIndex = 14;
            this.refreshbtn.Tooltip = "Refresh";
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // ComboUrl
            // 
            this.ComboUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboUrl.DisplayMember = "Text";
            this.ComboUrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboUrl.Enabled = false;
            this.ComboUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUrl.ForeColor = System.Drawing.Color.Black;
            this.ComboUrl.FormattingEnabled = true;
            this.ComboUrl.ItemHeight = 16;
            this.ComboUrl.Location = new System.Drawing.Point(124, 3);
            this.ComboUrl.Name = "ComboUrl";
            this.ComboUrl.Size = new System.Drawing.Size(293, 22);
            this.ComboUrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ComboUrl.TabIndex = 13;
            this.ComboUrl.WatermarkText = "Type url adress here";
            // 
            // faviconbtn
            // 
            this.faviconbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.faviconbtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.faviconbtn.EnableMarkup = false;
            this.faviconbtn.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.faviconbtn.Image = global::Fireweb.Properties.Resources.certificate;
            this.faviconbtn.Location = new System.Drawing.Point(94, 3);
            this.faviconbtn.Name = "faviconbtn";
            this.faviconbtn.Size = new System.Drawing.Size(30, 22);
            this.faviconbtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.faviconbtn.TabIndex = 3;
            this.faviconbtn.Tooltip = "Favicon";
            this.faviconbtn.Click += new System.EventHandler(this.faviconbtn_Click);
            // 
            // homebtn
            // 
            this.homebtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.homebtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.homebtn.EnableMarkup = false;
            this.homebtn.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.homebtn.Image = global::Fireweb.Properties.Resources.home;
            this.homebtn.Location = new System.Drawing.Point(64, 3);
            this.homebtn.Name = "homebtn";
            this.homebtn.Size = new System.Drawing.Size(30, 22);
            this.homebtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.homebtn.TabIndex = 2;
            this.homebtn.Tooltip = "Home";
            this.homebtn.Click += new System.EventHandler(this.homebtn_Click);
            // 
            // forwardbtn
            // 
            this.forwardbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.forwardbtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.forwardbtn.EnableMarkup = false;
            this.forwardbtn.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.forwardbtn.Image = global::Fireweb.Properties.Resources.forward;
            this.forwardbtn.Location = new System.Drawing.Point(34, 3);
            this.forwardbtn.Name = "forwardbtn";
            this.forwardbtn.Size = new System.Drawing.Size(30, 22);
            this.forwardbtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.forwardbtn.TabIndex = 1;
            this.forwardbtn.Tooltip = "Forward";
            this.forwardbtn.Click += new System.EventHandler(this.forwardbtn_Click);
            // 
            // backbtn
            // 
            this.backbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backbtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.backbtn.EnableMarkup = false;
            this.backbtn.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backbtn.Image = global::Fireweb.Properties.Resources.back;
            this.backbtn.Location = new System.Drawing.Point(4, 3);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(30, 22);
            this.backbtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backbtn.TabIndex = 0;
            this.backbtn.Tooltip = "Back";
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 28);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(455, 368);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.UseHttpActivityObserver = false;
            this.webBrowser1.DocumentCompleted += new System.EventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.EventHandler<Gecko.GeckoNavigatedEventArgs>(this.webBrowser1_Navigated);
            this.webBrowser1.DocumentTitleChanged += new System.EventHandler(this.webBrowser1_DocumentTitleChanged);
            this.webBrowser1.Navigating += new System.EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(this.webBrowser1_Navigating);
            // 
            // Popupfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 396);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Popupfrm";
            this.Text = "Fireweb Navigator";
            this.Shown += new System.EventHandler(this.Popupfrm_Shown);
            this.Resize += new System.EventHandler(this.Popupfrm_Resize);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX refreshbtn;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ComboUrl;
        private DevComponents.DotNetBar.ButtonX faviconbtn;
        private DevComponents.DotNetBar.ButtonX homebtn;
        private DevComponents.DotNetBar.ButtonX forwardbtn;
        private DevComponents.DotNetBar.ButtonX backbtn;
        internal GeckoWebBrowser webBrowser1;
    }
}
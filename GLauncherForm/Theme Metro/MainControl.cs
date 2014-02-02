using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Diagnostics;
using GLModule.Constants;

namespace GLauncherForm.Theme_Metro
{
    public partial class MainControl : SlidePanel
    {
        public MainControl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            itemPanel1.Location = new Point((this.Width - itemPanel1.Width) / 2 + 16, ((this.Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height + 16);
            base.OnResize(e);
        }

        private void labelX3_Click(object sender, EventArgs e)
        {
           // Process.Start("http://#");
        }

        private void TileSite_Click(object sender, EventArgs e)
        {
            Process.Start(GameConstants.UrlSite);
        }

        private void TileForum_Click(object sender, EventArgs e)
        {
            Process.Start(GameConstants.UrlForum);
        }

        private void TileHelp_Click(object sender, EventArgs e)
        {
            Process.Start(GameConstants.UrlHelp);
        }
    }
}

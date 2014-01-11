using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

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
           // System.Diagnostics.Process.Start("http://#");
        }

        private void TileSettingsGame_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLModule.Constants;
using Newtonsoft.Json;
using System.IO;

namespace GLauncherForm.Theme_Metro
{
    public partial class SettingsGLControl : UserControl
    {
        public event EventHandler CloseUserControl;

        public SettingsGLControl()
        {
            InitializeComponent();
        }

        private void SettingsGLControl_Load(object sender, EventArgs e)
        {
            this.chkAllowAnonPlugins.Checked = PluginConstants.AllowAnonymousSafePlugin;
            this.chkAllowPlugins.Checked = PluginConstants.AllowPluginJS;
            this.chkAllowSafePlugins.Checked = PluginConstants.AllowSafePlugin;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            PluginConstants.AllowAnonymousSafePlugin = this.chkAllowAnonPlugins.Checked;
            PluginConstants.AllowPluginJS = this.chkAllowPlugins.Checked;
            PluginConstants.AllowSafePlugin = this.chkAllowSafePlugins.Checked;

            string Serialized = JsonConvert.SerializeObject(new
            {
                AllowPluginJS = PluginConstants.AllowPluginJS,
                AllowSafePlugin = PluginConstants.AllowSafePlugin,
                AllowAnonymousSafePlugin = PluginConstants.AllowAnonymousSafePlugin
            }, Formatting.Indented);

            using(FileStream FS = File.Open("GLSettings\\Plugins.glconfig",FileMode.OpenOrCreate))
            {
                byte[] SerializedByte = Encoding.ASCII.GetBytes(Serialized);
                FS.BeginWrite(SerializedByte, 0, SerializedByte.Length,null,null);
            }

            CloseUserControl(this, EventArgs.Empty);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            CloseUserControl(this, EventArgs.Empty);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.chkAllowAnonPlugins.Checked = false;
            this.chkAllowPlugins.Checked = true;
            this.chkAllowSafePlugins.Checked = true;
        }
    }
}

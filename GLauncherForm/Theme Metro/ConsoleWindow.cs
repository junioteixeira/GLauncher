using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;
using GLModule.Constants;
using GLModule.PluginJS;
using System.Diagnostics;
using GLModule.PluginJS.Clear;

namespace GLauncherForm.Theme_Metro
{
    public partial class ConsoleWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ConsoleWindow()
        {
            InitializeComponent();
            ConsoleConstants.WriteInConsole = WriteInConsole;
        }

        private void WriteInConsole(string Text, Color color)
        {
            lock (richTextBoxEx1)
            {
                richTextBoxEx1.AppendText("[" + DateTime.Now.ToString("hh:mm:ss") + "] - ", Color.DarkRed);
                richTextBoxEx1.AppendText(Text + "\n", color);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visible = false;

            ConsoleConstants.WriteInConsole("Console closed", Color.Red);

            e.Cancel = true;

            base.OnClosing(e);
        }
    }
}
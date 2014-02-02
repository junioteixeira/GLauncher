using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLModule.Constants;

namespace GLauncherForm.Theme_Metro
{
    public partial class ConsoleWindow : Form
    {
        public ConsoleWindow()
        {
            InitializeComponent();
            ConsoleConstants.WriteInConsole = WriteInConsole;
        }

        private void WriteInConsole(string Text, Color color)
        {
            lock (richTextBox1)
            {
                richTextBox1.Call<RichTextBox>(rc =>
                    {
                        rc.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] - ", Color.DarkRed);
                        rc.AppendText(Text + "\n", color);
                    });
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

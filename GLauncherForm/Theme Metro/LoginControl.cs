using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLModule.Tcp.TcpData;

namespace GLauncherForm.Theme_Metro
{
    public partial class LoginControl : UserControl
    {
        public event EventHandler CloseUserControl;

        public LoginControl()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            tbLogin.Enabled = false;
            tbSenha.Enabled = false;
            buttonX1.Enabled = false;

            circularProgress1.IsRunning = true;
            circularProgress1.Visible = true;

            StaticInstances.ClientConn.SendData(TypeCommand.Login, tbLogin.Text, tbSenha.Text);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            CloseUserControl(this, e);
        }

        
    }
}

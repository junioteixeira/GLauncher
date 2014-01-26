using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro.ColorTables;
using GLModule.PluginJS;
using GLModule.PluginJS.Clear;
using GLResourceModule;

namespace GLauncherForm.Theme_Metro
{
    public partial class SplashForm : Form
    {
        ConsoleWindow consoleWnd = new ConsoleWindow();
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            new Thread(LoadLauncher).Start();
        }

        private void LoadLauncher()
        {
            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando configurações do tema.</font></div>");
            StyleManager.MetroColorGeneratorParameters = MetroColorGeneratorParameters.Default;
            MessageBoxEx.EnableGlass = false;
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 33); //Ajustar

            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Lendo Hardware</font></div>");
            HardwareInformation.ReadHardware();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 66);

            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando plugins.</font></div>");
            RegisterFunctionClear.Teste();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 100);

            this.Invoke(new Action(LoadMainForm));
        }

        private void LoadMainForm()
        {
            this.Visible = false;

            MainForm mainForm = new MainForm(consoleWnd);
            mainForm.ShowDialog();

            this.Close();
        }
    }
}

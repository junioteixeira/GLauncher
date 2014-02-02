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
using GLModule.Constants;
using GLModule.PluginJS;
using GLResourceModule;

namespace GLauncherForm.Theme_Metro
{
    public partial class SplashForm : Form
    {
        ConsoleWindow consoleWnd;
        MainForm mainForm;
        public SplashForm()
        {
            InitializeComponent();

            consoleWnd = new ConsoleWindow();
            mainForm = new MainForm(consoleWnd);

            ConsoleConstants.WriteInConsole("GLauncher iniciado", Color.DarkBlue);

            new Thread(LoadLauncher).Start();
        }

        private void LoadLauncher()
        {
            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando configurações do tema.</font></div>");
            StyleManager.MetroColorGeneratorParameters = MetroColorGeneratorParameters.Default;
            MessageBoxEx.EnableGlass = false;
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 33);

            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Lendo Hardware</font></div>");

            string[] Erros;
            HardwareInformation.ReadHardware(out Erros);
            if (Erros.Length > 0)
                for (int i = 0; i < Erros.Length; i++)
                    ConsoleConstants.WriteInConsole(Erros[i], Color.DarkRed);
            else
                ConsoleConstants.WriteInConsole("Hardware lido com sucesso", Color.DarkGreen);

            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 66);

            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando plugins.</font></div>");
            RegisterFunction.LoadPlugins();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 100);

            //InvokeFunctions.Invoke(FunctionsEnum.ComputeFileCompleted, new string[] { "Arg1 ar1", "Arg1 ar2" }, "Arg2");

            this.Invoke(new Action(LoadMainForm));
        }

        private void LoadMainForm()
        {
            this.Visible = false;

            mainForm.ShowDialog();

            this.Close();
        }
    }
}

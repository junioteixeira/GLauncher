using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
using Newtonsoft.Json;

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
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando plugins</font></div>");
            RegisterFunction.LoadPlugins();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 25);

            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando configurações do tema.</font></div>");
            LoadThemeConfigs();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 50);

            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Carregando configurações do GLauncher</font></div>");
            LoadConfigs();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 75);


            lbInfo.Call<LabelX>(lb =>
            lb.Text = "<div align=\"right\"><font size=\"+4\">Lendo Hardware</font></div>");
            LoadHardware();
            progressBarX1.Call<ProgressBarX>(pb => pb.Value = 100);

            this.Invoke(new Action(LoadMainForm));
        }

        #region Loads
        private void LoadThemeConfigs()
        {
            StyleManager.MetroColorGeneratorParameters = MetroColorGeneratorParameters.Default;
            MessageBoxEx.EnableGlass = false;
            ConsoleConstants.WriteInConsole("Configurações do tema carregadas com sucesso", Color.DarkGreen);
        }

        private void LoadHardware()
        {
            string[] Erros;
            if (HardwareInformation.ReadHardware(out Erros))
            {
                for (int i = 0; i < Erros.Length; i++)
                    ConsoleConstants.WriteInConsole(Erros[i], Color.DarkRed);

                InvokeFunctions.Invoke(FunctionsEnum.ReadHardware, Erros);
            }

            else
                ConsoleConstants.WriteInConsole("Hardware lido com sucesso", Color.DarkGreen);
        }

        private void LoadConfigs()
        {
            if (File.Exists("GLSettings\\Plugins.glconfig"))
            {
                using (FileStream FS = File.Open("GLSettings\\Plugins.glconfig", FileMode.Open))
                {
                    byte[] SerializedByte = new byte[FS.Length];
                    FS.Read(SerializedByte, 0, SerializedByte.Length);
                    string Serialized = Encoding.ASCII.GetString(SerializedByte);
                    var Fields = new
                    {
                        AllowPluginJS = true,
                        AllowSafePlugin = true,
                        AllowAnonymousSafePlugin = false
                    };
                    Fields = JsonConvert.DeserializeAnonymousType(Serialized, Fields);
                    PluginConstants.AllowAnonymousSafePlugin = Fields.AllowAnonymousSafePlugin;
                    PluginConstants.AllowPluginJS = Fields.AllowPluginJS;
                    PluginConstants.AllowSafePlugin = Fields.AllowSafePlugin;
                }
            }
            ConsoleConstants.WriteInConsole("Configurações do GLauncher carregadas com sucesso", Color.DarkGreen);
        }
        #endregion

        private void LoadMainForm()
        {
            this.Visible = false;

            mainForm.ShowDialog();

            this.Close();
        }
    }
}

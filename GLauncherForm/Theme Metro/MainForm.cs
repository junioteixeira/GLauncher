using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using GLModule.Constants;

namespace GLauncherForm.Theme_Metro
{
    public partial class MainForm : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        ConsoleWindow console;
        MainControl Main = null;
        SettingsGameControl _SettingsGame = null;
        public MainForm(ConsoleWindow consoleWnd)
        {
            InitializeComponent();
            this.console = consoleWnd;
            this.Text = GameConstants.NameGame + " - GLauncher";
            this.SuspendLayout();
            this.Main = new MainControl();
            this.Controls.Add(Main);
            this.Main.BringToFront();
            this.Main.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            this.Main.Click += delegate(object sender, EventArgs e) { Main.IsOpen = false; };
            this.Main.TileNews.Click += delegate(object sender, EventArgs e)
            {
                this.Main.IsOpen = false;
                this.TabNews.Select();
            };

            this.Main.TileSettingsGame.Click += delegate(object sender, EventArgs e)
            {
                if (_SettingsGame == null) { _SettingsGame = new SettingsGameControl(); }
                this._SettingsGame.CloseUserControl += CloseUserControl;
                if (!this.IsModalPanelDisplayed) { this.ShowModalPanel(_SettingsGame, eSlideSide.Left); }
            };

            this.ResumeLayout(false);
            UpdateControlsSizeAndLocation(Main);
        }


        private Rectangle GetStartControlBounds()
        {
            int captionHeight = metroShell1.MetroTabStrip.GetCaptionHeight() + 2;
            Thickness borderThickness = this.GetBorderThickness();
            return new Rectangle((int)borderThickness.Left, captionHeight, this.Width - (int)borderThickness.Horizontal, this.Height - captionHeight - 1);
        }

        private void UpdateControlsSizeAndLocation(SlidePanel Main)
        {
            if (Main != null)
            {
                if (!Main.IsOpen)
                    Main.OpenBounds = GetStartControlBounds();
                else
                    Main.Bounds = GetStartControlBounds();
                if (!IsModalPanelDisplayed)
                    Main.BringToFront();
            }
        }

        private void CloseUserControl(object sender, EventArgs e)
        {
            if (this.IsModalPanelDisplayed)
            {
                UserControl control = sender as UserControl;
                this.CloseModalPanel(control, eSlideSide.Left);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0112: //WM_SYSCOMMAND
                    {
                        int WParam = m.WParam.ToInt32() & 0xFFF0;
                        if (WParam == 0xF030) //Maximize
                            return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            this.Main.IsOpen = !this.Main.IsOpen;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ConsoleConstants.AllowConsoleWindow && keyData == ConsoleConstants.KeyConsoleWindow)
            {
                console.Visible = !console.Visible;
                if (console.Visible)
                    ConsoleConstants.WriteInConsole("Console opened", Color.DarkGreen);
                else
                    ConsoleConstants.WriteInConsole("Console closed", Color.Red);

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GLModule.Constants;
using GLModule.SettingsGame;
using GLResourceModule;
using DevComponents.DotNetBar.Controls;

namespace GLauncherForm.Theme_Metro
{
    public partial class SettingsGameControl : UserControl
    {
        public event EventHandler CloseUserControl;

        public SettingsGameControl()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            foreach (Control control in superTabControlPanel1.Controls)
            {
                ComboBoxEx combo = control as ComboBoxEx;
                if (combo != null)
                {
                    if (combo.SelectedIndex == -1)
                    {
                        MessageBoxEx.Show("Há campos que devem ser selecionados.", GameConstants.NameGame + " - GLauncher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            string Report;
            Settings.AnisotropicFilteringIndex = this.cbAnisotropic.SelectedIndex;
            Settings.AntialiasingIndex = this.cbAntialiasing.SelectedIndex;
            Settings.GraphicAdapterIndex = this.cbGraphicAdapter.SelectedIndex;
            Settings.Music = this.slMusic.Value;
            Settings.ResolutionIndex = this.cbResolution.SelectedIndex;
            Settings.Sound = this.slSound.Value;
            Settings.TopMost = this.chkTopMost.Checked;
            Settings.WindowMode = this.chkWindowMode.Checked;
            Settings.ApplyConfigs(out Report);
            CloseUserControl(this, EventArgs.Empty);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            CloseUserControl(this, EventArgs.Empty);
        }

        private void SettingsGameControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < HardwareInformation.GPUInfo.Length; i++)
                cbGraphicAdapter.Items.Add(HardwareInformation.GPUInfo[i].AdapterVideoName + " - (Memory:" + HardwareInformation.GPUInfo[i].DedicatedMemory + " MB)");

            try
            {
                List<String> Resolutions = HardwareInformation.GPUInfo[0].Resolution;
                for (int i = 0; i < Resolutions.Count; i++)
                {
                    cbResolution.Items.Add(Resolutions[i]);
                }
            }
            catch (Exception ex)
            { MessageBoxEx.Show(ex.Message, "ERRO READ HARDWARE", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}

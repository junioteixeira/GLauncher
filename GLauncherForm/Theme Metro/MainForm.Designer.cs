using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
namespace GLauncherForm.Theme_Metro
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroTabPanel1 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.metroTabPanel2 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroTabPanel3 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.webRanking = new System.Windows.Forms.WebBrowser();
            this.TabNews = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem2 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.TabRanking = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.btHome = new DevComponents.DotNetBar.ButtonItem();
            this.btSettings = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.metroShell1.SuspendLayout();
            this.metroTabPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.metroTabPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Controls.Add(this.metroTabPanel1);
            this.metroShell1.Controls.Add(this.metroTabPanel3);
            this.metroShell1.Controls.Add(this.metroTabPanel2);
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroShell1.ForeColor = System.Drawing.Color.Black;
            this.metroShell1.HelpButtonText = "Ajuda";
            this.metroShell1.HelpButtonVisible = false;
            this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TabNews,
            this.metroTabItem2,
            this.TabRanking});
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(0, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btHome,
            this.btSettings,
            this.buttonItem1});
            this.metroShell1.SettingsButtonText = "Configurações";
            this.metroShell1.SettingsButtonVisible = false;
            this.metroShell1.Size = new System.Drawing.Size(733, 460);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 0;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.Text = "metroShell1";
            // 
            // metroTabPanel1
            // 
            this.metroTabPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel1.Controls.Add(this.advTree1);
            this.metroTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel1.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel1.Name = "metroTabPanel1";
            this.metroTabPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel1.Size = new System.Drawing.Size(733, 409);
            // 
            // 
            // 
            this.metroTabPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel1.TabIndex = 1;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.Columns.Add(this.columnHeader4);
            this.advTree1.ForeColor = System.Drawing.Color.Black;
            this.advTree1.Location = new System.Drawing.Point(2, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(729, 387);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Título";
            this.columnHeader1.Width.Absolute = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Data";
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "Autor";
            this.columnHeader3.Width.Absolute = 170;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "Link";
            this.columnHeader4.Width.Absolute = 200;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // metroTabPanel2
            // 
            this.metroTabPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel2.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel2.Name = "metroTabPanel2";
            this.metroTabPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel2.Size = new System.Drawing.Size(733, 409);
            // 
            // 
            // 
            this.metroTabPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel2.TabIndex = 2;
            this.metroTabPanel2.Visible = false;
            // 
            // metroTabPanel3
            // 
            this.metroTabPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel3.Controls.Add(this.webRanking);
            this.metroTabPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel3.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel3.Name = "metroTabPanel3";
            this.metroTabPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel3.Size = new System.Drawing.Size(733, 409);
            // 
            // 
            // 
            this.metroTabPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel3.TabIndex = 3;
            this.metroTabPanel3.Visible = false;
            // 
            // webRanking
            // 
            this.webRanking.Location = new System.Drawing.Point(0, 0);
            this.webRanking.MinimumSize = new System.Drawing.Size(20, 20);
            this.webRanking.Name = "webRanking";
            this.webRanking.Size = new System.Drawing.Size(733, 387);
            this.webRanking.TabIndex = 0;
            // 
            // TabNews
            // 
            this.TabNews.Checked = true;
            this.TabNews.Name = "TabNews";
            this.TabNews.Panel = this.metroTabPanel1;
            this.TabNews.Text = "Notícias";
            // 
            // metroTabItem2
            // 
            this.metroTabItem2.Name = "metroTabItem2";
            this.metroTabItem2.Panel = this.metroTabPanel2;
            this.metroTabItem2.Text = "Estatísticas";
            // 
            // TabRanking
            // 
            this.TabRanking.Name = "TabRanking";
            this.TabRanking.Panel = this.metroTabPanel3;
            this.TabRanking.Text = "Ranking";
            // 
            // btHome
            // 
            this.btHome.Image = global::GLauncherForm.Properties.Resources.Home_icon;
            this.btHome.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btHome.Name = "btHome";
            this.superTooltip1.SetSuperTooltip(this.btHome, new DevComponents.DotNetBar.SuperTooltipInfo("Início", "", "Abrir ou fechar a página inicial do GLauncher.", null, null, DevComponents.DotNetBar.eTooltipColor.Default));
            this.btHome.Text = "Início";
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // btSettings
            // 
            this.btSettings.Image = global::GLauncherForm.Properties.Resources.database_settings_icon;
            this.btSettings.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btSettings.Name = "btSettings";
            this.superTooltip1.SetSuperTooltip(this.btSettings, new DevComponents.DotNetBar.SuperTooltipInfo("Configurações", "", "Configurações do GLauncher", null, null, DevComponents.DotNetBar.eTooltipColor.Gray));
            this.btSettings.Text = "Configurações";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = global::GLauncherForm.Properties.Resources.FAQ_icon;
            this.buttonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Ajuda";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.Teal;
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 440);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(733, 21);
            this.metroStatusBar1.TabIndex = 1;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "Pronto";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 462);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.metroShell1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAME - GLauncher";
            this.metroShell1.ResumeLayout(false);
            this.metroShell1.PerformLayout();
            this.metroTabPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.metroTabPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel2;
        private DevComponents.DotNetBar.Metro.MetroTabItem TabNews;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem2;
        private DevComponents.DotNetBar.ButtonItem btHome;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
        private DevComponents.DotNetBar.ButtonItem btSettings;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel3;
        private System.Windows.Forms.WebBrowser webRanking;
        private DevComponents.DotNetBar.Metro.MetroTabItem TabRanking;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
    }
}


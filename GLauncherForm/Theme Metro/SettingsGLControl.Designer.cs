namespace GLauncherForm.Theme_Metro
{
    partial class SettingsGLControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.chkAllowAnonPlugins = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkAllowSafePlugins = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkAllowPlugins = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(3, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(312, 40);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "Configurações GLauncher";
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(3, 46);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(417, 121);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 15;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.chkAllowAnonPlugins);
            this.superTabControlPanel1.Controls.Add(this.chkAllowSafePlugins);
            this.superTabControlPanel1.Controls.Add(this.chkAllowPlugins);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(417, 96);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // chkAllowAnonPlugins
            // 
            this.chkAllowAnonPlugins.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAllowAnonPlugins.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllowAnonPlugins.FocusCuesEnabled = false;
            this.chkAllowAnonPlugins.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowAnonPlugins.Location = new System.Drawing.Point(20, 61);
            this.chkAllowAnonPlugins.Name = "chkAllowAnonPlugins";
            this.chkAllowAnonPlugins.Size = new System.Drawing.Size(179, 23);
            this.chkAllowAnonPlugins.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTooltip1.SetSuperTooltip(this.chkAllowAnonPlugins, new DevComponents.DotNetBar.SuperTooltipInfo("Plugins Anônimos", "GLauncher", "São plugins recebidos do servidor, porém são para apenas alguns clients a escolha" +
            " do administrador em tempo de execução.\r\nHabilite essa opção apenas se tem confi" +
            "abilidade no servidor.", global::GLauncherForm.Properties.Resources.puzzle_icon_anon, null, DevComponents.DotNetBar.eTooltipColor.Gray, true, true, new System.Drawing.Size(300, 130)));
            this.chkAllowAnonPlugins.TabIndex = 8;
            this.chkAllowAnonPlugins.Text = "Permitir Plugins Anônimos";
            // 
            // chkAllowSafePlugins
            // 
            this.chkAllowSafePlugins.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAllowSafePlugins.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllowSafePlugins.FocusCuesEnabled = false;
            this.chkAllowSafePlugins.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowSafePlugins.Location = new System.Drawing.Point(20, 32);
            this.chkAllowSafePlugins.Name = "chkAllowSafePlugins";
            this.chkAllowSafePlugins.Size = new System.Drawing.Size(138, 23);
            this.chkAllowSafePlugins.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTooltip1.SetSuperTooltip(this.chkAllowSafePlugins, new DevComponents.DotNetBar.SuperTooltipInfo("SafePlugins", "GLauncher", "São plugins recebidos diretamente do servidor com a diferença que têm mais permis" +
            "sões e são testados pela equipe do Servidor.", global::GLauncherForm.Properties.Resources.puzzle_icon_safe, null, DevComponents.DotNetBar.eTooltipColor.Gray));
            this.chkAllowSafePlugins.TabIndex = 8;
            this.chkAllowSafePlugins.Text = "Permitir SafePlugins";
            // 
            // chkAllowPlugins
            // 
            this.chkAllowPlugins.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAllowPlugins.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllowPlugins.FocusCuesEnabled = false;
            this.chkAllowPlugins.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowPlugins.Location = new System.Drawing.Point(20, 3);
            this.chkAllowPlugins.Name = "chkAllowPlugins";
            this.chkAllowPlugins.Size = new System.Drawing.Size(118, 23);
            this.chkAllowPlugins.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllowPlugins.TabIndex = 8;
            this.chkAllowPlugins.Text = "Permitir Plugins";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Plugins";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.Location = new System.Drawing.Point(250, 173);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 12;
            this.buttonX3.Text = "Fechar";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Location = new System.Drawing.Point(171, 173);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 13;
            this.buttonX1.Text = "Padrão";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.Location = new System.Drawing.Point(91, 173);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 14;
            this.buttonX2.Text = "Salvar";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // SettingsGLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.labelX2);
            this.Name = "SettingsGLControl";
            this.Size = new System.Drawing.Size(429, 201);
            this.Load += new System.EventHandler(this.SettingsGLControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllowPlugins;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllowAnonPlugins;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllowSafePlugins;
    }
}

namespace GLauncherForm.Theme_Metro
{
    partial class MainControl
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
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.TileStartGame = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.TileSettingsGame = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.TileSite = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.TileNews = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.TileForum = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.TileHelp = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.itemPanel1.BackgroundStyle.BackColorGradientAngle = 90;
            this.itemPanel1.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(9, 68);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(561, 214);
            this.itemPanel1.TabIndex = 0;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(560, 200);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TileStartGame,
            this.TileSettingsGame,
            this.TileSite,
            this.TileNews,
            this.TileForum,
            this.TileHelp});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // TileStartGame
            // 
            this.TileStartGame.Image = global::GLauncherForm.Properties.Resources.Play;
            this.TileStartGame.Name = "TileStartGame";
            this.TileStartGame.Text = "<font size=\"+4\">Iniciar Jogo</font>";
            this.TileStartGame.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.TileStartGame.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.TileStartGame.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(155)))));
            this.TileStartGame.TileStyle.BackColorGradientAngle = 45;
            this.TileStartGame.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TileStartGame.TileStyle.PaddingBottom = 4;
            this.TileStartGame.TileStyle.PaddingLeft = 4;
            this.TileStartGame.TileStyle.PaddingRight = 4;
            this.TileStartGame.TileStyle.PaddingTop = 4;
            this.TileStartGame.TileStyle.TextColor = System.Drawing.Color.White;
            this.TileStartGame.TitleText = "Jogar";
            // 
            // TileSettingsGame
            // 
            this.TileSettingsGame.Image = global::GLauncherForm.Properties.Resources.Config;
            this.TileSettingsGame.Name = "TileSettingsGame";
            this.TileSettingsGame.Text = "<font size=\"+4\">Configurações<br/>do jogo</font>";
            this.TileSettingsGame.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            // 
            // 
            // 
            this.TileSettingsGame.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(151)))), ((int)(((byte)(42)))));
            this.TileSettingsGame.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(177)))), ((int)(((byte)(51)))));
            this.TileSettingsGame.TileStyle.BackColorGradientAngle = 45;
            this.TileSettingsGame.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TileSettingsGame.TileStyle.PaddingBottom = 4;
            this.TileSettingsGame.TileStyle.PaddingLeft = 4;
            this.TileSettingsGame.TileStyle.PaddingRight = 4;
            this.TileSettingsGame.TileStyle.PaddingTop = 4;
            this.TileSettingsGame.TileStyle.TextColor = System.Drawing.Color.White;
            this.TileSettingsGame.TitleText = "Configuração";
            this.TileSettingsGame.Click += new System.EventHandler(this.TileSettingsGame_Click);
            // 
            // TileSite
            // 
            this.TileSite.Image = global::GLauncherForm.Properties.Resources.pointer;
            this.TileSite.Name = "TileSite";
            this.TileSite.Text = "<font size=\"+4\">Acesso ao site</font>";
            this.TileSite.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            // 
            // 
            // 
            this.TileSite.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.TileSite.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(67)))), ((int)(((byte)(37)))));
            this.TileSite.TileStyle.BackColorGradientAngle = 45;
            this.TileSite.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TileSite.TileStyle.PaddingBottom = 4;
            this.TileSite.TileStyle.PaddingLeft = 4;
            this.TileSite.TileStyle.PaddingRight = 4;
            this.TileSite.TileStyle.PaddingTop = 4;
            this.TileSite.TileStyle.TextColor = System.Drawing.Color.White;
            this.TileSite.TitleText = "Site";
            // 
            // TileNews
            // 
            this.TileNews.Image = global::GLauncherForm.Properties.Resources.Invoice;
            this.TileNews.Name = "TileNews";
            this.TileNews.Text = "<font size=\"+4\">Notícias do jogo</font>";
            this.TileNews.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.TileNews.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.TileNews.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
            this.TileNews.TileStyle.BackColorGradientAngle = 45;
            this.TileNews.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TileNews.TileStyle.PaddingBottom = 4;
            this.TileNews.TileStyle.PaddingLeft = 4;
            this.TileNews.TileStyle.PaddingRight = 4;
            this.TileNews.TileStyle.PaddingTop = 4;
            this.TileNews.TileStyle.TextColor = System.Drawing.Color.White;
            this.TileNews.TitleText = "Notícias";
            // 
            // TileForum
            // 
            this.TileForum.Image = global::GLauncherForm.Properties.Resources.Fórum__IPB_;
            this.TileForum.Name = "TileForum";
            this.TileForum.Text = "<font size=\"+4\">Fórum do jogo</font>";
            this.TileForum.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            // 
            // 
            // 
            this.TileForum.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.TileForum.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(57)))), ((int)(((byte)(0)))));
            this.TileForum.TileStyle.BackColorGradientAngle = 45;
            this.TileForum.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TileForum.TileStyle.PaddingBottom = 4;
            this.TileForum.TileStyle.PaddingLeft = 4;
            this.TileForum.TileStyle.PaddingRight = 4;
            this.TileForum.TileStyle.PaddingTop = 4;
            this.TileForum.TileStyle.TextColor = System.Drawing.Color.White;
            this.TileForum.TitleText = "Fórum";
            // 
            // TileHelp
            // 
            this.TileHelp.Image = global::GLauncherForm.Properties.Resources.Help;
            this.TileHelp.Name = "TileHelp";
            this.TileHelp.Text = "<font size=\"+4\">Ajuda</font>";
            this.TileHelp.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.TileHelp.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.TileHelp.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(98)))), ((int)(((byte)(185)))));
            this.TileHelp.TileStyle.BackColorGradientAngle = 45;
            this.TileHelp.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TileHelp.TileStyle.PaddingBottom = 4;
            this.TileHelp.TileStyle.PaddingLeft = 4;
            this.TileHelp.TileStyle.PaddingRight = 4;
            this.TileHelp.TileStyle.PaddingTop = 4;
            this.TileHelp.TileStyle.TextColor = System.Drawing.Color.White;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(9, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(289, 40);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "GLauncher Soft.";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(411, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(196, 47);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "<div align=\"right\"><font size=\"+4\">Nick Jogador</font><br/>Player</div>";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(12, 321);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(81, 40);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "GL Team";
            this.labelX3.Click += new System.EventHandler(this.labelX3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::GLauncherForm.Properties.Resources.Person;
            this.pictureBox1.Location = new System.Drawing.Point(613, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // MainControl
            // 
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.itemPanel1);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(667, 361);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        public DevComponents.DotNetBar.Metro.MetroTileItem TileStartGame;
        public DevComponents.DotNetBar.Metro.MetroTileItem TileSettingsGame;
        public DevComponents.DotNetBar.Metro.MetroTileItem TileSite;
        public DevComponents.DotNetBar.Metro.MetroTileItem TileNews;
        public DevComponents.DotNetBar.Metro.MetroTileItem TileForum;
        public DevComponents.DotNetBar.Metro.MetroTileItem TileHelp;
        private DevComponents.DotNetBar.LabelX labelX3;


    }
}

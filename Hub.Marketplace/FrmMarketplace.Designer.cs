
namespace LojaWooCommerce
{
    partial class FrmMarketplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarketplace));
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadstroGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.bgAlerta = new System.ComponentModel.BackgroundWorker();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.LinkLabel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRequisitos = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPlugins = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.menu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Tag = "OK";
            this.notify.Text = "Loja Virtual";
            this.notify.Visible = true;
            this.notify.BalloonTipClicked += new System.EventHandler(this.notify_BalloonTipClicked);
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfig,
            this.menuCadstroGrupos,
            this.menuCadastro,
            this.menuPedidos,
            this.menuSobre,
            this.menuSair});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menu.Name = "menu";
            this.menu.ShowImageMargin = false;
            this.menu.Size = new System.Drawing.Size(211, 136);
            // 
            // menuConfig
            // 
            this.menuConfig.ForeColor = System.Drawing.Color.Black;
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(210, 22);
            this.menuConfig.Text = "1 - Configurações";
            this.menuConfig.Click += new System.EventHandler(this.menuConfig_Click);
            // 
            // menuCadstroGrupos
            // 
            this.menuCadstroGrupos.ForeColor = System.Drawing.Color.Black;
            this.menuCadstroGrupos.Name = "menuCadstroGrupos";
            this.menuCadstroGrupos.Size = new System.Drawing.Size(210, 22);
            this.menuCadstroGrupos.Text = "2 - Cadastro de Grupos";
            this.menuCadstroGrupos.Click += new System.EventHandler(this.menuCadstroGrupos_Click);
            // 
            // menuCadastro
            // 
            this.menuCadastro.ForeColor = System.Drawing.Color.Black;
            this.menuCadastro.Name = "menuCadastro";
            this.menuCadastro.Size = new System.Drawing.Size(210, 22);
            this.menuCadastro.Text = "3 - Cadastro de Produtos";
            this.menuCadastro.Click += new System.EventHandler(this.menuCadastro_Click);
            // 
            // menuPedidos
            // 
            this.menuPedidos.ForeColor = System.Drawing.Color.Black;
            this.menuPedidos.Name = "menuPedidos";
            this.menuPedidos.Size = new System.Drawing.Size(210, 22);
            this.menuPedidos.Text = "4 - Lista de Pedidos";
            this.menuPedidos.Click += new System.EventHandler(this.menuPedidos_Click);
            // 
            // menuSobre
            // 
            this.menuSobre.BackColor = System.Drawing.Color.Transparent;
            this.menuSobre.ForeColor = System.Drawing.Color.Black;
            this.menuSobre.Name = "menuSobre";
            this.menuSobre.Size = new System.Drawing.Size(210, 22);
            this.menuSobre.Text = "Sobre";
            this.menuSobre.Click += new System.EventHandler(this.menuSobre_Click);
            // 
            // menuSair
            // 
            this.menuSair.BackColor = System.Drawing.Color.Tomato;
            this.menuSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.menuSair.ForeColor = System.Drawing.Color.White;
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(210, 22);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // bgAlerta
            // 
            this.bgAlerta.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgAlerta_DoWork);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(162, 9);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(288, 106);
            this.label.TabIndex = 2;
            this.label.Text = "label";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(5, 96);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(150, 19);
            this.link.TabIndex = 3;
            this.link.TabStop = true;
            this.link.Text = "www.unitak.com.br";
            this.link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(396, 282);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(83, 31);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerificar.Location = new System.Drawing.Point(170, 260);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(141, 31);
            this.btnVerificar.TabIndex = 4;
            this.btnVerificar.Text = "Verificar Versões";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRequisitos);
            this.panel1.Location = new System.Drawing.Point(1, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 136);
            this.panel1.TabIndex = 5;
            // 
            // txtRequisitos
            // 
            this.txtRequisitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequisitos.Location = new System.Drawing.Point(0, 0);
            this.txtRequisitos.Name = "txtRequisitos";
            this.txtRequisitos.ReadOnly = true;
            this.txtRequisitos.Size = new System.Drawing.Size(238, 134);
            this.txtRequisitos.TabIndex = 0;
            this.txtRequisitos.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtPlugins);
            this.panel2.Location = new System.Drawing.Point(240, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 136);
            this.panel2.TabIndex = 5;
            // 
            // txtPlugins
            // 
            this.txtPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlugins.Location = new System.Drawing.Point(0, 0);
            this.txtPlugins.Name = "txtPlugins";
            this.txtPlugins.ReadOnly = true;
            this.txtPlugins.Size = new System.Drawing.Size(238, 134);
            this.txtPlugins.TabIndex = 1;
            this.txtPlugins.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(240, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "PLUGINS INSTALADOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(1, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "PLUGINS RECOMENDADOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMarketplace
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 431);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.link);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 470);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 470);
            this.Name = "FrmMarketplace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWooCommerce_FormClosing);
            this.Load += new System.EventHandler(this.FrmWooCommerce_Load);
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem menuPedidos;
        private System.ComponentModel.BackgroundWorker bgAlerta;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.LinkLabel link;
        private System.Windows.Forms.ToolStripMenuItem menuSobre;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ToolStripMenuItem menuCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuConfig;
        private System.Windows.Forms.ToolStripMenuItem menuCadstroGrupos;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtRequisitos;
        private System.Windows.Forms.RichTextBox txtPlugins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
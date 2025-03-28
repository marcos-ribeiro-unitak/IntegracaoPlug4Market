
namespace Unitak.Woocommerce
{
    partial class FrmListaPedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaPedidos));
            this.panel = new System.Windows.Forms.Panel();
            this.lblLoad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvPedidosCanc = new System.Windows.Forms.DataGridView();
            this.Entregue = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvPedidosEnv = new System.Windows.Forms.DataGridView();
            this.Faturado = new System.Windows.Forms.TabPage();
            this.dgvPedidosFatu = new System.Windows.Forms.DataGridView();
            this.Aprovado = new System.Windows.Forms.TabPage();
            this.dgvPedidosAprov = new System.Windows.Forms.DataGridView();
            this.tabAguardando = new System.Windows.Forms.TabPage();
            this.dgvPedidosAguar = new System.Windows.Forms.DataGridView();
            this.tabPedidos = new System.Windows.Forms.TabControl();
            this.dgvPedidosConc = new System.Windows.Forms.DataGridView();
            this.panel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosCanc)).BeginInit();
            this.Entregue.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosEnv)).BeginInit();
            this.Faturado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosFatu)).BeginInit();
            this.Aprovado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosAprov)).BeginInit();
            this.tabAguardando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosAguar)).BeginInit();
            this.tabPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosConc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.lblLoad);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.btnHide);
            this.panel.Controls.Add(this.tabPedidos);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(429, 431);
            this.panel.TabIndex = 10;
            // 
            // lblLoad
            // 
            this.lblLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoad.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoad.ForeColor = System.Drawing.Color.White;
            this.lblLoad.Location = new System.Drawing.Point(-1, 381);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(429, 49);
            this.lblLoad.TabIndex = 0;
            this.lblLoad.Text = "Carregando...";
            this.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lista de Pedidos";
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.Location = new System.Drawing.Point(385, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(42, 24);
            this.btnHide.TabIndex = 7;
            this.btnHide.TabStop = false;
            this.btnHide.Text = "V";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Visible = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvPedidosCanc);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(421, 370);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Cancelados";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosCanc
            // 
            this.dgvPedidosCanc.AllowUserToAddRows = false;
            this.dgvPedidosCanc.AllowUserToDeleteRows = false;
            this.dgvPedidosCanc.AllowUserToResizeColumns = false;
            this.dgvPedidosCanc.AllowUserToResizeRows = false;
            this.dgvPedidosCanc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvPedidosCanc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosCanc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPedidosCanc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosCanc.Location = new System.Drawing.Point(3, 3);
            this.dgvPedidosCanc.MultiSelect = false;
            this.dgvPedidosCanc.Name = "dgvPedidosCanc";
            this.dgvPedidosCanc.ReadOnly = true;
            this.dgvPedidosCanc.RowHeadersVisible = false;
            this.dgvPedidosCanc.RowTemplate.Height = 35;
            this.dgvPedidosCanc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosCanc.Size = new System.Drawing.Size(415, 364);
            this.dgvPedidosCanc.TabIndex = 8;
            this.dgvPedidosCanc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosCanc_CellClick);
            // 
            // Entregue
            // 
            this.Entregue.Controls.Add(this.dgvPedidosConc);
            this.Entregue.Location = new System.Drawing.Point(4, 26);
            this.Entregue.Name = "Entregue";
            this.Entregue.Size = new System.Drawing.Size(421, 370);
            this.Entregue.TabIndex = 6;
            this.Entregue.Text = "Entregue";
            this.Entregue.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPedidosEnv);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(421, 370);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Enviado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosEnv
            // 
            this.dgvPedidosEnv.AllowUserToAddRows = false;
            this.dgvPedidosEnv.AllowUserToDeleteRows = false;
            this.dgvPedidosEnv.AllowUserToResizeColumns = false;
            this.dgvPedidosEnv.AllowUserToResizeRows = false;
            this.dgvPedidosEnv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.dgvPedidosEnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosEnv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPedidosEnv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosEnv.Location = new System.Drawing.Point(3, 3);
            this.dgvPedidosEnv.MultiSelect = false;
            this.dgvPedidosEnv.Name = "dgvPedidosEnv";
            this.dgvPedidosEnv.ReadOnly = true;
            this.dgvPedidosEnv.RowHeadersVisible = false;
            this.dgvPedidosEnv.RowTemplate.Height = 35;
            this.dgvPedidosEnv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosEnv.Size = new System.Drawing.Size(415, 364);
            this.dgvPedidosEnv.TabIndex = 8;
            this.dgvPedidosEnv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosEnv_CellClick);
            // 
            // Faturado
            // 
            this.Faturado.Controls.Add(this.dgvPedidosFatu);
            this.Faturado.Location = new System.Drawing.Point(4, 26);
            this.Faturado.Name = "Faturado";
            this.Faturado.Size = new System.Drawing.Size(421, 370);
            this.Faturado.TabIndex = 5;
            this.Faturado.Text = "Faturado";
            this.Faturado.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosFatu
            // 
            this.dgvPedidosFatu.AllowUserToAddRows = false;
            this.dgvPedidosFatu.AllowUserToDeleteRows = false;
            this.dgvPedidosFatu.AllowUserToResizeColumns = false;
            this.dgvPedidosFatu.AllowUserToResizeRows = false;
            this.dgvPedidosFatu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvPedidosFatu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosFatu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPedidosFatu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosFatu.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidosFatu.MultiSelect = false;
            this.dgvPedidosFatu.Name = "dgvPedidosFatu";
            this.dgvPedidosFatu.ReadOnly = true;
            this.dgvPedidosFatu.RowHeadersVisible = false;
            this.dgvPedidosFatu.RowTemplate.Height = 35;
            this.dgvPedidosFatu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosFatu.Size = new System.Drawing.Size(421, 370);
            this.dgvPedidosFatu.TabIndex = 9;
            this.dgvPedidosFatu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosFatu_CellClick);
            // 
            // Aprovado
            // 
            this.Aprovado.Controls.Add(this.dgvPedidosAprov);
            this.Aprovado.Location = new System.Drawing.Point(4, 26);
            this.Aprovado.Name = "Aprovado";
            this.Aprovado.Size = new System.Drawing.Size(421, 370);
            this.Aprovado.TabIndex = 4;
            this.Aprovado.Text = "Aprovado";
            this.Aprovado.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosAprov
            // 
            this.dgvPedidosAprov.AllowUserToAddRows = false;
            this.dgvPedidosAprov.AllowUserToDeleteRows = false;
            this.dgvPedidosAprov.AllowUserToResizeColumns = false;
            this.dgvPedidosAprov.AllowUserToResizeRows = false;
            this.dgvPedidosAprov.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvPedidosAprov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosAprov.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPedidosAprov.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosAprov.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidosAprov.MultiSelect = false;
            this.dgvPedidosAprov.Name = "dgvPedidosAprov";
            this.dgvPedidosAprov.ReadOnly = true;
            this.dgvPedidosAprov.RowHeadersVisible = false;
            this.dgvPedidosAprov.RowTemplate.Height = 35;
            this.dgvPedidosAprov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosAprov.Size = new System.Drawing.Size(421, 370);
            this.dgvPedidosAprov.TabIndex = 8;
            this.dgvPedidosAprov.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosAprov_CellClick);
            // 
            // tabAguardando
            // 
            this.tabAguardando.BackColor = System.Drawing.Color.Transparent;
            this.tabAguardando.Controls.Add(this.dgvPedidosAguar);
            this.tabAguardando.Location = new System.Drawing.Point(4, 26);
            this.tabAguardando.Name = "tabAguardando";
            this.tabAguardando.Padding = new System.Windows.Forms.Padding(3);
            this.tabAguardando.Size = new System.Drawing.Size(421, 370);
            this.tabAguardando.TabIndex = 0;
            this.tabAguardando.Text = "Aguardando";
            // 
            // dgvPedidosAguar
            // 
            this.dgvPedidosAguar.AllowUserToAddRows = false;
            this.dgvPedidosAguar.AllowUserToDeleteRows = false;
            this.dgvPedidosAguar.AllowUserToResizeColumns = false;
            this.dgvPedidosAguar.AllowUserToResizeRows = false;
            this.dgvPedidosAguar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.dgvPedidosAguar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosAguar.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidosAguar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosAguar.Location = new System.Drawing.Point(3, 3);
            this.dgvPedidosAguar.MultiSelect = false;
            this.dgvPedidosAguar.Name = "dgvPedidosAguar";
            this.dgvPedidosAguar.ReadOnly = true;
            this.dgvPedidosAguar.RowHeadersVisible = false;
            this.dgvPedidosAguar.RowTemplate.Height = 35;
            this.dgvPedidosAguar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosAguar.Size = new System.Drawing.Size(415, 364);
            this.dgvPedidosAguar.TabIndex = 6;
            this.dgvPedidosAguar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPedidos_CellClick);
            this.dgvPedidosAguar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPedidos_CellMouseDoubleClick);
            // 
            // tabPedidos
            // 
            this.tabPedidos.Controls.Add(this.tabAguardando);
            this.tabPedidos.Controls.Add(this.Aprovado);
            this.tabPedidos.Controls.Add(this.Faturado);
            this.tabPedidos.Controls.Add(this.tabPage1);
            this.tabPedidos.Controls.Add(this.Entregue);
            this.tabPedidos.Controls.Add(this.tabPage3);
            this.tabPedidos.Location = new System.Drawing.Point(-1, 30);
            this.tabPedidos.Name = "tabPedidos";
            this.tabPedidos.SelectedIndex = 0;
            this.tabPedidos.Size = new System.Drawing.Size(429, 400);
            this.tabPedidos.TabIndex = 10;
            this.tabPedidos.SelectedIndexChanged += new System.EventHandler(this.tabPedidos_SelectedIndexChanged);
            // 
            // dgvPedidosConc
            // 
            this.dgvPedidosConc.AllowUserToAddRows = false;
            this.dgvPedidosConc.AllowUserToDeleteRows = false;
            this.dgvPedidosConc.AllowUserToResizeColumns = false;
            this.dgvPedidosConc.AllowUserToResizeRows = false;
            this.dgvPedidosConc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.dgvPedidosConc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosConc.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPedidosConc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosConc.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidosConc.MultiSelect = false;
            this.dgvPedidosConc.Name = "dgvPedidosConc";
            this.dgvPedidosConc.ReadOnly = true;
            this.dgvPedidosConc.RowHeadersVisible = false;
            this.dgvPedidosConc.RowTemplate.Height = 35;
            this.dgvPedidosConc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosConc.Size = new System.Drawing.Size(421, 370);
            this.dgvPedidosConc.TabIndex = 9;
            this.dgvPedidosConc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosConc_CellClick);
            // 
            // FrmListaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(429, 431);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmListaPedidos";
            this.Opacity = 0.99D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmListaPedidos";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FrmListaPedidos_Activated);
            this.Deactivate += new System.EventHandler(this.FrmListaPedidos_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmListaPedidos_FormClosing);
            this.Load += new System.EventHandler(this.FrmListaPedidos_Load);
            this.Shown += new System.EventHandler(this.FrmListaPedidos_Shown);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosCanc)).EndInit();
            this.Entregue.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosEnv)).EndInit();
            this.Faturado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosFatu)).EndInit();
            this.Aprovado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosAprov)).EndInit();
            this.tabAguardando.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosAguar)).EndInit();
            this.tabPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosConc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.TabControl tabPedidos;
        private System.Windows.Forms.TabPage tabAguardando;
        private System.Windows.Forms.DataGridView dgvPedidosAguar;
        private System.Windows.Forms.TabPage Aprovado;
        private System.Windows.Forms.DataGridView dgvPedidosAprov;
        private System.Windows.Forms.TabPage Faturado;
        private System.Windows.Forms.DataGridView dgvPedidosFatu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvPedidosEnv;
        private System.Windows.Forms.TabPage Entregue;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvPedidosCanc;
        private System.Windows.Forms.DataGridView dgvPedidosConc;
    }
}
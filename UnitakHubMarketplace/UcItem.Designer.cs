
namespace Unitak.Woocommerce
{
    partial class UcItem
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbEstoque = new System.Windows.Forms.GroupBox();
            this.chkGerenciaEstoque = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEstoque = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQtdEstoque = new System.Windows.Forms.TextBox();
            this.cbVisibilidade = new System.Windows.Forms.ComboBox();
            this.btnRecriarGrade = new System.Windows.Forms.Button();
            this.linkProduto = new System.Windows.Forms.LinkLabel();
            this.btnEnviarItem = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGrade = new System.Windows.Forms.TabPage();
            this.dgGrade = new System.Windows.Forms.DataGridView();
            this.tabImagens = new System.Windows.Forms.TabPage();
            this.pnlImagens = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCategoria = new System.Windows.Forms.TabPage();
            this.pnlCateg = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNovaCategoria = new System.Windows.Forms.TextBox();
            this.btnNovaCateg = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabTag = new System.Windows.Forms.TabPage();
            this.pnlTag = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNovaTag = new System.Windows.Forms.TextBox();
            this.btnNovaTag = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLargura = new System.Windows.Forms.TextBox();
            this.txtComprimento = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecoRegular = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bgLoad = new System.ComponentModel.BackgroundWorker();
            this.gbEstoque.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrade)).BeginInit();
            this.tabImagens.SuspendLayout();
            this.tabCategoria.SuspendLayout();
            this.tabTag.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEstoque
            // 
            this.gbEstoque.Controls.Add(this.chkGerenciaEstoque);
            this.gbEstoque.Controls.Add(this.label11);
            this.gbEstoque.Controls.Add(this.cbEstoque);
            this.gbEstoque.Controls.Add(this.label9);
            this.gbEstoque.Controls.Add(this.txtQtdEstoque);
            this.gbEstoque.Controls.Add(this.cbVisibilidade);
            this.gbEstoque.Location = new System.Drawing.Point(3, 124);
            this.gbEstoque.Name = "gbEstoque";
            this.gbEstoque.Size = new System.Drawing.Size(263, 118);
            this.gbEstoque.TabIndex = 23;
            this.gbEstoque.TabStop = false;
            this.gbEstoque.Text = "Estoque";
            // 
            // chkGerenciaEstoque
            // 
            this.chkGerenciaEstoque.AutoSize = true;
            this.chkGerenciaEstoque.Location = new System.Drawing.Point(16, 85);
            this.chkGerenciaEstoque.Name = "chkGerenciaEstoque";
            this.chkGerenciaEstoque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkGerenciaEstoque.Size = new System.Drawing.Size(152, 23);
            this.chkGerenciaEstoque.TabIndex = 23;
            this.chkGerenciaEstoque.Text = "Gerencia Estoque";
            this.chkGerenciaEstoque.UseVisualStyleBackColor = true;
            this.chkGerenciaEstoque.CheckedChanged += new System.EventHandler(this.chkGerenciaEstoque_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 19);
            this.label11.TabIndex = 15;
            this.label11.Text = "Visibilidade";
            // 
            // cbEstoque
            // 
            this.cbEstoque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstoque.FormattingEnabled = true;
            this.cbEstoque.Location = new System.Drawing.Point(122, 53);
            this.cbEstoque.Name = "cbEstoque";
            this.cbEstoque.Size = new System.Drawing.Size(121, 25);
            this.cbEstoque.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Estoque";
            // 
            // txtQtdEstoque
            // 
            this.txtQtdEstoque.Location = new System.Drawing.Point(174, 84);
            this.txtQtdEstoque.Name = "txtQtdEstoque";
            this.txtQtdEstoque.Size = new System.Drawing.Size(69, 24);
            this.txtQtdEstoque.TabIndex = 5;
            this.txtQtdEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdEstoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // cbVisibilidade
            // 
            this.cbVisibilidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisibilidade.FormattingEnabled = true;
            this.cbVisibilidade.Location = new System.Drawing.Point(122, 22);
            this.cbVisibilidade.Name = "cbVisibilidade";
            this.cbVisibilidade.Size = new System.Drawing.Size(121, 25);
            this.cbVisibilidade.TabIndex = 7;
            // 
            // btnRecriarGrade
            // 
            this.btnRecriarGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecriarGrade.Location = new System.Drawing.Point(3, 421);
            this.btnRecriarGrade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecriarGrade.Name = "btnRecriarGrade";
            this.btnRecriarGrade.Size = new System.Drawing.Size(123, 37);
            this.btnRecriarGrade.TabIndex = 18;
            this.btnRecriarGrade.Text = "Recriar Grade";
            this.btnRecriarGrade.UseVisualStyleBackColor = true;
            this.btnRecriarGrade.Click += new System.EventHandler(this.btnRecriarGrade_Click);
            // 
            // linkProduto
            // 
            this.linkProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkProduto.Location = new System.Drawing.Point(268, 42);
            this.linkProduto.Name = "linkProduto";
            this.linkProduto.Size = new System.Drawing.Size(277, 26);
            this.linkProduto.TabIndex = 22;
            this.linkProduto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProduto_LinkClicked);
            // 
            // btnEnviarItem
            // 
            this.btnEnviarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarItem.Location = new System.Drawing.Point(343, 444);
            this.btnEnviarItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnviarItem.Name = "btnEnviarItem";
            this.btnEnviarItem.Size = new System.Drawing.Size(206, 46);
            this.btnEnviarItem.TabIndex = 18;
            this.btnEnviarItem.Text = "Enviar Cadastro do Item ";
            this.btnEnviarItem.UseVisualStyleBackColor = true;
            this.btnEnviarItem.Click += new System.EventHandler(this.btnEnviarItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGrade);
            this.tabControl.Controls.Add(this.tabImagens);
            this.tabControl.Controls.Add(this.tabCategoria);
            this.tabControl.Controls.Add(this.tabTag);
            this.tabControl.Location = new System.Drawing.Point(3, 248);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(546, 173);
            this.tabControl.TabIndex = 21;
            // 
            // tabGrade
            // 
            this.tabGrade.Controls.Add(this.dgGrade);
            this.tabGrade.Location = new System.Drawing.Point(4, 26);
            this.tabGrade.Name = "tabGrade";
            this.tabGrade.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrade.Size = new System.Drawing.Size(538, 143);
            this.tabGrade.TabIndex = 2;
            this.tabGrade.Text = "Grade";
            this.tabGrade.UseVisualStyleBackColor = true;
            // 
            // dgGrade
            // 
            this.dgGrade.AllowUserToAddRows = false;
            this.dgGrade.AllowUserToDeleteRows = false;
            this.dgGrade.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGrade.Location = new System.Drawing.Point(3, 3);
            this.dgGrade.MultiSelect = false;
            this.dgGrade.Name = "dgGrade";
            this.dgGrade.ReadOnly = true;
            this.dgGrade.RowHeadersVisible = false;
            this.dgGrade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGrade.Size = new System.Drawing.Size(532, 137);
            this.dgGrade.TabIndex = 0;
            this.dgGrade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGrade_CellDoubleClick);
            this.dgGrade.SelectionChanged += new System.EventHandler(this.dgGrade_SelectionChanged);
            // 
            // tabImagens
            // 
            this.tabImagens.Controls.Add(this.pnlImagens);
            this.tabImagens.Location = new System.Drawing.Point(4, 26);
            this.tabImagens.Name = "tabImagens";
            this.tabImagens.Padding = new System.Windows.Forms.Padding(3);
            this.tabImagens.Size = new System.Drawing.Size(538, 143);
            this.tabImagens.TabIndex = 3;
            this.tabImagens.Text = "Imagens";
            this.tabImagens.UseVisualStyleBackColor = true;
            // 
            // pnlImagens
            // 
            this.pnlImagens.AutoScroll = true;
            this.pnlImagens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagens.Location = new System.Drawing.Point(3, 3);
            this.pnlImagens.Name = "pnlImagens";
            this.pnlImagens.Size = new System.Drawing.Size(532, 137);
            this.pnlImagens.TabIndex = 0;
            // 
            // tabCategoria
            // 
            this.tabCategoria.Controls.Add(this.pnlCateg);
            this.tabCategoria.Controls.Add(this.txtNovaCategoria);
            this.tabCategoria.Controls.Add(this.btnNovaCateg);
            this.tabCategoria.Controls.Add(this.label10);
            this.tabCategoria.Location = new System.Drawing.Point(4, 26);
            this.tabCategoria.Name = "tabCategoria";
            this.tabCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategoria.Size = new System.Drawing.Size(538, 143);
            this.tabCategoria.TabIndex = 0;
            this.tabCategoria.Text = "Categorias";
            this.tabCategoria.UseVisualStyleBackColor = true;
            // 
            // pnlCateg
            // 
            this.pnlCateg.Location = new System.Drawing.Point(17, 59);
            this.pnlCateg.Name = "pnlCateg";
            this.pnlCateg.Size = new System.Drawing.Size(495, 81);
            this.pnlCateg.TabIndex = 15;
            // 
            // txtNovaCategoria
            // 
            this.txtNovaCategoria.Location = new System.Drawing.Point(17, 28);
            this.txtNovaCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNovaCategoria.Name = "txtNovaCategoria";
            this.txtNovaCategoria.Size = new System.Drawing.Size(250, 24);
            this.txtNovaCategoria.TabIndex = 12;
            // 
            // btnNovaCateg
            // 
            this.btnNovaCateg.Location = new System.Drawing.Point(273, 24);
            this.btnNovaCateg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNovaCateg.Name = "btnNovaCateg";
            this.btnNovaCateg.Size = new System.Drawing.Size(64, 30);
            this.btnNovaCateg.TabIndex = 13;
            this.btnNovaCateg.Text = "Buscar";
            this.btnNovaCateg.UseVisualStyleBackColor = true;
            this.btnNovaCateg.Click += new System.EventHandler(this.btnNovaCateg_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "Buscar Categoria";
            // 
            // tabTag
            // 
            this.tabTag.Controls.Add(this.pnlTag);
            this.tabTag.Controls.Add(this.txtNovaTag);
            this.tabTag.Controls.Add(this.btnNovaTag);
            this.tabTag.Controls.Add(this.label12);
            this.tabTag.Location = new System.Drawing.Point(4, 26);
            this.tabTag.Name = "tabTag";
            this.tabTag.Padding = new System.Windows.Forms.Padding(3);
            this.tabTag.Size = new System.Drawing.Size(538, 143);
            this.tabTag.TabIndex = 1;
            this.tabTag.Text = "Tags";
            this.tabTag.UseVisualStyleBackColor = true;
            // 
            // pnlTag
            // 
            this.pnlTag.Location = new System.Drawing.Point(17, 59);
            this.pnlTag.Name = "pnlTag";
            this.pnlTag.Size = new System.Drawing.Size(495, 81);
            this.pnlTag.TabIndex = 17;
            // 
            // txtNovaTag
            // 
            this.txtNovaTag.Location = new System.Drawing.Point(17, 28);
            this.txtNovaTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNovaTag.Name = "txtNovaTag";
            this.txtNovaTag.Size = new System.Drawing.Size(250, 24);
            this.txtNovaTag.TabIndex = 15;
            
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 19);
            this.label12.TabIndex = 15;
            this.label12.Text = "Buscar Tag";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAltura);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLargura);
            this.groupBox2.Controls.Add(this.txtComprimento);
            this.groupBox2.Controls.Add(this.txtPeso);
            this.groupBox2.Location = new System.Drawing.Point(272, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 152);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimensões";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Peso (kg)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Altura (cm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Comp. (cm)";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(116, 27);
            this.txtAltura.MaxLength = 5;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(137, 24);
            this.txtAltura.TabIndex = 8;
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Largura (cm)";
            // 
            // txtLargura
            // 
            this.txtLargura.Location = new System.Drawing.Point(116, 57);
            this.txtLargura.MaxLength = 5;
            this.txtLargura.Name = "txtLargura";
            this.txtLargura.Size = new System.Drawing.Size(137, 24);
            this.txtLargura.TabIndex = 9;
            this.txtLargura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerKeyPress);
            // 
            // txtComprimento
            // 
            this.txtComprimento.Location = new System.Drawing.Point(116, 87);
            this.txtComprimento.MaxLength = 5;
            this.txtComprimento.Name = "txtComprimento";
            this.txtComprimento.Size = new System.Drawing.Size(137, 24);
            this.txtComprimento.TabIndex = 10;
            this.txtComprimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComprimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerKeyPress);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(116, 117);
            this.txtPeso.MaxLength = 6;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(137, 24);
            this.txtPeso.TabIndex = 11;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Location = new System.Drawing.Point(131, 99);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(121, 24);
            this.txtPrecoVenda.TabIndex = 5;
            this.txtPrecoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Preço Oferta";
            // 
            // txtPrecoRegular
            // 
            this.txtPrecoRegular.Location = new System.Drawing.Point(131, 69);
            this.txtPrecoRegular.Name = "txtPrecoRegular";
            this.txtPrecoRegular.Size = new System.Drawing.Size(121, 24);
            this.txtPrecoRegular.TabIndex = 4;
            this.txtPrecoRegular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoRegular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Preço";
            // 
            // txtSku
            // 
            this.txtSku.Enabled = false;
            this.txtSku.Location = new System.Drawing.Point(131, 39);
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(121, 24);
            this.txtSku.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cod. Barras";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(131, 9);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(413, 24);
            this.txtNome.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nome";
            // 
            // bgLoad
            // 
            this.bgLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoad_DoWork);
            this.bgLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoad_RunWorkerCompleted);
            // 
            // UcItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.gbEstoque);
            this.Controls.Add(this.btnRecriarGrade);
            this.Controls.Add(this.linkProduto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEnviarItem);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSku);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrecoRegular);
            this.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UcItem";
            this.Size = new System.Drawing.Size(552, 494);
            this.Load += new System.EventHandler(this.ucItem_Load);
            this.gbEstoque.ResumeLayout(false);
            this.gbEstoque.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabGrade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGrade)).EndInit();
            this.tabImagens.ResumeLayout(false);
            this.tabCategoria.ResumeLayout(false);
            this.tabCategoria.PerformLayout();
            this.tabTag.ResumeLayout(false);
            this.tabTag.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbVisibilidade;
        private System.Windows.Forms.ComboBox cbEstoque;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCategoria;
        private System.Windows.Forms.TextBox txtNovaCategoria;
        private System.Windows.Forms.Button btnNovaCateg;
        private System.Windows.Forms.TabPage tabTag;
        private System.Windows.Forms.TextBox txtNovaTag;
        private System.Windows.Forms.Button btnNovaTag;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLargura;
        private System.Windows.Forms.TextBox txtComprimento;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecoRegular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnviarItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel pnlCateg;
        private System.Windows.Forms.FlowLayoutPanel pnlTag;
        private System.Windows.Forms.TabPage tabGrade;
        private System.Windows.Forms.DataGridView dgGrade;
        private System.Windows.Forms.TabPage tabImagens;
        private System.Windows.Forms.FlowLayoutPanel pnlImagens;
        private System.ComponentModel.BackgroundWorker bgLoad;
        private System.Windows.Forms.LinkLabel linkProduto;
        private System.Windows.Forms.Button btnRecriarGrade;
        private System.Windows.Forms.CheckBox chkGerenciaEstoque;
        private System.Windows.Forms.TextBox txtQtdEstoque;
        private System.Windows.Forms.GroupBox gbEstoque;
    }
}

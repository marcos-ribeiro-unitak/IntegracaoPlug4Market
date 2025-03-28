
namespace Unitak.Woocommerce
{
    partial class FrmCadastroItens
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.chkSomenteGrade = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbQtdBusca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNaoCadastrado = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.cbMarcas = new System.Windows.Forms.ComboBox();
            this.cbGrupos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBusca = new System.Windows.Forms.Panel();
            this.dgItens = new System.Windows.Forms.DataGridView();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.lblCadastrarItens = new System.Windows.Forms.Label();
            this.btnCadastrarItens = new System.Windows.Forms.Button();
            this.btnAlteraDim = new System.Windows.Forms.Button();
            this.chkSelecionarTudo = new System.Windows.Forms.CheckBox();
            this.pnlFiltros.SuspendLayout();
            this.pnlBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItens)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.chkSomenteGrade);
            this.pnlFiltros.Controls.Add(this.checkBox2);
            this.pnlFiltros.Controls.Add(this.checkBox1);
            this.pnlFiltros.Controls.Add(this.cbQtdBusca);
            this.pnlFiltros.Controls.Add(this.label4);
            this.pnlFiltros.Controls.Add(this.chkNaoCadastrado);
            this.pnlFiltros.Controls.Add(this.btnAtualizar);
            this.pnlFiltros.Controls.Add(this.label1);
            this.pnlFiltros.Controls.Add(this.txtPesquisa);
            this.pnlFiltros.Controls.Add(this.cbMarcas);
            this.pnlFiltros.Controls.Add(this.cbGrupos);
            this.pnlFiltros.Controls.Add(this.label2);
            this.pnlFiltros.Controls.Add(this.label3);
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(824, 167);
            this.pnlFiltros.TabIndex = 14;
            // 
            // chkSomenteGrade
            // 
            this.chkSomenteGrade.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSomenteGrade.AutoSize = true;
            this.chkSomenteGrade.Location = new System.Drawing.Point(360, 100);
            this.chkSomenteGrade.Name = "chkSomenteGrade";
            this.chkSomenteGrade.Size = new System.Drawing.Size(138, 23);
            this.chkSomenteGrade.TabIndex = 11;
            this.chkSomenteGrade.Text = "Somente Grade";
            this.chkSomenteGrade.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(498, 68);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 23);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Todos";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(498, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 23);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Todos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // cbQtdBusca
            // 
            this.cbQtdBusca.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbQtdBusca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbQtdBusca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbQtdBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQtdBusca.FormattingEnabled = true;
            this.cbQtdBusca.Items.AddRange(new object[] {
            "100",
            "500",
            "Todos"});
            this.cbQtdBusca.Location = new System.Drawing.Point(252, 98);
            this.cbQtdBusca.Name = "cbQtdBusca";
            this.cbQtdBusca.Size = new System.Drawing.Size(87, 25);
            this.cbQtdBusca.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantidade de busca:";
            // 
            // chkNaoCadastrado
            // 
            this.chkNaoCadastrado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkNaoCadastrado.AutoSize = true;
            this.chkNaoCadastrado.Location = new System.Drawing.Point(252, 133);
            this.chkNaoCadastrado.Name = "chkNaoCadastrado";
            this.chkNaoCadastrado.Size = new System.Drawing.Size(210, 23);
            this.chkNaoCadastrado.TabIndex = 3;
            this.chkNaoCadastrado.Text = "Produtos não cadastrados";
            this.chkNaoCadastrado.UseVisualStyleBackColor = true;
            this.chkNaoCadastrado.CheckedChanged += new System.EventHandler(this.chkNaoCadastrado_CheckedChanged);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAtualizar.Location = new System.Drawing.Point(540, 120);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(106, 40);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Buscar Itens";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pesquisa:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPesquisa.Location = new System.Drawing.Point(252, 7);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(394, 24);
            this.txtPesquisa.TabIndex = 0;
            // 
            // cbMarcas
            // 
            this.cbMarcas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbMarcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMarcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarcas.FormattingEnabled = true;
            this.cbMarcas.Location = new System.Drawing.Point(252, 69);
            this.cbMarcas.Name = "cbMarcas";
            this.cbMarcas.Size = new System.Drawing.Size(240, 25);
            this.cbMarcas.TabIndex = 2;
            // 
            // cbGrupos
            // 
            this.cbGrupos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbGrupos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupos.FormattingEnabled = true;
            this.cbGrupos.Location = new System.Drawing.Point(252, 38);
            this.cbGrupos.Name = "cbGrupos";
            this.cbGrupos.Size = new System.Drawing.Size(240, 25);
            this.cbGrupos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Grupo:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Marca:";
            // 
            // pnlBusca
            // 
            this.pnlBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusca.Controls.Add(this.dgItens);
            this.pnlBusca.Controls.Add(this.btnEstoque);
            this.pnlBusca.Controls.Add(this.lblCadastrarItens);
            this.pnlBusca.Controls.Add(this.btnCadastrarItens);
            this.pnlBusca.Controls.Add(this.btnAlteraDim);
            this.pnlBusca.Controls.Add(this.chkSelecionarTudo);
            this.pnlBusca.Location = new System.Drawing.Point(0, 167);
            this.pnlBusca.Name = "pnlBusca";
            this.pnlBusca.Size = new System.Drawing.Size(824, 265);
            this.pnlBusca.TabIndex = 13;
            // 
            // dgItens
            // 
            this.dgItens.AllowUserToAddRows = false;
            this.dgItens.AllowUserToDeleteRows = false;
            this.dgItens.AllowUserToResizeColumns = false;
            this.dgItens.AllowUserToResizeRows = false;
            this.dgItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItens.Location = new System.Drawing.Point(0, 28);
            this.dgItens.Name = "dgItens";
            this.dgItens.ReadOnly = true;
            this.dgItens.RowHeadersVisible = false;
            this.dgItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItens.Size = new System.Drawing.Size(822, 176);
            this.dgItens.TabIndex = 0;
            this.dgItens.TabStop = false;
            this.dgItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItens_CellClick);
            this.dgItens.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItens_CellDoubleClick);
            this.dgItens.SelectionChanged += new System.EventHandler(this.dgItens_SelectionChanged);
            // 
            // btnEstoque
            // 
            this.btnEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstoque.Location = new System.Drawing.Point(714, 209);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(105, 50);
            this.btnEstoque.TabIndex = 5;
            this.btnEstoque.Text = "Alterar Estoque";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // lblCadastrarItens
            // 
            this.lblCadastrarItens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCadastrarItens.Location = new System.Drawing.Point(2, 214);
            this.lblCadastrarItens.Name = "lblCadastrarItens";
            this.lblCadastrarItens.Size = new System.Drawing.Size(145, 41);
            this.lblCadastrarItens.TabIndex = 6;
            this.lblCadastrarItens.Text = "Ações em massa: ";
            this.lblCadastrarItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCadastrarItens
            // 
            this.btnCadastrarItens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCadastrarItens.Location = new System.Drawing.Point(153, 209);
            this.btnCadastrarItens.Name = "btnCadastrarItens";
            this.btnCadastrarItens.Size = new System.Drawing.Size(119, 50);
            this.btnCadastrarItens.TabIndex = 5;
            this.btnCadastrarItens.Text = "Incluir Itens Selecionados";
            this.btnCadastrarItens.UseVisualStyleBackColor = true;
            this.btnCadastrarItens.Click += new System.EventHandler(this.btnCadastrarItens_Click);
            // 
            // btnAlteraDim
            // 
            this.btnAlteraDim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlteraDim.Location = new System.Drawing.Point(603, 209);
            this.btnAlteraDim.Name = "btnAlteraDim";
            this.btnAlteraDim.Size = new System.Drawing.Size(105, 50);
            this.btnAlteraDim.TabIndex = 5;
            this.btnAlteraDim.Text = "Alterar Dimensões";
            this.btnAlteraDim.UseVisualStyleBackColor = true;
            this.btnAlteraDim.Click += new System.EventHandler(this.btnAlteraDim_Click);
            // 
            // chkSelecionarTudo
            // 
            this.chkSelecionarTudo.AutoSize = true;
            this.chkSelecionarTudo.Location = new System.Drawing.Point(3, 3);
            this.chkSelecionarTudo.Name = "chkSelecionarTudo";
            this.chkSelecionarTudo.Size = new System.Drawing.Size(137, 23);
            this.chkSelecionarTudo.TabIndex = 3;
            this.chkSelecionarTudo.Text = "Selecionar Tudo";
            this.chkSelecionarTudo.UseVisualStyleBackColor = true;
            this.chkSelecionarTudo.CheckedChanged += new System.EventHandler(this.chkSelecionarTudo_CheckedChanged);
            // 
            // FrmCadastroItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(824, 431);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlBusca);
            this.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadastroItens";
            this.ShowIcon = false;
            this.Text = "Cadastro de Itens";
            this.Load += new System.EventHandler(this.FrmCadastroItens_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBusca.ResumeLayout(false);
            this.pnlBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.CheckBox chkNaoCadastrado;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.ComboBox cbMarcas;
        private System.Windows.Forms.ComboBox cbGrupos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBusca;
        private System.Windows.Forms.DataGridView dgItens;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Label lblCadastrarItens;
        private System.Windows.Forms.Button btnCadastrarItens;
        private System.Windows.Forms.Button btnAlteraDim;
        private System.Windows.Forms.CheckBox chkSelecionarTudo;
        private System.Windows.Forms.ComboBox cbQtdBusca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkSomenteGrade;
    }
}
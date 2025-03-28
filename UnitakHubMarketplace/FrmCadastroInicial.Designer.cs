
namespace Unitak.Woocommerce
{
    partial class FrmCadastroInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroInicial));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgItens = new System.Windows.Forms.DataGridView();
            this.gbEstoque = new System.Windows.Forms.GroupBox();
            this.chkGerenciaEstoque = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEstoque = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbVisibilidade = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLargura = new System.Windows.Forms.TextBox();
            this.txtComprimento = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAviso = new System.Windows.Forms.Label();
            this.bgGravar = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItens)).BeginInit();
            this.gbEstoque.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 54);
            this.panel2.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Tomato;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(4, 5);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 45);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(810, 5);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 45);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 50);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(841, 51);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 361);
            this.panel3.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-62, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(538, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Informar ao cliente que o resto sera setado como padrão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enviar Cadastro de Itens";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgItens
            // 
            this.dgItens.AllowUserToAddRows = false;
            this.dgItens.AllowUserToDeleteRows = false;
            this.dgItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgItens.Location = new System.Drawing.Point(0, 51);
            this.dgItens.Margin = new System.Windows.Forms.Padding(4);
            this.dgItens.MultiSelect = false;
            this.dgItens.Name = "dgItens";
            this.dgItens.RowHeadersVisible = false;
            this.dgItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItens.Size = new System.Drawing.Size(672, 220);
            this.dgItens.TabIndex = 6;
            this.dgItens.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItens_CellMouseEnter);
            // 
            // gbEstoque
            // 
            this.gbEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbEstoque.Controls.Add(this.chkGerenciaEstoque);
            this.gbEstoque.Controls.Add(this.label11);
            this.gbEstoque.Controls.Add(this.cbEstoque);
            this.gbEstoque.Controls.Add(this.label9);
            this.gbEstoque.Controls.Add(this.cbVisibilidade);
            this.gbEstoque.Location = new System.Drawing.Point(350, 275);
            this.gbEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.gbEstoque.Name = "gbEstoque";
            this.gbEstoque.Padding = new System.Windows.Forms.Padding(4);
            this.gbEstoque.Size = new System.Drawing.Size(322, 148);
            this.gbEstoque.TabIndex = 25;
            this.gbEstoque.TabStop = false;
            this.gbEstoque.Text = "Estoque";
            // 
            // chkGerenciaEstoque
            // 
            this.chkGerenciaEstoque.AutoSize = true;
            this.chkGerenciaEstoque.Location = new System.Drawing.Point(121, 102);
            this.chkGerenciaEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.chkGerenciaEstoque.Name = "chkGerenciaEstoque";
            this.chkGerenciaEstoque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkGerenciaEstoque.Size = new System.Drawing.Size(152, 23);
            this.chkGerenciaEstoque.TabIndex = 23;
            this.chkGerenciaEstoque.Text = "Gerencia Estoque";
            this.chkGerenciaEstoque.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 39);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 19);
            this.label11.TabIndex = 15;
            this.label11.Text = "Visibilidade";
            // 
            // cbEstoque
            // 
            this.cbEstoque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstoque.FormattingEnabled = true;
            this.cbEstoque.Location = new System.Drawing.Point(121, 69);
            this.cbEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.cbEstoque.Name = "cbEstoque";
            this.cbEstoque.Size = new System.Drawing.Size(160, 25);
            this.cbEstoque.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Estoque";
            // 
            // cbVisibilidade
            // 
            this.cbVisibilidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisibilidade.FormattingEnabled = true;
            this.cbVisibilidade.Location = new System.Drawing.Point(121, 36);
            this.cbVisibilidade.Margin = new System.Windows.Forms.Padding(4);
            this.cbVisibilidade.Name = "cbVisibilidade";
            this.cbVisibilidade.Size = new System.Drawing.Size(160, 25);
            this.cbVisibilidade.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAltura);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLargura);
            this.groupBox2.Controls.Add(this.txtComprimento);
            this.groupBox2.Controls.Add(this.txtPeso);
            this.groupBox2.Location = new System.Drawing.Point(4, 275);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(338, 148);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimensões";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Peso (kg)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Altura (cm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Comp. (cm)";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(141, 17);
            this.txtAltura.Margin = new System.Windows.Forms.Padding(4);
            this.txtAltura.MaxLength = 5;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(135, 24);
            this.txtAltura.TabIndex = 8;
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Largura (cm)";
            // 
            // txtLargura
            // 
            this.txtLargura.Location = new System.Drawing.Point(141, 49);
            this.txtLargura.Margin = new System.Windows.Forms.Padding(4);
            this.txtLargura.MaxLength = 5;
            this.txtLargura.Name = "txtLargura";
            this.txtLargura.Size = new System.Drawing.Size(135, 24);
            this.txtLargura.TabIndex = 9;
            this.txtLargura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // txtComprimento
            // 
            this.txtComprimento.Location = new System.Drawing.Point(141, 81);
            this.txtComprimento.Margin = new System.Windows.Forms.Padding(4);
            this.txtComprimento.MaxLength = 5;
            this.txtComprimento.Name = "txtComprimento";
            this.txtComprimento.Size = new System.Drawing.Size(135, 24);
            this.txtComprimento.TabIndex = 10;
            this.txtComprimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComprimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(141, 113);
            this.txtPeso.Margin = new System.Windows.Forms.Padding(4);
            this.txtPeso.MaxLength = 6;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(135, 24);
            this.txtPeso.TabIndex = 11;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalKeyPress);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblAviso);
            this.panel4.Location = new System.Drawing.Point(678, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 372);
            this.panel4.TabIndex = 26;
            // 
            // lblAviso
            // 
            this.lblAviso.BackColor = System.Drawing.Color.White;
            this.lblAviso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAviso.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblAviso.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAviso.Location = new System.Drawing.Point(0, 0);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(254, 370);
            this.lblAviso.TabIndex = 0;
            this.lblAviso.Text = resources.GetString("lblAviso.Text");
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgGravar
            // 
            this.bgGravar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGravar_DoWork);
            this.bgGravar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGravar_RunWorkerCompleted);
            // 
            // FrmCadastroInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 481);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.gbEstoque);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgItens);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCadastroInicial";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Enviar cadastro de itens";
            this.Load += new System.EventHandler(this.FrmCadastroInicial_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItens)).EndInit();
            this.gbEstoque.ResumeLayout(false);
            this.gbEstoque.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgItens;
        private System.Windows.Forms.GroupBox gbEstoque;
        private System.Windows.Forms.CheckBox chkGerenciaEstoque;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbEstoque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbVisibilidade;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLargura;
        private System.Windows.Forms.TextBox txtComprimento;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.ComponentModel.BackgroundWorker bgGravar;
        private System.Windows.Forms.Label lblAviso;
    }
}
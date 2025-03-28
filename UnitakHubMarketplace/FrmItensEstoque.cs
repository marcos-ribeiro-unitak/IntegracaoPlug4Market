using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UnitakHubMarketplace.Apis.Plug4Market;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;

namespace Unitak.Woocommerce
{
    public partial class FrmItensEstoque : Form
    {
        DataRow[] drs;
        Panel pnlProgress;

        public FrmItensEstoque(DataRow[] dtItens)
        {
            InitializeComponent();
            this.drs = dtItens;
        }

        private void FrmItensEstoque_Load(object sender, EventArgs e)
        {
            dgItens.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgItens.Columns.Add("ID_Item", "ID_Item");
            dgItens.Columns[0].Width = 60;
            dgItens.Columns.Add("Descricao", "Descricao");
            dgItens.Columns[1].Width = 200;
            dgItens.Columns.Add("ID_Ecommerce", "ID_Ecommerce");
            dgItens.Columns[2].Width = 60;

            DataGridViewComboBoxColumn cbEstoque = new DataGridViewComboBoxColumn();
            cbEstoque.HeaderText = "Estoque";
            cbEstoque.Name = "Estoque";
            cbEstoque.Items.Add("Em Estoque");
            cbEstoque.Items.Add("Esgotado");
            cbEstoque.Width = 120;
            dgItens.Columns.Add(cbEstoque);

            DataGridViewComboBoxColumn cbVisible = new DataGridViewComboBoxColumn();
            cbVisible.HeaderText = "Visibilidade";
            cbVisible.Name = "Visibilidade";
            cbVisible.Items.Add("Visivel");
            cbVisible.Items.Add("Invisivel");
            cbEstoque.Width = 120;
            dgItens.Columns.Add(cbVisible);

            DataGridViewCheckBoxColumn chkGeren = new DataGridViewCheckBoxColumn();
            chkGeren.Name = "Gerencia";
            chkGeren.HeaderText = "Gerencia";
            chkGeren.Width = 80;
            dgItens.Columns.Add(chkGeren);

            DataGridViewTextBoxColumn txtQtdEstoque = new DataGridViewTextBoxColumn();
            txtQtdEstoque.Name = "Qtd";
            txtQtdEstoque.HeaderText = "Qtd";
            txtQtdEstoque.Width = 80;
            txtQtdEstoque.ValueType = typeof(decimal);
            dgItens.Columns.Add(txtQtdEstoque);

            for (int i = 0; i < drs.Length; i++)
            {
                if (drs[i]["ID_Ecommerce"].ToString() != "")
                {
                    dgItens.Rows.Add(drs[i]["ID_Item"], drs[i]["Descricao"], drs[i]["ID_Ecommerce"],
                        "Em Estoque", "Visivel", false, 0);
                    dgItens.Rows[i].Height = 30;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgItens_Click(object sender, EventArgs e)
        {

        }

        private void dgItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 3)
            {
                dgItens.CurrentCell = dgItens.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgItens.BeginEdit(true);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            pnlProgress = ProgressPanel("Enviando dados, esta operação pode demorar...");
            bgGravarItens.RunWorkerAsync();
        }

        private bool Gravar()
        {
            List<Produto> listaProd = new List<Produto>();
            for (int i = 0; i < dgItens.Rows.Count; i++)
            {

                Produto p = new Produto();
                p.productId = dgItens.Rows[i].Cells["ID_MarketPlace"].Value.ToString();
                p.stock = int.Parse(dgItens.Rows[i].Cells["Qtd"].Value.ToString());

                p.active = (dgItens.Rows[i].Cells["Estoque"].Value.ToString() == "Em Estoque")
                    ? "true"
                    : "false";
                listaProd.Add(p);

            }

            return GravarMultiplos(listaProd);
        }

        public bool GravarMultiplos(List<Produto> listaProd)
        {
            ApiProdutos api = new ApiProdutos();
            DbProdutos db = new DbProdutos();

            int p100 = listaProd.Count / 100;
            int resto = listaProd.Count - (p100 * 100);
            for (int i = 0; i < p100; i++)
                //if (!db.UpdateWoo(drs, api.BatchAlterarProduto(listaProd.GetRange(i * 100, 100))))
                    return false;
            if (resto > 0)
                //if (!db.UpdateWoo(drs, api.BatchAlterarProduto(listaProd.GetRange((p100 * 100), resto))))
                    return false;

            return true;
        }


        private void dgItens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool chk = (bool)dgItens.Rows[e.RowIndex].Cells["Gerencia"].Value;

            if (dgItens.Rows[e.RowIndex].Cells["Qtd"].Value.ToString() == "" || !chk)
                dgItens.Rows[e.RowIndex].Cells["Qtd"].Value = "0";
            if (chk)
                dgItens.Rows[e.RowIndex].Cells["Estoque"].Value = "Em Estoque";
        }

        private void dgItens_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void dgItens_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        bool retorno = false;
        private void bgGravarItens_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            retorno = Gravar();
        }

        private void bgGravarItens_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pnlProgress.Visible = false;
            if (retorno)
                MessageBox.Show("Operação concluída com sucesso!!!");
            else
                MessageBox.Show("Houve um erro na operação");
            this.Dispose();
        }

        private Panel ProgressPanel(string mensagem)
        {
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.BackColor = this.BackColor;

            ProgressBar progress = new ProgressBar();
            // progress.Anchor = AnchorStyles.Bottom;
            progress.Location = new Point(145, 146);
            progress.Width = 450;
            progress.Height = 25;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Show();

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(200, 115);
            lbl.Font = new Font("Century Gothic", 10);
            lbl.Text = mensagem;//"Carregando informações...";

            pnl.Controls.Add(progress);
            pnl.Controls.Add(lbl);

            this.Controls.Add(pnl);
            pnl.BringToFront();

            return pnl;
        }
    }
}

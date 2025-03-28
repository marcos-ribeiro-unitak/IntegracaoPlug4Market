using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UnitakHubMarketplace;
using UnitakHubMarketplace.Db;

namespace Unitak.Woocommerce
{
    public partial class FrmCadastroItens : Form
    {
        DataTable dtGrupos, dtMarcas, dtItens, dtGrade;
        List<DataRow> linhasSelecionadas = new List<DataRow>();

        public FrmCadastroItens()
        {
            InitializeComponent();
        }

        private void FrmCadastroItens_Load(object sender, EventArgs e)
        {
            dtItens = new DataTable();
            dgItens.DataSource = dtItens;


            //btnAlteraDim.Enabled = false;
            //btnEstoque.Enabled = false;
            btnCadastrarItens.Enabled = false;

            DbProdutos db = new DbProdutos();
            dtGrupos = db.SelectGrupos();
            dtMarcas = db.SelectMarcas();
            foreach (DataRow dr in dtGrupos.Rows)
                cbGrupos.Items.Add(dr["Descricao"].ToString());
            //if (cbGrupos.Items.Count > 0)
            //    cbGrupos.SelectedIndex = 0;

            foreach (DataRow dr in dtMarcas.Rows)
                cbMarcas.Items.Add(dr["Marca"].ToString());
            cbQtdBusca.SelectedIndex = 0;
        }

        private void btnAlteraDim_Click(object sender, System.EventArgs e)
        {
            if (dgItens.SelectedRows.Count == 0)
                return;

            List<int> ids = new List<int>();
            for (int i = 0; i < dgItens.SelectedRows.Count; i++)
                ids.Add((int)dgItens.SelectedRows[i].Cells["ID_Item"].Value);

            int qtdgrade = dtItens.Select("ID_Item in (" + string.Join(",", ids) + ") and QTD_Grade > 1").Length;
            if (qtdgrade > 0)
            {
                MessageBox.Show("Você selecionou um ou mais itens com grade.\n\n" +
                    "Produtos com grade devem ser ajustados individualmente.\n\n" +
                    "Favor desmarcá-los para fazer essa operação.");
                return;
            }

            DataRow[] drs = dtItens.Select("ID_Item in (" + string.Join(",", ids) + ")");

            // pnlItem.Controls.Clear();
            FrmItensDimensao frmdim = new FrmItensDimensao(drs);
            frmdim.StartPosition = FormStartPosition.CenterParent;
            frmdim.ShowDialog();

            btnAtualizar.PerformClick();
        }

        private void btnAtualizar_Click(object sender, System.EventArgs e)
        {
            string pesquisa = txtPesquisa.Text.Trim();
            bool naoCad = chkNaoCadastrado.Checked;
            bool somenteGrade = chkSomenteGrade.Checked;

            int idGrupo = 0;
            if (cbGrupos.SelectedIndex >= 0)
                int.TryParse(dtGrupos.Rows[cbGrupos.SelectedIndex]["ID_Grupo"].ToString(), out idGrupo);
            if (cbGrupos.Enabled == false)
                idGrupo = 0;

            int idMarca = 0;
            if (cbMarcas.SelectedIndex >= 0)
                int.TryParse(dtMarcas.Rows[cbMarcas.SelectedIndex]["ID_Marca"].ToString(), out idMarca);
            if (cbMarcas.Enabled == false)
                idMarca = 0;

            string qtdBusca = cbQtdBusca.Text;
            int idEstoque = int.Parse(ConfigHub.ID_ESTOQUE);// database.variaveis.instance.Id_Estoque_Saida;

            dtItens = new DbProdutos().Select(pesquisa, idGrupo, idMarca, idEstoque, false, naoCad, qtdBusca, somenteGrade);
            dgItens.DataSource = dtItens;

            if (dgItens.Columns.Count > 0)
            {
                dgItens.Columns["Barras"].Width = 130;
                dgItens.Columns["Descricao"].Width = 180;
                dgItens.Columns["Preco_Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            foreach (DataGridViewColumn column in dgItens.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void ShowItem(int idItem, int linha)
        {
            
                UcItem uc = new UcItem(idItem, dtItens.Rows[linha], dtGrade);
                uc.Dock = DockStyle.Fill;
                uc.Show();

                Form frm = new Form();
                frm.Text = "Item";
                frm.ShowIcon = false;
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;
                frm.Size = new Size(580, 550);
                frm.MaximumSize = new Size(580, 550);
                frm.MinimumSize = new Size(580, 550);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Controls.Add(uc);
                frm.Show();
        


        }

        public void Tab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAtualizar.PerformClick();
        }

        private void btnEstoque_Click(object sender, System.EventArgs e)
        {
            if (dgItens.SelectedRows.Count == 0)
                return;

            List<int> ids = new List<int>();
            for (int i = 0; i < dgItens.SelectedRows.Count; i++)
                ids.Add((int)dgItens.SelectedRows[i].Cells["ID_Item"].Value);

            int qtdgrade = dtItens.Select("ID_Item in (" + string.Join(",", ids) + ") and QTD_Grade > 1").Length;
            if (qtdgrade > 0)
            {
                MessageBox.Show("Você selecionou um ou mais itens com grade.\n\n" +
                    "Produtos com grade devem ser ajustados individualmente.\n\n" +
                    "Favor desmarcá-los para fazer essa operação.");
                return;
            }

            DataRow[] drs = dtItens.Select("ID_Item in (" + string.Join(",", ids) + ")");

            // pnlItem.Controls.Clear();
            FrmItensEstoque frmest = new FrmItensEstoque(drs);
            frmest.StartPosition = FormStartPosition.CenterParent;
            frmest.ShowDialog();

            btnAtualizar.PerformClick();
        }

        private void chkSelecionarTudo_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSelecionarTudo.Checked)
                dgItens.SelectAll();
            else
                dgItens.ClearSelection();
        }

        private void dgItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = e.RowIndex;
            int idItem = (int)dtItens.Rows[linha]["ID_Item"];
            dtGrade = new DbProdutos().Grade(idItem, int.Parse(ConfigHub.ID_ESTOQUE));

            ShowItem(idItem, linha);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            cbGrupos.Enabled = !checkBox1.Checked;


        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            cbMarcas.Enabled = !checkBox2.Checked;
        }

        private void dgItens_SelectionChanged(object sender, EventArgs e)
        {
            //if(dgItens.SelectedRows.Count == 1)
            //{
            //    linhasSelecionadas.Clear();
            //}
        }

        private void dgItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow selec = ((DataRowView)dgItens.Rows[e.RowIndex].DataBoundItem).Row;
            //if (dgItens.Rows[e.RowIndex].Selected == true)
            //{
            //    if(!linhasSelecionadas.Contains(selec))
            //        linhasSelecionadas.Add(selec);
            //}
            //else
            //{
            //    if (linhasSelecionadas.Contains(selec))
            //        linhasSelecionadas.Remove(selec);
            //}

        }

        private void btnCadastrarGrupos_Click(object sender, System.EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void chkNaoCadastrado_CheckedChanged(object sender, System.EventArgs e)
        {
            dtItens.Clear();
            dgItens.DataSource = null;

            btnCadastrarItens.Enabled = chkNaoCadastrado.Checked;
            //btnCadastrarGrupos.Enabled = chkNaoCadastrado.Checked;
            btnAlteraDim.Enabled = !chkNaoCadastrado.Checked;
            btnEstoque.Enabled = !chkNaoCadastrado.Checked;
        }

        private void btnCadastrarItens_Click(object sender, System.EventArgs e)
        {
            if (dgItens.SelectedRows.Count == 0)
                return;

            List<int> ids = new List<int>();
            for (int i = 0; i < dgItens.SelectedRows.Count; i++)
                ids.Add((int)dgItens.SelectedRows[i].Cells["ID_Item"].Value);

            DataRow[] drs = dtItens.Select("ID_Item in (" + string.Join(",", ids) + ")");

            // pnlItem.Controls.Clear();
            FrmCadastroInicial frmcad = new FrmCadastroInicial(drs);
            frmcad.StartPosition = FormStartPosition.CenterParent;
            frmcad.ShowDialog();

            btnAtualizar.PerformClick();
        }
    }
}

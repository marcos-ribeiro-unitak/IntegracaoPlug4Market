using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UnitakHubMarketplace;
using UnitakHubMarketplace.Apis.Plug4Market;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;

namespace Unitak.Woocommerce
{
    public partial class FrmCategorias : Form
    {
        DataTable dtGrupo;

        public FrmCategorias()
        {
            InitializeComponent();
            
        }

        private void FrmCategorias_Load(object sender, System.EventArgs e)
        {
            ReloadDgGrupos();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            List<int> ids = new List<int>();
            for (int i = 0; i < dgGrupos.SelectedRows.Count; i++)
                ids.Add((int)dgGrupos.SelectedRows[i].Cells["ID_Grupo"].Value);

            DataRow[] drs = dtGrupo.Select("ID_Grupo in (" + string.Join(",", ids) + ")");
            ApiCustomCategories api = new ApiCustomCategories();
            
                List<CustomCategories> lista = new List<CustomCategories>();
                for (int i = 0; i < dgGrupos.SelectedRows.Count; i++)
                {
                    lista.Add(new CustomCategories()
                    {
                        alternativeId = (dgGrupos.SelectedRows[i].Cells["ID_Ecommerce"].Value.ToString() != "")
                            ? dgGrupos.SelectedRows[i].Cells["ID_Ecommerce"].ToString()
                            : "0",
                        name = dgGrupos.SelectedRows[i].Cells["Descricao"].Value.ToString(),
                    });
                }

            for (int i = 0; i < lista.Count; i++) {

                Retorno lRetorno = api.CriarCategoriaPersonalizada(lista[i]);
                bool ret = false;// new DbProdutos().UpdateGrupoWoo(drs, lRetorno);
                if (ret)
                    MessageBox.Show(this,
                        "Categorias enviadas com sucesso",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this,
                        "Não foi possível enviar todos os Grupo!\n" +
                        "Verifique no site se já existe uma categoria com o mesmo nome.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }






            ReloadDgGrupos();
        }

        private void chkSelecionarTudo_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSelecionarTudo.Checked)
                dgGrupos.SelectAll();
            else
                dgGrupos.ClearSelection();
        }

        private void dgGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idWoo = 0;
            int idGrupo = 0;
            int.TryParse(dgGrupos.Rows[e.RowIndex].Cells["ID_Ecommerce"].Value.ToString(), out idWoo);
            int.TryParse(dgGrupos.Rows[e.RowIndex].Cells["ID_Grupo"].Value.ToString(), out idGrupo);
            if (idWoo > 0)
            {
                DialogResult ret = MessageBox.Show("Deseja mesmo excluir esta categoria do site ?", "Deseja excluir ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(ret == DialogResult.Yes)
                {
                    ApiCustomCategories api = new ApiCustomCategories();
                       Retorno retorno = api.DeletarCategoriaPersonalizada(idWoo.ToString());

                        if (retorno != null)
                        {

                            bool resposta = new DbProdutos().RemoveIDGrupo(idGrupo);

                            if (resposta)
                            {
                                MessageBox.Show(this,
                                    "Categoria deletada com sucesso",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadDgGrupos();
                            }
                            else
                            {
                                MessageBox.Show(this,
                                    "Não foi deletar o Grupo!\n" +
                                    "Houve um erro ao tentar apagar o ID Woocomerce no banco",
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this,
                                    "Não foi deletar o Grupo!\n" +
                                    "Houve um erro ao tentar apagar a categoria no site",
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
                    
                }
            }
        }

        public void ReloadDgGrupos()
        {
            dtGrupo = new DbProdutos().SelectGrupos();
            dgGrupos.DataSource = dtGrupo;
            if (dgGrupos.Columns.Count > 0)
            {
                dgGrupos.Columns[0].Width = 100;
                dgGrupos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgGrupos.Columns[1].Width = 100;
                dgGrupos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgGrupos.Columns[2].Width = 250;
                dgGrupos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
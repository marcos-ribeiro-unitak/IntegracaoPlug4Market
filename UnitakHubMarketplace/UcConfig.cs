using System;
using System.Data;
using System.Windows.Forms;
using UnitakHubMarketplace.Db;

namespace UnitakHubMarketplace
{
    public partial class UcConfig : UserControl
    {
        DataTable dtCond, dtVend, dtItens, dtEstoque;

        public UcConfig()
        {
            InitializeComponent();
        }

        private void UcConfig_Load(object sender, EventArgs e)
        {
            ConfigHub.Carregar();
            InicializaCampos();
        }

      

        private void InicializaCampos()
        {
            //if (ConfigHub.INTEGRACAO == "Woocommerce")
            //    cbIntegracao.SelectedIndex = 0;
            //else
            //    cbIntegracao.SelectedIndex = 1;
            txtUrlSite.Text = ConfigHub.URL_API;
            txtAccessToken.Text = ConfigHub.ACCESS_TOKEN;
            txtRefreshToken.Text = ConfigHub.REFRESH_TOKEN;
            txtIDSeller.Text = ConfigHub.ID_SELLER;

            DbDav db = new DbDav();
            dtCond = db.SelectCondicoes();
            for (int i = 0; i < dtCond.Rows.Count; i++)
            {
                cbCondicao.Items.Add(dtCond.Rows[i]["Descricao"].ToString());
                if (dtCond.Rows[i]["ID_Condicao"].ToString() == ConfigHub.ID_CONDICAO)
                    cbCondicao.SelectedIndex = i;
            }

            dtVend = db.SelectVendedores();
            for (int i = 0; i < dtVend.Rows.Count; i++)
            {
                cbVendedor.Items.Add(dtVend.Rows[i]["Nome"].ToString());
                if (dtVend.Rows[i]["ID_Vendedor"].ToString() == ConfigHub.ID_VENDEDOR)
                    cbVendedor.SelectedIndex = i;
            }

            dtEstoque = db.SelectEstoques();
            for (int i = 0; i < dtEstoque.Rows.Count; i++)
            {
                cbEstoque.Items.Add(dtEstoque.Rows[i]["Estoque"].ToString());
                if (dtEstoque.Rows[i]["ID_Estoque"].ToString() == ConfigHub.ID_ESTOQUE)
                    cbEstoque.SelectedIndex = i;
            }

            dtItens = new DbProdutos().SelectCoringas();
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                cbCoringa.Items.Add(dtItens.Rows[i]["Descricao"].ToString());
                if (dtItens.Rows[i]["ID_Item"].ToString() == ConfigHub.ID_ITEM_CORINGA)
                    cbCoringa.SelectedIndex = i;
            }

            txtTimerPedidos.Text = ConfigHub.TIMER_PEDIDOS.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //ConfigHub.INTEGRACAO = cbIntegracao.SelectedItem.ToString();
            ConfigHub.URL_API = txtUrlSite.Text;

            ConfigHub.REFRESH_TOKEN = txtRefreshToken.Text;
            ConfigHub.ACCESS_TOKEN = txtAccessToken.Text;
            ConfigHub.LOGIN = txtUsuario.Text;
            ConfigHub.SENHA = txtSenha.Text;
            ConfigHub.ID_SELLER = txtIDSeller.Text;


            ConfigHub.ID_CONDICAO = dtCond.Rows[cbCondicao.SelectedIndex]["ID_Condicao"].ToString();
            ConfigHub.ID_VENDEDOR = dtVend.Rows[cbVendedor.SelectedIndex]["ID_Vendedor"].ToString();
            ConfigHub.ID_ESTOQUE = dtEstoque.Rows[cbEstoque.SelectedIndex]["ID_Estoque"].ToString();
            ConfigHub.ID_ITEM_CORINGA = dtItens.Rows[cbCoringa.SelectedIndex]["ID_Item"].ToString();
            //ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN = DateTime.Now;
            //ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN = DateTime.Now;
            ConfigHub.TIMER_PEDIDOS = int.Parse(txtTimerPedidos.Text.ToString());

            DataTable dtConfig = new DbConfig().Gravar();
            if (dtConfig != null && dtConfig.Rows.Count > 0)
            {
                MessageBox.Show("Gravado com Sucesso!");
                Parent.Dispose();
            }
        }

        private void IntegerKeyPress(object sender, KeyPressEventArgs e)
        {
            int i = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out i) && e.KeyChar != 8;
        }
    }
}

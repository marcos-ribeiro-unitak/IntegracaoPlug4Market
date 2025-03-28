using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UnitakHubMarketplace.Apis.Plug4Market;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;

namespace Unitak.Woocommerce
{
    public partial class FrmItensDimensao : Form
    {
        List<Produto> prodEnvios;
        DataRow[] drItens;

        Panel pnlProgress;

        public FrmItensDimensao()
        {
            InitializeComponent();
        }

        public FrmItensDimensao(DataRow[] drItens)
        {
            this.drItens = drItens;
            prodEnvios = new List<Produto>();

            InitializeComponent();
        }

        private void FrmItensDimensao_Load(object sender, EventArgs e)
        {
            Fill();

            txtAltura.Text = "0";
            txtComprimento.Text = "0";
            txtLargura.Text = "0";
            txtPeso.Text = "0";
        }

        private void Fill()
        {
            for (int i = 0; i < drItens.Length; i++)
            {
                Produto produto = new Produto();
                if (drItens[i]["ID_MarketPlace"].ToString() != "")
                    produto.productId = drItens[i]["ID_MarketPlace"].ToString();
                produto.name = drItens[i]["Descricao"].ToString();
                produto.price = double.Parse(drItens[i]["Preco_Unitario"].ToString());
                produto.salePrice = produto.price;
                //produto.regular_price = drItens[i]["Preco_Unitario"].ToString();
                produto.sku = drItens[i]["Barras"].ToString();
                produto.measurementUnit = "simple";
                //if (drItens[i]["ID_MarketPlace_categoria"].ToString() != "")
                //{
                //    produto.categories = new List<Categoria>();
                //    produto.categories.Add(new Categoria()
                //    {
                //        id = int.Parse(drItens[i]["ID_Ecommerce_categoria"].ToString()),
                //        name = drItens[i]["Descricao_Grupo"].ToString()
                //    }); 
                //}

                prodEnvios.Add(produto);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != ',')
                || (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(e.KeyChar) != -1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            pnlProgress = ProgressPanel("Aguarde, esta operação pode demorar...");
            bgGravar.RunWorkerAsync();
        }

        bool retorno = false;
        private void salvarBtn()
        {
            for (int i = 0; i < prodEnvios.Count; i++)
            {
                prodEnvios[i].height = int.Parse(txtAltura.Text);
                prodEnvios[i].length = int.Parse(txtComprimento.Text);
                prodEnvios[i].width = int.Parse(txtLargura.Text);
                prodEnvios[i].weight = int.Parse(txtPeso.Text);
            }
            retorno = GravarMultiplos(prodEnvios);
        }

        public bool GravarMultiplos(List<Produto> produto)
        {
            ApiProdutos api = new ApiProdutos();
            DbProdutos db = new DbProdutos();

            List<Produto> lCriar = produto.Where(prod => (prod.productId == "" || prod.productId == null)).ToList();
            List<Produto> lAlterar = produto.Where(prod => (prod.productId != "" && prod.productId != null)).ToList();

            int p100 = lCriar.Count / 100;
            int resto = lCriar.Count - (p100 * 100);
            for (int i = 0; i < p100; i++)
                //if (!db.UpdateWoo(drItens, api.BatchCriarProduto(lCriar.GetRange(i * 100, 100))))
                    return false;
            if (resto > 0)
                //if (!db.UpdateWoo(drItens, api.BatchCriarProduto(lCriar.GetRange((p100 * 100), resto))))
                    return false;

            p100 = lAlterar.Count / 100;
            resto = lAlterar.Count - (p100 * 100);
            for (int i = 0; i < p100; i++)
                //if(!db.UpdateWoo(drItens, api.BatchAlterarProduto(lAlterar.GetRange(i * 100, 100))))
                    return false;
            if (resto > 0)
                //if (!db.UpdateWoo(drItens, api.BatchAlterarProduto(lAlterar.GetRange((p100 * 100), resto))))
                    return false;

            return true;
        }

        private void bgGravar_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            salvarBtn();
        }

        private Panel ProgressPanel(string mensagem)
        {
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.BackColor = this.BackColor;

            ProgressBar progress = new ProgressBar();
            // progress.Anchor = AnchorStyles.Bottom;
            progress.Location = new Point(50, 106);
            progress.Width = 350;
            progress.Height = 20;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Show();

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(90, 75);
            lbl.Font = new Font("Century Gothic", 10);
            lbl.Text = mensagem;//"Carregando informações...";

            pnl.Controls.Add(progress);
            pnl.Controls.Add(lbl);

            this.Controls.Add(pnl);
            pnl.BringToFront();

            return pnl;
        }

        private void bgGravar_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pnlProgress.Visible = false;
            if (retorno)
                MessageBox.Show("Operação concluída com sucesso!!!");
            else
                MessageBox.Show("Houve um erro na operação");            
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
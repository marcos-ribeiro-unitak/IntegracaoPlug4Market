using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnitakHubMarketplace;
using UnitakHubMarketplace.Apis.Plug4Market;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;

namespace Unitak.Woocommerce
{
    public partial class FrmCadastroInicial : Form
    {
        Panel pnlProgress;

        //List<Unitak.Woocommerce.Models.ProdutoToSend> listaProdEnvioWoo;
        List<Produto> listaProdEnvioNuvem;
        List<int> idsComGrade;

        DataRow[] drItens;
        DataTable dtGrades;

        public FrmCadastroInicial(DataRow[] drItens)
        {
            InitializeComponent();
            this.drItens = drItens;
        }

        private void FrmCadastroInicial_Load(object sender, EventArgs e)
        {
            lblAviso.Text = "Os itens serão enviados com as informações cadastradas no sistema somadas às informações preenchidas abaixo.\n\n" +
                "As dimensões e configurações de estoque serão iguais para todos os produtos selecionados.\n\n" +
                "Isso é um pré-cadastro, posteriomente todos itens poderão ser alterados individualmente.";

            dgItens.Columns.Add("ID_Item", "ID_Item");
            dgItens.Columns[0].Width = 70;
            dgItens.Columns.Add("Descricao", "Descricao");
            dgItens.Columns[1].Width = 300;
            dgItens.Columns.Add("Preco_Unitario", "Preco_Unitario");
            dgItens.Columns[2].Width = 120;
            dgItens.Columns.Add("Estoque", "Estoque");
            dgItens.Columns[3].Width = 80;
            dgItens.Columns.Add("Barras", "Barras");
            dgItens.Columns[4].Width = 130;
            dgItens.Columns.Add("ID_Grupo", "ID_Grupo");
            dgItens.Columns[5].Width = 80;
            dgItens.Columns.Add("Descricao_Grupo", "Descricao_Grupo");
            dgItens.Columns[6].Width = 150;
            dgItens.Columns.Add("Qtd_Grade", "Qtd_Grade");
            dgItens.Columns[7].Width = 80;
            for (int i = 0; i < drItens.Length; i++)
            {
                dgItens.Rows.Add(
                    drItens[i]["ID_Item"],
                    drItens[i]["Descricao"],
                    drItens[i]["Preco_Unitario"],
                    drItens[i]["Estoque"],
                    drItens[i]["Barras"],
                    drItens[i]["ID_Grupo"],
                    drItens[i]["Descricao_Grupo"],
                    drItens[i]["Qtd_Grade"]);

                dgItens.Rows[i].Height = 30;
            }

            txtAltura.Text = "0";
            txtComprimento.Text = "0";
            txtLargura.Text = "0";
            txtPeso.Text = "0";

            cbEstoque.Items.Add("Em Estoque");
            cbEstoque.Items.Add("Fora de Estoque");
            cbVisibilidade.Items.Add("Visível");
            cbVisibilidade.Items.Add("Invisível");
            cbEstoque.SelectedIndex = 0;
            cbVisibilidade.SelectedIndex = 0;

            LoadGrade();
        }

        private void FillProdutosWoo()
        {
            //listaProdEnvioWoo = new List<ProdutoToSend>();
            for (int i = 0; i < drItens.Length; i++)
            {
                Produto produto = new Produto();
                //if (drItens[i]["ID_Woocommerce"].ToString() != "")
                //    produto.id = int.Parse(drItens[i]["ID_Woocommerce"].ToString());
                produto.name = drItens[i]["Descricao"].ToString();
                produto.salePrice = double.Parse(drItens[i]["Preco_Unitario"].ToString());
                produto.price = produto.salePrice;
                produto.sku = drItens[i]["Barras"].ToString();
                produto.measurementUnit = "simple";

                int qtdGrade = (drItens[i]["Barras"] != DBNull.Value && drItens[i]["Barras"].ToString() != "")
                    ? dtGrades.Select("ID_Item = " + drItens[i]["Barras"].ToString()).Length
                    : 0;

                //if (qtdGrade > 1)
                //{
                //    produto.type = "variable";
                //    produto.attributes = new List<Models.Attribute>();
                //    produto.attributes.Add(new Models.Attribute()
                //    {
                //        name = "Cor",
                //        variation = true,
                //        options = new List<string>()
                //    });
                //    produto.attributes.Add(new Models.Attribute()
                //    {
                //        name = "Tamanho",
                //        variation = true,
                //        options = new List<string>()
                //    });

                //    for (int j = 1; j < dtGrades.Rows.Count; j++)
                //    {
                //        if (drItens[i]["ID_Item"].ToString() == dtGrades.Rows[j]["ID_Item"].ToString())
                //        {
                //            string cor = dtGrades.Rows[j]["Cor"].ToString();
                //            if (!produto.attributes[0].options.Contains(cor))
                //                produto.attributes[0].options.Add(cor);

                //            string tam = dtGrades.Rows[j]["Tamanho"].ToString();
                //            if (!produto.attributes[1].options.Contains(tam))
                //                produto.attributes[1].options.Add(tam);
                //        }
                //    }
                //}

                if (drItens[i]["ID_Ecommerce_categoria"].ToString() != "")
                {
                    produto.categoryId = drItens[i]["ID_Ecommerce_categoria"].ToString();
                    
                }

                produto.height = int.Parse(txtAltura.Text);
                produto.length = int.Parse(txtComprimento.Text);
                produto.width = int.Parse(txtLargura.Text);
                produto.weight = int.Parse(txtPeso.Text);

                if (cbEstoque.Text == "Em Estoque")
                    produto.active = "true";
                else if (cbEstoque.Text == "Fora de Estoque")
                    produto.active = "false";

                //if (cbVisibilidade.Text == "Visível")
                //    produto.catalog_visibility = "visible";
                //else if (cbVisibilidade.Text == "Invisível")
                //    produto.catalog_visibility = "hidden";

                
                produto.stock = (chkGerenciaEstoque.Checked)
                    ? int.Parse(dgItens.Rows[i].Cells["Estoque"].Value.ToString())
                    : 0;

                //listaProdEnvioWoo.Add(produto);
            }
        }
        

        //private List<VariantToSend> CriarGrade(Unitak.Woocommerce.NuvemShopModels.ProductToSend produto, DataRow item)
        //{
        //    List<VariantToSend> listaVariantes = new List<VariantToSend>();
        //    DbProdutos dbProdutos = new DbProdutos();
        //    DataTable gradeVariante = dbProdutos.Grade(int.Parse(item["ID_Item"].ToString()), int.Parse(ConfigWoo.ID_ESTOQUE));
        //    if (gradeVariante.Rows.Count > 0)
        //    {
        //        if (produto.attributes == null)
        //            produto.attributes = new List<Attribute>();

        //        if (produto.attributes.Count == 0)
        //        {
        //            produto.attributes.Add(new Attribute()
        //            {
        //                en = "Cor",
        //                pt = "Cor",
        //                es = "Cor",
        //            });

        //            produto.attributes.Add(new Attribute()
        //            {
        //                en = "Tamanho",
        //                pt = "Tamanho",
        //                es = "Tamanho",
        //            });
        //        }

        //        for (int i = 0; i < gradeVariante.Rows.Count; i++)
        //        {

        //            VariantToSend variante = new VariantToSend();
        //            variante.price = item["Preco_Unitario"].ToString();
        //            variante.price = variante.price.Replace(",", ".");
        //            variante.cost = item["Preco_Unitario"].ToString();
        //            variante.cost = variante.cost.Replace(",", ".");
        //            variante.sku = gradeVariante.Rows[i]["Barras_Gerada"].ToString();
        //            variante.barcode = gradeVariante.Rows[i]["Barras_Gerada"].ToString();
        //            variante.stock = int.Parse(gradeVariante.Rows[i]["Estoque"].ToString().Replace(",0000", ""));


        //            if (variante.values == null)
        //                variante.values = new List<Value>();
        //            variante.values.Add(new Value()
        //            {
        //                en = gradeVariante.Rows[i]["Cor"].ToString(),
        //                es = gradeVariante.Rows[i]["Cor"].ToString(),
        //                pt = gradeVariante.Rows[i]["Cor"].ToString()
        //            });
        //            variante.values.Add(new Value()
        //            {
        //                en = gradeVariante.Rows[i]["Tamanho"].ToString(),
        //                es = gradeVariante.Rows[i]["Tamanho"].ToString(),
        //                pt = gradeVariante.Rows[i]["Tamanho"].ToString()
        //            });

        //            listaVariantes.Add(variante);
        //        }
        //    }
        //    return listaVariantes;
        //}

        //private List<Variante> GetVariantesWoo(DataRow[] drsGrade, DataRow drItem)
        //{
        //    List<Variante> listaVarEnvio = new List<Variante>();
        //    for (int i = 0; i < drsGrade.Length; i++)
        //    {
        //        if (drsGrade[i]["Cor"].ToString() != "Todos")
        //        {
        //            Variante var = new Variante();
        //            var.regular_price = drItem["Preco_Unitario"].ToString();
        //            var.regular_price = var.regular_price.Replace(",", ".");


        //            var.sku = drsGrade[i]["Barras"].ToString();

        //            var.attributes = new List<Models.Attribute>();
        //            var.attributes.Add(new Models.Attribute()
        //            {
        //                name = "Cor",
        //                option = drsGrade[i]["Cor"].ToString()
        //            });
        //            var.attributes.Add(new Models.Attribute()
        //            {
        //                name = "Tamanho",
        //                option = drsGrade[i]["Tamanho"].ToString()
        //            });

        //            //var.stock_status = listaProdEnvioWoo[0].stock_status;
        //            //var.catalog_visibility = listaProdEnvioWoo[0].catalog_visibility;
        //            //var.manage_stock = listaProdEnvioWoo[0].manage_stock;
        //            var.stock_quantity = ((bool)var.manage_stock)
        //                ? drsGrade[i]["Estoque"].ToString()
        //                : null;

        //            listaVarEnvio.Add(var);
        //        }
        //    }
        //    return listaVarEnvio;
        //}

        //private List<VariantToSend> GetVariantesNuvem(DataRow[] drsGrade, DataRow drItem)
        //{
        //    List<NuvemShopModels.VariantToSend> listaVarEnvio = new List<NuvemShopModels.VariantToSend>();
           
        //    for (int i = 0; i < drsGrade.Length; i++)
        //    {
        //        if (drsGrade[i]["Cor"].ToString() != "Todos")
        //        {
        //            VariantToSend variante = new VariantToSend();
        //            variante.price = drItem["Preco_Unitario"].ToString().FormataDecimaisComPonto();
        //            variante.sku = drsGrade[i]["Barras_Gerada"].ToString();
        //            variante.height = txtAltura.Text.FormataDecimaisComPonto();
        //            variante.depth = txtComprimento.Text.FormataDecimaisComPonto();
        //            variante.width = txtLargura.Text.FormataDecimaisComPonto();
        //            variante.weight = txtPeso.Text.FormataDecimaisComPonto();
        //            if (chkGerenciaEstoque.Checked)
        //                variante.stock = int.Parse(drsGrade[i]["Estoque"].ToString());
        //            variante.stock_management = (chkGerenciaEstoque.Checked);


        //            if (variante.values == null)
        //                variante.values = new List<Value>();
        //            variante.values.Add(new Value()
        //            {
        //                pt = drsGrade[i]["Cor"].ToString()
        //            });
        //            variante.values.Add(new Value()
        //            {
        //                pt = drsGrade[i]["Tamanho"].ToString()
        //            });

        //            listaVarEnvio.Add(variante);
        //        }
        //    }
        //    return listaVarEnvio;
        //}

        private void LoadGrade()
        {
            idsComGrade = new List<int>();
            for (int i = 0; i < dgItens.Rows.Count; i++)
                if ((int)dgItens.Rows[i].Cells["Qtd_Grade"].Value > 1)
                    idsComGrade.Add((int)dgItens.Rows[i].Cells["ID_Item"].Value);

            dtGrades = new DbProdutos().Grade(idsComGrade.ToArray(), int.Parse(ConfigHub.ID_ESTOQUE));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            pnlProgress = ProgressPanel("Aguarde, esta operação pode demorar...");
            bgGravar.RunWorkerAsync();
        }

        private void DecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != ',')
                || (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(e.KeyChar) != -1);
        }

        public bool GravarProdutos()
        {
            //int p50 = listaProdEnvioWoo.Count / 50;
            //int resto = listaProdEnvioWoo.Count - (p50 * 50);
            //for (int i = 0; i < p50; i++)
            //{
            //    List<Produto> listEnviados = api.BatchCriarProduto(listaProdEnvioWoo.GetRange(i * 50, 50));
            //    if (!db.UpdateWoo(drItens, listEnviados))
            //        return false;
            //}

            //if (resto > 0)
            //{
            //    List<Produto> listEnviados = api.BatchCriarProduto(listaProdEnvioWoo.GetRange(p50 * 50, resto));
            //    if (!db.UpdateWoo(drItens, listEnviados))
            //        return false;
            //}

            //if (!GravarVariantesWoo())
            //return false;
                FillProdutosWoo();
            
            return true;
        }

        public bool GravarVariantesWoo()
        {
            if (idsComGrade.Count == 0)
                return true;

            ApiProdutos api = new ApiProdutos();

            DataTable dtItensComGrade = new DbProdutos().SelectIDs(idsComGrade.ToArray());
            for (int i = 0; i < dtItensComGrade.Rows.Count; i++)
            {
                int idItem = int.Parse(dtItensComGrade.Rows[i]["ID_Item"].ToString());
                int idWoo = int.Parse(dtItensComGrade.Rows[i]["ID_Ecommerce"].ToString());
                DataRow[] drsGrade = dtGrades.Select("ID_Item = " + idItem);

                //List<Variante> lista = GetVariantesWoo(drsGrade, dtItensComGrade.Rows[i]);

                //int p100 = lista.Count / 100;
                //int resto = lista.Count - (p100 * 100);
                //for (int j = 0; j < p100; j++)
                //    api.CriarVariantes(idWoo, lista.GetRange(j * 100, 100));
                //if (resto > 0)
                //    api.CriarVariantes(idWoo, lista.GetRange(p100 * 100, resto));
            }

            return true;
        }


        bool retorno = false;
        private void bgGravar_DoWork(object sender, DoWorkEventArgs e)
        {
           
            retorno = GravarProdutos();
        }

        private void bgGravar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            progress.Location = new Point(300, 206);
            progress.Width = 350;
            progress.Height = 20;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Show();

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(330, 175);
            lbl.Font = new Font("Century Gothic", 10);
            lbl.Text = mensagem;//"Carregando informações...";

            pnl.Controls.Add(progress);
            pnl.Controls.Add(lbl);

            this.Controls.Add(pnl);
            pnl.BringToFront();

            return pnl;
        }

        private void dgItens_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtGrades == null)
                return;

            int idItem = (int)dgItens.Rows[e.RowIndex].Cells["ID_Item"].Value;
            DataRow[] drsGrade = dtGrades.Select("ID_Item = " + idItem);

            StringBuilder sb = new StringBuilder();
            if (drsGrade.Length > 1)
            {
                for (int i = 1; i < drsGrade.Length; i++)
                {
                    DataRow dr = drsGrade[i];
                    sb.Append("Cor: " + dr["Cor"].ToString() + "  Tam.: " + dr["Tamanho"].ToString() + "  Qtd.: " + dr["Estoque"].ToString());
                    sb.Append("\n");
                }
            }
            else if (drsGrade.Length == 1)
            {
                DataRow dr = drsGrade[0];
                sb.Append("Qtd. em Estoque: " + dr["Estoque"].ToString());
            }

            dgItens.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = sb.ToString();
        }
    }
}
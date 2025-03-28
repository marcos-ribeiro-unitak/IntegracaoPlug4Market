using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UnitakHubMarketplace;
using UnitakHubMarketplace.Apis.Plug4Market;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;

namespace Unitak.Woocommerce
{
    public partial class UcItem : UserControl
    {
        Produto produto;
        //List<Variante> listaVariantes;

        int idItem;
        ApiProdutos api;

        DataRow drItem;
        DataTable dtGrade;

        Panel pnlProgress;

        public UcItem()
        {
            InitializeComponent();

            produto = new Produto();
        }

        public UcItem(int idItem, DataRow drItem, DataTable dtGrade)
        {
            InitializeComponent();

            api = new ApiProdutos();

            this.idItem = idItem;
            this.drItem = drItem;
            this.dtGrade = dtGrade;
        }

        private void ucItem_Load(object sender, System.EventArgs e)
        {
            ConfigHub.Carregar();
            pnlProgress = ProgressPanel("Carregando informações...");
            FillProduto();
        }

        private Panel ProgressPanel(string mensagem)
        {
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.BackColor = this.BackColor;

            ProgressBar progress = new ProgressBar();
            progress.Anchor = AnchorStyles.None;
            progress.Width = 200;
            progress.Height = 20;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Show();

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(190, 175);
            lbl.Text = mensagem;//"Carregando informações...";

            pnl.Controls.Add(progress);
            pnl.Controls.Add(lbl);

            this.Controls.Add(pnl);
            pnl.BringToFront();

            return pnl;
        }

        public void inicializaCampos()
        {
            if (produto == null)
                produto = new Produto();

            txtNome.Text = produto.name;
            txtSku.Text = produto.sku;
            //if (!string.IsNullOrEmpty(produto.s))
            //    linkProduto.Text = "Ver Produto na Loja";
            txtPrecoRegular.Text = produto.price.ToString();
            txtPrecoVenda.Text =  produto.salePrice.ToString();

            
            txtAltura.Text = produto.height.ToString();
            txtLargura.Text = produto.width.ToString();
            txtComprimento.Text = produto.length.ToString();
            txtPeso.Text = produto.weight.ToString();



            cbEstoque.Items.Clear();
            cbEstoque.Items.Add("Em Estoque");
            cbEstoque.Items.Add("Fora de Estoque");
            if (produto.active == "true")
                cbEstoque.SelectedIndex = 1;
            else
                cbEstoque.SelectedIndex = 0;

            txtQtdEstoque.Enabled = chkGerenciaEstoque.Checked;
            txtQtdEstoque.Text = produto.stock.ToString();

            //if (listaVariantes.Count > 0)
            //{
            //    txtSku.Enabled = false;
            //    txtPrecoRegular.Enabled = false;
            //    txtPrecoVenda.Enabled = false;
            //    //cbEstoque.Enabled = false;
            //    //cbVisibilidade.Enabled = false;
            //    gbEstoque.Enabled = false;
            //    chkGerenciaEstoque.Checked = false;
            //    txtQtdEstoque.Text = "0";
            //}

            FillCategorias();
            FillGrade();
            FillImagens();
        }

        private void FillProduto()
        {
            bgLoad.RunWorkerAsync(Operacao.CARREGAR);
        }

        private void FillCategorias()
        {
            pnlCateg.Controls.Clear();
        }


        private void FillImagens()
        {
            Button btnMais = new Button();
            btnMais.Width = 70;
            btnMais.Height = 40;
            btnMais.FlatStyle = FlatStyle.Flat;
            btnMais.BackColor = Color.LightBlue;
            btnMais.Text = "+ Fotos";
            btnMais.Click += (sender, e) =>
            {
                BuscaImagens();
            };

            if (produto.images == null)
                produto.images = new List<string>();
            if (produto.images.Count == 0)
            {
                pnlImagens.Controls.Clear();
                pnlImagens.Controls.Add(btnMais);
                return;
            }

            pnlImagens.Controls.Clear();
            for (int i = 0; i < produto.images.Count; i++)
                pnlImagens.Controls.Add(FillPanelImagem(i));

            pnlImagens.Controls.Add(btnMais);
        }

        private void BuscaImagens()
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Multiselect = true;
            dia.Title = "Selecionar Fotos";
            //filtra para exibir somente arquivos de imagens
            dia.Filter = "Images (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG;";
            dia.CheckFileExists = true;
            dia.CheckPathExists = true;
            dia.FilterIndex = 2;
            dia.RestoreDirectory = true;
            dia.ReadOnlyChecked = true;
            dia.ShowReadOnly = true;

            DialogResult dr = dia.ShowDialog();
            if (dr == DialogResult.OK)
            {
                for (int i = 0; i < dia.FileNames.Length; i++)
                {
                    string[] ext = dia.FileNames[i].Split('.');
                    string file = (i + 1) + "." + ext[ext.Length - 1];
                    //bool ret = FtpAccess.UploadFile(dia.FileNames[i], "/produtos_temp", file);
                    //if (ret)
                    //    produto.images.Add(new Image()
                    //    {
                    //        src = ConfigWoo.URL_SITE + "/wp-content/uploads/produtos_temp/" + file
                    //    });
                    //else
                    //    MessageBox.Show("Erro ao fazer upload do arquivo!\n" + dia.FileNames[i]);
                }
                FillImagens();
            }
        }

        private Panel FillPanelImagem(int i)
        {
            Panel pnl = new Panel();
            pnl.Width = 100;
            pnl.Height = 100;

            PictureBox pic = new PictureBox();
            pic.Width = 90;
            pic.Height = 90;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.LoadAsync(produto.images[i]);

            Button btnX = new Button();
            btnX.Width = 20;
            btnX.Height = 20;
            btnX.FlatStyle = FlatStyle.Flat;
            btnX.BackColor = Color.Red;
            btnX.ForeColor = Color.White;
            btnX.Font = new Font("Consolas", 8);
            btnX.Text = "X";
            btnX.Location = new Point(80, 0);
            btnX.Click += (sender, e) =>
            {
                produto.images.RemoveAt(i);
                FillImagens();
            };

            pnl.Controls.Add(pic);
            pnl.Controls.Add(btnX);

            btnX.BringToFront();

            return pnl;
        }

        private void FillGrade()
        {
            if (dtGrade.Rows.Count > 1)
            {
                tabControl.TabPages["tabGrade"].Show();
                btnRecriarGrade.Visible = true;
            }
            else
            {
                if (tabControl.TabPages.ContainsKey("tabGrade"))
                    tabControl.TabPages["tabGrade"].Dispose();
                btnRecriarGrade.Visible = false;
            }

            if (dgGrade.Columns.Count == 0)
            {
                dgGrade.AllowUserToResizeRows = false;
                dgGrade.AllowUserToResizeColumns = false;

                dgGrade.Columns.Add("id", "#");
                dgGrade.Columns.Add("sku", "Barras");
                dgGrade.Columns.Add("cor", "Cor");
                dgGrade.Columns.Add("tamanho", "Tam");
                dgGrade.Columns.Add("estoque", "Disponível");
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                col.Name = "manage";
                col.HeaderText = "C";
                dgGrade.Columns.Add(col);

                //dgGrade.Columns.Add("manage", "C");
                dgGrade.Columns.Add("qtdEstoque", "Qtd");
                dgGrade.Columns.Add("preco", "Preço");
                dgGrade.Columns.Add("oferta", "Oferta");

                dgGrade.Columns[0].Width = 60;
                dgGrade.Columns[1].Width = 120;
                dgGrade.Columns[2].Width = 60;
                dgGrade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgGrade.Columns[3].Width = 40;
                dgGrade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgGrade.Columns[4].Width = 90;
                dgGrade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgGrade.Columns[5].Width = 30;
                dgGrade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgGrade.Columns[6].Width = 50;
                dgGrade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgGrade.Columns[7].Width = 75;
                dgGrade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgGrade.Columns[8].Width = 75;
                dgGrade.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgGrade.Rows.Clear();

            //listaVariantes =
            //    listaVariantes.OrderBy(
            //        v =>
            //    v.attributes[0].option + v.attributes[1].option
            //).ToList();

            //foreach (Variante v in listaVariantes)
            //{
            //    if (v.stock_status == null)
            //        v.stock_status = "instock";

            //    dgGrade.Rows.Add(v.id, v.sku,
            //        v.attributes[0].option,
            //        v.attributes[1].option,
            //        (v.stock_status == "instock")
            //            ? "Disponivel"
            //            : "Esgotado",
            //        v.manage_stock,
            //        v.stock_quantity,
            //        v.regular_price,
            //        v.sale_price);

            //    if (v.stock_status != "instock")
            //    {
            //        dgGrade.Rows[dgGrade.Rows.Count - 1].Cells["estoque"].Style.BackColor = Color.Tomato;
            //        dgGrade.Rows[dgGrade.Rows.Count - 1].Cells["estoque"].Style.SelectionBackColor = Color.Tomato;
            //    }
            //    else
            //    {
            //        dgGrade.Rows[dgGrade.Rows.Count - 1].Cells["estoque"].Style.BackColor = Color.LightCyan;
            //        dgGrade.Rows[dgGrade.Rows.Count - 1].Cells["estoque"].Style.SelectionBackColor = Color.LightCyan;
            //        dgGrade.Rows[dgGrade.Rows.Count - 1].Cells["estoque"].Style.SelectionForeColor = Color.DimGray;
            //    }
            //}
        }

        private void dgGrade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = e.RowIndex;

            //FrmVariacao frm = new FrmVariacao(listaVariantes[linha], linha);
            //DialogResult dr = frm.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    listaVariantes[linha] = frm.variante;
            //    if (listaVariantes[linha].image == null && produto.images != null && produto.images.Count > 0)
            //        listaVariantes[linha].image = produto.images[0];
            //}
            FillGrade();
        }

        Produto prodEnvio;
        private void btnEnviarItem_Click(object sender, System.EventArgs e)
        {
            prodEnvio = produto;
            prodEnvio.name = txtNome.Text;
            prodEnvio.sku = txtSku.Text;
            prodEnvio.price = double.Parse(txtPrecoRegular.Text.Replace(",", "."));
            prodEnvio.salePrice = double.Parse(txtPrecoVenda.Text.Replace(",", "."));

            prodEnvio.height = int.Parse(txtAltura.Text);
                prodEnvio.length = int.Parse(txtComprimento.Text);
                prodEnvio.width = int.Parse(txtLargura.Text);
            prodEnvio.weight = int.Parse(txtPeso.Text.Replace(",", "."));
            //prodEnvio.categories = produto.categories;
            //prodEnvio.tags = produto.tags;

            prodEnvio.images = produto.images;

            prodEnvio.active = (cbEstoque.SelectedItem.ToString() == "Em Estoque")
                    ? "true"
                    : "false";

            prodEnvio.stock = int.Parse(txtQtdEstoque.Text);

            pnlProgress = ProgressPanel("Gravando informações...");

            bgLoad.RunWorkerAsync(Operacao.GRAVAR);
        }

        private void btnNovaCateg_Click(object sender, System.EventArgs e)
        {
            //string busca = txtNovaCategoria.Text;
            //if (!validaBusca(busca, Tipo.CATEGORIA))
            //    return;

            //int selected = -1;
            //List<Categoria> lista = new ApiCategoria().GetAllCategoria(busca);
            //FrmSelecionar frm = new FrmSelecionar(lista, busca);
            //if (frm.ShowDialog() == DialogResult.OK)
            //    selected = frm.selected;

            //if (selected >= 0)
            //{
            //    if (!validaBusca(lista[selected].name, Tipo.CATEGORIA))
            //        return;
            //    produto.categories.Add(lista[selected]);
            //    FillCategorias();
            //}
        }

        


        private void DecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != ',')
                || (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(e.KeyChar) != -1);
        }

        private void IntegerKeyPress(object sender, KeyPressEventArgs e)
        {
            int i = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out i) && e.KeyChar != 8;
        }

        enum Operacao { CARREGAR, GRAVAR }
        private void bgLoad_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Operacao op = (Operacao)e.Argument;
            if (op == Operacao.CARREGAR)
                CarregarDados();
            else if (op == Operacao.GRAVAR)
                GravarDados();
        }

        private void CarregarDados()
        {
            
            produto = new Produto();
            if (drItem["ID_MarketPlace"].ToString() == "")
            {
                produto.name = drItem["Descricao"].ToString();
                produto.price = double.Parse(drItem["Preco_Unitario"].ToString());
                produto.salePrice = produto.price;
                produto.sku = drItem["Barras"].ToString();
                produto.measurementUnit = (dtGrade.Rows.Count > 1)
                    ? "variable"
                    : "simple";

                if (produto.images == null && drItem["Fotografia"].ToString() != "")
                {
                    byte[] data = (byte[])drItem["Fotografia"];
                    var fileStream = new FileStream(Application.StartupPath + "\\img.jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fileStream.Write(data, 0, data.Length);
                    fileStream.Close();

                    //bool ret = FtpAccess.UploadFile(Application.StartupPath + "\\img.jpg", "/produtos_temp", "1.jpg");
                    //produto.images = new List<Image>();
                    //if (ret)
                    //    produto.images.Add(new Image()
                    //    {
                    //        src = ConfigWoo.URL_SITE + "/wp-content/uploads/produtos_temp/1.jpg" //+ file
                    //    });
                }


                CriarGrade();
            }
            else
            {
                string sku = drItem["ID_MarketPlace"].ToString();
                produto = api.GetProdutoSku(sku);

               
                if (dtGrade.Rows.Count > 1)
                    CriarGrade();
            }

            this.Invoke((MethodInvoker)(() =>
            {
                inicializaCampos();
            }));
        }

        private void CriarGrade()
        {
            if (dtGrade.Rows.Count > 1)
            {
                //if (produto.attributes == null)
                //    produto.attributes = new List<Attribute>();

                //if (produto.attributes.Count == 0)
                //{
                //    produto.attributes.Add(new Attribute()
                //    {
                //        name = "Cor",
                //        variation = true,
                //        options = new List<string>()
                //    });

                //    produto.attributes.Add(new Attribute()
                //    {
                //        name = "Tamanho",
                //        variation = true,
                //        options = new List<string>()
                //    });
                //}

                //for (int i = 1; i < dtGrade.Rows.Count; i++)
                //{
                //    string cor = dtGrade.Rows[i]["Cor"].ToString();
                //    if (!produto.attributes[0].options.Contains(cor))
                //        produto.attributes[0].options.Add(cor);

                //    string tam = dtGrade.Rows[i]["Tamanho"].ToString();
                //    if (!produto.attributes[1].options.Contains(tam))
                //        produto.attributes[1].options.Add(tam);

                //    Variante variante = new Variante();
                //    variante.regular_price = drItem["Preco_Unitario"].ToString();
                //    variante.regular_price = variante.regular_price.Replace(",", ".");
                //    //variante.regular_price = drItem["Preco_Unitario"].ToString();
                //    variante.sku = dtGrade.Rows[i]["Barras_Gerada"].ToString();

                //    if (variante.attributes == null)
                //        variante.attributes = new List<Attribute>();
                //    variante.attributes.Add(new Attribute()
                //    {
                //        name = "Cor",
                //        option = dtGrade.Rows[i]["Cor"].ToString()
                //    });
                //    variante.attributes.Add(new Attribute()
                //    {
                //        name = "Tamanho",
                //        option = dtGrade.Rows[i]["Tamanho"].ToString()
                //    });

                //    listaVariantes.Add(variante);
                //}
            }
        }

        private void GravarDados()
        {
            if (produto.productId == null && produto.sku != "")
            {
                Produto produtoSku = api.GetProdutoSku(produto.sku);
                if (produtoSku != null )
                {
                    string msg = "Não foi possível gravar o item, pois já existe um produto com esse código de barras (SKU) no site.\n" +
                        "Modifique o código ou exclua o item do site para não haver duplicidade.\n\n" +
                        "Deseja acessar o item no site?\n\n" +
                        "* Para editar o produto é necessário estar logado com uma conta de administrador do site";

                    this.Invoke((MethodInvoker)(() =>
                    {
                        DialogResult res = MessageBox.Show(this, msg, "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                            System.Diagnostics.Process.Start(produtoSku.description);
                    }));
                    return;
                }
            }

            var produtoGravado = api.CriarProdutoSku(prodEnvio);
            if (produtoGravado != null)
                produto = produtoGravado;

            //if (listaVariantes.Count > 0)
            //{
            //    for (int i = 0; i < listaVariantes.Count; i++)
            //    {
            //        if (listaVariantes[i].regular_price == "" || listaVariantes[i].regular_price == null)
            //            listaVariantes[i].regular_price = prodEnvio.regular_price;
            //        if (listaVariantes[i].sale_price == "" || listaVariantes[i].sale_price == null)
            //            listaVariantes[i].sale_price = prodEnvio.sale_price;

            //        listaVariantes[i].weight = prodEnvio.weight;
            //        listaVariantes[i].dimensions = prodEnvio.dimensions;
            //    }

            //    List<Variante> variantesGravados = api.GravarVariantes(produto.id, listaVariantes);// listaVariacao);
            //    if (variantesGravados.Count > 0)
            //        listaVariantes = variantesGravados;

            //    prodEnvio.variations = listaVariantes.Select(v => v.id.Value).ToList();
            //}
            bool retDb = new DbProdutos().UpdateWoo(idItem, produtoGravado);

            this.Invoke((MethodInvoker)(() =>
            {
                inicializaCampos();
                if (retDb)
                    MessageBox.Show(this, produtoGravado.productId + " - " + produtoGravado.name + "\nGravado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, "Erro ao gravar produto no banco de dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void bgLoad_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pnlProgress.Visible = false;
        }

        private void dgGrade_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgGrade.SelectedRows.Count < 1)
                return;

            int linha = dgGrade.SelectedRows[0].Index;
            //txtPrecoRegular.Text = listaVariantes[linha].regular_price;
            //txtPrecoVenda.Text = listaVariantes[linha].sale_price;
        }

        private void linkProduto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(produto.permalink))
            //    System.Diagnostics.Process.Start(produto.permalink);
        }

        private void btnRecriarGrade_Click(object sender, System.EventArgs e)
        {
            string msg = "Isso apagará a grade existente no site e recriará à partir do sistema.\n" +
                "Deseja continuar?";
            DialogResult res = MessageBox.Show(this, msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //var ret = api.DeletarVariantes(produto);
                //if (ret != null)
                //{
                //    produto.variations = null;
                //    listaVariantes.Clear();
                //    CriarGrade();
                //    FillGrade();
                //}
            }
        }

        private void chkGerenciaEstoque_CheckedChanged(object sender, System.EventArgs e)
        {
            if(txtQtdEstoque.Text == "" || !chkGerenciaEstoque.Checked)
                txtQtdEstoque.Text = "0";
            if (chkGerenciaEstoque.Checked)
                cbEstoque.SelectedItem = "Em Estoque";
            txtQtdEstoque.Enabled = chkGerenciaEstoque.Checked;
            cbEstoque.Enabled = !chkGerenciaEstoque.Checked;
        }

        
    }
}
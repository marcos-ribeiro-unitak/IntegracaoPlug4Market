using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unitak.Uteis.Tipos;
using UnitakHubMarketplace;
using UnitakHubMarketplace.Apis.Plug4Market;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;
using UnitakHubMarketplace.SyslojaModels;
namespace Unitak.Woocommerce
{
    public enum Tipo { BOTAO, ICONE }

    public partial class FrmListaPedidos : Form
    {
        public int qtdPedAguardando;
        public Exception erro;

        Tipo tipo;
        Panel progress;
        Thread tBuscaAguard;
        Thread tAtualizaEstoque;

        public FrmListaPedidos(Tipo tipo)
        {
            this.tipo = tipo;
            InitializeComponent();
        }

        private void FrmListaPedidos_Load(object sender, System.EventArgs e)
        {
            ConfigHub.Carregar();
            new ApiAuth().Autenticar();

            InicializaCampos();

            tBuscaAguard = new Thread(new ThreadStart(tBuscaPedidosAguardando));
            tAtualizaEstoque = new Thread(new ThreadStart(tAtualizaOEstoque));
            tAtualizaEstoque.Start();
            tBuscaAguard.Start();

            if (!ConfigHub.validaConfig())
                return;
        }

        private void InicializaCampos()
        {
            //if (ConfigHub.INTEGRACAO == "NuvemShop")
            //tabPedidos.TabPages.RemoveAt(1);//PROCESSADOS

            if (dgvPedidosAguar.Columns.Count == 0)
            {
                AddCols(dgvPedidosAguar);
                AddCols(dgvPedidosAprov);
                AddCols(dgvPedidosFatu);
                //if (ConfigHub.INTEGRACAO == "Woocommerce")
                AddCols(dgvPedidosEnv);
                AddCols(dgvPedidosConc);
                AddCols(dgvPedidosCanc);

                dgvPedidosAguar.Columns.Add(colAbrir());
                dgvPedidosAprov.Columns.Add(colAbrir());
                dgvPedidosFatu.Columns.Add(colAbrir());
                dgvPedidosEnv.Columns.Add(colAbrir());
                dgvPedidosConc.Columns.Add(colAbrir());
                dgvPedidosCanc.Columns.Add(colAbrir());
            }
        }

        private void AddCols(DataGridView dgv)
        {
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            dgv.Columns.Add("id", "#");
            dgv.Columns.Add("total", "Total");
            dgv.Columns.Add("payment_method_title", "Forma");
            dgv.Columns.Add("date_paid", "Pagamento");

            dgv.Columns[0].Width = 60;
            dgv.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns[1].Width = 60;
            dgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //if (ConfigHub.INTEGRACAO == "NuvemShop" && dgv.Name == "dgvPedidosAguard")
            //    dgv.Columns[2].Width = 146;
            //else
            dgv.Columns[2].Width = 100;
            dgv.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            //if (ConfigHub.INTEGRACAO == "NuvemShop" && dgv.Name == "dgvPedidosAguard")
            //    dgv.Columns[3].Width = 146;
            //else
            dgv.Columns[3].Width = 100;
            dgv.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private DataGridViewImageColumn colAbrir()
        {
            DataGridViewImageColumn colAbrir = new DataGridViewImageColumn();
            //colAbrir.Image = new Bitmap(Properties.Resources.edit_branco);
            colAbrir.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colAbrir.Width = 92;
            colAbrir.DefaultCellStyle.Padding = new Padding(7);
            colAbrir.DefaultCellStyle.BackColor = Color.Orange;
            colAbrir.DefaultCellStyle.SelectionBackColor = Color.Orange;
            colAbrir.HeaderText = "";
            colAbrir.ToolTipText = "Clique para ABRIR o pedido";

            return colAbrir;
        }


        private string GravarDav(Order pedido)
        {
            DbClientes dbCli = new DbClientes();

            Cliente cli = new Cliente();
            DataTable dtCliente = dbCli.GravarCliente(pedido);
            if (dtCliente.Rows.Count > 0)
                cli = new Cliente(dtCliente.Rows[0], true);
            cli.Fill(pedido.billing);

            DbDav dbDav = new DbDav();
            Dav dav = dbDav.GravarODav(pedido, cli);

            GravarDavItens(pedido.orderItems, dav.ID_DAV);

            return dav.ID_DAV;
        }

        private void GravarDavItens(List<OrderItem> items, string ID_Dav)
        {
            DbDavItem dbDavIt = new DbDavItem();
            DbProdutos dbIt = new DbProdutos();
            for (int i = 0; i < items.Count; i++)
            {
                DavItem davit = new DavItem();
                Item it = new Item();
                DataTable dtIt = dbIt.SelectItem(int.Parse(items[i].productId));
                if (dtIt.Rows.Count > 0)
                {
                    davit = new DavItem(dtIt.Rows[0]);

                }
                davit.Fill(items[i], ID_Dav, i);

                //davit.Item = new Item(dtIt.Rows[0], [],true);
                //DataTable dtIt = dbDavIt.Select(items[i].productId);
                //if (dtIt.Rows.Count > 0)
                //    davit = new DavItem(dtIt.Rows[0]);
                davit.ID_Empresa = "1";

                davit.ID_DAV_Item = dbDavIt.Gravar(davit).ToString();
            }
        }

        private void tBuscaPedidosAguardando()
        {
            while (!IsDisposed)// && ConfigHub.TIMER_PEDIDOS > 0)
            {
                //CASO O LOGIN OU SENHA NÃO ESTEJAM CONFIGURADOS NÃO FAZ NADA
                //CASO O LOGIN OU SENHA NÃO ESTEJAM CONFIGURADOS NÃO FAZ NADA
                if (!string.IsNullOrEmpty(ConfigHub.LOGIN) || !string.IsNullOrEmpty(ConfigHub.SENHA))
                {

                    ApiPedido apiPedido = new ApiPedido();
                    RetornoOrders lista = apiPedido.GetPedidos(/*"paid"*/);
                    if (lista == null)
                        erro = new Exception("Erro ao buscar lista de Pedidos");
                    else
                        erro = null;

                    if (erro == null)
                    {
                        qtdPedAguardando = lista.data.Count;
                        for (int i = 0; i < lista.data.Count(); i++)
                        {
                            if (lista.data[i].status == "APPROVED" && (lista.data[i].orderIdStore == "" || lista.data[i].orderIdStore == null))
                                FillLista(dgvPedidosAguar, lista, lista.data[i].status);
                        }
                    }
                    else
                    {
                        if (apiPedido.retorno.error_status == 401)
                        {
                            new ApiAuth().Autenticar();
                        }
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                Thread.Sleep(ConfigHub.TIMER_PEDIDOS * 1000);

            }
        }

        private void tAtualizaOEstoque()
        {
            while (!IsDisposed)// && ConfigHub.TIMER_PEDIDOS > 0)
            {
                DateTime ultimaAtualizacao;

                ultimaAtualizacao = DateTime.Now;
                DbProdutos dbProdutos = new DbProdutos();
                ApiProdutos apiProdutos = new ApiProdutos();
                DataTable dtEstoque = dbProdutos.SelectEstoqueCardex();
                List<string> lIdSku = new List<string>();
                List<Produto> lProduto = new List<Produto>();
                /// select utlima atualização
                foreach (DataRow dr in dtEstoque.Rows)
                {
                    if (dr["ID_Marketplace"].ToString() != null && dr["ID_Marketplace"].ToString() != "")
                    {
                        Produto pRetorno = apiProdutos.GetProdutoSku(dr["ID_Marketplace"].ToString());
                        double estoque = double.Parse(dr["Estoque_Depois"].ToString());
                        if (estoque < 0)
                            estoque = 0;
                        //pRetorno.variation_attributes[i].stock = (int) estoque;
                        lProduto.Add(pRetorno);
                        //for (int i = 0; i < pRetorno.variation_attributes.Count; i++) {
                        //    if (pRetorno.variation_attributes[i].value_id == dr["Codigo"].ToString() && !lIdSku.Contains(dr["Codigo"].ToString()) )
                        //    {
                        //        double estoque = double.Parse(dr["Estoque_Depois"].ToString());
                        //        if (estoque < 0)
                        //            estoque = 0;
                        //        //pRetorno.variation_attributes[i].stock = (int) estoque;
                        //        lProduto.Add(pRetorno);
                        //        lIdSku.Add(pRetorno.variation_attributes[i].value_id);
                        //    }
                        //}

                    }
                }
                if (dtEstoque.Rows.Count > 0)
                {
                    //apiProdutos.AlterarStockNuvemShop(lProduto);
                    ConfigHub.ULTIMA_ATUALIZACAO = ultimaAtualizacao;
                }





                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                Thread.Sleep(ConfigHub.TIMER_PEDIDOS * 1000);
            }
        }

        private Panel ProgressPanel(string mensagem)
        {
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.BackColor = this.BackColor;

            ProgressBar progress = new ProgressBar();
            progress.Anchor = AnchorStyles.None;
            progress.Width = 220;
            progress.Height = 20;
            progress.Style = ProgressBarStyle.Marquee;
            progress.Show();

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(140, 140);
            lbl.Text = mensagem;

            pnl.Controls.Add(progress);
            pnl.Controls.Add(lbl);

            this.Controls.Add(pnl);
            pnl.BringToFront();

            return pnl;
        }

        private void FrmListaPedidos_Deactivate(object sender, EventArgs e)
        {
            if (tipo == Tipo.BOTAO)
                this.Hide();
        }

        private void FrmListaPedidos_Shown(object sender, EventArgs e)
        {
            tabPedidos.SelectedIndex = 0;
        }


        public bool forceClose = false;
        private void FrmListaPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !forceClose;
            if (tBuscaAguard != null)
            {
                tBuscaAguard.Abort();
                tBuscaAguard = null;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TaskBusca(string status)
        {
            lblLoad.Visible = true;
            lblLoad.Text = "Carregando...";
            lblLoad.BackColor = Color.DodgerBlue;

            dgvPedidosAguar.Rows.Clear();
            dgvPedidosAprov.Rows.Clear();
            dgvPedidosFatu.Rows.Clear();
            dgvPedidosEnv.Rows.Clear();
            dgvPedidosConc.Rows.Clear();
            dgvPedidosCanc.Rows.Clear();

            Task.Run(() =>
            {
                ApiPedido apiPedido = new ApiPedido();
                RetornoOrders lista = apiPedido.GetPedidos();

                if (lista != null)
                {
                    for (int i = 0; i < lista.data.Count(); i++)
                    {
                        if (lista.data[i].status == "APPROVED" && (lista.data[i].orderIdStore == "" || lista.data[i].orderIdStore == null))
                            FillLista(dgvPedidosAguar, lista, lista.data[i].status);
                        else if (lista.data[i].status == "APPROVED" && (lista.data[i].orderIdStore != "" && lista.data[i].orderIdStore != null))
                            FillLista(dgvPedidosAprov, lista, lista.data[i].status);
                        else if (lista.data[i].status == "INVOICED")
                            FillLista(dgvPedidosFatu, lista, lista.data[i].status);
                        else if (lista.data[i].status == "SHIPPED")
                            FillLista(dgvPedidosEnv, lista, lista.data[i].status);
                        else if (lista.data[i].status == "COMPLETED")
                            FillLista(dgvPedidosConc, lista, lista.data[i].status);
                        else if (lista.data[i].status == "CANCELED")
                            FillLista(dgvPedidosCanc, lista, lista.data[i].status);
                    }
                }
            });
        }

        private void tabPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabPedidos.SelectedIndex == 0)
                TaskBusca("NEW");
            else if (tabPedidos.SelectedIndex == 1)
                TaskBusca("APPROVED");
            else if (tabPedidos.SelectedIndex == 2)
                TaskBusca("INVOICED");
            else if (tabPedidos.SelectedIndex == 3)
                TaskBusca("SHIPPED");
            else if (tabPedidos.SelectedIndex == 4)
                TaskBusca("COMPLETED");
            else if (tabPedidos.SelectedIndex == 5)
                TaskBusca("CANCELED");
            else
                lblLoad.Visible = false;



        }

        private void dgPedidos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 4)
            {
                this.Hide();
                ApiPedido apiPedido = new ApiPedido();
                DataOrder retPed = (DataOrder)dgvPedidosAguar.Rows[e.RowIndex].Tag;
                Order order = apiPedido.GetPedido(retPed.id.ToString());
                if (order != null)
                {
                    FrmPedido frm = new FrmPedido(order);
                    frm.ShowInTaskbar = true;
                    DialogResult result = frm.ShowDialog();
                    this.Show();
                    if (result == DialogResult.Yes)
                        new ApiPedido().ConfirmaPedido(order);
                }

            }
        }


        private void FrmListaPedidos_Activated(object sender, EventArgs e)
        {
            tabPedidos.SelectedIndex = 0;
        }

        public void FillLista(DataGridView dgv, RetornoOrders lista, string status)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                List<DataOrder> listaStatus = new List<DataOrder>();
                if (dgv.Columns.Count == 0 || lista == null)
                {
                    lblLoad.Text = "Erro ao buscar Pedidos";
                    lblLoad.BackColor = Color.Red;
                    return;
                }

                dgv.Rows.Clear();
                if (dgv.Name == "dgvPedidosAguar")
                {
                    listaStatus = lista.data.Where((e) => e.status == status && (e.orderIdStore == null || e.orderIdStore == "")).ToList();

                }
                else if (dgv.Name == "dgvPedidosAprov")
                {
                    listaStatus = lista.data.Where((e) => e.status == status && (e.orderIdStore != null && e.orderIdStore != "")).ToList();
                }
                else
                {
                    listaStatus = lista.data.Where((e) => e.status == status).ToList();
                }
                for (int i = 0; i < listaStatus.Count; i++)
                {
                    if (status == listaStatus[i].status)
                    {
                        DataOrder ped = listaStatus[i];
                        dgv.Rows.Add(ped.id, ped.amount, ped.status, ped.updatedAt, ped.note, ped.saleChannelId);
                        dgv.Rows[i].Tag = ped;
                    }
                }

                lblLoad.Visible = false;
            }));
        }


        /// <summary>
        /// DataGrid View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 /*|| e.ColumnIndex == 5*/)
            {
                //FrmPedido frm = null;

                DataOrder retPed = (DataOrder)dgvPedidosAguar.Rows[e.RowIndex].Tag;
                Order order = new ApiPedido().GetPedido(retPed.id.ToString());
                FrmPedido frm = new FrmPedido(order);
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    order.orderIdStore = GravarDav(order);
                    if (order.orderIdStore != null && order.orderIdStore != null)
                        new ApiPedido().ConfirmaPedido(order);
                }
                //if (e.ColumnIndex == 4)
                //    new ApiPedido().ConfirmaPedido(order);
                this.Show();


                //if (frm != null)
                //    frm.Dispose();

            }
        }


        private void dgvPedidosConc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();

                DataOrder retPed = (DataOrder)dgvPedidosConc.Rows[e.RowIndex].Tag;
                Order order = new ApiPedido().GetPedido(retPed.id.ToString());
                FrmPedido frm = new FrmPedido(order);
                DialogResult result = frm.ShowDialog();
                //if (result == DialogResult.OK)
                //    new ApiPedido().ConfirmaçaoEntrega(order);
                //frm.ShowInTaskbar = true;
                //frm.ShowDialog();
                this.Show();
            }
        }

        private void dgvPedidosCanc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();
                DataOrder retPed = (DataOrder)dgvPedidosCanc.Rows[e.RowIndex].Tag;
                Order order = new ApiPedido().GetPedido(retPed.id.ToString());
                FrmPedido frm = new FrmPedido(order);
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.OK)
                    //new ApiPedido().ConfirmaPedido(order);
                    frm.ShowInTaskbar = true;
                //frm.ShowDialog();

                this.Show();
            }
        }


        private void dgvPedidosAprov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();
                DataOrder retPed = (DataOrder)dgvPedidosAprov.Rows[e.RowIndex].Tag;
                Order order = new ApiPedido().GetPedido(retPed.id.ToString());
                FrmPedido frm = new FrmPedido(order);
                // if order.invoice == null preencher os dados para faturamento

                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    if (order.invoice == null)
                    {
                        DbDav dav = new DbDav();
                        DataTable dt = dav.SelectDavNfe(int.Parse(order.orderIdStore));
                        if (dt.Rows.Count > 0)
                        {
                            order.invoice.Fill(order, dt);
                        }
                        else
                        {
                            //criar um dialog para receber as informaçoes manualmente
                        }
                    }
                    //new DbDav().GravarODav();
                    if (order.invoice != null)
                        new ApiPedido().ConfirmaFaturamento(order);

                }
                frm.ShowInTaskbar = true;

                this.Show();
            }
        }

        private void dgvPedidosFatu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();
                DataOrder retPed = (DataOrder)dgvPedidosFatu.Rows[e.RowIndex].Tag;
                Order order = new ApiPedido().GetPedido(retPed.id.ToString());
                FrmPedido frm = new FrmPedido(order);
                // preencher o envio

                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (order.shipment == null)
                    {
                        order.shipment = new Shipment();
                        order.shipment.shippingCarrier = "A";
                        order.shipment.trackingUrl = "string";
                        order.shipment.trackingNumber = "afg";
                    }
                    new ApiPedido().ConfirmaEnvio(order);
                }
                frm.ShowInTaskbar = true;

                this.Show();
            }
        }

        private void dgvPedidosEnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();
                DataOrder retPed = (DataOrder)dgvPedidosEnv.Rows[e.RowIndex].Tag;
                Order order = new ApiPedido().GetPedido(retPed.id.ToString());
                FrmPedido frm = new FrmPedido(order);
                DialogResult result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (order.deliveredAt == null)
                    {
                        order.deliveredAt = DateTime.Now;
                    }
                    new ApiPedido().ConfirmaçaoEntrega(order);
                }
                frm.ShowInTaskbar = true;

                this.Show();
            }
        }
    }
}
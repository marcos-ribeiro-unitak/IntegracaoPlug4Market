using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Unitak.Woocommerce;
using UnitakHubMarketplace;

namespace LojaWooCommerce
{
    public partial class FrmMarketplace : Form
    {
        FrmListaPedidos frmPedidos;
        bool isHide = false;
        bool forceClose = false;
        int qtd = 0;

        public FrmMarketplace()
        {
            InitializeComponent();
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isHide == false)
            {
                frmPedidos.Hide();
                isHide = true;
            }
            else
            {
                frmPedidos.WindowState = FormWindowState.Normal;
                //frmPedidos.BringToFront();
                frmPedidos.TopLevel = true;
                frmPedidos.Show();
                isHide = false;
            }
        }

        private void FrmWooCommerce_Load(object sender, System.EventArgs e)
        {
            this.Hide();

            StringBuilder sb = new StringBuilder();
            sb.Append("Unitak Tecnologia\n\n");
            sb.Append("Módulo de integração do sistema Sysloja PRO com ");
            sb.Append("a plataforma de loja virtual Wordpress e WooCommerce");

            label.Text = sb.ToString();

            StringBuilder sbReq = new StringBuilder();
            sbReq.Append("Woocommerce\nVersão 7.9.0\n\n");
            sbReq.Append("Brazilian Market on WooCommerce\nVersão 3.8.2\n\n");
            sbReq.Append("Claudio Sanches - Correios for WooCommerce\nVersão 3.8.0\n\n");
            sbReq.Append("Claudio Sanches - PagSeguro for WooCommerce\nVersão 2.14.0");
            txtRequisitos.Text = sbReq.ToString();


            frmPedidos = new FrmListaPedidos(Tipo.ICONE);
            frmPedidos.StartPosition = FormStartPosition.Manual;
            //frmPedidos.WindowState = FormWindowState.Minimized;
            //frm.Height = Screen.PrimaryScreen.Bounds.Height - 40;

            int x = Screen.PrimaryScreen.Bounds.Width - frmPedidos.Width;
            int y = Screen.PrimaryScreen.Bounds.Height - frmPedidos.Height - 40;

            frmPedidos.Location = new Point(x, y);
            frmPedidos.Show();
            frmPedidos.Hide();
            isHide = true;

            bgAlerta.RunWorkerAsync();
        }


        private void bgAlerta_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!IsDisposed)
            {
                try
                {
                    if (frmPedidos.qtdPedAguardando > 0 && notify.Tag.ToString() != "NOVO")
                    {
                        //notify.Icon = Icon.FromHandle(Properties.Resources.ico_woo_notify.GetHicon());
                        notify.Tag = "NOVO";

                        if (qtd < frmPedidos.qtdPedAguardando)
                            notify.ShowBalloonTip(500, "Loja Virtual", "Novo Pedido", ToolTipIcon.Info);

                        qtd = frmPedidos.qtdPedAguardando;
                    }
                    else if (frmPedidos.qtdPedAguardando == 0 && notify.Tag.ToString() != "OK")
                    {
                        //notify.Icon = Icon.FromHandle(Properties.Resources.ico_woo_azul.GetHicon());
                        notify.Tag = "OK";
                        qtd = 0;
                    }
                    else if (frmPedidos.erro != null && notify.Tag.ToString() != "ERRO")// && !frmPedidos.alreadyShowError)
                    {
                        //notify.Icon = Icon.FromHandle(Properties.Resources.ico_woo_vermelho.GetHicon());
                        notify.Tag = "ERRO";
                        
                        notify.ShowBalloonTip(ConfigHub.TIMER_PEDIDOS * 1000, "Loja Virtual", "Erro: " + frmPedidos.erro.Message, ToolTipIcon.Error);
                        Thread.Sleep(ConfigHub.TIMER_PEDIDOS * 1000);

                        notify.Visible = false;
                        notify.Visible = true;
                    }

                    Thread.Sleep(1000);
                }
                catch (System.Exception)
                {
                    //do nothing
                }
            }
        }

        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void notify_BalloonTipClicked(object sender, System.EventArgs e)
        {
            frmPedidos.WindowState = FormWindowState.Normal;
            frmPedidos.TopLevel = true;
            frmPedidos.Show();
            isHide = false;
        }

        private void FrmWooCommerce_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !forceClose;
        }


        private void menuConfig_Click(object sender, System.EventArgs e)
        {
            frmPedidos.Hide();
            isHide = true;

            Form frmSenha = new Form();
            frmSenha.BackColor = frmPedidos.BackColor;
            frmSenha.Text = "Digite a senha para acessar as configurações";
            frmSenha.Padding = new Padding(10);
            frmSenha.Width = 310;
            frmSenha.Height = 100;
            frmSenha.ShowIcon = false;
            frmSenha.Font = new Font("Century Gothic", 10f);
            frmSenha.StartPosition = FormStartPosition.CenterScreen;
            frmSenha.ShowIcon = false;
            frmSenha.MinimizeBox = false;
            frmSenha.MaximizeBox = false;
            frmSenha.FormBorderStyle = FormBorderStyle.FixedSingle;

            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.Dock = DockStyle.Fill;
            pnl.FlowDirection = FlowDirection.LeftToRight;

            Label lbl = new Label();
            lbl.Width = 60;
            lbl.Text = "Senha:";
            lbl.Anchor = AnchorStyles.None;

            TextBox txt = new TextBox();
            txt.Width = 200;
            txt.PasswordChar = '*';
            txt.Anchor = AnchorStyles.None;
            txt.KeyDown += (s, eh) =>
            {
                if (eh.KeyCode == Keys.Enter)
                {
                    if (txt.Text == "uni2008")
                    {
                        frmSenha.Dispose();

                        Form frmConfig = new Form();
                        frmConfig.Text = "Configurações";
                        frmConfig.Width = 550;
                        frmConfig.Height = 600;
                        frmConfig.StartPosition = FormStartPosition.CenterScreen;
                        frmConfig.ShowIcon = false;

                        frmConfig.Controls.Add(new UcConfig());
                        frmConfig.MinimizeBox = false;
                        frmConfig.MaximizeBox = false;
                        frmConfig.FormBorderStyle = FormBorderStyle.FixedSingle;
                        frmConfig.ShowDialog();
                    }
                    else
                    {
                        frmSenha.Dispose();
                        MessageBox.Show("Senha inválida");
                    }

                }
            };


            pnl.Controls.Add(lbl);
            pnl.Controls.Add(txt);

            frmSenha.Controls.Add(pnl);

            frmSenha.ShowDialog();

        }

        private void menuCadstroGrupos_Click(object sender, System.EventArgs e)
        {
            if (!ConfigHub.validaConfig())
                return;

            //FrmCategorias frm = new FrmCategorias();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.Show();

            frmPedidos.Hide();
            isHide = true;
        }

        private void menuPedidos_Click(object sender, System.EventArgs e)
        {
            if (!ConfigHub.validaConfig())
                return;

            if (frmPedidos == null)
                frmPedidos = new FrmListaPedidos(Tipo.ICONE);
            frmPedidos.WindowState = FormWindowState.Normal;
            frmPedidos.TopLevel = true;
            frmPedidos.Show();
            isHide = false;
        }

        private void menuCadastro_Click(object sender, System.EventArgs e)
        {
            if (!ConfigHub.validaConfig())
                return;
            
            //FrmCadastroItens cad = new FrmCadastroItens();
            //cad.StartPosition = FormStartPosition.CenterScreen;
            //cad.Show();
            //UcCadastroItens uc = new UcCadastroItens();
            //uc.Dock = DockStyle.Fill;
            //uc.Show();

            //Form frmCadastro = new Form();
            //frmCadastro.StartPosition = FormStartPosition.CenterScreen;
            //frmCadastro.MinimumSize = new Size(1100, 550);
            //frmCadastro.Controls.Add(uc);
            //frmCadastro.ShowIcon = false;
            //frmCadastro.Show();

            frmPedidos.Hide();
            isHide = true;
        }

        private void menuSobre_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            frmPedidos.Hide();
            isHide = true;
        }

        private void menuSair_Click(object sender, System.EventArgs e)
        {
            frmPedidos.forceClose = true;
            forceClose = true;
            Application.Exit();
        }

        private void btnVerificar_Click(object sender, System.EventArgs e)
        {
            //ApiStatus api = new ApiStatus();
            //List<dynamic> dPlugins = new List<dynamic>();
            //dPlugins.AddRange(api.GetPlugins());

            //dynamic[] pWoo = dPlugins.Where(p => p.name == "WooCommerce").ToArray();
            //dynamic[] pMarket = dPlugins.Where(p => p.name == "Brazilian Market on WooCommerce").ToArray();
            //dynamic[] pCorreios = dPlugins.Where(p => p.name == "Claudio Sanches - Correios for WooCommerce").ToArray();
            //dynamic[] pPagSeguro = dPlugins.Where(p => p.name == "Claudio Sanches - PagSeguro for WooCommerce").ToArray();

            //StringBuilder sb = new StringBuilder();
            //if (pWoo.Length > 0)
            //    sb.Append(pWoo[0].name + "\nVersão " + pWoo[0].version + "\n\n");
            //if (pMarket.Length > 0)
            //    sb.Append(pMarket[0].name + "\nVersão " + pMarket[0].version + "\n\n");
            //if (pCorreios.Length > 0)
            //    sb.Append(pCorreios[0].name + "\nVersão " + pCorreios[0].version + "\n\n");
            //if (pPagSeguro.Length > 0)
            //    sb.Append(pPagSeguro[0].name + "\nVersão " + pPagSeguro[0].version + "");

            //txtPlugins.Text = sb.ToString();
        }
    }
}

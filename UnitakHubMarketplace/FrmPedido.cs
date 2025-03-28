using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace
{
    public partial class FrmPedido : Form
    {

        Order order;
        //Apiorder apiPedido;

        public FrmPedido(Order order)
        {
            //apiPedido = new ApiPedido();
            this.order = order;
            InitializeComponent();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            inicializaCampos();
        }

        private void inicializaCampos()
        {

            if (order.status == "NEW")
            {
                pnlTop.BackColor = Color.FromArgb(220, 220, 220);

                lblStatus.Text = "Pagamento Pendente";
                pnlRodape.Enabled = false;
                dgItens.ReadOnly = true;
                btnFinalizar.Visible = false;
                btnRecusar.Visible = false;
                btnAceitar.Visible = false;
            }
            else if (order.status == "APPROVED")
            {
                pnlTop.BackColor = Color.FromArgb(255, 255, 130);

                lblStatus.Text = "Aprovado";
                btnFinalizar.Visible = false;
                //if (order.status_detail == null)
                //    btnAceitar.Enabled = false;

            }
            else if (order.status == "INVOICED")
            {
                pnlTop.BackColor = Color.FromArgb(100, 240, 150);

                lblStatus.Text = "Faturado";
                dgItens.ReadOnly = true;
                btnFinalizar.Visible = true;
                btnRecusar.Visible = false;
                btnAceitar.Visible = false;
            }
            else if (order.status == "SHIPPED")
            {
                pnlTop.BackColor = Color.FromArgb(100, 240, 150);

                lblStatus.Text = "Enviado";
                dgItens.ReadOnly = true;
                btnFinalizar.Visible = true;
                btnRecusar.Visible = false;
                btnAceitar.Visible = false;
            }
            else if (order.status == "COMPLETED")
            {
                pnlTop.BackColor = Color.FromArgb(100, 200, 255);

                lblStatus.Text = "Concluído";
                pnlRodape.Enabled = false;
                dgItens.ReadOnly = true;
                btnFinalizar.Visible = false;
                btnRecusar.Visible = false;
                btnAceitar.Visible = false;
            }
            else if (order.status == "CANCELED")
            {
                pnlTop.BackColor = Color.FromArgb(255, 100, 100);

                lblStatus.Text = "Cancelado";
                pnlRodape.Enabled = false;
                dgItens.ReadOnly = true;
                btnFinalizar.Visible = false;
                btnRecusar.Visible = false;
                btnAceitar.Visible = false;
            }

            lblPedido.Text = "Pedido #" + order.id;
            //CHAMAR A API DE SHIPING PASSANDO O ID PARA RECEBER ESSAS INFORMAÇOES
            lblNomeFat.Text = order.billing.name;
            lblEnderecoFat.Text = order.billing.street + ", " + order.billing.streetNumber;
            if (order.billing.streetComplement != null || order.billing.streetComplement != "")
                lblCompFat.Text = order.billing.streetComplement;
            lblBairroFat.Text = order.billing.district;
            lblCidadeFat.Text = order.billing.city + " - " + order.billing.state;
            lblCepFat.Text = order.billing.zipCode;

            lblNomeEnt.Text = order.shipping.recipientName;
            lblEnderecoEnt.Text = order.shipping.street + ", " + order.shipping.streetNumber;
            if (order.shipping.streetComplement != null || order.shipping.streetComplement != "")
                lblCompEnt.Text = order.shipping.streetComplement;
            lblBairroEnt.Text = order.shipping.district;
            lblCidadeEnt.Text = order.shipping.city + " - " + order.shipping.state;
            lblCepEnt.Text = order.shipping.zipCode;

            txtEmail.Text = order.billing.email;
            txtCelular.Text = order.billing.phone;
            txtCelular.Text = order.shipping.phone;

            //if (order.shipping_lines != null && order.shipping_lines.Count > 0)
                //lblMetodoEnt.Text = order.shipping_lines[0].method_title + " - R$ " + order.shipping_lines[0].total;


            lblMetodoPag.Text = order.paymentMethods[0].method + "\n" +
                ((order.status == "NEW" || order.status == "CREATED")
                    ? "Pagamento Pendente"
                    : "Pagamento Aprovado");

            if (order.status == "NEW" || order.status == "CREATED")
                pnlPagamento.BackColor = Color.FromArgb(255, 120, 120);
            else
                pnlPagamento.BackColor = Color.FromArgb(100, 240, 150);

            lblTotalPedido.Text = "TOTAL: R$ " + order.totalAmount;
            
           

            FillItens();
        }

        private void FillItens()
        {
            if (dgItens.Columns.Count == 0)
            {
                dgItens.AllowUserToResizeRows = false;
                dgItens.AllowUserToResizeColumns = false;

                dgItens.Columns.Add("id", "#");
                dgItens.Columns["id"].Width = 40;
                dgItens.Columns.Add("product_id", "Prod.");
                dgItens.Columns["product_id"].Width = 50;
                dgItens.Columns.Add("name", "Descrição");
                dgItens.Columns["name"].Width = 160;

                dgItens.Columns.Add("price", "Preço");
                dgItens.Columns["price"].Width = 60;
                dgItens.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgItens.Columns.Add("quantity", "Qtd.");
                dgItens.Columns["quantity"].Width = 60;
                dgItens.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgItens.Columns.Add("subtotal", "Sub.");
                dgItens.Columns["subtotal"].Width = 60;
                dgItens.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgItens.Columns.Add("total", "Total");
                dgItens.Columns["total"].Width = 60;
                dgItens.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgItens.Columns.Add("sku", "Barras");
                dgItens.Columns["sku"].Width = 150;
            }

            foreach (OrderItem item in order.orderItems)
            {
                dgItens.Rows.Add(item.productId, item.sku, item.name,
                    item.price, item.quantity, item.discount, item.total, item.originalPrice);
            }
            
            
            
        }

        private void linkAdminPedido_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (order.orderId > 0)
                System.Diagnostics.Process.Start(ConfigHub.URL_API + "" + order.orderId);
            
            
        }

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Dispose();
        }

        private void btnRecusar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Dispose();
        }        

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

       
    }
}
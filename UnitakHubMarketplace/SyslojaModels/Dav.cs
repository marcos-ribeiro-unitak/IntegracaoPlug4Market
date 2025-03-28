using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unitak.Uteis.Tipos;
using UnitakHubMarketplace.Models.MercadoLivre;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class Dav
    {
        public string ID_DAV { get; set; } = "";
        public string ID_Marketplace { get; set; } = "";
        public string ID_Empresa { get; set; } = "0";
        public string ID_PDV { get; set; } = "NULL";
        public string ID_Venda { get; set; } = "NULL";
        public string ID_Serie { get; set; } = "NULL";
        public string ID_Vendedor { get; set; } = "0";
        public string ID_Condicao { get; set; } = "0";
        public CondicaoPgto Condicao { get; set; }
        public Cliente Cliente { get; set; }
        public string Nome { get; set; } = "";
        public string Fone { get; set; } = "";
        public string CNPJ_CPF { get; set; } = "";
        public Endereco Endereco { get; set; }
        public string Forma_de_Entrega { get; set; } = "";
        public string Data_cx { get; set; } = "";
        public string Hora_cx { get; set; } = "";
        public string Descontos_Porcentagem { get; set; } = "0";
        public string Descontos_ID_Usuario { get; set; } = "0";
        public string Descontos_User_Name { get; set; } = "";
        public string Descontos_Nota { get; set; } = "";
        public string Tabela { get; set; } = "";
        public string Movimento { get; set; } = "";
        public string Tempo { get; set; } = "0";
        public string Status { get; set; } = "";
        public string Nota { get; set; } = "";
        public string Atualizacao { get; set; } = "";
        public string Hora { get; set; } = "";
        public string Exclusao { get; set; } = "";

        public string Valor_Itens_Tabela { get; set; } = "0";
        public string Descontos_Tabela { get; set; } = "0";
        public string Acrescimo_Tabela { get; set; } = "0";
        public string Valor_Itens { get; set; } = "0";

        public string Valor_Servicos_Tabela { get; set; } = "0";
        public string Descontos_Servicos_Tabela { get; set; } = "0";
        public string Acrescimo_Servicos_Tabela { get; set; } = "0";
        public string Valor_Servicos { get; set; } = "0";

        public string Descontos_nos_Itens { get; set; } = "0";
        public string Descontos_no_Total { get; set; } = "0";
        public string Valor_Liquido { get; set; } = "0";
        public string Valor_Frete { get; set; } = "0";

        public string Valor_Entrada { get; set; } = "0";
        public string Valor_Parcela_01 { get; set; } = "0";
        public string Valor_Demais_Parcelas { get; set; } = "0";

        public string ID_Usuario { get; set; } = "0";
        public string User_Name { get; set; } = "";

        public List<DavItem> lDavItem { get; set; }

        public Dav() { }

        public Dav(DataRow dr)
        {
            ID_DAV = dr["ID_DAV"].ToString();
            ID_Empresa = dr["ID_Empresa"].ToString();
            ID_PDV = dr["ID_PDV"].ToString();
            ID_Venda = dr["ID_Venda"].ToString();
            ID_Serie = dr["ID_Serie"].ToString();
            ID_Vendedor = dr["ID_Vendedor"].ToString();

            ID_Condicao = dr["ID_Condicao"].ToString();
            Condicao = new CondicaoPgto();
            Condicao.ID_Condicao = dr["ID_Condicao"].ToString();
            Condicao.Descricao = dr["Forma_PGTO"].ToString();
            Condicao.Parcelas = dr["QTD_Parcela"].ToString();

            Tabela = "A Vista";
            Movimento = "Dinheiro";
            int parc = 0;
            int.TryParse(Condicao.Parcelas, out parc);
            if (parc > 1 || (parc == 1 && Condicao.Entrada.Contains("Não")))
            {
                Tabela = "Crediário";
                Movimento = "Crediário";
            }

            Cliente = new Cliente(dr, false);
            Nome = dr["Nome"].ToString();
            Fone = dr["Fone"].ToString();
            CNPJ_CPF = dr["CNPJ_CPF"].ToString();

            Endereco = new Endereco(dr);
            Forma_de_Entrega = dr["Forma_de_Entrega"].ToString();

            Data_cx = dr["Data_cx"].ToString();
            Hora_cx = dr["Hora_cx"].ToString();
            Descontos_Porcentagem = dr["Descontos_Porcentagem"].ToString();
            Descontos_ID_Usuario = dr["Descontos_ID_Usuario"].ToString();
            Descontos_User_Name = dr["Descontos_User_Name"].ToString();
            Descontos_Nota = dr["Descontos_Nota"].ToString();
            Tabela = dr["Tabela"].ToString();
            Movimento = dr["Movimento"].ToString();
            Tempo = "0" + dr["Tempo"].ToString();
            Status = dr["Status"].ToString();
            Nota = dr["Nota"].ToString();
            Atualizacao = dr["Atualizacao"].ToString();
            Exclusao = dr["Exclusao"].ToString();
            Hora = dr["Hora"].ToString();

            Valor_Itens_Tabela = dr["Valor_Itens_Tabela"].ToString();
            Descontos_Tabela = dr["Descontos_Tabela"].ToString();
            Acrescimo_Tabela = dr["Acrescimo_Tabela"].ToString();
            Valor_Itens = dr["Valor_Itens"].ToString();
            Valor_Frete = dr["Valor_Frete"].ToString();

            Valor_Servicos_Tabela = dr["Valor_Servicos_Tabela"].ToString();
            Descontos_Servicos_Tabela = dr["Descontos_Servicos_Tabela"].ToString();
            Acrescimo_Servicos_Tabela = dr["Acrescimo_Servicos_Tabela"].ToString();
            Valor_Servicos = dr["Valor_Servicos"].ToString();

            Descontos_nos_Itens = dr["Descontos_nos_Itens"].ToString();
            Descontos_no_Total = dr["Descontos_no_Total"].ToString();
            Valor_Liquido = dr["Valor_Liquido"].ToString();

            Valor_Entrada = dr["Valor_Entrada"].ToString();
            Valor_Parcela_01 = dr["Valor_Parcela_01"].ToString();
            Valor_Demais_Parcelas = dr["Valor_Demais_Parcelas"].ToString();

            ID_Usuario = dr["ID_Usuario"].ToString();
            User_Name = dr["User_Name"].ToString();

            lDavItem = new List<DavItem>();
            //lDavServ = new List<DavServico>();
        }

        public string GetCampos()
        {
            Endereco.isDav = true;
            string campos = "ID_Marketplace, ID_DAV, ID_Empresa, ID_PDV, ID_Venda, ID_Serie, ID_Vendedor, ID_Condicao, " +
                "Forma_PGTO, ID_Cliente, Nome, Fone, CNPJ_CPF, " +
                Endereco.GetCampos() + ", Forma_de_Entrega, " +
                "Data_cx, Hora_cx, Valor_Itens_Liquido, " +
                "Descontos_Porcentagem, Descontos_ID_Usuario, Descontos_User_Name, " +
                "Descontos_Nota, Tabela, Movimento, Tempo, Status, Nota, ID_Usuario, User_Name, " +

                "Valor_Itens, Valor_Itens_Tabela, Descontos_Tabela, Acrescimo_Tabela, " +
                "Valor_Servicos, Valor_Servicos_Tabela, Descontos_Servicos_Tabela, Acrescimo_Servicos_Tabela, " +
                "Descontos_nos_Itens, Descontos_no_Total, Valor_Liquido, Valor_Frete," +
                "Devolucao, Subtotal, " +
                "Qtd_Parcela, Valor_Entrada, Valor_Parcela_01, Valor_Demais_Parcelas, Valor_Prazo, " +
                "Vendedor ";

            return campos;
        }

        public string GetValores()
        {
            Endereco.isDav = true;
            if (Condicao != null)
            {
                Tabela = "A Vista";
                Movimento = "Dinheiro";
                int parc = 0;
                int.TryParse(Condicao.Parcelas, out parc);
                if (parc > 1 || (parc == 1 && Condicao.Entrada.Contains("Não")))
                {
                    Tabela = "Crediário";
                    Movimento = "Crediário";
                }
            }

            string valores = ID_Marketplace + "," + ID_DAV + "," + ID_Empresa + "," + ID_PDV + "," + ID_Venda + "," + ID_Serie + "," + ID_Vendedor + "," + ID_Condicao + "," +
                "'" + Condicao.Descricao + "'," + Cliente.ID_Cliente + ",'" + Nome + "','" + Fone + "','" + CNPJ_CPF + "'," +
                Endereco.GetValores() + ",'" + Forma_de_Entrega + "'," +
                Data_cx + "," + Hora_cx + "," +
                Valor_Itens.Replace(",", ".") + "," +

                Descontos_Porcentagem.Replace(",", ".") + "," + Descontos_ID_Usuario + ",'" + Descontos_User_Name + "'," +
                "'" + Descontos_Nota + "','" + Tabela + "','" + Movimento + "', 0" + Tempo.Replace(",", ".") + ",'" + Status + "','" + Nota + "'," +
                ID_Usuario + ",'" + User_Name + "'," +

                Valor_Itens.Replace(",", ".") + "," + Valor_Itens.Replace(",", ".") + "," + Descontos_Tabela.Replace(",", ".") + ", " + Acrescimo_Tabela.Replace(",", ".") + ", " +
                Valor_Servicos.Replace(",", ".") + "," + Valor_Servicos.Replace(",", ".") + "," + Descontos_Servicos_Tabela.Replace(",", ".") + ", " + Acrescimo_Servicos_Tabela.Replace(",", ".") + ", " +
                Descontos_nos_Itens.Replace(",", ".") + "," + Descontos_no_Total.Replace(",", ".") + "," + Valor_Liquido.Replace(",", ".") + "," + Valor_Frete.Replace(",", ".") + "," +
                "0, " + Valor_Liquido.Replace(",", ".") + "," +
                Condicao.Parcelas + "," + Valor_Entrada.Replace(",", ".") + "," + Valor_Parcela_01.Replace(",", ".") + ", " + Valor_Demais_Parcelas.Replace(",", ".") + ", " + GetValorTotal().ToString().Replace(",", ".") + ", " +
                "''";

            return valores;
        }

        public decimal GetValorTotal()
        {
            decimal liquido = 0;
            decimal descIt = 0;
            decimal descTot = 0;
            decimal acres = 0;
            decimal frete = 0;

            decimal.TryParse(Valor_Liquido, out liquido);
            decimal.TryParse(Descontos_nos_Itens, out descIt);
            decimal.TryParse(Descontos_no_Total, out descTot);
            decimal.TryParse(Acrescimo_Tabela, out acres);
            decimal.TryParse(Valor_Frete, out frete);

            return liquido + frete + acres - descIt - descTot;
        }

        public decimal GetDescontos()
        {
            decimal descIt = 0;
            decimal descTot = 0;
            decimal acres = 0;

            decimal.TryParse(Descontos_nos_Itens, out descIt);
            decimal.TryParse(Descontos_no_Total, out descTot);
            decimal.TryParse(Acrescimo_Tabela, out acres);

            return acres - descIt - descTot;
        }

        public string GetCamposValores(bool id)
        {
            Endereco.isDav = true;
            StringBuilder sb = new StringBuilder();
            if (id)
                sb.Append("ID_DAV = " + ID_DAV + ",");

            if (!string.IsNullOrWhiteSpace(ID_Marketplace))
                sb.Append("ID_Marketplace = " + ID_Marketplace + ",");
            if (!string.IsNullOrWhiteSpace(ID_Empresa))
                sb.Append("ID_Empresa = " + ID_Empresa + ",");
            if (!string.IsNullOrWhiteSpace(ID_PDV))
                sb.Append("ID_PDV = " + ID_PDV + ",");
            if (!string.IsNullOrWhiteSpace(ID_Venda))
                sb.Append("ID_Venda = " + ID_Venda + ",");
            if (!string.IsNullOrWhiteSpace(ID_Serie))
                sb.Append("ID_Serie = " + ID_Serie + ",");
            if (!string.IsNullOrWhiteSpace(ID_Vendedor))
                sb.Append("ID_Vendedor = " + ID_Vendedor + ",");
            if (!string.IsNullOrWhiteSpace(ID_Condicao))
                sb.Append("ID_Condicao = " + ID_Condicao + ",");

            if (!string.IsNullOrWhiteSpace(Condicao.Descricao))
                sb.Append("Forma_PGTO = '" + Condicao.Descricao + "',");

            Tabela = "A Vista";
            Movimento = "Dinheiro";
            int parc = 0;
            int.TryParse(Condicao.Parcelas, out parc);
            if (parc > 1 || (parc == 1 && Condicao.Entrada.Contains("Não")))
            {
                Tabela = "Crediário";
                Movimento = "Crediário";
            }

            sb.Append("Movimento = '" + Movimento + "',");
            sb.Append("Tabela = '" + Tabela + "',");

            if (!string.IsNullOrWhiteSpace(Cliente.ID_Cliente))
                sb.Append("ID_Cliente = " + Cliente.ID_Cliente + ",");
            if (!string.IsNullOrWhiteSpace(Nome))
                sb.Append("Nome = '" + Nome + "',");
            if (!string.IsNullOrWhiteSpace(Fone))
                sb.Append("Fone = '" + Fone + "',");
            if (!string.IsNullOrWhiteSpace(CNPJ_CPF))
                sb.Append("CNPJ_CPF = '" + CNPJ_CPF + "',");

            sb.Append(Endereco.GetCamposValores(true) + ", ");
            sb.Append("Forma_de_Entrega = '" + Forma_de_Entrega + "',");

            if (!string.IsNullOrWhiteSpace(Data_cx))
                sb.Append("Data_cx = CONVERT(DATETIME, '" + Data_cx + "', 103),");
            if (!string.IsNullOrWhiteSpace(Hora_cx))
                sb.Append("Hora_cx = CONVERT(DATETIME, '" + Hora_cx + "', 103),");

            sb.Append("Descontos_Porcentagem = " + Descontos_Porcentagem.Replace(",", ".") + ",");
            sb.Append("Descontos_ID_Usuario = " + Descontos_ID_Usuario + ",");
            sb.Append("Descontos_User_Name = '" + Descontos_User_Name + "',");
            sb.Append("Descontos_Nota = '" + Descontos_Nota + "',");

            if (!string.IsNullOrWhiteSpace(Tempo))
                sb.Append("Tempo = " + Tempo.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Status))
                sb.Append("Status = '" + Status + "',");
            sb.Append("Nota = '" + Nota + "',");

            sb.Append("Valor_Itens = " + Valor_Itens.Replace(",", ".") + ",");
            sb.Append("Valor_Itens_Liquido = " + Valor_Itens.Replace(",", ".") + ",");
            sb.Append("Valor_Itens_Tabela = " + Valor_Itens_Tabela.Replace(",", ".") + ",");
            sb.Append("Descontos_Tabela = " + Descontos_Tabela.Replace(",", ".") + ",");
            sb.Append("Acrescimo_Tabela = " + Acrescimo_Tabela.Replace(",", ".") + ",");
            sb.Append("Valor_Servicos = " + Valor_Servicos.Replace(",", ".") + ",");
            sb.Append("Valor_Servicos_Tabela = " + Valor_Servicos_Tabela.Replace(",", ".") + ",");
            sb.Append("Descontos_Servicos_Tabela = " + Descontos_Servicos_Tabela.Replace(",", ".") + ",");
            sb.Append("Acrescimo_Servicos_Tabela = " + Acrescimo_Servicos_Tabela.Replace(",", ".") + ",");

            sb.Append("Descontos_nos_Itens = " + Descontos_nos_Itens.Replace(",", ".") + ",");
            sb.Append("Descontos_no_Total = " + Descontos_no_Total.Replace(",", ".") + ",");
            sb.Append("Valor_Liquido = " + Valor_Liquido.Replace(",", ".") + ",");
            sb.Append("Valor_Frete = " + Valor_Frete.Replace(",", ".") + ",");

            sb.Append("SubTotal = " + Valor_Liquido.Replace(",", ".") + ",");

            sb.Append("Valor_Entrada = " + Valor_Entrada.Replace(",", ".") + ",");
            sb.Append("Valor_Parcela_01 = " + Valor_Parcela_01.Replace(",", ".") + ",");
            sb.Append("Valor_Demais_Parcelas = " + Valor_Demais_Parcelas.Replace(",", ".") + ",");

            sb.Append("ID_Usuario = " + ID_Usuario + ",");
            sb.Append("User_Name = '" + User_Name + "',");

            string ret = sb.ToString().Substring(0, sb.ToString().Length - 1);

            return ret;
        }

        public Dav(Order pedido, Cliente cliente)
        {
            Fill(pedido, cliente);
        }

        public void Fill(Order pedido, Cliente cliente)
        {
            ID_Marketplace = pedido.orderId.ToString();
            ID_Empresa = Unitak.Config.VariaveisConn.Instance.ID_Empresa.ToString(); //database.variaveis.instance.Id_empresa.ToString();
            ID_PDV = "0";// database.variaveis.instance.ID_PDV.ToString();
            ID_Serie = Unitak.Config.VariaveisConn.Instance.ID_Serie.ToString();//database.variaveis.instance.ID_Serie.ToString();
            ID_Condicao = ConfigHub.ID_CONDICAO;
            Condicao = new CondicaoPgto();

            Cliente = cliente;
            Nome = cliente.Nome;
            Fone = cliente.Fone;
            CNPJ_CPF = cliente.CNPJ_CPF;
            Endereco = cliente.Endereco;

            Forma_de_Entrega = "2-Entregar";
            Descontos_Porcentagem = "0";
            Descontos_ID_Usuario = "0";
            Descontos_User_Name = "0";
            Descontos_Nota = "0";
            Tabela = "A Vista";
            Movimento = "DAV";
            Tempo = "0";
            Status = "Liberado";// pedido.status;
            //Nota = pedido.note;

            Descontos_Tabela = "0";
            Acrescimo_Tabela = "0";
            //Valor_Itens = pedido.products.Sum(item => ConfigHub.StringToDecimal(item.price)).ToString();
            Valor_Itens_Tabela = Valor_Itens;

            Descontos_nos_Itens = "0";
            //Descontos_no_Total = ConfigHub.StringToDecimal(pedido.discount).ToString();
            Valor_Liquido = ConfigHub.StringToDecimal(pedido.totalAmount.ToString()).ToString();
            Valor_Frete = ConfigHub.StringToDecimal(pedido.shipment.total.ToString()).ToString();

            //Valor_Entrada = pedido.total;
            Valor_Parcela_01 = "0";
            Valor_Demais_Parcelas = "0";

            ID_Vendedor = ConfigHub.ID_VENDEDOR;
            ID_Usuario = "0";
            User_Name = "Loja Virtual";

            lDavItem = new List<DavItem>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using UnitakHubMarketplace.Models.MercadoLivre;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class DavItem
    {
        public string ID_Marketplace { get; set; } = "";
        public string ID_DAV_Item { get; set; } = "";
        public string ID_Empresa { get; set; } = "0";
        public string ID_PDV { get; set; } = "0";
        public string ID_Venda { get; set; } = "0";
        public string ID_Serie { get; set; } = "0";
        public string ID_DAV { get; set; } = "";
        public string ID_Lista { get; set; } = "0";
        public string Index { get; set; } = "0";

        public Item Item { get; set; }
        public string Quantidade { get; set; } = "0";
        public string Codigo { get; set; } = "0";
        public string Unitario { get; set; } = "0";
        public string Valor { get; set; } = "0";

        public string Rateio_Descontos { get; set; } = "0";
        public string Descontos_Item { get; set; } = "0";
        public string Valor_Liquido { get; set; } = "0";

        public string Descontos_Porcentagem { get; set; } = "0";
        public string Descontos_ID_Usuario { get; set; } = "0";
        public string Descontos_User_Name { get; set; } = "";

        public string Tabela { get; set; } = "0";
        public string Movimento { get; set; } = "0";
        public string Status { get; set; } = "";

        public string Atualizacao { get; set; } = "";
        public string Hora { get; set; } = "";
        public string Exclusao { get; set; } = "";

        public string Unitario_Tabela { get; set; } = "0";
        public string Descontos_Tabela { get; set; } = "0";
        public string Acrescimo_Tabela { get; set; } = "0";
        public string Preco_Unitario { get; set; } = "0";

        public string ID_Vendedor { get; set; } = "0";
        public string ID_Usuario { get; set; } = "0";
        public string User_Name { get; set; } = "";
        public DavItem() { }
        public void Fill(OrderItem item, string idDav, int i)
        {
            ID_Marketplace = item.productId.ToString();
            ID_DAV = idDav;
            ID_Empresa = Unitak.Config.VariaveisConn.Instance.ID_Empresa.ToString();//database.variaveis.instance.Id_empresa.ToString();
            ID_PDV = "0";// database.variaveis.instance.ID_PDV.ToString();
            ID_Serie = Unitak.Config.VariaveisConn.Instance.ID_Serie.ToString();//database.variaveis.instance.ID_Serie.ToString();
            Index = (i + 1).ToString();

            Item = new Item(int.Parse(item.productId));
            Item.isDavIt = true;

            Item.Descricao = item.name.ToUpper();
            Quantidade = item.quantity.ToString();
            Codigo = item.sku;

            Unitario = item.originalPrice.ToString(); // int.Parse(item.q)).ToString();
            Valor = item.price.ToString();

            Rateio_Descontos = "0";
            Descontos_Item = "0";
            //Valor_Liquido = item.price;

            Descontos_Porcentagem = "0";
            Descontos_ID_Usuario = "0";
            Descontos_User_Name = "";

            //ID_Lista = "11";
            Tabela = "";
            Movimento = "";
            Status = "Liberado";

            Unitario_Tabela = Unitario;
            Descontos_Tabela = "0";
            Acrescimo_Tabela = "0";
            Preco_Unitario = Unitario;

            ID_Vendedor = ConfigHub.ID_VENDEDOR;
            ID_Usuario = "0";
            User_Name = "Loja Virtual";
           
        }
        public DavItem(DataRow dr)
        {
            ID_DAV_Item = dr["ID_DAV_Item"].ToString();
            ID_Empresa = dr["ID_Empresa"].ToString();
            ID_PDV = dr["ID_PDV"].ToString();
            ID_Venda = dr["ID_Venda"].ToString();
            ID_Serie = dr["ID_Serie"].ToString();
            ID_DAV = dr["ID_DAV"].ToString();
            Index = dr["Item"].ToString();
            ID_Lista = dr["ID_Lista"].ToString();

            Item = new Item(dr, null, true);
            Codigo = dr["Codigo"].ToString();
            Quantidade = dr["Quantidade"].ToString();
            Unitario = dr["Unitario"].ToString();

            Valor = dr["Valor"].ToString();
            Rateio_Descontos = dr["Rateio_Descontos"].ToString();
            Descontos_Item = dr["Descontos_Item"].ToString();
            Valor_Liquido = dr["Valor_Liquido"].ToString();
            Descontos_Porcentagem = dr["Descontos_Porcentagem"].ToString();
            Descontos_ID_Usuario = dr["Descontos_ID_Usuario"].ToString();
            Descontos_User_Name = dr["Descontos_User_Name"].ToString();
            Tabela = dr["Tabela"].ToString();
            Movimento = dr["Movimento"].ToString();
            Status = dr["Status"].ToString();
            Atualizacao = dr["Atualizacao"].ToString();
            Hora = dr["Hora"].ToString();
            Exclusao = dr["Exclusao"].ToString();

            Unitario_Tabela = dr["Unitario_Tabela"].ToString();
            Descontos_Tabela = dr["Descontos_Tabela"].ToString();
            Acrescimo_Tabela = dr["Acrescimo_Tabela"].ToString();
            Preco_Unitario = dr["Unitario"].ToString();

            ID_Vendedor = dr["ID_Vendedor"].ToString();
            ID_Usuario = dr["ID_Usuario"].ToString();
            User_Name = dr["User_Name"].ToString();
        }

        public void FillRow(DataRow dr, int idDav)
        {
            dr["ID_DAV"] = idDav;
            dr["ID_DAV_Item"] = (ID_DAV_Item != string.Empty) ? ID_DAV_Item : "";
            dr["ID_Empresa"] = (ID_Empresa != string.Empty) ? ID_Empresa : "0";
            dr["ID_PDV"] = (ID_PDV != string.Empty) ? ID_PDV : "0";
            dr["ID_Venda"] = (ID_Venda != string.Empty) ? ID_Venda : "0";
            dr["ID_Serie"] = (ID_Serie != string.Empty) ? ID_Serie : "0";
            dr["ID_Lista"] = (ID_Lista != string.Empty) ? ID_Lista : "0";
            dr["Item"] = (Index != string.Empty) ? Index : "0";
            if (Item != null)
            {
                dr["ID_Grupo"] = (Item.ID_Grupo != string.Empty) ? Item.ID_Grupo : "0";
                dr["ID_Marca"] = (Item.ID_Marca != string.Empty) ? Item.ID_Marca : "0";
                dr["ID_Item"] = (Item.ID_Item != string.Empty) ? Item.ID_Item : "0";
                dr["Descricao"] = (Item.Descricao != null) ? Item.Descricao : "";
                dr["Preco_Custo"] = (Item.Preco_Custo != string.Empty) ? Item.Preco_Custo : "0";
                dr["Preco_Unitario"] = (Item.Preco_Unitario != string.Empty) ? Item.Preco_Unitario : "0";
                dr["ID_ICMS"] = (Item.ID_ICMS != string.Empty) ? Item.ID_ICMS : "0";
                dr["Barras_Gerada"] = (Item.X_Grade != null && Item.X_Grade.Count > 0) ? Item.X_Grade[0].Barras_Gerada : "";
            }

            dr["Codigo"] = (Codigo != null) ? Codigo : "";
            dr["Quantidade"] = (Quantidade != string.Empty) ? Quantidade : "0";
            dr["Unitario"] = (Unitario != string.Empty) ? Unitario : "0";
            dr["Valor"] = (Valor != string.Empty) ? Valor : "0";
            dr["Rateio_Descontos"] = (Rateio_Descontos != string.Empty) ? Rateio_Descontos : "0";
            dr["Descontos_Item"] = (Descontos_Item != string.Empty) ? Descontos_Item : "0";
            dr["Valor_Liquido"] = (Valor_Liquido != string.Empty) ? Valor_Liquido : "0";
            dr["Descontos_Porcentagem"] = (Descontos_Porcentagem != string.Empty) ? Descontos_Porcentagem : "0";
            dr["Descontos_ID_Usuario"] = (Descontos_ID_Usuario != string.Empty) ? Descontos_ID_Usuario : "0";
            dr["Descontos_User_Name"] = (Descontos_User_Name != string.Empty) ? Descontos_User_Name : "0";
            dr["Tabela"] = (Tabela != null) ? Tabela : "";
            dr["Valor_Liquido"] = (Valor_Liquido != string.Empty) ? Valor_Liquido : "0";

            dr["ID_Vendedor"] = (ID_Vendedor != string.Empty) ? ID_Vendedor : "0";
            dr["ID_Usuario"] = (ID_Usuario != string.Empty) ? ID_Usuario : "0";
            dr["User_Name"] = (User_Name != null) ? User_Name : "";

            dr["Unitario_Tabela"] = (Unitario_Tabela != string.Empty) ? Unitario_Tabela : "0";
            dr["Descontos_Tabela"] = (Descontos_Tabela != string.Empty) ? Descontos_Tabela : "0";
            dr["Acrescimo_Tabela"] = (Acrescimo_Tabela != string.Empty) ? Acrescimo_Tabela : "0";
            //dr["Preco_Unitario"] = (Preco_Unitario != string.Empty) ? Preco_Unitario : "0";

            dr["Movimento"] = "DAV";
            dr["Status"] = (Status != null) ? Status : "Pendente";
        }
        public string GetCampos()
        {
            string campos = "ID_Marketplace, ID_DAV_Item, ID_Empresa, ID_PDV, ID_Venda, ID_Serie, ID_DAV, ID_Lista, " +
                    "Item, " +
                    Item.GetCampos() + ", Unidade, Quantidade, Codigo, Unitario, Valor, " +
                    "Rateio_Descontos, Descontos_Item, " +
                    "Valor_Liquido, Descontos_Porcentagem, Descontos_ID_Usuario, " +
                    "Descontos_User_Name, Tabela, Movimento, Status, " +
                    "ID_Vendedor, ID_Usuario, User_Name, " +

                    "Barras_Gerada, " +
                    //"Referencia, " +
                    "Acrescimo_Tabela, Unitario_Tabela, " +
                    "Descontos_Tabela, Valor_Tabela ";

            return campos;
        }

        public string GetValores()
        {
            string valores = ID_Marketplace + ", " + ID_DAV_Item + ", " + ID_Empresa + ", " + ID_PDV + ", " + ID_Venda + ", " + ID_Serie + ", " + ID_DAV + ", " + ID_Lista + ", " +
                    Index + ", " +
                    Item.GetValores() + ", '" + Item.UN + "', " + Quantidade.Replace(",", ".") + ", '" + Codigo + "', " + Unitario.Replace(",", ".") + ", " + Valor.Replace(",", ".") + ", " +
                    Rateio_Descontos.Replace(",", ".") + ", " + Descontos_Item.Replace(",", ".") + ", " +
                    Valor_Liquido.Replace(",", ".") + ", " + Descontos_Porcentagem.Replace(",", ".") + ", " + Descontos_ID_Usuario + ", '" +
                    Descontos_User_Name + "', '" + Tabela + "', '" + Movimento + "', '" + Status + "', " +
                    ID_Vendedor + ", " + ID_Usuario + ", '" + User_Name + "',";

            if (Item.X_Grade.Count > 1)
                valores = valores + "'" + Item.X_Grade.Where(s =>
                    Codigo == s.Barras_Gerada || Codigo == s.Barras || Codigo == s.ID_Item
                ).ToArray()[0].Barras_Gerada + "', ";
            else
                valores = valores + "'" + Item.X_Grade[0].Barras_Gerada + "', ";

            //valores = valores + "'11111111111', ";//WTF????
            valores = valores + Acrescimo_Tabela.Replace(",", ".") + ", " + Unitario_Tabela.Replace(",", ".") + ", " +
                    Descontos_Tabela.Replace(",", ".") + ", " + Valor.Replace(",", ".");



            return valores;
        }
        public string GetCamposValores(bool id)
        {
            StringBuilder sb = new StringBuilder();
            if (id)
                sb.Append("ID_DAV_Item = " + ID_DAV_Item + ",");
            if (id)
                sb.Append("ID_Marketplace = " + ID_Marketplace + ",");
            if (!string.IsNullOrWhiteSpace(ID_Empresa))
                sb.Append("ID_Empresa = " + ID_Empresa + ",");
            if (!string.IsNullOrWhiteSpace(ID_PDV))
                sb.Append("ID_PDV = " + ID_PDV + ",");
            if (!string.IsNullOrWhiteSpace(ID_Venda))
                sb.Append("ID_Venda = " + ID_Venda + ",");
            if (!string.IsNullOrWhiteSpace(ID_Serie))
                sb.Append("ID_Serie = " + ID_Serie + ",");
            if (!string.IsNullOrWhiteSpace(ID_DAV))
                sb.Append("ID_DAV = " + ID_DAV + ",");
            if (!string.IsNullOrWhiteSpace(ID_Lista))
                sb.Append("ID_Lista = " + ID_Lista + ",");
            if (!string.IsNullOrWhiteSpace(Index))
                sb.Append("Item = " + Index + ",");
            sb.Append(Item.GetCamposValores(true) + ",");
            if (!string.IsNullOrWhiteSpace(Quantidade))
                sb.Append("Quantidade = " + Quantidade.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Codigo))
                sb.Append("Codigo = '" + Codigo + "',");
            if (!string.IsNullOrWhiteSpace(Unitario))
                sb.Append("Unitario = " + Unitario.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Valor))
                sb.Append("Valor = " + Valor.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Rateio_Descontos))
                sb.Append("Rateio_Descontos = " + Rateio_Descontos.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Descontos_Item))
                sb.Append("Descontos_Item = " + Descontos_Item.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Valor_Liquido))
                sb.Append("Valor_Liquido = " + Valor_Liquido.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Descontos_Porcentagem))
                sb.Append("Descontos_Porcentagem = " + Descontos_Porcentagem.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Descontos_ID_Usuario))
                sb.Append("Descontos_ID_Usuario = " + Descontos_ID_Usuario + ",");
            if (!string.IsNullOrWhiteSpace(Descontos_User_Name))
                sb.Append("Descontos_User_Name = '" + Descontos_User_Name + "',");
            if (!string.IsNullOrWhiteSpace(Tabela))
                sb.Append("Tabela = '" + Tabela + "',");
            if (!string.IsNullOrWhiteSpace(Movimento))
                sb.Append("Movimento = '" + Movimento + "',");
            if (!string.IsNullOrWhiteSpace(Status))
                sb.Append("Status = '" + Status + "',");
            //if (!string.IsNullOrWhiteSpace(Atualizacao))
            //    sb.Append("Atualizacao = '" + Atualizacao + "',");
            //if (!string.IsNullOrWhiteSpace(Hora))
            //    sb.Append("Hora = '" + Hora + "',");
            if (!string.IsNullOrWhiteSpace(Exclusao))
                sb.Append("Exclusao = " + Exclusao + ",");
            if (!string.IsNullOrWhiteSpace(ID_Vendedor))
                sb.Append("ID_Vendedor = " + ID_Vendedor + ",");
            if (!string.IsNullOrWhiteSpace(ID_Usuario))
                sb.Append("ID_Usuario = " + ID_Usuario + ",");
            if (!string.IsNullOrWhiteSpace(User_Name))
                sb.Append("User_Name = '" + User_Name + "',");


            if (!string.IsNullOrWhiteSpace(Unitario_Tabela))
                sb.Append("Unitario_Tabela = " + Unitario_Tabela.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Descontos_Tabela))
                sb.Append("Descontos_Tabela = " + Descontos_Tabela.Replace(",", ".") + ",");
            if (!string.IsNullOrWhiteSpace(Acrescimo_Tabela))
                sb.Append("Acrescimo_Tabela = " + Acrescimo_Tabela.Replace(",", ".") + ",");
            //if (!string.IsNullOrWhiteSpace(Item.Preco_Unitario))
            //    sb.Append("Preco_Unitario = " + Item.Preco_Unitario.Replace(",", ".") + ",");

            //sb.Append("Descontos_Tabela = 0,");
            if (!string.IsNullOrWhiteSpace(Valor_Liquido))
                sb.Append("Valor_Tabela = " + Valor_Liquido.Replace(",", ".") + ",");


            string ret = sb.ToString().Substring(0, sb.ToString().Length - 1);

            return ret;
        }
    }
}

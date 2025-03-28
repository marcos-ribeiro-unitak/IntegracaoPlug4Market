using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitakHubMarketplace.Db;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class Item
    {
        public string _Controle { get; set; } = "";
        public string ID_Item { get; set; } = "0";
        public string ID_Empresa { get; set; } = "0";
        public string ID_Grupo { get; set; } = "0";
        public string ID_Marca { get; set; } = "0";
        public string ID_SubGrupo { get; set; } = "0";
        public string ID_Fornecedor { get; set; } = "0";
        public string ID_ICMS { get; set; } = "0";
        public string NCM { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Descricao_Reduzida { get; set; } = "";
        public string UN { get; set; } = "";
        public string Preco_Custo { get; set; } = "0";
        public string Preco_Unitario { get; set; } = "0";
        public string Preco_Atacado { get; set; } = "0";
        public string QTD_Atacado { get; set; } = "0";
        public string Comissao { get; set; } = "0";
        public string Situacao { get; set; } = "";
        public string Controla_Estoque { get; set; } = "";
        public string Permite_Estoque_Negativo { get; set; } = "";
        public string Vende_Fracionado { get; set; } = "";
        public string Fotografia { get; set; } = "";
        public string Atualizacao { get; set; } = "";
        public string Hora { get; set; } = "";
        public string Exclusao { get; set; } = "";

        public List<Grade> X_Grade { get; set; }
        public List<Kit> Lista_KIT { get; set; }
        public string Tipo { get; set; } = "";

        public bool isDavIt = false;

        public Item(bool isDavIt)
        {
            this.isDavIt = isDavIt;
        }

        public Item()
        {

        }

        public Item(int idMarket)
        {
            DbProdutos db = new DbProdutos();
            DataTable dtIt = db.SelectItem(idMarket);
            if (dtIt.Rows.Count == 0)
                dtIt = db.SelectItemPadrao();

            X_Grade = new List<Grade>();
            foreach (DataRow dr in dtIt.Rows)
                X_Grade.Add(new Grade(dr));

            if (dtIt.Rows.Count > 0)
                Fill(dtIt.Rows[0], X_Grade, true);
        }

        public Item(DataRow dr, List<Grade> listaGrade, bool isDavIt)
        {
            Fill(dr, listaGrade, isDavIt);
        }

        private void Fill(DataRow dr, List<Grade> listaGrade, bool isDavIt)
        {
            this.isDavIt = isDavIt;
            _Controle = "Itens";
            ID_Item = dr["ID_Item"].ToString();
            ID_Empresa = dr["ID_Empresa"].ToString();
            ID_Grupo = dr["ID_Grupo"].ToString();
            ID_Marca = dr["ID_Marca"].ToString();
            if (dr.Table.Columns.Contains("ID_SubGrupo"))
                ID_SubGrupo = dr["ID_SubGrupo"].ToString();
            if (dr.Table.Columns.Contains("ID_Fornecedor"))
                ID_Fornecedor = (!string.IsNullOrWhiteSpace(dr["ID_Fornecedor"].ToString()))
                    ? dr["ID_Fornecedor"].ToString()
                    : "0";
            if (dr.Table.Columns.Contains("ID_ICMS"))
                ID_ICMS = dr["ID_ICMS"].ToString();

            if (listaGrade != null)
                X_Grade = listaGrade;

            if (dr.Table.Columns.Contains("NCM"))
                NCM = dr["NCM"].ToString();
            Descricao = dr["Descricao"].ToString();
            if (dr.Table.Columns.Contains("Descricao_Reduzida"))
                Descricao_Reduzida = dr["Descricao_Reduzida"].ToString();
            if (dr.Table.Columns.Contains("UNIDADE"))
                UN = dr["UNIDADE"].ToString();
            if (dr.Table.Columns.Contains("Preco_Custo"))
                Preco_Custo = dr["Preco_Custo"].ToString();
            if (dr.Table.Columns.Contains("Preco_Unitario"))
                Preco_Unitario = dr["Preco_Unitario"].ToString();
            if (dr.Table.Columns.Contains("Preco_Atacado"))
                Preco_Atacado = dr["Preco_Atacado"].ToString();
            if (dr.Table.Columns.Contains("QTD_Atacado"))
                QTD_Atacado = dr["QTD_Atacado"].ToString();
            //if (dr.Table.Columns.Contains("Unitario"))
            //    Preco_Unitario = dr["Unitario"].ToString();
            if (dr.Table.Columns.Contains("Comissao"))
                Comissao = (!string.IsNullOrWhiteSpace(dr["Comissao"].ToString()))
                    ? dr["Comissao"].ToString()
                    : "0,00";
            if (dr.Table.Columns.Contains("Situacao"))
                Situacao = dr["Situacao"].ToString();
            if (dr.Table.Columns.Contains("Controla_Estoque"))
                Controla_Estoque = dr["Controla_Estoque"].ToString();
            if (dr.Table.Columns.Contains("Permite_Estoque_Negativo"))
                Permite_Estoque_Negativo = dr["Permite_Estoque_Negativo"].ToString();
            if (dr.Table.Columns.Contains("Vende_Fracionado"))
                Vende_Fracionado = dr["Vende_Fracionado"].ToString();

            if (dr.Table.Columns.Contains("Atualizacao"))
                Atualizacao = dr["Atualizacao"].ToString();
            if (dr.Table.Columns.Contains("Hora"))
                Hora = dr["Hora"].ToString();
            if (dr.Table.Columns.Contains("Exclusao"))
                Exclusao = dr["Exclusao"].ToString();

            if (dr.Table.Columns.Contains("Fotografia"))
                Fotografia = dr["Fotografia"].ToString();

            if (dr.Table.Columns.Contains("Tipo"))
                Tipo = dr["Tipo"].ToString();
        }

        public string GetCampos()
        {
            string campos = "ID_Item, ID_Grupo, ID_Marca, " +
                "ID_ICMS, Descricao, Preco_Custo";

            if (!isDavIt)
                campos = campos + ", ID_Empresa, ID_SubGrupo, ID_Fornecedor, " +
                    "Comissao, Preco_Unitario, " +
                    "NCM, Descricao_Reduzida, UN, Situacao, " +
                    "Controla_Estoque, " +
                    "Permite_Estoque_Negativo, Vende_Fracionado, Tipo";

            return campos;
        }

        public string GetValores()
        {
            string valores = ID_Item + ", " + ID_Grupo + ", " + ID_Marca + ", " +
                ID_ICMS + ", '" + Descricao + "', " + Preco_Custo.Replace(",", ".") + "";

            if (!isDavIt)
                valores = valores + ", " + ID_Empresa + ", " + ID_SubGrupo + ", " + ID_Fornecedor + ", " +
                        Comissao.Replace(",", ".") + ", " + Preco_Unitario.Replace(",", ".") + ", '" +
                        NCM + "', '" + Descricao_Reduzida + "', '" + UN + "', '" + Situacao + "', '" +
                        Controla_Estoque + "', '" +
                        Permite_Estoque_Negativo + "', '" + Vende_Fracionado + "', '" + Tipo + "'";

            return valores;
        }

        public string GetCamposValores(bool id)
        {
            StringBuilder sb = new StringBuilder();
            if (id)
                sb.Append("ID_Item = " + ID_Item + ",");
            if (!string.IsNullOrWhiteSpace(ID_Grupo))
                sb.Append("ID_Grupo = " + ID_Grupo + ",");
            if (!string.IsNullOrWhiteSpace(ID_Marca))
                sb.Append("ID_Marca = " + ID_Marca + ",");
            if (!isDavIt)
            {
                sb.Append("ID_Empresa = " + ID_Empresa + ",");
                sb.Append("ID_SubGrupo = " + ID_SubGrupo + ",");
                sb.Append("ID_Fornecedor = " + ID_Fornecedor + ",");
                sb.Append("Preco_Unitario = " + Preco_Unitario.Replace(",", ".") + ",");
                sb.Append("Comissao = " + Comissao.Replace(",", ".") + ",");
                if (!string.IsNullOrWhiteSpace(Vende_Fracionado))
                    sb.Append("Vende_Fracionado = '" + Vende_Fracionado + "',");
                if (!string.IsNullOrWhiteSpace(UN))
                    sb.Append("UN = '" + UN + "',");

                if (!string.IsNullOrWhiteSpace(NCM))
                    sb.Append("NCM = '" + NCM + "',");
                if (!string.IsNullOrWhiteSpace(Descricao_Reduzida))
                    sb.Append("Descricao_Reduzida = '" + Descricao_Reduzida + "',");
                if (!string.IsNullOrWhiteSpace(Situacao))
                    sb.Append("Situacao = '" + Situacao + "',");
                if (!string.IsNullOrWhiteSpace(Controla_Estoque))
                    sb.Append("Controla_Estoque = '" + Controla_Estoque + "',");
                if (!string.IsNullOrWhiteSpace(Permite_Estoque_Negativo))
                    sb.Append("Permite_Estoque_Negativo = '" + Permite_Estoque_Negativo + "',");
                if (!string.IsNullOrWhiteSpace(Tipo))
                    sb.Append("Tipo = '" + Tipo + "',");
            }
            if (!string.IsNullOrWhiteSpace(ID_ICMS))
                sb.Append("ID_ICMS = " + ID_ICMS + ",");
            if (!string.IsNullOrWhiteSpace(Descricao))
                sb.Append("Descricao = '" + Descricao + "',");
            if (!string.IsNullOrWhiteSpace(Preco_Custo))
                sb.Append("Preco_Custo = " + Preco_Custo.Replace(",", ".") + ",");

            string ret = sb.ToString().Substring(0, sb.ToString().Length - 1);

            return ret;
        }

        public void RecalcularPrecoKit()
        {
            decimal total = 0;

            foreach (Kit kit in Lista_KIT)
            {
                if (string.IsNullOrEmpty(kit.item.Exclusao))
                {
                    decimal unitario = decimal.Parse(kit.item.Preco_Unitario);
                    decimal quantidade = decimal.Parse(kit.KIT_Quantidade);

                    total = total + (unitario * quantidade);
                }
            }

            Preco_Unitario = total.ToString();
        }
    }
}

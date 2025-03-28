using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.MercadoLivre;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class Endereco
    {
        public string ID_Cliente_End { get; set; } = "0";
        public string Descricao { get; set; } = "PADRÃO";
        public string Rua { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string CEP { get; set; } = "";
        public string ID_Cidade { get; set; } = "0";
        public string Cidade { get; set; } = "";
        public string ID_UF { get; set; } = "0";
        public string UF { get; set; } = "";
        public string Complemento { get; set; } = "";

        public bool isDav = false;

        public Endereco() { }

        
        public Endereco(Billing billing)
        {
            Rua = billing.street.ToUpper();
            Complemento = (billing.streetComplement == null || billing.streetComplement == "") ? "" : billing.streetComplement.ToUpper();
            Numero = (billing.streetNumber == null) ? "" : billing.streetNumber.ToUpper();
            Bairro = (billing.district == null) ? "" : billing.district.ToUpper();
            Cidade = billing.city.ToUpper();
            string uf = new DbClientes().GetUF(billing.state);
            UF = (billing.state == null || billing.state == "") ? "" : uf.ToUpper();
            CEP = (billing.zipCode == null || billing.zipCode == "") ? "" : billing.zipCode.ToUpper();
        }

        public Endereco(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ID_Cliente_End"))
                ID_Cliente_End = dr["ID_Cliente_End"].ToString();
            if (dr.Table.Columns.Contains("Descricao"))
                Descricao = dr["Descricao"].ToString();
            if (dr.Table.Columns.Contains("Desc_Endereco"))
                Descricao = dr["Desc_Endereco"].ToString();

            if (dr.Table.Columns.Contains("Endereco"))
                Rua = dr["Endereco"].ToString();
            if (dr.Table.Columns.Contains("Numero"))
                Numero = dr["Numero"].ToString();
            if (dr.Table.Columns.Contains("Bairro"))
                Bairro = dr["Bairro"].ToString();
            if (dr.Table.Columns.Contains("CEP"))
                CEP = dr["CEP"].ToString();

            if (dr.Table.Columns.Contains("ID_Cidade"))
                ID_Cidade = dr["ID_Cidade"].ToString();
            if (dr.Table.Columns.Contains("Cidade"))
                Cidade = dr["Cidade"].ToString();
            if (dr.Table.Columns.Contains("ID_UF"))
                ID_UF = dr["ID_UF"].ToString();
            if (dr.Table.Columns.Contains("UF"))
                UF = dr["UF"].ToString();

            if (dr.Table.Columns.Contains("Complemento"))
                Complemento = dr["Complemento"].ToString();
        }

        public void FillRow(DataRow dr)
        {
            dr["ID_Cliente_End"] = (ID_Cliente_End != null) ? ID_Cliente_End : "0";
            dr["Descricao"] = (Descricao != null) ? Descricao : ".";
            dr["Endereco"] = (Rua != null) ? Rua : ".";
            dr["Numero"] = (Numero != null) ? Numero : ".";
            dr["Bairro"] = (Bairro != null) ? Bairro : ".";
            dr["CEP"] = (CEP != null) ? CEP : "";
            dr["ID_Cidade"] = (ID_Cidade != null) ? ID_Cidade : "0";
            dr["Cidade"] = (Cidade != null) ? Cidade : "";
            dr["ID_UF"] = (ID_UF != null) ? ID_UF : "0";
            dr["UF"] = (UF != null) ? UF : "SP";
            dr["Complemento"] = (Complemento != null) ? Complemento : "";
        }

        public string GetCampos()
        {
            string campos = "";
            if (!string.IsNullOrWhiteSpace(ID_Cliente_End) && ID_Cliente_End != "0")
            {
                campos = "ID_Cliente_End, ";
                if (!isDav)
                    campos = campos + " Descricao, ";
            }

            campos = campos + "Endereco, Numero, Bairro," +
                "CEP, ID_Cidade, Cidade, ID_UF, UF";

            if (!isDav)
                campos = campos + ", Complemento";

            return campos;
        }

        public string GetValores()
        {
            setIdCidadeEstado();
            string valores = "";
            if (!string.IsNullOrWhiteSpace(ID_Cliente_End) && ID_Cliente_End != "0")
            {
                valores = ID_Cliente_End + ", ";
                if (!isDav)
                    valores = valores + "'" + Descricao + "', ";
            }

            valores = valores + "'" + Rua + "', '" + Numero + "', '" + Bairro + "', '" + CEP + "', " +
                ID_Cidade + ", '" + Cidade + "', " + ID_UF + ", '" + UF + "'";

            if (!isDav)
                valores = valores + ",'" + Complemento + "'";

            return valores;
        }

        public string GetCamposValores(bool id)
        {
            setIdCidadeEstado();
            StringBuilder sb = new StringBuilder();
            if (id)
                sb.Append("ID_Cliente_End = " + ID_Cliente_End + ",");
            if (!string.IsNullOrWhiteSpace(Descricao) && Descricao != "PADRÃO" && !isDav)
                sb.Append("Descricao = '" + Descricao + "',");
            if (!string.IsNullOrWhiteSpace(Rua))
                sb.Append("Endereco = '" + Rua + "',");
            if (!string.IsNullOrWhiteSpace(Numero))
                sb.Append("Numero = '" + Numero + "',");
            if (!string.IsNullOrWhiteSpace(Bairro))
                sb.Append("Bairro = '" + Bairro + "',");
            if (!string.IsNullOrWhiteSpace(CEP))
                sb.Append("CEP = '" + CEP + "',");
            if (!string.IsNullOrWhiteSpace(ID_Cidade))
                sb.Append("ID_Cidade = " + ID_Cidade + ",");
            if (!string.IsNullOrWhiteSpace(Cidade))
                sb.Append("Cidade = '" + Cidade + "',");
            if (!string.IsNullOrWhiteSpace(ID_UF))
                sb.Append("ID_UF = " + ID_UF + ",");
            if (!string.IsNullOrWhiteSpace(UF))
                sb.Append("UF = '" + UF + "',");
            if (!isDav)
                sb.Append("Complemento = '" + Complemento + "',");

            string ret = sb.ToString().Substring(0, sb.ToString().Length - 1);
            return ret;
        }

        private void setIdCidadeEstado()
        {
            if ((ID_Cidade == "" || ID_Cidade == "0") && Cidade != "" && !isDav)
                ID_Cidade = "(SELECT ISNULL((SELECT TOP(1) ID_Cidade FROM Cidade " +
                                        "WHERE Cidade like '" + Cidade.Trim() + "%'), 0))";

            if ((ID_UF == "" || ID_UF == "0") && UF != "" && !isDav)
                ID_UF = "(SELECT ISNULL((SELECT TOP(1) ID_UF FROM Estado " +
                                        "WHERE UF like '" + UF.Trim() + "'), 0))";
        }
    }
}

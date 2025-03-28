using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitakHubMarketplace.Models.MercadoLivre;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class Cliente
    {
        public string ID_Cliente { get; set; } = "0";
        public string ID_Empresa { get; set; } = "0";
        public string Nome { get; set; } = "";
        public string Tratamento { get; set; } = "";
        public string CNPJ_CPF { get; set; } = "";
        public string Inscricao_RG { get; set; } = "";
        public string Fone { get; set; } = "";
        public string Celular { get; set; } = "";
        public string Email { get; set; } = "";
        public string Atualizacao { get; set; } = "";
        public string Exclusao { get; set; } = "";
        public Endereco Endereco { get; set; }
        public List<Endereco> ListaEndereco { get; set; } = new List<Endereco>();

        public Cliente() { }

        public void Fill(Billing cobranca)
        {
            Nome = (cobranca.name).ToUpper();
            Tratamento = cobranca.name.ToUpper();
            CNPJ_CPF = (cobranca.documentId == null || cobranca.documentId == "") ? "" : (cobranca.documentId).ToUpper();
            Inscricao_RG = ""; //(cobranca.rg + cobranca.ie).ToUpper();

            Fone = (cobranca.phone == null) ? "" : cobranca.phone.ToUpper();
            Celular = Fone;
            Email = cobranca.email.ToUpper();

            Endereco = new Endereco(cobranca);
            Endereco.isDav = true;
        }
        public Cliente(DataRow dr, bool carregaEndereco)
        {
            ID_Cliente = dr["ID_Cliente"].ToString();
            ID_Empresa = dr["ID_Empresa"].ToString();
            Nome = dr["Nome"].ToString();
            if (dr.Table.Columns.Contains("Tratamento"))
                Tratamento = dr["Tratamento"].ToString();
            if (dr.Table.Columns.Contains("CNPJ_CPF"))
                CNPJ_CPF = dr["CNPJ_CPF"].ToString();
            if (dr.Table.Columns.Contains("Inscricao_RG"))
                Inscricao_RG = dr["Inscricao_RG"].ToString();
            if (dr.Table.Columns.Contains("Fone"))
                Fone = dr["Fone"].ToString();
            if (dr.Table.Columns.Contains("Celular"))
                Celular = dr["Celular"].ToString();
            if (dr.Table.Columns.Contains("Email"))
                Email = dr["Email"].ToString();

            if (dr.Table.Columns.Contains("Hora"))
                Atualizacao = dr["Hora"].ToString();
            if (dr.Table.Columns.Contains("Exclusao"))
                Exclusao = dr["Exclusao"].ToString();

            if (carregaEndereco)
                Endereco = new Endereco(dr);
        }

        public void FillRow(DataRow dr)
        {
            dr["ID_Cliente"] = (ID_Cliente != null) ? ID_Cliente : "";
            dr["ID_Empresa"] = (ID_Empresa != null) ? ID_Empresa : "1";
            dr["Nome"] = (Nome != null) ? Nome : "";
            dr["Tratamento"] = (Tratamento != null) ? Tratamento : "";
            dr["CNPJ_CPF"] = (CNPJ_CPF != null) ? CNPJ_CPF : "";
            dr["Inscricao_RG"] = (Inscricao_RG != null) ? Inscricao_RG : "";
            dr["Fone"] = (Fone != null) ? Fone : "";
            dr["Celular"] = (Celular != null) ? Celular : "";
            dr["Email"] = (Email != null) ? Email : "";
            //dr["Atualizacao"] = (Atualizacao != null) ? Atualizacao : "";
            //dr["Exclusao"] = (Exclusao != null) ? Exclusao : "";

            Endereco.FillRow(dr);
        }

        public string GetCampos()
        {
            string campos = "ID_Cliente, ID_Empresa, Nome, Tratamento," +
                "CNPJ_CPF, Inscricao_RG, Fone, Celular, Email";
            if (Endereco != null)
                campos = campos + ", " + Endereco.GetCampos();
            return campos;
        }

        public string GetValores()
        {
            string valores = ID_Cliente + "," + ID_Empresa + ",'" + Nome + "','" + Tratamento + "','" +
                CNPJ_CPF + "','" + Inscricao_RG + "','" + Fone + "','" + Celular + "','" + Email + "'";
            if (Endereco != null)
                valores = valores + ", " + Endereco.GetValores();
            return valores;
        }

        public string GetCamposValores(bool id)
        {
            StringBuilder sb = new StringBuilder();
            if (id)
                sb.Append("ID_Cliente = " + ID_Cliente + ",");
            if (!string.IsNullOrWhiteSpace(ID_Empresa))
                sb.Append("ID_Empresa = " + ID_Empresa + ",");
            if (!string.IsNullOrWhiteSpace(Nome))
                sb.Append("Nome = '" + Nome + "',");
            if (!string.IsNullOrWhiteSpace(Tratamento))
                sb.Append("Tratamento = '" + Tratamento + "',");
            if (!string.IsNullOrWhiteSpace(CNPJ_CPF))
                sb.Append("CNPJ_CPF = '" + CNPJ_CPF + "',");
            if (!string.IsNullOrWhiteSpace(Inscricao_RG))
                sb.Append("Inscricao_RG = '" + Inscricao_RG + "',");
            if (!string.IsNullOrWhiteSpace(Fone))
                sb.Append("Fone = '" + Fone + "',");
            if (!string.IsNullOrWhiteSpace(Celular))
                sb.Append("Celular = '" + Celular + "',");
            if (!string.IsNullOrWhiteSpace(Email))
                sb.Append("Email = '" + Email + "',");
            sb.Append(Endereco.GetCamposValores(false));

            string ret = sb.ToString();//.Substring(0, sb.ToString().Length - 1);

            return ret;
        }

        public string GetJsonIds()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            sb.Append("\"ID_Cliente\": \"" + ID_Cliente + "\",");
            sb.Append("\"ListaEndereco\": [ ");

            if (ListaEndereco.Count > 0)
            {
                sb.Append("{ ");
                sb.Append("\"ID_Cliente_End\": \"" + ListaEndereco[0].ID_Cliente_End + "\",");
                sb.Append("\"Descricao\": \"" + ListaEndereco[0].Descricao + "\"");
                sb.Append("}");
                for (int i = 1; i < ListaEndereco.Count; i++)
                {
                    sb.Append(", { ");
                    sb.Append("\"ID_Cliente_End\": \"" + ListaEndereco[i].ID_Cliente_End + "\",");
                    sb.Append("\"Descricao\": \"" + ListaEndereco[i].Descricao + "\"");
                    sb.Append("}");
                }
            }
            sb.Append(" ] ");
            sb.Append(" } ");

            return sb.ToString();
        }
    }
}

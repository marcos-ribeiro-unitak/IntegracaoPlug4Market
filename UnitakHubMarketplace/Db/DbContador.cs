using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.Db
{
    class DbContador
    {
        DbAccess con;

        public DbContador()
        {
            con = new DbAccess();
        }

        public int SelectNextID(string tabela, string colunaId, string idEmpresa)
        {
            string contTabela = "";
            if (tabela.ToUpper().Contains("DAV"))
                contTabela = "DAV_Contador";
            else if (tabela.ToUpper().Contains("CLIENTES"))
                contTabela = "Clientes_Contador";
            else if (tabela.ToUpper().Contains("ITENS"))
                contTabela = "Itens_Contador";
            else
                return -1;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ISNULL(" + colunaId + ", 0) + " + idEmpresa.PadRight(7, '0') + "1 ");
            sb.Append("AS " + colunaId + " FROM " + contTabela);
            sb.Append(" WHERE ID_Empresa = " + idEmpresa);

            DataTable dt = con.Select(sb.ToString());
            if (dt.Rows.Count == 0)
            {
                InsertMaxID(tabela, colunaId, idEmpresa);
                dt = con.Select(sb.ToString());
            }

            int max_id = -1;
            int.TryParse(dt.Rows[0][colunaId].ToString(), out max_id);

            return max_id;
        }

        public int SelectNextID(string tabela, string colunaId, string idEmpresa, string idPdv, string idSerie)
        {
            string contTabela = tabela + "_Contador";
            //if (tabela.ToUpper().Contains("DAV"))
            //    contTabela = "DAV_Contador";
            //else if (tabela.ToUpper().Contains("CLIENTES"))
            //    contTabela = "Clientes_Contador";
            //else if (tabela.ToUpper().Contains("ITENS"))
            //    contTabela = "Itens_Contador";
            //else
            //    return -1;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ISNULL(" + colunaId + ", 0) + " + idEmpresa.PadRight(7, '0') + "1 ");
            sb.Append("AS " + colunaId + " FROM " + contTabela);
            sb.Append(" WHERE ID_Empresa = " + idEmpresa);
            if (idPdv != "")
                sb.Append(" AND ID_PDV = " + idPdv);
            if (idSerie != "")
                sb.Append(" AND ID_Serie = " + idSerie);


            DataTable dt = con.Select(sb.ToString());
            if (dt.Rows.Count == 0)
            {
                InsertMaxID(tabela, colunaId, idEmpresa);
                dt = con.Select(sb.ToString());
            }

            int max_id = -1;
            int.TryParse(dt.Rows[0][colunaId].ToString(), out max_id);

            return max_id;
        }

        public void InsertMaxID(string tabela, string colunaId, string idEmpresa)
        {
            string contTabela = "";
            if (tabela.ToUpper().Contains("DAV"))
                contTabela = "DAV_Contador";
            else if (tabela.ToUpper().Contains("CLIENTES"))
                contTabela = "Clientes_Contador";
            else if (tabela.ToUpper().Contains("ITENS"))
                contTabela = "Itens_Contador";
            else
                return;

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + contTabela + " ");
            sb.Append("(ID_Empresa, " + colunaId + ") ");
            sb.Append("VALUES ");
            sb.Append("(" + idEmpresa + ", 0)");

            con.Insert(sb.ToString());
        }

        public void UpdateMaxID(string tabela, string colunaId, string idEmpresa)
        {
            string contTabela = "";
            if (tabela.ToUpper().Contains("DAV"))
                contTabela = "DAV_Contador";
            else if (tabela.ToUpper().Contains("CLIENTES"))
                contTabela = "Clientes_Contador";
            else if (tabela.ToUpper().Contains("ITENS"))
                contTabela = "Itens_Contador";
            else
                return;

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE " + contTabela + " SET ");
            sb.Append(colunaId + " = (SELECT MAX(" + colunaId + ") - (" + idEmpresa.PadRight(8, '0') + ") ");
            sb.Append("FROM " + tabela + " WHERE ID_Empresa = " + idEmpresa + ") ");
            sb.Append("WHERE ID_Empresa = " + idEmpresa);

            con.Update(sb.ToString());
        }
    }
}

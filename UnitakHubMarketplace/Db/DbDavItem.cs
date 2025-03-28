using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitakHubMarketplace.SyslojaModels;

namespace UnitakHubMarketplace.Db
{
    public class DbDavItem
    {
        DbAccess con;
        DbContador contador;
        string NomeTabela = "DAV_Itens";

        public DbDavItem()
        {
            con = new DbAccess();
            contador = new DbContador();
        }

        public DataTable Select(string idMarketPlace)
        {
            string sql = "SELECT * FROM dav_itens WHERE ID_Marketplace = " + idMarketPlace;
            return con.Select(sql);
        }

        public int Gravar(DavItem davit)
        {
            int result = 0;
            int next_id = contador.SelectNextID(NomeTabela, "ID_DAV_Item", davit.ID_Empresa);
            if (next_id < 0)
                return next_id;

            StringBuilder sb = new StringBuilder();
            if (davit.ID_DAV_Item == "0" || string.IsNullOrWhiteSpace(davit.ID_DAV_Item))
            {
                davit.ID_DAV_Item = next_id.ToString();
                sb.Append("INSERT INTO " + NomeTabela + " (");
                sb.Append(davit.GetCampos() + ", Atualizacao, Hora)");
                sb.Append(" OUTPUT INSERTED.ID_DAV_Item ");
                sb.Append("VALUES (");
                sb.Append(davit.GetValores() + ", GETDATE(), GETDATE()");
                sb.Append(");");

                //davit.ID_DAV_Item = "0";

                result = con.Insert(sb.ToString());
            }
            else
            {
                int.TryParse(davit.ID_DAV_Item, out result);

                sb.Append("UPDATE " + NomeTabela + " SET ");
                sb.Append(davit.GetCamposValores(false));
                sb.Append(", Atualizacao = GETDATE(), Hora = GETDATE()");
                sb.Append(" WHERE ID_DAV_Item = " + davit.ID_DAV_Item + ";");

                con.Update(sb.ToString());
            }
            contador.UpdateMaxID(NomeTabela, "ID_DAV_Item", davit.ID_Empresa);

            return result;
        }

        public List<DavItem> Buscar(int ID_Dav)
        {
            return Select(ID_Dav, 0, 0, 0);
        }

        public List<DavItem> Buscar(int ID_Dav, int ID_Vendedor, int ID_Cliente)
        {
            return Select(ID_Dav, ID_Vendedor, ID_Cliente, 0);
        }

        private List<DavItem> Select(int ID_DAV, int ID_Vendedor, int ID_Cliente, int ID_DAV_Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT d.*, i.Vende_Fracionado, il.Preco_Unitario, ");
            sb.Append("ISNULL(at.Preco_Atacado, 0) AS 'Preco_Atacado', ");
            sb.Append("ISNULL(at.QTD_Atacado, 0) AS 'QTD_Atacado' ");
            sb.Append("FROM DAV_Itens d ");
            sb.Append("INNER JOIN Itens i on i.ID_Item = d.ID_Item ");
            sb.Append("INNER JOIN ItensListaPreco il on i.ID_Item = il.ID_Item ");
            sb.Append("LEFT JOIN ItensListaPrecoAtacado at on i.ID_Item = at.ID_Item ");
            sb.Append("WHERE d.Exclusao IS NULL ");
            sb.Append("AND d.ID_Lista = il.ID_Lista ");

            if (ID_DAV_Item != 0)
                sb.Append(" AND d.ID_DAV_Item = " + ID_DAV_Item);
            if (ID_DAV != 0)
                sb.Append(" AND d.ID_DAV = " + ID_DAV);
            if (ID_Vendedor != 0)
                sb.Append(" AND d.ID_Vendedor = " + ID_Vendedor);
            if (ID_Cliente != 0)
                sb.Append(" AND d.ID_Cliente = " + ID_Cliente);

            DataTable dt = con.Select(sb.ToString());
            List<DavItem> lista = new List<DavItem>();
            foreach (DataRow row in dt.Rows)
                lista.Add(new DavItem(row));

            return lista;
        }
    }
}

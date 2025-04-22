using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unitak.Uteis.Tipos;
using UnitakHubMarketplace.Models.Plug4Market;
using UnitakHubMarketplace.SyslojaModels;

namespace UnitakHubMarketplace.Db
{
    public class DbDav
    {
        DbAccess con;
        DbContador contador;
        string NomeTabela = "DAV";

        public DbDav()
        {
            con = new DbAccess();
            contador = new DbContador();
        }

        public DataTable SelectDav(long idMarketPlace)
        {
            string sql = "SELECT * FROM Dav WHERE ID_Marketplace = " + idMarketPlace;
            return con.Select(sql);
        }

        public DataTable SelectCondPadrao()
        {
            string sql = "select * from Condicoes_pgto where id_Condicao = " + ConfigHub.ID_CONDICAO;
            return con.Select(sql);
        }

        public DataTable SelectCondicoes()
        {
            string sql = "select * from Condicoes_pgto where Exclusao is null";
            return con.Select(sql);
        }

        public DataTable SelectEstoques()
        {
            string sql = "select * from Config_Estoque where Exclusao is null";
            return con.Select(sql);
        }

        public DataTable SelectVendedores()
        {
            string sql = "select * from Usuarios where Exclusao is null";
            return con.Select(sql);
        }


        public Dav GravarODav(Order pedido, Cliente cliente)
        {
            Dav dav = new Dav();

            if (pedido.orderIdStore != null && pedido.orderIdStore != "") {
                DataTable dtDav = SelectDav(long.Parse(pedido.orderIdStore.ToString()));
                if (dtDav.Rows.Count > 0)
                    dav = new Dav(dtDav.Rows[0]);
            }
            

            dav.Fill(pedido, cliente);
            dav.ID_Empresa = cliente.ID_Empresa;
            DataTable dtCond = SelectCondPadrao();
            if (dtCond.Rows.Count > 0)
                dav.Condicao = new CondicaoPgto(dtCond.Rows[0]);

            int id = Gravar(dav);
            if (dav.ID_DAV == "0")
                dav.ID_DAV = id.ToString();

            return dav;
        }
        public int Gravar(Dav dav)
        {
            int result = 0;
            int next_id = contador.SelectNextID(NomeTabela, "ID_DAV", dav.ID_Empresa);
            if (next_id < 0)
                return next_id;
            //string sqlContador = "UPDATE DAV_Contador SET ID_Dav = " + max_id + " - (" + dav.ID_Empresa.PadRight(8, '0') + ")";

            StringBuilder sb = new StringBuilder();
            if (dav.ID_DAV == "0" || string.IsNullOrWhiteSpace(dav.ID_DAV))
            {
                dav.Hora_cx = "GETDATE()";
                dav.Data_cx = "GETDATE()";

                dav.ID_DAV = next_id.ToString();
                sb.Append("INSERT INTO " + NomeTabela + " (");
                sb.Append(dav.GetCampos() + ", Atualizacao, Hora )");
                sb.Append(" OUTPUT INSERTED.ID_DAV ");
                sb.Append("VALUES (");
                sb.Append(dav.GetValores() + ", GETDATE(), GETDATE()");
                sb.Append(");");

                //dav.ID_DAV = next_id.ToString();

                result = con.Insert(sb.ToString());
            }
            else
            {
                int.TryParse(dav.ID_DAV, out result);
                sb.Append("UPDATE " + NomeTabela + " SET ");
                sb.Append(dav.GetCamposValores(false));
                sb.Append(", Atualizacao = GETDATE(), Hora = GETDATE()");
                sb.Append(" WHERE ID_DAV = " + dav.ID_DAV + ";");

                con.Update(sb.ToString());
            }
            contador.UpdateMaxID(NomeTabela, "ID_Dav", dav.ID_Empresa);
            //con.Update(sqlContador);

            return result;
        }


        // Depois da venda

        public DataTable SelectDavNfe(long idMarketPlace)
        {
            string sql = "SELECT nxml.ID_Serie,nxml.XML,nxml.NFE,nfe.Data_Emissao FROM Dav d" +
                " inner join Vendas v on v.ID_Venda = d.ID_Venda" +
                " inner join NFe nfe on NFe.ID_NFe = v.ID_NFe" +
                " inner join NFe_XML nxml on nxml.ID_NFe = nfe.ID_NFe" +
                " WHERE d.ID_Marketplace = " + idMarketPlace;
            return con.Select(sql);
        }
    }
}

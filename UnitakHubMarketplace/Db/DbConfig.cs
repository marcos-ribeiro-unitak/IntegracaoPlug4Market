using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace UnitakHubMarketplace.Db
{
    public class DbConfig
    {
        SqlConnection conn;
        string sql = "select top(0) * from Config_MarketPlace;";
        DbAccess db;

        public DbConfig()
        {
            new database.Banco_de_Dados();
            conn = new SqlConnection(Unitak.Config.VariaveisConn.Instance.ConectionString);//database.variaveis.instance.String_sql);
            db = new DbAccess();
        }

        public void CriarTabela()
        {
            DataTable dt = db.Select("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Config_MarketPlace'");

            if (dt.Rows.Count == 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE TABLE Config_MarketPlace(");
                sb.Append("ID_Marketplace int primary key,");
                sb.Append("ID_CONDICAO int,");
                sb.Append("ID_VENDEDOR int,");
                sb.Append("ID_ITEM_CORINGA int,");
                sb.Append("URL_API nvarchar(200),");

                sb.Append("ID_SELLER nvarchar(255),");
                sb.Append("ACCESS_TOKEN nvarchar(MAX),");
                sb.Append("REFRESH_TOKEN nvarchar(MAX),");

                sb.Append("CNPJ_LOJA nvarchar(50),");
                sb.Append("LOGIN nvarchar(50),");
                sb.Append("SENHA nvarchar(50),");

                sb.Append("USER_ID int,");
                sb.Append("USER_AGENT nvarchar(200),");
                sb.Append("ULTIMA_ATUALIZACAO DateTime,");
                sb.Append("ULTIMA_ATUALIZACAO_ACCESS_TOKEN DateTime,");
                sb.Append("ULTIMA_ATUALIZACAO_REFRESH_TOKEN DateTime,");
                sb.Append("TIMER_PEDIDOS int); ");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.ExecuteNonQuery();

                CriarColunas();
            }
        }

        public void CriarColunas()
        {
            DataTable dtVendas = db.Select("select top 0 * from Vendas");
            DataTable dtDAV = db.Select("select top 0 * from DAV");
            DataTable dtItens = db.Select("select top 0 * from Itens");
            DataTable dtItensGrupos = db.Select("select top 0 * from ItensGrupos");
            DataTable dtDavIt = db.Select("select top 0 * from DAV_Itens");
            DataTable dtVendasIt = db.Select("select top 0 * from Vendas_Itens");
            DataTable dtVendasRec = db.Select("select top 0 * from Vendas_Receber");

            StringBuilder sb = new StringBuilder();
            if (!dtItens.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table Itens add ID_Marketplace int; ");

            if (!dtItensGrupos.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table ItensGrupos add ID_Marketplace int; ");

            if (!dtDAV.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table DAV add ID_Marketplace int; ");
            if (!dtDAV.Columns.Contains("Valor_Frete"))
                sb.Append("alter table DAV add Valor_Frete decimal(10, 2); ");

            if (!dtDavIt.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table DAV_Itens add ID_Marketplace int; ");

            if(!dtVendas.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table Vendas add ID_Marketplace int; ");
            if (!dtVendas.Columns.Contains("Status_MarketPlace"))
                sb.Append("alter table Vendas add Status_MarketPlace nvarchar(50)");
            if (!dtVendas.Columns.Contains("Valor_Frete"))
                sb.Append("alter table Vendas add Valor_Frete decimal(10, 2); ");

            if (!dtVendasIt.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table Vendas_Itens add ID_Marketplace int; ");

            if (!dtVendasRec.Columns.Contains("ID_Marketplace"))
                sb.Append("alter table Vendas_Receber add ID_Marketplace int; ");

            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetColumns()
        {
            return db.Select("select * from Config_MarketPlace");
        }

        public DataTable Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Config_MarketPlace ");

            DataTable dt = new DbAccess().Select(sb.ToString());
            if (dt.Rows.Count > 0)
            {
                ConfigHub.ID_CONDICAO = dt.Rows[0]["ID_CONDICAO"].ToString();
                ConfigHub.ID_VENDEDOR = dt.Rows[0]["ID_VENDEDOR"].ToString();
                ConfigHub.ID_ITEM_CORINGA = dt.Rows[0]["ID_ITEM_CORINGA"].ToString();
                //ConfigHub.URL_SITE = dt.Rows[0]["URL_SITE"].ToString();
                ConfigHub.URL_API = dt.Rows[0]["URL_API"].ToString();
                ConfigHub.ACCESS_TOKEN = dt.Rows[0]["ACCESS_TOKEN"].ToString();
                ConfigHub.REFRESH_TOKEN = dt.Rows[0]["REFRESH_TOKEN"].ToString();
                ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN = DateTime.Parse(dt.Rows[0]["ULTIMA_ATUALIZACAO_ACCESS_TOKEN"].ToString());
                ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN = DateTime.Parse(dt.Rows[0]["ULTIMA_ATUALIZACAO_REFRESH_TOKEN"].ToString());
                ConfigHub.CNPJ_LOJA = dt.Rows[0]["CNPJ_LOJA"].ToString();
                ConfigHub.LOGIN = dt.Rows[0]["LOGIN"].ToString();
                ConfigHub.SENHA = dt.Rows[0]["SENHA"].ToString();
                ConfigHub.TIMER_PEDIDOS = (int)dt.Rows[0]["TIMER_PEDIDOS"];
                //ConfigHub.ULTIMA_ATUALIZACAO = (DateTime) dt.Rows[0]["ULTIMA_ATUALIZACAO"];
            }
            else
            {
                dt = Gravar();
            }

            return dt;
        }

        public DataTable Gravar()
        {
            DataTable dt = GetColumns();
            dt.TableName = "Config_MarketPlace";

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add();
                dt.Rows[0]["ID_Marketplace"] = 1;
            }
            dt.Rows[0]["ID_CONDICAO"] = ConfigHub.ID_CONDICAO;
            dt.Rows[0]["ID_VENDEDOR"] = ConfigHub.ID_VENDEDOR;
            dt.Rows[0]["ID_ITEM_CORINGA"] = ConfigHub.ID_ITEM_CORINGA;
            //dt.Rows[0]["URL_SITE"] = ConfigHub.URL_SITE;
            dt.Rows[0]["URL_API"] = ConfigHub.URL_API;
            dt.Rows[0]["CNPJ_LOJA"] = ConfigHub.CNPJ_LOJA;
            dt.Rows[0]["LOGIN"] = ConfigHub.LOGIN;
            dt.Rows[0]["SENHA"] = ConfigHub.SENHA;
            dt.Rows[0]["TIMER_PEDIDOS"] = ConfigHub.TIMER_PEDIDOS;

            dt.Rows[0]["REFRESH_TOKEN"] = ConfigHub.REFRESH_TOKEN;
            dt.Rows[0]["ACCESS_TOKEN"] = ConfigHub.ACCESS_TOKEN;
            dt.Rows[0]["ULTIMA_ATUALIZACAO_ACCESS_TOKEN"] = ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN;
            dt.Rows[0]["ULTIMA_ATUALIZACAO_REFRESH_TOKEN"] = ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN;
            dt.Rows[0]["ULTIMA_ATUALIZACAO"] = ConfigHub.ULTIMA_ATUALIZACAO;

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            new SqlCommandBuilder(da);
            int ret = da.Update(dt);

            if (ret > 0)
                return dt;
            else
                return null;
        }
    }
}

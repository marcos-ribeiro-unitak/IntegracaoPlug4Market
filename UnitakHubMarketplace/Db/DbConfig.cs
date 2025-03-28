using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.Db
{
    public class DbConfig
    {
        SqlConnection conn;
        string sql = "select top(0) * from Config_Hub;";
        DbAccess db;

        public DbConfig()
        {
            new database.Banco_de_Dados();
            conn = new SqlConnection(Unitak.Config.VariaveisConn.Instance.ConectionString);//database.variaveis.instance.String_sql);
            db = new DbAccess();
        }

        public DataTable GetColumns()
        {
            return db.Select("select * from Config_Hub");
        }

        public DataTable Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Config_Hub ");

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
            dt.TableName = "Config_Hub";

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

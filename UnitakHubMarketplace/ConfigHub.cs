using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitakHubMarketplace.Db;

namespace UnitakHubMarketplace
{
    /*
    //CRIAR COLUNAS 

alter table Itens add ID_Marketplace int
alter table ItensGrupos add ID_Marketplace int

alter table DAV add ID_Marketplace int
alter table DAV_Itens add ID_Marketplace int

alter table Vendas add ID_Marketplace int
alter table Vendas_Itens add ID_Marketplace int
alter table Vendas_Receber add ID_Marketplace int

alter table Dav add Valor_Frete decimal (10,2)
alter table Vendas add Valor_Frete decimal (10,2)
alter table Vendas add Status_MarketPlace nvarchar(50)


CREATE NONCLUSTERED INDEX [sk_ID_Item_Exclusao]
ON [dbo].[ItensGrade] ([ID_Item],[Exclusao])
INCLUDE ([Barras_Gerada],[Barras])



//CRIAR TABELA DE CONFIGURAÇÃO

CREATE TABLE Config_MarketPlace(
    ID_Marketplace int primary key,
    ID_CONDICAO int,
    ID_VENDEDOR int,
    ID_ITEM_CORINGA int,
    URL_API nvarchar(200),
    ACCESS_TOKEN nvarchar(255),
    REFRESH_TOKEN nvarchar(255),
    LOGIN nvarchar(50),
    SENHA nvarchar(50),
	ID_SELLER nvarchar(255),
    USER_ID int,
    USER_AGENT nvarchar(200),
    ULTIMA_ATUALIZACAO DateTime,
    ULTIMA_ATUALIZACAO_ACCESS_TOKEN DateTime,
    ULTIMA_ATUALIZACAO_REFRESH_TOKEN DateTime,
    TIMER_PEDIDOS int
);

    */


    public static class ConfigHub
    {

        //public static string INTEGRACAO = "MercadoLivre";
        public static string ID_CONDICAO = "0";
        public static string ID_VENDEDOR = "0";
        public static string ID_ITEM_CORINGA = "0";
        public static string ID_ESTOQUE = "11";

        public static string URL_API = "https://api.sandbox.plug4market.com.br";
        //public static string URL_API() { return URL_SITE; } 
        public static string ID_SELLER = "";
        public static string LOGIN = "";
        public static string SENHA = "";

        public static string ACCESS_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzb2Z0d2FyZUhvdXNlIjoiMDM3NTM5MTkwMDAxNDQiLCJzdG9yZSI6IjgwNDAxMDExMDAwMTEyIiwidXJsIjoiYXBpLnNhbmRib3gucGx1ZzRtYXJrZXQuY29tLmJyIiwidXNlcklkIjoiMzc5ZTY0MmYtYzFjYi00ZDcxLTllYzItNmVjY2Q4ODA3Njc4IiwicmVmcmVzaFRva2VuIjoiZjdkZDRiZDIyMGJhMjM5NjE3OGMzZTg2YTJjMzdiN2JjYzlhODg3YTNjZDZjMGM0MGRmOGIzNzUxNzc5MmQzYiIsInR5cGUiOiJzdG9yZSIsImlhdCI6MTc0MjgzNjg1NiwiZXhwIjoxNzQyOTIzMjU2fQ.Hj9rId8LzByF8g_rQl9ZbQljhHQwWG7c-0GXeUvG668";
        public static string REFRESH_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzb2Z0d2FyZUhvdXNlQ25waiI6IjAzNzUzOTE5MDAwMTQ0Iiwic3RvcmVDbnBqIjoiODA0MDEwMTEwMDAxMTIiLCJ1c2VySWQiOiIzNzllNjQyZi1jMWNiLTRkNzEtOWVjMi02ZWNjZDg4MDc2NzgiLCJyZWZyZXNoVG9rZW4iOiJmN2RkNGJkMjIwYmEyMzk2MTc4YzNlODZhMmMzN2I3YmNjOWE4ODdhM2NkNmMwYzQwZGY4YjM3NTE3NzkyZDNiIiwiaWF0IjoxNzQyODM2ODU2LCJleHAiOjE3NDM0NDE2NTZ9.cYVgVY3ZVL9GUXtArb1lmzSkOsSrKf-Xk9N1eEJsb1U";

        public static DateTime ULTIMA_ATUALIZACAO = DateTime.Now;
        public static DateTime ULTIMA_ATUALIZACAO_ACCESS_TOKEN = DateTime.Now;
        public static DateTime ULTIMA_ATUALIZACAO_REFRESH_TOKEN = DateTime.Now;


        public static int TIMER_PEDIDOS = 30;


        public static string GetFullUrl(string path, string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(URL_API + path);
            if (id != "")
                sb.Append("/" + id.ToString());

            return sb.ToString();
        }

        public static decimal StringToDecimal(string dec)
        {
            return decimal.Parse(dec.Replace(",", "").Replace(".", ","));
        }

        public static void Carregar()
        {
            new DbConfig().Get();
        }

        public static bool validaConfig()
        {
            bool ret = !string.IsNullOrEmpty(ConfigHub.ACCESS_TOKEN) && !string.IsNullOrEmpty(ConfigHub.REFRESH_TOKEN) && !string.IsNullOrEmpty(ConfigHub.URL_API);
            if (!ret)
                MessageBox.Show(null, "Integração não configurada\n\nAcesse o menu '1 - Configurações' antes de continuar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ret;
        }

    }
}

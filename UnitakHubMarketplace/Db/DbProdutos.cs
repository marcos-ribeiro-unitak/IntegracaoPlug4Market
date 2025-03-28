using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.Db
{
    public class DbProdutos
    {
        public bool RemoveIDGrupo(int idgrupo)
        {
            string sql = "update itensgrupos set ID_MarketPlace = null  where id_grupo =" + idgrupo;
            return new DbAccess().ExecCommand(sql);
        }

        public DataTable SelectCoringas()
        {
            string sql = "select * from itens" +
                " where Editar_Na_Venda = 'Sim' " +
                //" and Editar_Descricao_na_Venda = 'Sim' " +
                " and Exclusao is null";

            DbAccess db = new DbAccess();
            return db.Select(sql);
        }

        public DataTable SelectItemPadrao()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Itens it ");
            sb.Append(" inner join Itens_ICMS ic on ic.ID_ICMS = it.ID_ICMS ");
            sb.Append(" inner join ItensGrade ig on ig.ID_Item = it.ID_Item ");
            sb.Append(" where it.ID_Item = " + ConfigHub.ID_ITEM_CORINGA);

            DbAccess db = new DbAccess();
            return db.Select(sb.ToString());
        }
        public DataTable SelectEstoqueCardex()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select cardex.ID_Estoque_Cardex, cardex.ID_Item, cardex.Codigo, cardex.Estoque_Antes, cardex.Estoque_Depois, cardex.Hora, it.ID_Marketplace ");
            sb.Append("from Estoque_Itens_Cardex cardex ");
            sb.Append("inner join Itens it on it.ID_Item = cardex.ID_Item ");
            sb.Append("where cardex.Hora > convert(datetime, '" + ConfigHub.ULTIMA_ATUALIZACAO + "', 103) and ID_Marketplace is not null ");
            sb.Append("order by cardex.Hora desc ");
            DbAccess db = new DbAccess();
            return db.Select(sb.ToString());
        }
        public DataTable SelectItem(int idMarketPlace)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Itens it ");
            sb.Append(" inner join Itens_ICMS ic on ic.ID_ICMS = it.ID_ICMS ");
            sb.Append(" inner join ItensGrade ig on ig.ID_Item = it.ID_Item ");
            sb.Append(" where it.ID_Marketplace = " + idMarketPlace);

            return new DbAccess().Select(sb.ToString());
        }

        public DataTable SelectGrupos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ID_Grupo, ID_Marketplace, Descricao from ItensGrupos ");
            sb.Append(" where Exclusao is null");

            return new DbAccess().Select(sb.ToString());
        }

        public DataTable SelectMarcas()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ItensMarcas ");
            sb.Append(" where Exclusao is null");

            return new DbAccess().Select(sb.ToString());
        }

        public DataTable SelectAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select it.ID_Item, min(bar.Barras) as Barras, it.ID_Marketplace, it.Descricao, ");
            sb.Append("it.Descricao_Reduzida, pr.Preco_Unitario, CONVERT(VARBINARY(8000), it.Fotografia) AS Fotografia, ");
            sb.Append("count(bar.ID_ItemGrade) as QTD_Grade from itens it ");
            sb.Append("inner  join ItensListaPreco pr on pr.id_item = it.ID_Item ");
            sb.Append("Inner join ItensGrade bar on bar.id_item = it.ID_Item ");
            sb.Append("where it.Exclusao is null ");
            sb.Append(" group by it.ID_Item, it.ID_Marketplace, it.Descricao, ");
            sb.Append("it.Descricao_Reduzida, pr.Preco_Unitario, CONVERT(VARBINARY(8000), it.Fotografia)");

            DbAccess db = new DbAccess();
            return db.Select(sb.ToString());
        }

        public DataTable SelectIDs(int[] ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select it.ID_Item, it.ID_Marketplace, pre.Preco_Unitario From Itens it ");
            sb.Append(" inner join ItensListaPreco pre on pre.ID_Item = it.ID_Item ");
            sb.Append("where it.ID_Item in (" + string.Join(",", ids) + ")");

            DbAccess db = new DbAccess();
            return db.Select(sb.ToString());
        }

        public DataTable Select(string pesquisa, int idGrupo, int idMarca, int idEstoque, bool onlyGrade, bool naoCad, string qtdBusca, bool somenteGrade)
        {
            StringBuilder sb = new StringBuilder();
            int top = 0;
            if (!string.IsNullOrEmpty(qtdBusca) && int.TryParse(qtdBusca, out top))
            {
                sb.Append("select TOP (" + top.ToString() + ") it.ID_Item, it.ID_Marketplace, it.Descricao,   ");
            }
            else
            {
                sb.Append("select it.ID_Item, it.ID_Marketplace, it.Descricao,   ");
            }
            sb.Append("pr.Preco_Unitario, max(bar.Barras) as Barras, sum(est.Estoque) as Estoque, count(bar.ID_ItemGrade) as QTD_Grade, ");
            sb.Append("CONVERT(VARBINARY(8000), it.Fotografia) AS Fotografia, ");
            sb.Append("gru.ID_grupo, gru.Descricao as Descricao_Grupo, gru.ID_Marketplace as ID_Marketplace_categoria ");
            sb.Append("from itens it ");
            sb.Append("inner join ItensListaPreco pr on pr.id_item = it.ID_Item ");
            sb.Append("Inner join ItensGrade bar on bar.id_item = it.ID_Item ");
            sb.Append("Inner join ItensGrupos gru on gru.id_grupo = it.ID_grupo ");
            sb.Append("Inner join ItensEstoque est on est.Barras_Gerada = bar.Barras_Gerada ");
            sb.Append("where it.Exclusao is null and bar.Exclusao is null ");
            if (somenteGrade)
            {
                sb.Append("and bar.ID_Grade <> 0 ");
                sb.Append("and bar.Exclusao is null ");
                sb.Append("and bar.Cor <> 'Todos' ");
                sb.Append("and bar.Tamanho <> 'Todos' ");
            }
            sb.Append("and est.ID_Estoque = " + idEstoque + " ");
            sb.Append("and est.Exclusao is null ");
            int aux = 0;
            if (int.TryParse(pesquisa, out aux))
                sb.Append("and it.ID_Item = " + pesquisa + " ");
            else if (!string.IsNullOrEmpty(pesquisa))
                sb.Append("and it.Descricao like '%" + pesquisa + "%' ");
            if (naoCad)
                sb.Append("and it.ID_Marketplace is null ");
            else
                sb.Append("and it.ID_Marketplace is not null ");

            if (idGrupo > 0)
                sb.Append("and  it.ID_Grupo = " + idGrupo + " ");
            if (idMarca > 0)
                sb.Append("and  it.ID_Marca = " + idMarca + " ");
            sb.Append(" group by it.ID_Item, it.ID_Marketplace, it.Descricao, ");
            //sb.Append("it.Descricao_Reduzida, pr.Preco_Unitario, CONVERT(VARBINARY(8000), it.Fotografia)");
            sb.Append("pr.Preco_Unitario, CONVERT(VARBINARY(8000), it.Fotografia), ");
            sb.Append("gru.ID_grupo, gru.Descricao, gru.ID_Marketplace ");
            if (onlyGrade)
                sb.Append("HAVING COUNT(bar.ID_ItemGrade) > 1 ");

            return new DbAccess().Select(sb.ToString());
        }


        public DataTable Grade(int iditem, int idEstoque)
        {
            //string select = "select ID_Item, ID_ItemGrade, Cor, Tamanho, Barras," +
            //    " Barras_Gerada from ItensGrade where ID_item =" + iditem;

            StringBuilder sb = new StringBuilder();
            sb.Append("select gr.ID_Item, gr.ID_ItemGrade, gr.Barras, gr.Barras_Gerada, est.ID_Estoque, est.Estoque, gr.Cor, gr.Tamanho ");
            sb.Append("from itensGrade gr ");
            sb.Append("inner join ItensEstoque est on est.Barras_Gerada = gr.Barras_Gerada ");
            sb.Append("where 1=1 ");
            if (iditem > 0)
                sb.Append("AND gr.ID_Item = " + iditem + " ");
            else
                sb.Append("and gr.ID_Item = 0 ");
            sb.Append("and est.ID_Estoque = " + idEstoque + "; ");

            DbAccess db = new DbAccess();
            return db.Select(sb.ToString());
        }

        public DataTable Grade(int[] iditem, int idEstoque)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select gr.ID_Item, gr.ID_ItemGrade, gr.Barras, gr.Barras_Gerada, est.ID_Estoque, est.Estoque, gr.Cor, gr.Tamanho ");
            sb.Append("from itensGrade gr ");
            sb.Append("inner join ItensEstoque est on est.Barras_Gerada = gr.Barras_Gerada ");
            sb.Append("where 1=1 ");
            if (iditem.Length > 0)
                sb.Append("AND gr.ID_Item in (" + string.Join(",", iditem) + ") ");
            else
                sb.Append("and gr.ID_Item = 0 ");
            sb.Append("and gr.Cor <> 'Todos' ");
            sb.Append("and gr.Tamanho <> 'Todos' ");
            sb.Append("and est.ID_Estoque = " + idEstoque + "; ");

            DbAccess db = new DbAccess();
            return db.Select(sb.ToString());
        }



        public bool UpdateWoo(int iditem, Produto produto)
        {
            if (produto.productId != null && produto.productId != "")
            {
                string sql = "update itens set ID_Marketplace = " + produto.productId + " where id_item =" + iditem;
                return new DbAccess().ExecCommand(sql);
            }
            return false;
        }

        public bool UpdateWoo(DataRow[] drItens, List<Produto> lista)
        {
            bool retorno = false;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].productId != null && lista[i].productId != "")
                {
                    foreach (var item in drItens)
                    {
                        if (lista[i].sku == item["Barras"].ToString())
                        {
                            //int idIte = int.Parse(drItens[i]["ID_Item"].ToString());
                            int idIte = int.Parse(item["ID_Item"].ToString());
                            retorno = UpdateWoo(idIte, lista[i]);
                            break;
                        }
                    }
                }
            }
            return retorno;
        }
    }
}

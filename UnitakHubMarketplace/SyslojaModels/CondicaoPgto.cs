using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class CondicaoPgto
    {
        public string ID_Condicao { get; set; } = "0";
        public string ID_Lista { get; set; } = "0";
        public string Descricao { get; set; } = "";
        public string Forma { get; set; } = "";
        public string Gerar_Contas { get; set; } = "";
        public string Parcelas { get; set; } = "0";
        public string Entrada { get; set; } = "";
        public string Porcentagem_Entrada { get; set; } = "0";
        public string Descontos { get; set; } = "0";
        public string Acrescimos { get; set; } = "0";
        public string Identificar_Cliente { get; set; } = "0";
        public string ComissaoAdicional { get; set; } = "0";
        public string Atacado { get; set; } = "";
        public string Margem_Lucro_Forcada { get; set; } = "0";

        public decimal CalcValorEntrada(decimal vTotal)
        {
            int parc = 0;
            int.TryParse(Parcelas, out parc);
            if (Entrada.Contains("Não"))
                return 0;
            return (vTotal / parc);
        }

        public decimal CalcParc1(decimal vTotal)
        {
            int parc = 0;
            int.TryParse(Parcelas, out parc);
            if (Entrada.Contains("Sim") && parc == 1)
                return 0;
            return (vTotal / parc);
        }

        public decimal CalcDemaisParc(decimal vTotal)
        {
            int parc = 0;
            int.TryParse(Parcelas, out parc);
            if (Entrada.Contains("Sim") && parc < 2)
                return 0;
            return (vTotal - CalcParc1(vTotal) - CalcValorEntrada(vTotal));
        }

        public CondicaoPgto() { }

        public override string ToString()
        {
            return Descricao;
        }

        public CondicaoPgto(DataRow dr)
        {
            ID_Condicao = dr["ID_Condicao"].ToString();
            ID_Lista = dr["ID_Lista"].ToString();
            Descricao = dr["Descricao"].ToString();
            if (dr.Table.Columns.Contains("Forma"))
                Forma = dr["Forma"].ToString();
            if (dr.Table.Columns.Contains("Gerar_Contas"))
                Gerar_Contas = dr["Gerar_Contas"].ToString();
            if (dr.Table.Columns.Contains("Parcelas"))
                Parcelas = dr["Parcelas"].ToString();
            if (dr.Table.Columns.Contains("Entrada"))
                Entrada = dr["Entrada"].ToString();
            if (dr.Table.Columns.Contains("Porcentagem_Entrada"))
                Porcentagem_Entrada = dr["Porcentagem_Entrada"].ToString();
            if (dr.Table.Columns.Contains("Descontos"))
                Descontos = dr["Descontos"].ToString();
            if (dr.Table.Columns.Contains("Acrescimos"))
                Acrescimos = dr["Acrescimos"].ToString();
            if (dr.Table.Columns.Contains("Identificar_Cliente"))
                Identificar_Cliente = dr["Identificar_Cliente"].ToString();
            if (dr.Table.Columns.Contains("Atacado"))
                ComissaoAdicional = dr["ComissaoAdicional"].ToString();
            if (dr.Table.Columns.Contains("Atacado"))
                Atacado = dr["Atacado"].ToString();
            if (dr.Table.Columns.Contains("Preco_Custo_Mais_Margem_Lucro"))
                Margem_Lucro_Forcada = dr["Preco_Custo_Mais_Margem_Lucro"].ToString();
        }
    }
}

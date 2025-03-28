using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class Grade
    {
        public string ID_ItemGrade { get; set; } = "0";
        public string ID_Empresa { get; set; } = "0";
        public string Barras { get; set; } = "";
        public string Referencia { get; set; } = "";
        public string ID_Item { get; set; } = "0";
        public string ID_Grade { get; set; } = "0";
        public string ID_GradeTamanho { get; set; } = "0";
        public string ID_Cor { get; set; } = "0";
        public string Barras_Gerada { get; set; } = "";
        public string Cor { get; set; } = "Todos";
        public string Tamanho { get; set; } = "Todos";

        public string ID_Empresa_Estoque { get; set; } = "0";
        public string ID_Estoque { get; set; } = "0";
        public string Estoque { get; set; } = "0";

        public Grade() { }

        public Grade(DataRow dr)
        {
            ID_ItemGrade = dr["ID_ItemGrade"].ToString();
            ID_Empresa = dr["ID_Empresa"].ToString();
            Barras = dr["Barras"].ToString();
            Referencia = dr["Referencia"].ToString();
            ID_Item = dr["ID_Item"].ToString();
            ID_Grade = dr["ID_Grade"].ToString();
            ID_GradeTamanho = dr["ID_GradeTamanho"].ToString();
            ID_Cor = dr["ID_Cor"].ToString();
            Barras_Gerada = dr["Barras_Gerada"].ToString();
            Cor = dr["Cor"].ToString();
            Tamanho = dr["Tamanho"].ToString();
            if (dr.Table.Columns.Contains("ID_Empresa_Estoque"))
            {
                ID_Empresa_Estoque = dr["ID_Empresa_Estoque"].ToString();
                ID_Estoque = dr["ID_Estoque"].ToString();
                Estoque = dr["Estoque"].ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.SyslojaModels
{
    public class Kit
    {
        public string ID_Composicao { get; set; } = "0";
        public string ID_Empresa { get; set; } = "0";
        public string ID_Item_Kit { get; set; } = "0";
        public Item item { get; set; }
        public string KIT_Quantidade { get; set; } = "";

        public Kit() { }
        public Kit(DataRow drKit)
        {
            ID_Composicao = drKit["ID_Composicao"].ToString();
            ID_Empresa = drKit["ID_Empresa"].ToString();
            ID_Item_Kit = drKit["ID_ITEM_KIT"].ToString();
            KIT_Quantidade = drKit["KIT_Quantidade"].ToString();

            item = new Item(drKit, null, false);
        }
    }
}

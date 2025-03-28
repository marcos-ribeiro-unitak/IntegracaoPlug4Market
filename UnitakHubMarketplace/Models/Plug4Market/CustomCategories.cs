using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.Models.Plug4Market
{
    public class CustomCategories
    {
        public string name { get; set; }
        public string alternativeId { get; set; }
        public string fatherAlternativeId { get; set; }
    }

   
    public class CustomCategoriesToSalesCategories
    {
        public List<CustomCategories> categories { get; set; }
        public string saleChannelCategoryId { get; set; }
        public int saleChannel { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parent { get; set; }
        public bool children { get; set; }
        public string alternativeId { get; set; }
    }
}

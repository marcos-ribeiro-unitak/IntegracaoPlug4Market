using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.Models.Plug4Market
{
    public class CustomCategory
    {
        public string alternativeId { get; set; }
    }

    public class ForSale
    {
        public double salePrice { get; set; }
        public DateTime saleDateStart { get; set; }
        public DateTime saleDateEnd { get; set; }
    }

    public class Metafield
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Produto
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public List<SalesChannel> salesChannels { get; set; }
        public string origin { get; set; }
        public string gender { get; set; }
        public string categoryId { get; set; }
        public string active { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public int weight { get; set; }
        public List<Metafield> metafields { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string voltage { get; set; }
        public string flavor { get; set; }
        public string potency { get; set; }
        public double warranty { get; set; }
        public int stock { get; set; }
        public double price { get; set; }
        public string model { get; set; }
        public List<string> images { get; set; }
        public List<string> videos { get; set; }
        public string ean { get; set; }
        public string ncm { get; set; }
        public double salePrice { get; set; }
        public DateTime saleDateStart { get; set; }
        public DateTime saleDateEnd { get; set; }
        public string manufacturerPartNumber { get; set; }
        public int crossDockingDays { get; set; }
        public int unitMultiplier { get; set; }
        public string measurementUnit { get; set; }
        public int costPrice { get; set; }
        public CustomCategory customCategory { get; set; }
    }

    public class SalesChannel
    {
        public int id { get; set; }
        public double price { get; set; }
        public ForSale forSale { get; set; }
    }

    public class Imagem {
        public string base64Image { get; set; }
    }

}

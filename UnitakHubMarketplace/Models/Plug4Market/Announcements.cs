using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.Models.Plug4Market
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Announcement
    {
        public string announcementId { get; set; }
        public string sellerId { get; set; }
        public string productId { get; set; }
        public string listingType { get; set; }
        public string sku { get; set; }
        public string description { get; set; }
        public string productName { get; set; }
    }

    public class Announcements
    {
        public int saleChannel { get; set; }
        public List<Announcement> announcements { get; set; }
    }


}

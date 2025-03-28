using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ErrorMessage
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }

    public class Retorno
    {
        public int error_status { get; set; }
        public List<ErrorMessage> error_messages { get; set; }

        
    }


}


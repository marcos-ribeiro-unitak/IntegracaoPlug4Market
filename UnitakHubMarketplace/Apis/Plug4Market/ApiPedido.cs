using System.Collections.Generic;
using Newtonsoft.Json;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.Apis.Plug4Market
{
    public class ApiPedido
    {
        public string path = "/orders";
        public Retorno retorno = new Retorno();

        public void fillRetorno(string Json)
        {
            if (Json == "")
            {
                retorno = new Retorno();

                retorno.error_status = 400;
                retorno.error_messages = new List<ErrorMessage>() {
                    new ErrorMessage(){
                        statusCode = 400,
                        error = "Bad Request",
                        message = "Não encontrado",
                    }
                };
            }
            else if (Json.Contains("error_status"))
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(Json);
                if (retorno.error_status == 401) {
                    ApiAuth apiAuth = new ApiAuth();
                    apiAuth.Autenticar();
                }
            }
            else
            {
                retorno = new Retorno();

                retorno.error_status = 400;
                retorno.error_messages = new List<ErrorMessage>() {
                    new ErrorMessage(){
                        statusCode = 400,
                        error = "Bad Request",
                        message = "Erro desconhecido",
                    }
                };
            }

        }

        public Order GetPedido(string id)
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, id), ConfigHub.ACCESS_TOKEN);
            //Retorno ret = JsonConvert.DeserializeObject<Retorno>(Json);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Order>(Json);

            }
        }

        
        public RetornoOrders GetPedidos()
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, ""), ConfigHub.ACCESS_TOKEN );
            //return GetRetorno<List<Order>>(Json);


            Retorno ret = JsonConvert.DeserializeObject<Retorno>(Json);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<RetornoOrders>(Json);

            }
        }

        public  Retorno GerarEtiqueta(Order pedido)
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, pedido.id) + "/label",ConfigHub.ACCESS_TOKEN);
            fillRetorno(Json);
            return retorno;
        }

        public Retorno ConfirmaPedido(Order pedido)
        {
           
            string body = "{\"orderIdStore\":\"" + pedido.orderIdStore + "\"}";//string body = JsonConvert.SerializeObject(auth.refreshToken, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, pedido.id)+"/confirm", ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            fillRetorno(Json);
            return retorno;
        }

        public Retorno ConfirmaFaturamento(Order pedido)
        {
            string body = JsonConvert.SerializeObject(pedido.invoice);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, pedido.id) + "/invoice", ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            fillRetorno(Json);
            return retorno;
        }

        public Retorno ConfirmaEnvio(Order pedido)
        {
            string body = JsonConvert.SerializeObject(pedido.shipment);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, pedido.id)+ "/shipment", ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            fillRetorno(Json);
            return retorno;
        }

        public Retorno ConfirmaçaoEntrega(Order pedido)
        {
            //string body = JsonConvert.SerializeObject(pedido.deliveredAt);
            string body = "{\"deliveredAt\":\"" + pedido.deliveredAt + "\"}";//string body = JsonConvert.SerializeObject(auth.refreshToken, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, pedido.id) + "/delivered", ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            fillRetorno(Json);
            return retorno;
        }


    }
}

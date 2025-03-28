using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.Apis.Plug4Market
{
    public class ApiAnnouncements
    {
        public string path = "/products";
        public string pathComplemento = "/announcements";

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
        public Retorno UpdateAnuncio(string sku, Announcements anuncio)
        {
            string body = JsonConvert.SerializeObject(anuncio);
            string Json = ApiAccess.Put(ConfigHub.GetFullUrl(path, sku)+ pathComplemento, ConfigHub.ACCESS_TOKEN, body);
            fillRetorno(Json);
            return retorno;
        }

        public Announcements CriarAnuncio(Announcements anuncio)
        {
            string body = JsonConvert.SerializeObject(anuncio);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, "0"), ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Announcements>(Json);

            }
        }

        public Retorno DeletarAnuncio(string sku, Announcements anuncio)
        {
            string body = JsonConvert.SerializeObject(anuncio);
            string Json = ApiAccess.Delete(ConfigHub.GetFullUrl(path, sku) + pathComplemento, ConfigHub.ACCESS_TOKEN, body);
            fillRetorno(Json);
            return retorno;
        }
    }
}

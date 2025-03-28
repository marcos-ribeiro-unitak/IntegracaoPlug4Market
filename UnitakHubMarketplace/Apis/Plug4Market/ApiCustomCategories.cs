using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.Apis.Plug4Market
{

    public class ApiCustomCategories
    {
        public string path = "/custom-categories";

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

        public List<Category> GetCategoriesList()
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, ""));
            Retorno ret = JsonConvert.DeserializeObject<Retorno>(Json);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Category>>(Json);

            }
        }
        public List<Category> GetCategoriesListFilhas(string parentId)
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, parentId));
            Retorno ret = JsonConvert.DeserializeObject<Retorno>(Json);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json); 
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Category>>(Json);

            }
        }

        public Retorno CriarCategoriaPersonalizada(CustomCategories categoriaPersonalizada)
        {
            string body = JsonConvert.SerializeObject(categoriaPersonalizada);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, ""), ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            fillRetorno(Json);
            return retorno;
        }

        public Retorno AssociarCategoriaCanalVendas(CustomCategoriesToSalesCategories associaCategoria)
        {
            string body = JsonConvert.SerializeObject(associaCategoria);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, "")+"/sale_channel", ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);            
            fillRetorno(Json);
            return retorno;

        }

        public Retorno DeletarCategoriaPersonalizada(string id)
        {
            string Json = ApiAccess.Delete(ConfigHub.GetFullUrl(path, id), ConfigHub.ACCESS_TOKEN);
            fillRetorno(Json);
            return retorno;
        }
    }
}

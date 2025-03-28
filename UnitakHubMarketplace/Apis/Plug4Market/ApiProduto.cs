using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnitakHubMarketplace.Models.Plug4Market;

namespace UnitakHubMarketplace.Apis.Plug4Market
{
    public class ApiProdutos
    {
        public string path = "/products";
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

        public List<dynamic> GetListaCanaisVendas()
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl("/sales-channels", ""));
            return JsonConvert.DeserializeObject<List<dynamic>>(Json);
        }
        public List<Produto> GetProdutos()
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, ""));
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Produto>>(Json);

            }
        }

        public Produto GetProdutoSku(string sku)
        {
            string Json = ApiAccess.Get(ConfigHub.GetFullUrl(path, sku));
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Produto>(Json);

            }
        }

        public Produto UpdateProdutoSku(string sku, Produto produto)
        {
            string body = JsonConvert.SerializeObject(produto);
            string Json = ApiAccess.Put(ConfigHub.GetFullUrl(path, sku), ConfigHub.ACCESS_TOKEN, body);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Produto>(Json);

            }
        }

        public Produto CriarProdutoSku(Produto produto)
        {
            string body = JsonConvert.SerializeObject(produto);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, "0"), ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Produto>(Json);

            }

        }
        public Retorno SendImagemProduto(string sku, Imagem imagem)
        {
            string body = JsonConvert.SerializeObject(imagem);
            string Json = ApiAccess.Post(ConfigHub.GetFullUrl(path, sku), ConfigHub.ACCESS_TOKEN, body, ApiAccess.ContentType.APPLICATION_JSON);
            
            fillRetorno(Json);
            return retorno;
            
        }
    }
}

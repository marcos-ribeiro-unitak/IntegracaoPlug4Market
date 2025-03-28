using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnitakHubMarketplace.Db;
using UnitakHubMarketplace.Models.Plug4Market;
using static System.Net.WebRequestMethods;

namespace UnitakHubMarketplace.Apis.Plug4Market
{
    public class ApiAuth
    {
        public string path = "https://api.sandbox.plug4market.com.br/auth";
        public Retorno retorno = new Retorno();
        Auth auth = new Auth();
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

        public dynamic RefreshBearer()
        {
            auth.accessToken = ConfigHub.ACCESS_TOKEN;
            auth.refreshToken = ConfigHub.REFRESH_TOKEN;
            auth.usuario = ConfigHub.LOGIN;
            auth.senha = ConfigHub.SENHA;

            string body = "{\"refreshToken\":\"" + ConfigHub.REFRESH_TOKEN + "\"}";//string body = JsonConvert.SerializeObject(auth.refreshToken, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            
            string Json = ApiAccess.PostNoAuth(path+"/refresh", body);

            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                dynamic RetAuth = JsonConvert.DeserializeObject<dynamic>(Json);
                ConfigHub.ACCESS_TOKEN = auth.accessToken;
                ConfigHub.REFRESH_TOKEN = auth.refreshToken;
                ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN = DateTime.Now;
                ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN = DateTime.Now;
                DbConfig dbConfig = new DbConfig();
                dbConfig.Gravar();
                return JsonConvert.DeserializeObject<dynamic>(Json);

            }
        }
        public dynamic AuthLogin()
        {
            
            auth.accessToken = ConfigHub.ACCESS_TOKEN;
            auth.refreshToken = ConfigHub.REFRESH_TOKEN;
            auth.usuario = ConfigHub.LOGIN;
            auth.senha = ConfigHub.SENHA;
            string body = JsonConvert.SerializeObject(auth.refreshToken, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string Json = ApiAccess.PostNoAuth(path, body);

            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                dynamic RetAuth = JsonConvert.DeserializeObject<dynamic>(Json);
                ConfigHub.ACCESS_TOKEN = auth.accessToken;
                DbConfig dbConfig = new DbConfig();
                dbConfig.Gravar();
                return RetAuth;

            }
        }
        public dynamic CreateStore(string login,string senha)
        {
            string conta = "{\"login\": \""+ login + "\",\"password\": \""+senha+"\"}";
            string body = JsonConvert.SerializeObject(conta, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string Json = ApiAccess.PostNoAuth(path+"/login", body);

            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<dynamic>(Json);

            }
        }

        public dynamic GetStoreToken(string store, string softwareHouse)
        {
            path = "https://api.sandbox.plug4market.com.br/stores/"+store+"/software-houses/"+softwareHouse+"/token?notEncoded=true";
            string Json = ApiAccess.Get(path, ConfigHub.ACCESS_TOKEN);

            if (Json.Contains("error_status") || Json == "")
            {
                fillRetorno(Json);
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<dynamic>(Json);

            }
        }
    }
}

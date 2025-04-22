using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using UnitakHubMarketplace.Db;

namespace UnitakHubMarketplace.Apis.Plug4Market
{
    public class ApiAuth
    {
        public string path = "https://api.sandbox.plug4market.com.br/auth";
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


        public void Autenticar()
        {
            TimeSpan diferencaRefresh = DateTime.Now - ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN;

            //EM CASO DE PRIMEIRO LOGIN OU SE REFRESH TOKEN ESTIVER VENCIDO
            if (ConfigHub.ACCESS_TOKEN == "" || ConfigHub.REFRESH_TOKEN == "" || diferencaRefresh.TotalDays >= 300)
            {
                dynamic login = Login(ConfigHub.LOGIN, ConfigHub.SENHA);
                if (login != null && login.accessToken != null)
                {
                    string cnpjLoja = ConfigHub.CNPJ_LOJA.Replace(".", "").Replace("/", "").Replace("-", "");
                    string cnpjDev = "03753919000144";

                    dynamic auth = GerarTokenLoja(cnpjLoja, cnpjDev, login.accessToken.ToString());
                    if (auth != null && auth.accessToken != null)
                    {
                        ConfigHub.ACCESS_TOKEN = auth.accessToken;
                        ConfigHub.REFRESH_TOKEN = auth.refreshToken;
                        ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN = DateTime.Now;
                        ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN = DateTime.Now;

                        new DbConfig().Gravar();
                    }
                }
                else
                {                    
                    MessageBox.Show("Erro de autenticação de credenciais de login!\nVerifique se os campos 'Usuário' e 'Senha' estão preenchidos corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                TimeSpan diferencaAccess = DateTime.Now - ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN;
                //CASO O BEARER ESTIVER PERTO DE VENCER
                if (diferencaAccess.TotalHours >= 23)
                {
                    dynamic bearer = RefreshBearer();
                    if (bearer != null && bearer.accessToken != null)
                    {
                        ConfigHub.ACCESS_TOKEN = bearer.accessToken;
                        ConfigHub.REFRESH_TOKEN = bearer.refreshToken;
                        ConfigHub.ULTIMA_ATUALIZACAO_ACCESS_TOKEN = DateTime.Now;
                        ConfigHub.ULTIMA_ATUALIZACAO_REFRESH_TOKEN = DateTime.Now;

                        new DbConfig().Gravar();
                    }
                    else
                    {
                        //CASO DE ERRO DE RENOVAÇÃO DO BEARER
                        //FORÇA TODO O PROCESSO DE AUTENTICAÇÃO NOVAMENTE
                        ConfigHub.ACCESS_TOKEN = "";
                        ConfigHub.REFRESH_TOKEN = "";
                        new DbConfig().Gravar();

                        Autenticar();
                    }
                }
                
            }
        }

        private dynamic RefreshBearer()
        {
            string body = "{\"refreshToken\":\"" + ConfigHub.REFRESH_TOKEN + "\"}";//string body = JsonConvert.SerializeObject(auth.refreshToken, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string Json = ApiAccess.PostNoAuth(path + "/refresh", body);

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

        /// <summary>
        /// FAZ O LOGIN PARA GERAR O TOKEN DE LOGIN
        /// SOMENTE USADO PARA GERAR O TOKEN E REFRESH TOKEN PARA A LOJA
        /// </summary>
        /// <param name="login">LOGIN_DEV: unitak@unitak.com.br </param>
        /// <param name="senha">SENHA_DEV: *******</param>
        /// <returns></returns>
        private dynamic Login(string login, string senha)
        {
            string body = "{\"login\": \"" + login + "\",\"password\": \"" + senha + "\"}";
            string Json = ApiAccess.PostNoAuth(path + "/login", body);

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

        /// <summary>
        /// GERA O TOKEN E O REFRESH TOKEN DA SOFTWARE HOUSE PARA ACESSAR A API DA LOJA
        /// ASSIM NÃO HÁ A NECESSIDADE DE GERAR MANUALMENTE PELO SITE
        /// </summary>
        /// <param name="store">CNPJ DA LOJA (SOMENTE NÚMEROS)</param>
        /// <param name="softwareHouse">CNPJ DA SOFTWARE HOUSE (SOMENTE NÚMEROS)</param>
        /// <returns></returns>
        private dynamic GerarTokenLoja(string store, string softwareHouse, string loginToken)
        {
            //path = "https://api.sandbox.plug4market.com.br/stores/" + store + "/software-houses/" + softwareHouse + "/token?notEncoded=true";

            string url = path.Replace("/auth", "/stores") + "/" + store + "/software-houses/" + softwareHouse + "/token?notEncoded=true";//?notEncoded=true";
            string Json = ApiAccess.Get(url, loginToken);

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

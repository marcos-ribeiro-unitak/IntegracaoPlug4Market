using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace UnitakHubMarketplace.Apis
{
    public static class ApiAccess
    {

        public static string Get(string url)
        {
            return Get(url, null, null, null);
        }

        public static string Get(string url, string auth)
        {
            return Get(url, auth, null, null);
        }

        public static string Get(string url, string auth, string[] key, string[] value)
        {
            return Get(url, auth, null, key, value, null);
        }

        public static string Get(string url, string auth, string userAgent, string[] key, string[] value, X509Certificate2 certificado)
        {
            var request = FillRequest(Method.Get, auth, userAgent, key, value, null, ContentType.NONE, url);
            RestResponse response = GetClient(url, certificado).Execute(request);

            return response.Content;
        }

        public static string Post(string url, string auth)
        {
            return Post(url, auth, "", ContentType.TEXT_PLAIN);
        }

        public static string PostNoAuth(string url, string body)
        {
            return Post(url, "", body, ContentType.APPLICATION_JSON);
        }

        public enum ContentType { TEXT_PLAIN, APPLICATION_JSON, NONE }
        public static string Post(string url, string auth, string body, ContentType type)
        {
            var request = FillRequest(Method.Post, auth, body, type, url);
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }
        public static string Post(string url, string auth, string body, string userAgent, ContentType type)
        {
            var request = FillRequest(Method.Post, auth, userAgent, null, null, body, type, url);
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }

        public static string Patch(string url, string auth, string body)
        {
            return Patch(url, auth, body, null);
        }

        public static string Patch(string url, string auth, string body, X509Certificate2 certificado)
        {
            var request = FillRequest(Method.Patch, auth, body, ContentType.APPLICATION_JSON, url);
            RestResponse response = GetClient(url, certificado).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }

        public static string Patch(string url, string auth, string body, string userAgent, ContentType type)
        {
            var request = FillRequest(Method.Patch, auth, userAgent, null, null, body, type, url);
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }
        public static string Post(string url, string auth, string[] key, string[] value)
        {
            return Post(url, auth, key, value, null);
        }

        public static string Post(string url, string auth, string[] key, string[] value, X509Certificate2 certificado)
        {
            var request = FillRequest(Method.Post, auth, key, value, url);
            RestResponse response = GetClient(url, certificado).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }

        public static string Put(string url, string auth, string body)
        {
            return Put(url, auth, body, null);
        }

        public static string PutNoAuth(string url, string body)
        {
            return Put(url, "", body, null);
        }

        public static string Put(string url, string auth, string body, X509Certificate2 certificado)
        {


            RestClient client = new RestClient(url);
            var request = FillRequest(Method.Post, auth, null, null, body, ContentType.APPLICATION_JSON, url);
            client.AddDefaultHeader("X-HTTP-Method-Override", "PUT");
            RestResponse response = client.Execute(request);

            return response.Content;


        }

        public static string Put(string url, string auth, string userAgent, string body, X509Certificate2 certificado)
        {


            RestClient client = new RestClient(url);
            var request = FillRequest(Method.Post, auth, userAgent, null, null, body, ContentType.APPLICATION_JSON, url);
            client.AddDefaultHeader("X-HTTP-Method-Override", "PUT");
            RestResponse response = client.Execute(request);

            return response.Content;


        }

        public static string Execute(string url, RestRequest request)
        {
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }


        public static string Delete(string url, string auth)
        {
            var request = FillRequest(Method.Delete, auth, null, null, url);
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }

        public static string Delete(string url)
        {

            //RestClient client = new RestClient(url);
            //var request = FillRequest(Method.Post, auth, null, null, body, ContentType.APPLICATION_JSON, url);
            //client.AddDefaultHeader("X-HTTP-Method-Override", "DELETE");
            //RestResponse response = client.Execute(request);

            //return response.Content;


            var request = FillRequest(Method.Delete, "", null, null, url);
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }


        public static string Delete(string url, string auth, string[] key, string[] value, X509Certificate2 certificado)
        {
            var request = FillRequest(Method.Delete, auth, key, value, url);
            RestResponse response = GetClient(url, certificado).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }

        public static string Delete(string url, string auth, string userAgent)
        {
            var request = FillRequest(Method.Delete, auth, userAgent, null, null, null, ContentType.NONE, url);
            RestResponse response = GetClient(url).Execute(request);

            if (string.IsNullOrEmpty(response.Content))
                return "";// response.StatusCode.ToString();

            return response.Content;
        }


        /***********************************************************************/
        /********************PREENCHE REQUISIÇÃO********************************/
        /***********************************************************************/
        private static RestClient GetClient(string url)
        {
            return new RestClient(new RestClientOptions { MaxTimeout = -1 });
        }

        private static RestClient GetClient(string url, X509Certificate certificado)
        {
            RestClient client = new RestClient(new RestClientOptions { MaxTimeout = -1 });
            //if (certificado != null)
            //{
            //    client.ClientCertificates = new X509CertificateCollection();
            //    client.ClientCertificates.Add(certificado);
            //}

            return client;
        }

        private static RestRequest FillRequest(Method method, string auth,
            string body, ContentType contentType, string url)
        {
            return FillRequest(method, auth, null, null, body, contentType, url);
        }

        private static RestRequest FillRequest(Method method, string auth,
            string[] key, string[] value, string url)
        {
            return FillRequest(method, auth, key, value, null, ContentType.NONE, url);
        }

        public static RestRequest FillRequest(Method method, string auth,
            string[] key, string[] value, string body, ContentType contentType, string url)
        {
            RestRequest request = new RestRequest(url, method);


            if (!string.IsNullOrWhiteSpace(auth))
                request.AddHeader("Authorization", "Bearer " + auth);
            if (key != null && value != null)
                for (int i = 0; i < key.Length; i++)
                    request.AddParameter(key[i], value[i]);
            if (!string.IsNullOrEmpty(body))
            {
                switch (contentType)
                {
                    case ContentType.APPLICATION_JSON:
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        break;
                    case ContentType.TEXT_PLAIN:
                        request.AddParameter("text/plain", body, ParameterType.RequestBody);
                        break;
                }
            }

            return request;
        }

        public static RestRequest FillRequest(Method method, string auth, string userAgent,
            string[] key, string[] value, string body, ContentType contentType, string url)
        {
            RestRequest request = new RestRequest(url, method);


            if (!string.IsNullOrWhiteSpace(auth))
                request.AddHeader("Authorization", "Bearer "+auth);
            if (!string.IsNullOrWhiteSpace(userAgent))
                request.AddHeader("User-Agent", userAgent);
            if (key != null && value != null)
                for (int i = 0; i < key.Length; i++)
                    request.AddParameter(key[i], value[i]);
            if (!string.IsNullOrEmpty(body))
            {
                switch (contentType)
                {
                    case ContentType.APPLICATION_JSON:
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        break;
                    case ContentType.TEXT_PLAIN:
                        request.AddParameter("text/plain", body, ParameterType.RequestBody);
                        break;
                }
            }

            return request;
        }
    }
}

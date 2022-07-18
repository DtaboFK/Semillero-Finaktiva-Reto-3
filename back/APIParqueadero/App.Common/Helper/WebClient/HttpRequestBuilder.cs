using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Common.Helper.WebClient
{
    public class HttpRequestBuilder
    {
        private HttpMethod method = null;
        private string requestUri = "";
        private HttpContent content = null;
        private string bearerToken = "";
        private string basic = "";
        private string acceptHeader = "";/// MediaTypesNames.ApplicationJson;
        private TimeSpan timeout = new TimeSpan(0, 1, 0);
        private bool allowAutoRedirect = false;
        private Dictionary<string, string> headers;
        private HttpClientHandler handler;

        /// <summary>
        /// Se realiza la instancia de HttpClientHandler
        /// </summary>
        public HttpRequestBuilder()
        {
            headers = new Dictionary<string, string>();
            handler = new HttpClientHandler();
        }

        /// <summary>
        /// Este metodo asigan el metodo de peticion
        /// </summary>
        /// <param name="method">HttpMethod</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddMethod(HttpMethod method)
        {
            this.method = method;
            return this;
        }

        /// <summary>
        /// Este metodo se encarga de de setear la url de la peticion
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddRequestUri(string requestUri)
        {
            this.requestUri = requestUri;
            return this;
        }

        /// <summary>
        /// Este metodo se encarga de asignar el HttpContent
        /// </summary>
        /// <param name="content">HttpContent</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddContent(HttpContent content)
        {
            this.content = content;
            return this;
        }

        /// <summary>
        /// Este metodo se encarga de asignar el token
        /// </summary>
        /// <param name="bearerToken">bearerToken</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddBearerToken(string bearerToken)
        {
            this.bearerToken = bearerToken;
            return this;
        }

        /// <summary>
        /// Este metodo se encarga organizar el basic
        /// </summary>
        /// <param name="username">usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddBasic(string username, string password)
        {
            this.basic = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            return this;
        }

        /// <summary>
        /// Este metodo se encarga de acceptHeader
        /// </summary>
        /// <param name="acceptHeader">acceptHeader</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            this.acceptHeader = acceptHeader;
            return this;
        }

        /// <summary>
        /// Este metodo se encarga de asignar el timeout
        /// </summary>
        /// <param name="timeout">timeout</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            this.timeout = timeout;
            return this;
        }

        /// <summary>
        /// este metodo se encarga de asignar el AddAllowAuto
        /// </summary>
        /// <param name="allowAutoRedirect">allowAutoRedirect</param>
        /// <returns>HttpRequestBuilder</returns>
        public HttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect)
        {
            this.allowAutoRedirect = allowAutoRedirect;
            return this;
        }

        /// <summary>
        /// Permite agregar una cabecera a la petición
        /// </summary>
        /// <param name="name">Clave o nombre de la cabecera</param>
        /// <param name="valueHeader">Valor de la cabecera</param>
        /// <returns>Objeto para petición Http</returns>
        public HttpRequestBuilder AddHeader(string name, string valueHeader)
        {
            this.headers.Add(name, valueHeader);
            return this;
        }

        /// <summary>
        /// Permite agregar una lista de cabeceras a la petición
        /// </summary>
        /// <param name="headerList">Lista de cabeceras con clave y valor</param>
        /// <returns>Objeto para petición Http</returns>
        public HttpRequestBuilder AddHeaders(Dictionary<string, string> headerList)
        {
            this.headers = headerList;
            return this;
        }

        /// <summary>
        /// Permite obtener la ruta absoluta
        /// </summary>
        /// <param name="file">ruta relativa del archivo</param>
        /// <returns>Ruta absoluta del archivo</returns>
        private string GetPathFile(string urlFile)
        {
            var path = Directory.GetCurrentDirectory() + urlFile;

            if (File.Exists(path))
            {
                return path;
            }
            return "";
        }

        /// <summary>
        /// Este metodo se encarga enviar la peticion
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> SendAsync()
        {
            // Check required arguments
            EnsureArguments();

            // Set up request
            var request = new HttpRequestMessage
            {
                Method = this.method,
                RequestUri = new Uri(this.requestUri)
            };

            if (headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (this.content != null)
                request.Content = this.content;

            if (!string.IsNullOrEmpty(this.bearerToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");
            }

            if (!string.IsNullOrEmpty(this.basic))
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", this.basic);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this.acceptHeader))
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.acceptHeader));



            // Setup client
            handler.AllowAutoRedirect = this.allowAutoRedirect;

            var client = new System.Net.Http.HttpClient(handler);

            return await client.SendAsync(request);
        }


        /// <summary>
        /// Este metodo se encarga de enviar  Sms
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> SendAsyncSms()
        {
            // Check required arguments
            EnsureArguments();

            // Set up request
            var request = new HttpRequestMessage
            {
                Method = this.method,
                RequestUri = new Uri(this.requestUri)
            };

            if (this.content != null)
                request.Content = this.content;

            if (!string.IsNullOrEmpty(this.bearerToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");
                content.Headers.Add("Ocp-Apim-Subscription-Key", "342caad8c72c4eab8303571fefc1dd8f");
            }

            if (!string.IsNullOrEmpty(this.basic))
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", this.basic);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this.acceptHeader))
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.acceptHeader));



            // Setup client
            handler.AllowAutoRedirect = this.allowAutoRedirect;

            var client = new System.Net.Http.HttpClient(handler);
            client.Timeout = this.timeout;
            var result = await client.SendAsync(request);
            handler.Dispose();
            client.Dispose();
            return result;
        }

        #region " Private "

        /// <summary>
        /// Este metodo se encarga de generar un exepcion si no existe un method y una  Url
        /// </summary>
        private void EnsureArguments()
        {
            if (this.method == null)
                throw new ArgumentNullException("Method");

            if (string.IsNullOrEmpty(this.requestUri))
                throw new ArgumentNullException("Request Uri");
        }

        #endregion
    }
}

using Infraestructure.Common.Helper.WebClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestructure.Common.Helper
{
    public static class HttpRequestFactory
    {
        /// <summary>
        /// Este metodo ejecuta en el vio get
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Get(string requestUri)
            => await Get(requestUri, "");

        public static async Task<HttpResponseMessage> Get(string requestUri, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Permite realizar una petición por GET con cabeceras personalizadas
        /// </summary>
        /// <param name="requestUri">URL de la solicitud con parámetros</param>
        /// <param name="headers">Lista de cabeceras para la petición</param>
        /// <returns>Respuesta de la solicitud</returns>
        public static async Task<HttpResponseMessage> Get(string requestUri, Dictionary<string, string> headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddHeaders(headers);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Este metodo ejecuta el metodo que envia el post
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="value">value</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Post(string requestUri, object value)
            => await Post(requestUri, value, "");

        public static async Task<HttpResponseMessage> Post(
            string requestUri, Dictionary<string, string> value)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new FormUrlEncodedContent(value));

            return await builder.SendAsync();
        }

        /// <summary>
        /// Este metodo ejecuta el metodo que envia el post con token
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="value">value</param>
        /// <param name="bearerToken">bearerToken</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Este metodo ejecuta el metodo que envia el post con token
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="value">value</param>
        /// <param name="bearerToken">bearerToken</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Post(
            string requestUri, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Este metodo ejecuta el metodo que envia el post con una autenticacion basic
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="value">value</param>
        /// <param name="basicUsername">basicUsername</param>
        /// <param name="basicPassword">basicPassword</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Post(
        string requestUri, object value, string basicUsername, string basicPassword)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBasic(basicUsername, basicPassword);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Permite realizar una petición por POST con certificado y con autenticación básica
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="value">Objeto para enviar por post</param>
        /// <param name="basicUsername">Nombre de usuario para Basic Auth</param>
        /// <param name="basicPassword">Contraseña para Basic Auth</param>
        /// <param name="certificate">Ruta relativa de certificado</param>
        /// <param name="certificatePassword">Contraseña para el certificado</param>
        /// <returns>Respuesta de la solicitud</returns>
        public static async Task<HttpResponseMessage> Post(string requestUri, object value, string basicUsername, string basicPassword, string certificate, string certificatePassword)
        {

            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBasic(basicUsername, basicPassword);
            return await builder.SendAsync();
        }

        /// <summary>
        /// Permite realizar una petición por POST con cabeceras personalizadas
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="value">Objeto para enviar por post</param>
        /// <param name="headers">Lista de cabeceras para la petición</param>
        /// <returns>Respuesta de la solicitud</returns>
        public static async Task<HttpResponseMessage> Post(string requestUri, object value, Dictionary<string, string> headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddHeaders(headers);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Metodo que ejecuta el metodo put
        /// </summary>
        /// <param name="requestUri">requestUri</param>
        /// <param name="value"> el request de la peticion</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Put(string requestUri, object value)
            => await Put(requestUri, value, "");

        public static async Task<HttpResponseMessage> Put(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Permite realizar una petición por PUT con cabeceras personalizadas
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="value">Objeto para enviar por post</param>
        /// <param name="headers">Lista de cabeceras para la petición</param>
        /// <returns>Respuesta de la solicitud</returns>
        public static async Task<HttpResponseMessage> Put(string requestUri, object value, Dictionary<string, string> headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddHeaders(headers);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Metodo que ejecuta el metodo puth
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="value">el request de la peticion</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Patch(string requestUri, object value)
            => await Patch(requestUri, value, "");

        public static async Task<HttpResponseMessage> Patch(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(new HttpMethod("PATCH"))
                                .AddRequestUri(requestUri)
                                .AddContent(new PatchContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Permite realizar una petición por PATCH con cabeceras personalizadas
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="value">Objeto para enviar por post</param>
        /// <param name="headers">Lista de cabeceras para la petición</param>
        /// <returns>Respuesta de la solicitud</returns>
        public static async Task<HttpResponseMessage> Patch(string requestUri, object value, Dictionary<string, string> headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(new HttpMethod("PATCH"))
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddHeaders(headers);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Metodo que ejecuta el metodo delete
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Delete(string requestUri)
            => await Delete(requestUri, "");

        public static async Task<HttpResponseMessage> Delete(
            string requestUri, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Metodo que ejecuta el metodo de postFile
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="filePath">Ubicacion de archivo</param>
        /// <param name="apiParamName">apiParamName</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> PostFile(string requestUri,
            string filePath, string apiParamName)
            => await PostFile(requestUri, filePath, apiParamName, "");

        public static async Task<HttpResponseMessage> PostFile(string requestUri,
            string filePath, string apiParamName, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new FileContent(filePath, apiParamName))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        /// <summary>
        /// Metodo que envia sms
        /// </summary>
        /// <param name="requestUri">URL de la solicitud</param>
        /// <param name="value">Request de la peticion</param>
        /// <param name="bearerToken">Token se seguridad tipo bearer</param>
        /// <returns>HttpResponseMessagess</returns>
        public static async Task<HttpResponseMessage> PostSms(
         string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsyncSms();
        }
    }
}

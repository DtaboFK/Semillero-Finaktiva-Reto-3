using Newtonsoft.Json;
using System.Net.Http;

namespace Infraestructure.Common.Helper.WebClient
{
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Metodo que desealiza la respuesta de los servivios
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>Retorna un objeto generico </returns>
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                            default(T) :
                            JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Metodo que serializa la respuesta del servicio
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>la respuesta serealizada del HttpResponseMessage</returns>
        public static string ContentAsJson(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Metodo que obtiene solo el string de la respuesta del servicio
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>Retorna la captura de la respuesta del servicio</returns>
        public static string ContentAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}

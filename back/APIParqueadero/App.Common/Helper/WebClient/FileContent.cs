using System.IO;
using System.Net.Http;

namespace Infraestructure.Common.Helper.WebClient
{
    public class FileContent : MultipartFormDataContent
    {
        /// <summary>
        /// Este metodo se encarga de crear un tipo de contenido que se puede utilizar para establecer la propiedad en un archivo
        /// </summary>
        /// <param name="filePath">El path del archivo</param>
        /// <param name="apiParamName">Paremetro del api</param>
        public FileContent(string filePath, string apiParamName)
        {
            var filestream = File.Open(filePath, FileMode.Open);
            var filename = Path.GetFileName(filePath);

            Add(new StreamContent(filestream), apiParamName, filename);
        }
    }
}

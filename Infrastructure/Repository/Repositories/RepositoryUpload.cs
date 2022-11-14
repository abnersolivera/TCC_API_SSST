using Azure.Storage.Blobs;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RepositoryUpload : IUpload
    {
        public string UploadBase64(string base64, string container)
        {
            //Gerar um nome randomico
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            //Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64, "");

            //Gerando um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a image será armazenada
            var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=ssststorage;AccountKey=5hYFUTX6JTpMBJ1zutrJotsZ4Bz+CDlhl0FDnVFumQ/qjcU4QsY0bUGvN3G9GPiReVJW5ktadwTt+AStA+gM6w==;EndpointSuffix=core.windows.net", container, fileName);

            // Enviando a image
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            //Retornando a URL
            return blobClient.Uri.AbsoluteUri;
        }
    }
}

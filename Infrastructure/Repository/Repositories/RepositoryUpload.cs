using System.Text.RegularExpressions;
using Azure.Storage.Blobs;
using Domain.Interfaces;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUpload(IStorageService storageService) : IUpload
    {
        public async Task<Uri> UploadBase64(string base64)
        {
            //Gerar um nome randomico
            var fileName = $"{Guid.NewGuid()}.jpg";

            //Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64, "");

            //Gerando um array de Bytes
            var imageBytes = Convert.FromBase64String(data);
            
            // Enviando a image
            var sasUri = await storageService.UploadAsync(new MemoryStream(imageBytes), fileName, "image/jpeg");

            //Retornando a URL
            return sasUri;
        }
    }
}
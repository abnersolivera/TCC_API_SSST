namespace Domain.Interfaces
{
    public interface IUpload
    {
        Task<Uri> UploadBase64(string base64);
    }
}

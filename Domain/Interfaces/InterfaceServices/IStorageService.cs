namespace Domain.Interfaces;

public interface IStorageService
{
    Task<Uri> UploadAsync(Stream fileStream, string fileName, string contentType, CancellationToken cancellationToken = default);
}
using AutoMapper;

namespace Domain.Services.Utils;

public class ConvertDateTime : ITypeConverter<DateTime, string>
{
    public string Convert(DateTime source, string destination, ResolutionContext context) => source.ToString("yyyy-MM-ddTHH:mm:ssZ");
}
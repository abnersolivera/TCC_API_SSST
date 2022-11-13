using Entities.Entities.Prestadores;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServicePrestador
    {
        Task Adicionar(Prestador Objeto);

        Task Atualizar(Prestador Objeto);

        Task<List<Prestador>> ListarPrestadorAtivas();
    }
}

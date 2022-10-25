using Entities.Entities.Empresas;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceEmpresa
    {
        Task Adicionar(Empresa Objeto);

        Task Atualizar(Empresa Objeto);

        Task<List<Empresa>> ListarEmpresaAtivas();
    }
}

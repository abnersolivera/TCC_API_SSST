using Entities.Entities;
using Entities.Entities.Empresas;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceEmpresa
    {
        Task <Notifies2<Empresa>> Adicionar(Empresa empresa);

        Task <Notifies2<Empresa>> Atualizar(Empresa empresa);

        Task<List<Empresa>> ListarEmpresaAtivas();
    }
}

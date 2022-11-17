using Domain.Interfaces.Generics;
using Entities.Entities.Empresas;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IEmpresa : IGeneric<Empresa>
    {
        Task<List<Empresa>> ListarEmpresa(Expression<Func<Empresa, bool>> exEmpresa);

        Task<List<Empresa>> ListarNomeEmpresa(string? nome, int? id, string? cnpj, string? cpf);
    }
}

using Domain.Interfaces.Generics;
using Entities.Entities.Empresas;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUnidade : IGeneric<Unidade>
    {
        Task<List<Unidade>> ListarUnidade(Expression<Func<Unidade, bool>> exUnidade);
    }
}

using Domain.Interfaces.Generics;
using Entities.Entities.Pessoas;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IPessoa : IGeneric<Pessoa>
    {
        Task<List<Pessoa>> ListarPessoa(Expression<Func<Pessoa, bool>> exPessoa);
    }
}

using Domain.Interfaces.Generics;
using Entities.Entities.Endereco;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IEndereco : IGeneric<Endereco>
    {
        Task<List<Endereco>> ListarEndereco(Expression<Func<Endereco, bool>> exEndereco);
    }
}

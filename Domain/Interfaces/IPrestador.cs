using Domain.Interfaces.Generics;
using Entities.Entities.Prestadores;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IPrestador : IGeneric<Prestador>
    {
        Task<List<Prestador>> ListarPrestador(Expression<Func<Prestador, bool>> exPrestador);
    }
}

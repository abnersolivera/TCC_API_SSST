using Domain.Interfaces.Generics;
using Entities.Entities.Cargos;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ICargo : IGeneric<Cargo>
    {
        Task<List<Cargo>> ListarCargo(Expression<Func<Cargo, bool>> exCargo);
    }
}

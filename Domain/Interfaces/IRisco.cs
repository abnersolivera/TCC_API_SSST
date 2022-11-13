using Domain.Interfaces.Generics;
using Entities.Entities.Riscos;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRisco : IGeneric<Risco>
    {
        Task<List<Risco>> ListarRiscos(Expression<Func<Risco, bool>> exRisco);
    }
}

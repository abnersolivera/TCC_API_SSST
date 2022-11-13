using Domain.Interfaces.Generics;
using Entities.Entities.Setores;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ISetor : IGeneric<Setor>
    {
        Task<List<Setor>> ListarSetor(Expression<Func<Setor, bool>> exSetor);

        Task<List<Setor>> Listar(int id);
    }
}

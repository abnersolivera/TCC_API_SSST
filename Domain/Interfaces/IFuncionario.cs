using Domain.Interfaces.Generics;
using Entities.Entities.Funcionarios;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IFuncionario : IGeneric<Funcionario>
    {
        Task<List<Funcionario>> ListarFuncionario(Expression<Func<Funcionario, bool>> exFuncionario);
    }
}

using Domain.Interfaces.Generics;
using Entities.Entities.Funcionarios;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IFuncionario : IGeneric<Funcionario>
    {
        Task<List<Funcionario>> ListarFuncionario(Expression<Func<Funcionario, bool>> exFuncionario);

        Task<List<Funcionario>> Listar(int id);

        Task<List<FuncionarioEmpresaCargoSetor>> ListarEmpresaCargoSetor(int? id, int? idFuncionario);

        Task<List<FuncionarioEmpresaCargoSetor>> ListarFuncionarioCargoSetor(string nome);
    }
}

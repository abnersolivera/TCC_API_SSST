using Domain.Interfaces.Generics;
using Entities.Entities.Funcionarios;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IFuncionario : IGeneric<Funcionario>
    {
        Task<List<Funcionario>> ListarFuncionario(Expression<Func<Funcionario, bool>> exFuncionario);

        Task<List<Funcionario>> Listar(int id);

        Task<List<FuncionarioEmpresaCargoSetor>> ListarEmpresa();

        Task<List<FuncionarioEmpresaCargoSetor>> ListarEmpresaCargoSetor(int? id, int? idFuncionario, string? nome, string? empresa, string? unidade);

        Task<List<FuncionarioEmpresaCargoSetor>> ListarFuncionarioCargoSetor(string nome);

        Task<List<FuncionarioAtendimento>> FuncionarioAtendimento(int? idAtendimento, int? idFuncionario, int? idEmpresa);

        
    }
}

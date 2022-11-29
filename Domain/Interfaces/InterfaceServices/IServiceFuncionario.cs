using Entities.Entities.Funcionarios;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceFuncionario
    {
        Task Adicionar(Funcionario Objeto);

        Task Atualizar(Funcionario Objeto);

        Task<List<Funcionario>> ListarFuncionarioAtivas();

        Task<List<Funcionario>> ListarFuncionarioEmpresa(int id);

        Task<List<FuncionarioEmpresaCargoSetor>> ListarFuncionarioEmpresaCargoSetor(int? id, int? idFuncionario);

        Task<List<FuncionarioEmpresaCargoSetor>> ListarNomeFuncionarioEmpresaCargoSetor(string nome);

        Task<List<FuncionarioAtendimento>> ListarFuncionarioAtendimento(int? idAtendimento, int? idFuncionario, int? idEmpresa);
    }
}

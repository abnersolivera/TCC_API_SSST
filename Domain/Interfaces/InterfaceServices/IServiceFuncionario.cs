using Entities.Entities.Funcionarios;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceFuncionario
    {
        Task Adicionar(Funcionario Objeto);

        Task Atualizar(Funcionario Objeto);

        Task<List<Funcionario>> ListarFuncionarioAtivas();
    }
}

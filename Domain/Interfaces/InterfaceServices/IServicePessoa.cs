using Entities.Entities.Pessoas;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServicePessoa
    {
        Task Adicionar(Pessoa Objeto);

        Task Atualizar(Pessoa Objeto);

        Task<List<Pessoa>> ListarPessoaAtivas();
    }
}

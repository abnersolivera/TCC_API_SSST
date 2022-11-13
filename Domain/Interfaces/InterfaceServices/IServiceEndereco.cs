using Entities.Entities.Endereco;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceEndereco
    {
        Task Adicionar(Endereco Objeto);

        Task Atualizar(Endereco Objeto);

        Task<List<Endereco>> ListarEnderecoAtivas();
    }
}

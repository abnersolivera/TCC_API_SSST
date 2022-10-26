using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Endereco;

namespace Domain.Services
{
    public class ServiceEndereco : IServiceEndereco
    {
        private readonly IEndereco _IEndereco;

        public ServiceEndereco(IEndereco iEndereco)
        {
            _IEndereco = iEndereco;
        }

        public async Task Adicionar(Endereco Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.EnderecoEndereco, "EnderecoEndereco");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.StatusEndereco = true;
                await _IEndereco.Add(Objeto);
            }
        }

        public async Task Atualizar(Endereco Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.EnderecoEndereco, "EnderecoEndereco");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IEndereco.Update(Objeto);
            }
        }

        public async Task<List<Endereco>> ListarEnderecoAtivas()
        {
            return await _IEndereco.ListarEndereco(n => n.StatusEndereco);
        }
    }
}

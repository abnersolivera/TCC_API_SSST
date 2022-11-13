using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Pessoas;

namespace Domain.Services
{
    public class ServicePessoa : IServicePessoa
    {
        private readonly IPessoa _IPessoa;

        public ServicePessoa(IPessoa iPessoa)
        {
            _IPessoa = iPessoa;
        }

        public async Task Adicionar(Pessoa Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomePessoas, "NomePessoas");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.StatusPessoas = true;
                await _IPessoa.Add(Objeto);
            }
        }

        public async Task Atualizar(Pessoa Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomePessoas, "NomePessoas");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IPessoa.Update(Objeto);
            }
        }

        public async Task<List<Pessoa>> ListarPessoaAtivas()
        {
            return await _IPessoa.ListarPessoa(n => n.StatusPessoas);
        }
    }
}

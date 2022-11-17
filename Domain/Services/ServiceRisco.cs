using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Riscos;

namespace Domain.Services
{
    public class ServiceRisco : IServiceRisco
    {
        private readonly IRisco _IRisco;

        public ServiceRisco(IRisco iRisco)
        {
            _IRisco = iRisco;
        }

        public async Task Adicionar(Risco Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeRisco, "NomeRisco");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoRisco = true;
                await _IRisco.Add(Objeto);
            }
        }

        public async Task Atualizar(Risco Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeRisco, "NomeRisco");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IRisco.Update(Objeto);
            }
        }

        public async Task<List<Risco>> ListarRiscoAtivo() => await _IRisco.ListarRiscos(n => n.SituacaoRisco);

        public async Task<List<Risco>> ListarRiscosNome(string nome) => await _IRisco.RiscosNome(nome);
    }
}

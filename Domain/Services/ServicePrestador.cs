using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Prestadores;

namespace Domain.Services
{
    public class ServicePrestador : IServicePrestador
    {
        private readonly IPrestador _IPrestador;

        public ServicePrestador(IPrestador iPrestador)
        {
            _IPrestador = iPrestador;
        }
        public async Task Adicionar(Prestador Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomePrestador, "NomePrestador");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SitucaoPrestador = true;
                await _IPrestador.Add(Objeto);
            }
        }

        public async Task Atualizar(Prestador Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomePrestador, "NomePrestador");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IPrestador.Update(Objeto);
            }
        }

        public async Task<List<Prestador>> ListarPrestadorAtivas()
        {
            return await _IPrestador.ListarPrestador(n => n.SitucaoPrestador);
        }
    }
}

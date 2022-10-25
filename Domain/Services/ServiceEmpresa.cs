using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Empresas;

namespace Domain.Services
{
    public class ServiceEmpresa : IServiceEmpresa
    {
        private readonly IEmpresa _IEmpresa;

        public ServiceEmpresa(IEmpresa iEmpresa)
        {
            _IEmpresa = iEmpresa;
        }

        public async Task Adicionar(Empresa Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.RazaoSocialEmpresa, "RazaoSocialEmpresa");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoEmpresa = true;
                await _IEmpresa.Add(Objeto);
            }
        }

        public async Task Atualizar(Empresa Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.RazaoSocialEmpresa, "RazaoSocialEmpresa");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IEmpresa.Update(Objeto);
            }
        }

        public async Task<List<Empresa>> ListarEmpresaAtivas()
        {
            return await _IEmpresa.ListarEmpresa(n => n.SituacaoEmpresa);
        }
    }
}

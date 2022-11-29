using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
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

        public async Task<Notifies2<Empresa>> Adicionar(Empresa empresa)
        {
            var validateResult = new Notifies2<Empresa> { Value = empresa };


            var validaNome = (validateResult.ValidarPropriedadeString(empresa.RazaoSocialEmpresa, "RazaoSocialEmpresa"));

            if (validaNome)
            {
                empresa.DataCadastro = DateTime.Now;
                empresa.DataAlteracao = DateTime.Now;
                empresa.SituacaoEmpresa = true;
                await _IEmpresa.Add(empresa);
            }

            return validateResult;
        }

        public async Task<Notifies2<Empresa>> Atualizar(Empresa empresa)
        {
            var validateResult = new Notifies2<Empresa> { Value = empresa };

            var validaNome = validateResult.ValidarPropriedadeString(empresa.RazaoSocialEmpresa, "RazaoSocialEmpresa");
            if (validaNome)
            {
                empresa.DataAlteracao = DateTime.Now;
                await _IEmpresa.Update(empresa);
            }

            return validateResult;
        }

        public async Task<List<Empresa>> ListarEmpresaAtivas()
        {
            return await _IEmpresa.ListarEmpresa(n => n.SituacaoEmpresa);
        }

        public async Task<List<Empresa>> ListarNomeEmpresaId(string? nome, int? id, string? cnpj, string? cpf) => await _IEmpresa.ListarNomeEmpresa(nome, id, cnpj, cpf);
    }
}

using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceUnidade : IServiceUnidade
    {
        private readonly IUnidade _IUnidade;

        public ServiceUnidade(IUnidade iUnidade)
        {
            _IUnidade = iUnidade;
        }

        public async Task Adicionar(Unidade Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.RazaoSocialUnidade, "RazaoSocialUnidade");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoUnidade = true;
                await _IUnidade.Add(Objeto);
            }
        }

        public async Task Atualizar(Unidade Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.RazaoSocialUnidade, "RazaoSocialUnidade");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IUnidade.Update(Objeto);
            }
        }

        public async Task<List<Unidade>> ListarUnidadeAtivas() => await _IUnidade.ListarUnidade(n => n.SituacaoUnidade);

        public async Task<List<Unidade>> ListarUnidadeEmpresa(int id) => await _IUnidade.Listar(id);
    }
}

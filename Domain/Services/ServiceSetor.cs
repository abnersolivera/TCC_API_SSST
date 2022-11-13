using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Cargos;
using Entities.Entities.Setores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceSetor : IServiceSetor
    {
        private readonly ISetor _ISetor;

        public ServiceSetor(ISetor iSetor)
        {
            _ISetor = iSetor;
        }

        public async Task Adicionar(Setor Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeSetor, "NomeSetor");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoSetor = true;
                await _ISetor.Add(Objeto);
            }
        }

        public async Task Atualizar(Setor Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeSetor, "NomeSetor");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _ISetor.Update(Objeto);
            }
        }

        public async Task<List<Setor>> ListarSetorAtivo() => await _ISetor.ListarSetor(n => n.SituacaoSetor);

        public async Task<List<Setor>> ListarSetorEmpresa(int id) => await _ISetor.Listar(id);

    }
}


using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Atendimentos;
using Entities.Entities.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceAtendimento : IServiceAtendimento
    {

        private readonly IAtendimento _IAtendimento;

        public ServiceAtendimento(IAtendimento iAtendimento)
        {
            _IAtendimento = iAtendimento;
        }

        public async Task Adicionar(Atendimento Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.FuncionarioAtendimento, "FuncionarioAtendimento");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                await _IAtendimento.Add(Objeto);
            }
        }

        public async Task Atualizar(Atendimento Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.FuncionarioAtendimento, "FuncionarioAtendimento");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IAtendimento.Update(Objeto);
            }
        }
    }
}

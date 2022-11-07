using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Atendimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceAgendamento : IServiceAgendamento
    {
        private readonly IAgendamento _IAgendamento;

        public ServiceAgendamento(IAgendamento iAgendamento)
        {
            _IAgendamento = iAgendamento;
        }

        public async Task Adicionar(Agendamento Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.FuncionarioAgendamentoo, "FuncionarioAgendamentoo");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                await _IAgendamento.Add(Objeto);
            }
        }

        public async Task Atualizar(Agendamento Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.FuncionarioAgendamentoo, "FuncionarioAgendamentoo");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IAgendamento.Update(Objeto);
            }
        }
    }
}

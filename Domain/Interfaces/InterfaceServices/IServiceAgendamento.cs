using Entities.Entities.Atendimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceAgendamento
    {
        Task Adicionar(Agendamento Objeto);

        Task Atualizar(Agendamento Objeto);
    }
}

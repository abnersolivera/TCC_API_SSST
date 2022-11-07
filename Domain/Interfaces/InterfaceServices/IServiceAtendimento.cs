using Entities.Entities.Atendimentos;
using Entities.Entities.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceAtendimento
    {
        Task Adicionar(Atendimento Objeto);

        Task Atualizar(Atendimento Objeto);
        
    }
}

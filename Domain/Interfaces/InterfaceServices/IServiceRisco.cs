using Entities.Entities.Riscos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceRisco
    {
        Task Adicionar(Risco Objeto);

        Task Atualizar(Risco Objeto);

        Task<List<Risco>> ListarRiscoAtivo();

        Task<List<Risco>> ListarRiscosNome(string nome);
    }
}

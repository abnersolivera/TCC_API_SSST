using Entities.Entities.Exames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceExame
    {
        Task Adicionar(Exame Objeto);

        Task Atualizar(Exame Objeto);

        Task<List<Exame>> ListarExamesAtivo();

        Task<List<ExameDetails>> ListarExamesDetalhe();
    }
}

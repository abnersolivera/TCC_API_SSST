using Entities.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceUnidade
    {
        Task Adicionar(Unidade Objeto);

        Task Atualizar(Unidade Objeto);

        Task<List<Unidade>> ListarUnidadeAtivas();
    }
}

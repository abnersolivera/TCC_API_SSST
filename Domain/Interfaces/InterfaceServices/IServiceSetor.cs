using Entities.Entities.Empresas;
using Entities.Entities.Setores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceSetor
    {
        Task Adicionar(Setor Objeto);

        Task Atualizar(Setor Objeto);

        Task<List<Setor>> ListarSetorAtivo();
    }
}

using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceCargo
    {
        Task Adicionar(Cargo Objeto);

        Task Atualizar(Cargo Objeto);

        Task<List<Cargo>> ListarCargoAtivo();

        Task<List<Cargo>> ListarCargoEmpresa(int id);
    }

}

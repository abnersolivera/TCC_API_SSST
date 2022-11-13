using Entities.Entities;
using Entities.Entities.Setores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceUser
    {
        Task<List<ApplicationUser>> ListarUserAtivo();
    }
}

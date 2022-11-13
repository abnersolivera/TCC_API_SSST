using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IUser _IUser;

        public ServiceUser(IUser iUser)
        {
            _IUser = iUser;
        }

        public async Task<List<ApplicationUser>> ListarUserAtivo()
        {
            return await _IUser.ListarUser(n => n.StatusUsuario);
        }
    }
}

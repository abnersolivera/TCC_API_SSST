using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Funcionarios;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUser : IGeneric<ApplicationUser>
    {
        Task<ApplicationUser> ListarUserById(string Id);

        Task<List<ApplicationUser>> ListarUser(Expression<Func<ApplicationUser, bool>> exUser);
    }
}

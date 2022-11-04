using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Funcionarios;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUser : RepositoryGenerics<ApplicationUser>, IUser
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryUser()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }



        public async Task<List<ApplicationUser>> ListarUser(Expression<Func<ApplicationUser, bool>> exUser)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.ApplicationUser.Where(exUser).AsNoTracking().ToListAsync();
            }
        }

        public async Task<ApplicationUser> ListarUserById(string Id)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Set<ApplicationUser>().FindAsync(Id);

            }
        }
    }
}

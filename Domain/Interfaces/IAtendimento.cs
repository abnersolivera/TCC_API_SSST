using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Atendimentos;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IAtendimento : IGeneric<Atendimento>
    {
        Task<ApplicationUser> ListarUserById(string Id);
    }
}

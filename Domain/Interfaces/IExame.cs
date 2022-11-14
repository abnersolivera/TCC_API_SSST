using Domain.Interfaces.Generics;
using Entities.Entities.Exames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExame : IGeneric<Exame>
    {
        Task<List<Exame>> ListarExame(Expression<Func<Exame, bool>> exExame);

        Task<ExameDetails> Listar(int curretPage);
    }
}

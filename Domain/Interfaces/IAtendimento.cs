using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Atendimentos;
using Entities.Entities.Empresas;
using Entities.Entities.Exames;
using Entities.Entities.Funcionarios;
using Entities.Entities.Riscos;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IAtendimento : IGeneric<Atendimento>
    {
        Task<Atendimento> ListarUserById(string Id);

        Task<Atendimento> Atendimentos(Atendimento atendimento, Empresa empresa, Funcionario funcionario, List<Risco> risco, List<Exame> exame);

    }
}
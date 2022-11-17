using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Empresas;
using Entities.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceFuncionario : IServiceFuncionario
    {
        private readonly IFuncionario _IFuncionario;

        public ServiceFuncionario(IFuncionario iFuncionario)
        {
            _IFuncionario = iFuncionario;
        }

        public async Task Adicionar(Funcionario Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeFuncionario, "NomeFuncionario");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoFuncionario = true;
                await _IFuncionario.Add(Objeto);
            }
        }

        public async Task Atualizar(Funcionario Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeFuncionario, "NomeFuncionario");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IFuncionario.Add(Objeto);
            }
        }

        public async Task<List<Funcionario>> ListarFuncionarioAtivas() => await _IFuncionario.ListarFuncionario(n => n.SituacaoFuncionario);

        public async Task<List<Funcionario>> ListarFuncionarioEmpresa(int id) => await _IFuncionario.Listar(id);

        public async Task<List<FuncionarioEmpresaCargoSetor>> ListarFuncionarioEmpresaCargoSetor(int id, int idFuncionario) => await _IFuncionario.ListarEmpresaCargoSetor(id, idFuncionario);

        public async Task<List<FuncionarioEmpresaCargoSetor>> ListarNomeFuncionarioEmpresaCargoSetor(string nome) => await _IFuncionario.ListarFuncionarioCargoSetor(nome);

    }
}

using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCargo : IServiceCargo
    {
        private readonly ICargo _ICargo;

        public ServiceCargo(ICargo iCargo)
        {
            _ICargo = iCargo;
        }

        public async Task Adicionar(Cargo Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeCargo, "NomeCargo");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoCargo = true;
                await _ICargo.Add(Objeto);
            }
        }

        public async Task Atualizar(Cargo Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeCargo, "NomeCargo");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _ICargo.Update(Objeto);
            }
        }

        public async Task<List<Cargo>> ListarCargoAtivo()
        {
            return await _ICargo.ListarCargo(n => n.SituacaoCargo);
        }
    }
}

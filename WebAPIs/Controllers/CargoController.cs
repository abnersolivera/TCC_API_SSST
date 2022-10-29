using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Cargos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly ICargo _ICargo;
        private readonly IServiceCargo _IServiceCargo;

        public CargoController(IMapper imapper, ICargo iCargo, IServiceCargo iServiceCargo)
        {
            _Imapper = imapper;
            _ICargo = iCargo;
            _IServiceCargo = iServiceCargo;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Cargo/Add")]
        public async Task<List<Notifies>> Add(CargoViewModel cargo)
        {
            var cargoMap = _Imapper.Map<Cargo>(cargo);
            await _IServiceCargo.Adicionar(cargoMap);
            return cargoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Cargo/Update")]
        public async Task<List<Notifies>> Update(CargoViewModel cargo)
        {
            var cargoMap = _Imapper.Map<Cargo>(cargo);
            await _IServiceCargo.Atualizar(cargoMap);
            return cargoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Cargo/Delete")]
        public async Task<List<Notifies>> Delete(CargoViewModel cargo)
        {
            var cargoMap = _Imapper.Map<Cargo>(cargo);
            await _ICargo.Delete(cargoMap);
            return cargoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Cargo/GetEntityById")]
        public async Task<CargoViewModel> GetEntityById(CargoViewModel cargo)
        {
            var cargos = await _ICargo.GetEntityById(cargo.IdCargo);
            var cargoMap = _Imapper.Map<CargoViewModel>(cargos);
            return cargoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Cargo/List")]
        public async Task<List<CargoViewModel>> List()
        {
            var cargo = await _ICargo.List();
            var cargoMap = _Imapper.Map<List<CargoViewModel>>(cargo);
            return cargoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Cargo/ListarCargoAtivos")]
        public async Task<List<CargoViewModel>> ListarCargoAtivos()
        {
            var cargo = await _IServiceCargo.ListarCargoAtivo();
            var cargoMap = _Imapper.Map<List<CargoViewModel>>(cargo);
            return cargoMap;
        }
    }
}

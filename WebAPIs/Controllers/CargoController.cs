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
        public async Task<IActionResult> Add(CargoViewModel cargo)
        {
            try
            {
                var cargoMap = _Imapper.Map<Cargo>(cargo);
                await _IServiceCargo.Adicionar(cargoMap);
                return Ok(cargoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Cargo/Update")]
        public async Task<IActionResult> Update(CargoDTO cargo)
        {
            try
            {
                var cargoMap = _Imapper.Map<Cargo>(cargo);
                await _IServiceCargo.Atualizar(cargoMap);
                return Ok(cargoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Cargo/Delete")]
        public async Task<IActionResult> Delete([FromQuery] CargoIdViewModel cargo)
        {
            try
            {
                var cargoMap = _Imapper.Map<Cargo>(cargo);
                await _ICargo.Delete(cargoMap);
                return Ok(cargoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Cargo/GetEntityById")]
        public async Task<CargoDTO> GetEntityById([FromQuery] CargoIdViewModel cargo)
        {
            var cargos = await _ICargo.GetEntityById(cargo.IdCargo);
            var cargoMap = _Imapper.Map<CargoDTO>(cargos);
            return cargoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Cargo/List")]
        public async Task<List<CargoDTO>> List()
        {
            var cargo = await _ICargo.List();
            var cargoMap = _Imapper.Map<List<CargoDTO>>(cargo);
            return cargoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Cargo/ListarCargoAtivos")]
        public async Task<List<CargoDTO>> ListarCargoAtivos()
        {
            var cargo = await _IServiceCargo.ListarCargoAtivo();
            var cargoMap = _Imapper.Map<List<CargoDTO>>(cargo);
            return cargoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Cargo/ListarCargoEmpresa")]
        public async Task<List<CargoDTO>> ListarCargoEmpresa([FromQuery] int idEmpresa)
        {
            var cargos = await _IServiceCargo.ListarCargoEmpresa(idEmpresa);
            var cargoMap = _Imapper.Map<List<CargoDTO>>(cargos);
            return cargoMap;
        }
    }
}

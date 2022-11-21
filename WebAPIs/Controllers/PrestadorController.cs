using AutoMapper;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Services;
using Entities.Entities.Pessoas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using WebAPIs.Models;
using Entities.Entities.Prestadores;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private readonly IMapper _Imapper;

        private readonly IPrestador _IPrestador;
        private readonly IServicePrestador _IServicePrestador;

        public PrestadorController(IMapper iMapper, IPrestador iPrestador, IServicePrestador iServicePrestador)
        {
            _Imapper = iMapper;
            _IPrestador = iPrestador;
            _IServicePrestador = iServicePrestador;
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
        [HttpPost("/api/Prestador/Add")]
        public async Task<IActionResult> Add(PrestadorViewModel prestador)
        {
            try
            {
                var prestadorMap = _Imapper.Map<Prestador>(prestador);
                await _IServicePrestador.Adicionar(prestadorMap);
                return Ok(prestadorMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Prestador/Update")]
        public async Task<IActionResult> Update(PrestadorDTO prestador)
        {
            try
            {
                var prestadorMap = _Imapper.Map<Prestador>(prestador);
                await _IServicePrestador.Atualizar(prestadorMap);
                return Ok(prestadorMap);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Prestador/Delete")]
        public async Task<IActionResult> Delete([FromQuery] PrestadorIdViewModel prestador)
        {
            try
            {
                var prestadorMap = _Imapper.Map<Prestador>(prestador);
                await _IPrestador.Delete(prestadorMap);
                return Ok(prestadorMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Prestador/GetEntityById")]
        public async Task<PrestadorDTO> GetEntityById([FromQuery] PrestadorIdViewModel prestador)
        {
            var prestadores = await _IPrestador.GetEntityById(prestador.IdPrestador);
            var pessoaMap = _Imapper.Map<PrestadorDTO>(prestadores);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Prestador/List")]
        public async Task<List<PrestadorDTO>> List()
        {
            var prestador = await _IPrestador.List();
            var pessoaMap = _Imapper.Map<List<PrestadorDTO>>(prestador);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Prestador/ListarPrestadorAtivos")]
        public async Task<List<PrestadorDTO>> ListarPrestadorAtivos()
        {
            var prestador = await _IServicePrestador.ListarPrestadorAtivas();
            var prestadorMap = _Imapper.Map<List<PrestadorDTO>>(prestador);
            return prestadorMap;
        }
    }
}

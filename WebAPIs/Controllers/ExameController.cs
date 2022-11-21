using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Exames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IExame _IExame;
        private readonly IServiceExame _IServiceExame;

        public ExameController(IMapper iMapper, IExame iExame, IServiceExame iServiceExame)
        {
            _IMapper = iMapper;
            _IExame = iExame;
            _IServiceExame = iServiceExame;
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
        [HttpPost("/api/Exame/Add")]
        public async Task<IActionResult> Add(ExameViewModel exame)
        {
            try
            {
                var exameMap = _IMapper.Map<Exame>(exame);
                await _IServiceExame.Adicionar(exameMap);
                return Ok(exameMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Exame/Update")]
        public async Task<IActionResult> Update(ExameDTO exame)
        {
            try
            {
                var exameMap = _IMapper.Map<Exame>(exame);
                await _IServiceExame.Atualizar(exameMap);
                return Ok(exameMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Exame/Delete")]
        public async Task<IActionResult> Delete(int exame)
        {
            try
            {
                var exameMap = _IMapper.Map<Exame>(exame);
                await _IExame.Delete(exameMap);
                return Ok(exameMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/GetEntityById")]
        public async Task<IActionResult> GetEntityById([FromQuery] ExameIdViewModel exame)
        {
            try
            {
                var exames = await _IExame.GetEntityById(exame.IdExame);
                var exameMap = _IMapper.Map<ExameDTO>(exames);
                return Ok(exameMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/List")]
        public async Task<List<ExameDTO>> List()
        {
            var exame = await _IExame.List();
            var exameMap = _IMapper.Map<List<ExameDTO>>(exame);
            return exameMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/ListarExamesAtivos")]
        public async Task<List<ExameDTO>> ListarExamesAtivos()
        {
            var exame = await _IServiceExame.ListarExamesAtivo();
            var exameMap = _IMapper.Map<List<ExameDTO>>(exame);
            return exameMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/ListarExamesDetalhe")]
        public async Task<ExameDetailsViewModel> ListarExamesDetalhe([FromQuery] int? curretPage = 1)
        {
            try
            {
                var exame = await _IServiceExame.ListarExamesDetalhe(curretPage!.Value);
                var exameMap = _IMapper.Map<ExameDetailsViewModel>(exame);
                return exameMap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/ListarExamesNome")]
        public async Task<List<ExameDTO>> ListarExamesNome([FromQuery] string nome)
        {
            var exame = await _IServiceExame.ListarExamesNome(nome);
            var exameMap = _IMapper.Map<List<ExameDTO>>(exame);
            return exameMap;
        }
    }
}

using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Endereco;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IMapper _Imapper;

        private readonly IEndereco _IEndereco;
        private readonly IServiceEndereco _IServiceEndereco;

        public EnderecoController(IMapper imapper, IEndereco iEndereco, IServiceEndereco iServiceEndereco)
        {
            _Imapper = imapper;
            _IEndereco = iEndereco;
            _IServiceEndereco = iServiceEndereco;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Endereco/Add")]
        public async Task<IActionResult> Add(EnderecoViewModel endereco)
        {
            try
            {
                var enderecoMap = _Imapper.Map<Endereco>(endereco);
                await _IServiceEndereco.Adicionar(enderecoMap);
                return Ok(enderecoMap);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Endereco/Update")]
        public async Task<IActionResult> Update(EnderecoDTO endereco)
        {
            try
            {
                var enderecoMap = _Imapper.Map<Endereco>(endereco);
                await _IServiceEndereco.Atualizar(enderecoMap);
                return Ok(enderecoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Endereco/Delete")]
        public async Task<IActionResult> Delete([FromQuery] EnderecoIdViewModel endereco)
        {
            try
            {
                var enderecoMap = _Imapper.Map<Endereco>(endereco);
                await _IEndereco.Delete(enderecoMap);
                return Ok(enderecoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Endereco/GetEntityById")]
        public async Task<EnderecoDTO> GetEntityById([FromQuery] EnderecoIdViewModel endereco)
        {
            var enderecos = await _IEndereco.GetEntityById(endereco.IdEndereco);
            var enderecoMap = _Imapper.Map<EnderecoDTO>(enderecos);
            return enderecoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Endereco/List")]
        public async Task<List<EnderecoDTO>> List()
        {
            var endereco = await _IEndereco.List();
            var enderecoMap = _Imapper.Map<List<EnderecoDTO>>(endereco);
            return enderecoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Endereco/ListarEnderecoAtivos")]
        public async Task<List<EnderecoDTO>> ListarEnderecoAtivos()
        {
            var endereco = await _IServiceEndereco.ListarEnderecoAtivas();
            var enderecoMap = _Imapper.Map<List<EnderecoDTO>>(endereco);
            return enderecoMap;
        }
    }
}

using AutoMapper;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces;
using Entities.Entities.Exames;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Riscos;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiscoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IRisco _IRisco;
        private readonly IServiceRisco _IServiceRisco;

        public RiscoController(IMapper iMapper, IRisco iRisco, IServiceRisco iServiceRisco)
        {
            _IMapper = iMapper;
            _IRisco = iRisco;
            _IServiceRisco = iServiceRisco;
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
        [HttpPost("/api/Risco/Add")]
        public async Task<List<Notifies>> Add(RiscoViewModel risco)
        {
            var riscoMap = _IMapper.Map<Risco>(risco);
            await _IServiceRisco.Adicionar(riscoMap);
            return riscoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Risco/Update")]
        public async Task<List<Notifies>> Update(RiscoViewModel risco)
        {
            var riscoMap = _IMapper.Map<Risco>(risco);
            await _IServiceRisco.Atualizar(riscoMap);
            return riscoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Risco/Delete")]
        public async Task<List<Notifies>> Delete([FromQuery] RiscoIdViewModel risco)
        {
            var riscoMap = _IMapper.Map<Risco>(risco);
            await _IRisco.Delete(riscoMap);
            return riscoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Risco/GetEntityById")]
        public async Task<RiscoDTO> GetEntityById([FromQuery] RiscoIdViewModel risco)
        {
            var riscos = await _IRisco.GetEntityById(risco.IdRisco);
            var riscoMap = _IMapper.Map<RiscoDTO>(riscos);
            return riscoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Risco/List")]
        public async Task<List<RiscoDTO>> List()
        {
            var risco = await _IRisco.List();
            var riscoMap = _IMapper.Map<List<RiscoDTO>>(risco);
            return riscoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Risco/ListarRiscosAtivos")]
        public async Task<List<RiscoDTO>> ListarRiscosAtivos()
        {
            var risco = await _IServiceRisco.ListarRiscoAtivo();
            var riscoMap = _IMapper.Map<List<RiscoDTO>>(risco);
            return riscoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Risco/ListarRiscosNome")]
        public async Task<List<RiscoDTO>> ListarRiscosNome([FromQuery] string nome)
        {
            var risco = await _IServiceRisco.ListarRiscosNome(nome);
            var riscoMap = _IMapper.Map<List<RiscoDTO>>(risco);
            return riscoMap;
        }

    }
}

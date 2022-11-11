using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Atendimentos;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAtendimento _IAtendimento;
        
        private readonly IServiceAtendimento _IServiceAtendimento;
        

        public AtendimentoController(IMapper iMapper, IAtendimento iAtendimento, IServiceAtendimento iServiceAtendimento)
        {
            _IMapper = iMapper;
            _IAtendimento = iAtendimento;
            _IServiceAtendimento = iServiceAtendimento;
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
        [HttpPost("/api/Atendimento/Add")]
        public async Task<List<Notifies>> Add(AtendimentoViewModel atendimento)
        {
            var IdLogado = RetornaIdUsuarioLogado().Result;
            var user = await _IAtendimento.ListarUserById(IdLogado.ToString());            
            atendimento.IdUsuarioAtendimento = user.Id;
            var atendimentoMap = _IMapper.Map<Atendimento>(atendimento);
            await _IServiceAtendimento.Adicionar(atendimentoMap);
            return atendimentoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Atendimento/Update")]
        public async Task<List<Notifies>> Update(AtendimentoViewModel atendimento)
        {
            var atendimentoMap = _IMapper.Map<Atendimento>(atendimento);
            await _IServiceAtendimento.Atualizar(atendimentoMap);
            return atendimentoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Atendimento/Delete")]
        public async Task<List<Notifies>> Delete([FromQuery] AtendimentoIdViewModel atendimento)
        {
            var atendimentoMap = _IMapper.Map<Atendimento>(atendimento);
            await _IAtendimento.Delete(atendimentoMap);
            return atendimentoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Atendimento/GetEntityById")]
        public async Task<AtendimentoDTO> GetEntityById([FromQuery] AtendimentoIdViewModel atendimento)
        {
            var atendimentos = await _IAtendimento.GetEntityById(atendimento.IdAtendimento);
            var atendimentoMap = _IMapper.Map<AtendimentoDTO>(atendimentos);
            return atendimentoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Atendimento/List")]
        public async Task<List<AtendimentoDTO>> List()
        {
            var atendimento = await _IAtendimento.List();
            var atendimentoMap = _IMapper.Map<List<AtendimentoDTO>>(atendimento);
            return atendimentoMap;
        }

    }
}

using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Atendimentos;
using Entities.Entities.Empresas;
using Entities.Entities.Funcionarios;
using Entities.Entities.Riscos;
using Entities.Entities.Exames;

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
        public async Task<IActionResult> Add(AtendimentoViewModel atendimento)
        {
            try
            {
                var IdLogado = RetornaIdUsuarioLogado().Result;
                atendimento.IdUsuarioAtendimento = IdLogado;
                var atendimentoMap = _IMapper.Map<Atendimento>(atendimento);
                await _IServiceAtendimento.Adicionar(atendimentoMap);
                return Ok(atendimentoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Atendimento/Atendimentos")]
        public async Task<IActionResult> Atendimentos([FromBody] AtendimentoGerals urlParamAtendimento)
        {
            try
            {
                var atendimentoMap = _IMapper.Map<Atendimento>(urlParamAtendimento.Atendimento);
                var IdLogado = RetornaIdUsuarioLogado().Result;
                atendimentoMap.IdUsuarioAtendimento = IdLogado;
                var empresaMap = _IMapper.Map<Empresa>(urlParamAtendimento.Empresa);
                var fucionarioMap = _IMapper.Map<Funcionario>(urlParamAtendimento.Funcionario);
                var riscoMap = _IMapper.Map<List<Risco>>(urlParamAtendimento.Riscos);
                var exameMap = _IMapper.Map<List<Exame>>(urlParamAtendimento.Exames);
                var result = await _IAtendimento.Atendimentos(atendimentoMap, empresaMap, fucionarioMap, riscoMap, exameMap);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Atendimento/Update")]
        public async Task<IActionResult> Update(AtendimentoViewModel atendimento)
        {
            try
            {
                var atendimentoMap = _IMapper.Map<Atendimento>(atendimento);
                await _IServiceAtendimento.Atualizar(atendimentoMap);
                return Ok(atendimentoMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Atendimento/Delete")]
        public async Task<IActionResult> Delete([FromQuery] AtendimentoIdViewModel atendimento)
        {
            var atendimentoMap = _IMapper.Map<Atendimento>(atendimento);
            await _IAtendimento.Delete(atendimentoMap);
            return Ok(atendimentoMap);
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

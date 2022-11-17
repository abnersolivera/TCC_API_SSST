using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Entities.Entities.Funcionarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IFuncionario _IFuncionario;
        private readonly IServiceFuncionario _IServiceFuncionario;

        public FuncionarioController(IMapper iMapper, IFuncionario iFuncionario, IServiceFuncionario iServiceFuncionario)
        {
            _IMapper = iMapper;
            _IFuncionario = iFuncionario;
            _IServiceFuncionario = iServiceFuncionario;
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
        [HttpPost("/api/Funcionario/Add")]
        public async Task<IActionResult> Add(FuncionarioViewModel funcionario)
        {
            try
            {
                var funcionarioMap = _IMapper.Map<Funcionario>(funcionario);
                await _IServiceFuncionario.Adicionar(funcionarioMap);
                return Ok(funcionarioMap);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Funcionario/Update")]
        public async Task<IActionResult> Update(FuncionarioDTO funcionario)
        {
            try
            {
                var funcionarioMap = _IMapper.Map<Funcionario>(funcionario);
                await _IServiceFuncionario.Atualizar(funcionarioMap);
                return Ok(funcionarioMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Funcionario/Delete")]
        public async Task<List<Notifies>> Delete([FromQuery] FuncionarioIdViewModel funcionario)
        {
            var funcionarioMap = _IMapper.Map<Funcionario>(funcionario);
            await _IFuncionario.Delete(funcionarioMap);
            return funcionarioMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/GetEntityById")]
        public async Task<FuncionarioDTO> GetEntityById([FromQuery] FuncionarioIdViewModel funcionario)
        {
            var funcionarios = await _IFuncionario.GetEntityById(funcionario.IdFuncionario);
            var funcionarioMap = _IMapper.Map<FuncionarioDTO>(funcionarios);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/List")]
        public async Task<List<FuncionarioDTO>> List()
        {
            var funcionario = await _IFuncionario.List();
            var funcionarioMap = _IMapper.Map<List<FuncionarioDTO>>(funcionario);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/ListarFuncionarioAtivas")]
        public async Task<List<FuncionarioDTO>> ListarFuncionarioAtivas()
        {
            var funcionario = await _IServiceFuncionario.ListarFuncionarioAtivas();
            var funcionarioMap = _IMapper.Map<List<FuncionarioDTO>>(funcionario);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/ListarFuncionarioEmpresa")]
        public async Task<List<FuncionarioDTO>> ListarFuncionarioEmpresa([FromQuery] int idEmpresa)
        {
            var funcionario = await _IServiceFuncionario.ListarFuncionarioEmpresa(idEmpresa);
            var funcionarioMap = _IMapper.Map<List<FuncionarioDTO>>(funcionario);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/ListarEmpresaCargoSetor")]
        public async Task<List<FuncionarioEmpCarSerDTO>> ListarEmpresaCargoSetor([FromQuery] int? idEmpresa, int? idFuncionario)
        {
            var funcionario = await _IServiceFuncionario.ListarFuncionarioEmpresaCargoSetor(idEmpresa, idFuncionario);
            var funcionarioMap = _IMapper.Map<List<FuncionarioEmpCarSerDTO>>(funcionario);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/ListarNomeFuncionarioEmpresaCargoSetor")]
        public async Task<List<FuncionarioEmpCarSerDTO>> ListarNomeFuncionarioEmpresaCargoSetor([FromQuery] string nome)
        {
            var funcionario = await _IServiceFuncionario.ListarNomeFuncionarioEmpresaCargoSetor(nome);
            var funcionarioMap = _IMapper.Map<List<FuncionarioEmpCarSerDTO>>(funcionario);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/ListarFuncionarioAtendimento")]
        public async Task<List<FuncionarioAtendimentoDTO>> ListarFuncionarioAtendimento([FromQuery] int? idAtendimento, int? idFuncionario, int? idEmpresa)
        {
            var funcionario = await _IServiceFuncionario.ListarFuncionarioAtendimento(idAtendimento, idFuncionario, idEmpresa);
            var funcionarioMap = _IMapper.Map<List<FuncionarioAtendimentoDTO>>(funcionario);
            return funcionarioMap;
        }

    }
}

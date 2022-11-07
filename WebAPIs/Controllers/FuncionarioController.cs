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
        public async Task<List<Notifies>> Add(FuncionarioViewModel funcionario)
        {
            var funcionarioMap = _IMapper.Map<Funcionario>(funcionario);
            await _IServiceFuncionario.Adicionar(funcionarioMap);
            return funcionarioMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Funcionario/Update")]
        public async Task<List<Notifies>> Update(FuncionarioViewModel funcionario)
        {
            var funcionarioMap = _IMapper.Map<Funcionario>(funcionario);
            await _IServiceFuncionario.Atualizar(funcionarioMap);
            return funcionarioMap.Notitycoes;
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
        public async Task<FuncionarioViewModel> GetEntityById([FromQuery] FuncionarioIdViewModel funcionario)
        {
            var funcionarios = await _IFuncionario.GetEntityById(funcionario.IdFuncionario);
            var funcionarioMap = _IMapper.Map<FuncionarioViewModel>(funcionarios);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/List")]
        public async Task<List<FuncionarioViewModel>> List()
        {
            var funcionario = await _IFuncionario.List();
            var funcionarioMap = _IMapper.Map<List<FuncionarioViewModel>>(funcionario);
            return funcionarioMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Funcionario/ListarFuncionarioAtivas")]
        public async Task<List<FuncionarioViewModel>> ListarFuncionarioAtivas()
        {
            var funcionario = await _IServiceFuncionario.ListarFuncionarioAtivas();
            var funcionarioMap = _IMapper.Map<List<FuncionarioViewModel>>(funcionario);
            return funcionarioMap;
        }

    }
}

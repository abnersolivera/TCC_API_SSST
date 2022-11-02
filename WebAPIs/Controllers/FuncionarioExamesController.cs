using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Exames;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioExamesController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IFuncionarioExames _IFuncionarioExames;

        public FuncionarioExamesController(IMapper iMapper, IFuncionarioExames iFuncionarioExames)
        {
            _IMapper = iMapper;
            _IFuncionarioExames = iFuncionarioExames;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/FuncionarioExames/Add")]
        public async Task<List<Notifies>> Add(FuncionarioExamesViewModel funcionarioExames)
        {
            var funcionarioExamesMap = _IMapper.Map<FuncionarioExames>(funcionarioExames);
            await _IFuncionarioExames.Add(funcionarioExamesMap);
            return funcionarioExamesMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/FuncionarioExames/Update")]
        public async Task<List<Notifies>> Update(FuncionarioExamesViewModel funcionarioExames)
        {
            var funcionarioExamesMap = _IMapper.Map<FuncionarioExames>(funcionarioExames);
            await _IFuncionarioExames.Update(funcionarioExamesMap);
            return funcionarioExamesMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/FuncionarioExames/Delete")]
        public async Task<List<Notifies>> Delete(FuncionarioExamesViewModel funcionarioExames)
        {
            var funcionarioExamesMap = _IMapper.Map<FuncionarioExames>(funcionarioExames);
            await _IFuncionarioExames.Delete(funcionarioExamesMap);
            return funcionarioExamesMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/FuncionarioExames/GetEntityById")]
        public async Task<FuncionarioExamesViewModel> GetEntityById(FuncionarioExamesViewModel funcionarioExames)
        {
            var funcionarioExame = await _IFuncionarioExames.GetEntityById(funcionarioExames.IdFuncionarioExames);
            var funcionarioExamesMap = _IMapper.Map<FuncionarioExamesViewModel>(funcionarioExame);
            return funcionarioExamesMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/FuncionarioExames/List")]
        public async Task<List<FuncionarioExamesViewModel>> List()
        {
            var funcionarioExames = await _IFuncionarioExames.List();
            var funcionarioExamesMap = _IMapper.Map<List<FuncionarioExamesViewModel>>(funcionarioExames);
            return funcionarioExamesMap;
        }
    }
}

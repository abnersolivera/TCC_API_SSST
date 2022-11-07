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

    }
}

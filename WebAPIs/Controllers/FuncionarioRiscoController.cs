using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Riscos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioRiscoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IFuncionarioRisco _FuncionarioRisco;

        public FuncionarioRiscoController(IMapper iMapper, IFuncionarioRisco funcionarioRisco)
        {
            _IMapper = iMapper;
            _FuncionarioRisco = funcionarioRisco;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/FuncionarioRisco/Add")]
        public async Task<List<Notifies>> Add(FuncionarioRiscoViewModel funcionarioRisco)
        {
            var funcionarioRiscoMap = _IMapper.Map<FuncionarioRisco>(funcionarioRisco);
            await _FuncionarioRisco.Add(funcionarioRiscoMap);
            return funcionarioRiscoMap.Notitycoes;
        }
    }
}

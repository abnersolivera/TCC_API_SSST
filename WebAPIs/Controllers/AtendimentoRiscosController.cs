using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Empresas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Riscos;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoRiscosController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAtendimentoRiscos _IAtendimentoRiscos;

        public AtendimentoRiscosController(IMapper iMapper, IAtendimentoRiscos iAtendimentoRiscos)
        {
            _IMapper = iMapper;
            _IAtendimentoRiscos = iAtendimentoRiscos;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AtendimentoRiscos/Add")]
        public async Task<List<Notifies>> Add(AtendimentoRiscosViewModel atendimentoRiscos)
        {
            var atendimentoRiscosMap = _IMapper.Map<AtendimentoRiscos>(atendimentoRiscos);
            await _IAtendimentoRiscos.Add(atendimentoRiscosMap);
            return atendimentoRiscosMap.Notitycoes;
        }
    }
}

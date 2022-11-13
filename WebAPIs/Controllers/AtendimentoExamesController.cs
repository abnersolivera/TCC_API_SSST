using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Empresas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Exames;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoExamesController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAtendimentoExames _IAtendimentoExames;

        public AtendimentoExamesController(IMapper iMapper, IAtendimentoExames iAtendimentoExames)
        {
            _IMapper = iMapper;
            _IAtendimentoExames = iAtendimentoExames;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AtendimentoExames/Add")]
        public async Task<List<Notifies>> Add(AtendimentoExamesViewModel atendimentoExames)
        {
            var atendimentoExamesMap = _IMapper.Map<AtendimentoExames>(atendimentoExames);
            await _IAtendimentoExames.Add(atendimentoExamesMap);
            return atendimentoExamesMap.Notitycoes;
        }
    }
}

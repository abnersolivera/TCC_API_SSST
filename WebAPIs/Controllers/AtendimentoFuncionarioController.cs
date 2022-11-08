using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Empresas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Funcionarios;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoFuncionarioController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAtendimentoFuncionario _IAtendimentoFuncionario;

        public AtendimentoFuncionarioController(IMapper iMapper, IAtendimentoFuncionario iAtendimentoFuncionario)
        {
            _IMapper = iMapper;
            _IAtendimentoFuncionario = iAtendimentoFuncionario;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AtendimentoFuncionario/Add")]
        public async Task<List<Notifies>> Add(AtendimentoFuncionarioViewModel atendimentoFuncionario)
        {
            var atendimentoFuncionarioMap = _IMapper.Map<AtendimentoFuncionario>(atendimentoFuncionario);
            await _IAtendimentoFuncionario.Add(atendimentoFuncionarioMap);
            return atendimentoFuncionarioMap.Notitycoes;
        }
    }
}

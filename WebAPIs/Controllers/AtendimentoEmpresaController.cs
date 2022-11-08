using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Endereco;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Empresas;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoEmpresaController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAtendimentoEmpresa _IAtendimentoEmpresa;

        public AtendimentoEmpresaController(IMapper iMapper, IAtendimentoEmpresa iAtendimentoEmpresa)
        {
            _IMapper = iMapper;
            _IAtendimentoEmpresa = iAtendimentoEmpresa;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AtendimentoEmpresa/Add")]
        public async Task<List<Notifies>> Add(AtendimentoEmpresaViewModel atendimentoEmpresa)
        {
            var atendimentoEmpresaMap = _IMapper.Map<AtendimentoEmpresa>(atendimentoEmpresa);
            await _IAtendimentoEmpresa.Add(atendimentoEmpresaMap);
            return atendimentoEmpresaMap.Notitycoes;
        }
    }
}

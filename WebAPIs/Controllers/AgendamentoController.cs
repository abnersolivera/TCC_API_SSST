﻿using Entities.Entities.Atendimentos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAgendamento _IAgendamento;
        private readonly IServiceAgendamento _IServiceAgendamento;

        public AgendamentoController(IMapper iMapper, IAgendamento iAgendamento, IServiceAgendamento iServiceAgendamento)
        {
            _IMapper = iMapper;
            _IAgendamento = iAgendamento;
            _IServiceAgendamento = iServiceAgendamento;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Agendamento/Add")]
        public async Task<List<Notifies>> Add(AgendamentoViewModel agendamento)
        {
            var agendamentoMap = _IMapper.Map<Agendamento>(agendamento);
            await _IServiceAgendamento.Adicionar(agendamentoMap);
            return agendamentoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Agendamento/Update")]
        public async Task<List<Notifies>> Update(AgendamentoViewModel agendamento)
        {
            var agendamentoMap = _IMapper.Map<Agendamento>(agendamento);
            await _IServiceAgendamento.Atualizar(agendamentoMap);
            return agendamentoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Agendamento/Delete")]
        public async Task<List<Notifies>> Delete([FromQuery] AgendamentoIdViewModel atendimento)
        {
            var agendamentoMap = _IMapper.Map<Agendamento>(atendimento);
            await _IAgendamento.Delete(agendamentoMap);
            return agendamentoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Agendamento/GetEntityById")]
        public async Task<AgendamentoViewModel> GetEntityById([FromQuery] AgendamentoIdViewModel atendimento)
        {
            var agendamentos = await _IAgendamento.GetEntityById(atendimento.IdAgendamento);
            var agendamentoMap = _IMapper.Map<AgendamentoViewModel>(agendamentos);
            return agendamentoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Agendamento/List")]
        public async Task<List<AgendamentoViewModel>> List()
        {
            var agendamento = await _IAgendamento.List();
            var agendamentoMap = _IMapper.Map<List<AgendamentoViewModel>>(agendamento);
            return agendamentoMap;
        }
    }
}

﻿using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Exames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceExamecs : IServiceExame
    {
        private readonly IExame _IExame;

        public ServiceExamecs(IExame iExame)
        {
            _IExame = iExame;
        }

        public async Task Adicionar(Exame Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeExame, "NomeExame");
            if (validaNome)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.SituacaoExame = true;
                await _IExame.Add(Objeto);
            }
        }

        public async Task Atualizar(Exame Objeto)
        {
            var validaNome = Objeto.ValidarPropriedadeString(Objeto.NomeExame, "NomeExame");
            if (validaNome)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IExame.Update(Objeto);
            }
        }

        public async Task<List<Exame>> ListarExamesAtivo()
        {
            return await _IExame.ListarExame(n => n.SituacaoExame);
        }
    }
}

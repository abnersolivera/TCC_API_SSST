﻿using Entities.Enums;

namespace WebAPIs.Models
{
    public class AtendimentoViewModel
    {
        public DateTime DataAtendimento { get; set; }

        public DateTime? DataAgendamentoAtendimento { get; set; }

        public DateTime? HoraInicialAtendimento { get; set; }

        public DateTime? HoraFinalAtendimento { get; set; }

        public DateTime? HoraAgendadaAtendimento { get; set; }

        public TipoExame CompromissoAtendimento { get; set; }

        public TipoCompromisso TipoCompromissoAtendimento { get; set; }

        public string RazaoSocialAtendimento { get; set; }

        public string FuncionarioAtendimento { get; set; }

        public string RGAtendimento { get; set; }

        public string CPFAtendimento { get; set; }

        public string? MatriculaAtendimento { get; set; }

        public string UnidadeAtendimento { get; set; }

        public string SetorAtendimento { get; set; }

        public string CargoAtendimento { get; set; }

        public string? AtendimentoAtendimento { get; set; }

        public string IdUsuarioAtendimento { get; set; }

        public TipoAtendimento StatusAtendimento { get; set; }
    }

    public class AtendimentoIdViewModel
    {
        public int IdAtendimento { get; set; }
    }

    public class AtendimentoDTO
    {
        public int IdAtendimento { get; set; }

        public string DataAtendimento { get; set; }

        public string? DataAgendamentoAtendimento { get; set; }

        public string? HoraInicialAtendimento { get; set; }

        public string? HoraFinalAtendimento { get; set; }

        public string? HoraAgendadaAtendimento { get; set; }

        public TipoExame CompromissoAtendimento { get; set; }

        public TipoCompromisso TipoCompromissoAtendimento { get; set; }

        public string RazaoSocialAtendimento { get; set; }

        public string FuncionarioAtendimento { get; set; }

        public string RGAtendimento { get; set; }

        public string CPFAtendimento { get; set; }

        public string? MatriculaAtendimento { get; set; }

        public string UnidadeAtendimento { get; set; }

        public string SetorAtendimento { get; set; }

        public string CargoAtendimento { get; set; }

        public string? AtendimentoAtendimento { get; set; }

        public string IdUsuarioAtendimento { get; set; }

        public TipoAtendimento StatusAtendimento { get; set; }

        public string? DataCadastro { get; set; }

        public string? DataAlteracao { get; set; }

    }

    public class AtendimentoGeralDTO 
    {
        public AtendimentoViewModel Atendimento { get; set; } 

        public EmpresaDTO Empresa { get; set; }

        public FuncionarioDTO Funcionario { get; set; }

        public List<RiscoDTO> Riscos { get; set; }

        public List<ExameDTO> Exames { get; set; }
    }

    public class AgendamentoViewModel
    {

        public DateTime DataAgendamento { get; set; }

        public TipoExame CompromissoAgendamento { get; set; }

        public TipoCompromisso TipoCompromissoAgendamento { get; set; }

        public string RazaoSocialAgendamento { get; set; }

        public string FuncionarioAgendamento { get; set; }

        public TipoAtendimento StatusAgendamento { get; set; }

        public int IdFuncionario { get; set; }

    }

    public class AgendamentoIdViewModel
    {
        public int IdAgendamento { get; set; }
    }

    public class AgendamentoDTO
    {
        public int IdAgendamento { get; set; }

        public string DataAgendamento { get; set; }

        public TipoExame CompromissoAgendamento { get; set; }

        public TipoCompromisso TipoCompromissoAgendamento { get; set; }

        public string RazaoSocialAgendamento { get; set; }

        public string FuncionarioAgendamento { get; set; }

        public TipoAtendimento StatusAgendamento { get; set; }

        public int IdFuncionario { get; set; }

        public string DataCadastro { get; set; }

        public string DataAlteracao { get; set; }
    }

    public class AgendamentCount
    {
        public int Count { get; set; }
    }
}





﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Atendimentos
{
    [Table("Agendamento")]
    public class Agendamento : Notifies
    {
        [Key()]
        [Column("id_Agendamento")]
        public int IdAgendamento { get; set; }

        [Column("data_Agendamento")]
        public DateTime DataAgendamento { get; set; }

        [Column("hota_Agendamento")]
        public DateTime HoraAgendada { get; set; }

        [Column("compromisso_Agendamento")]
        public TipoExame CompromissoAgendamento { get; set; }

        [Column("tipoCompromisso_Agendamento")]
        public TipoCompromisso? TipoCompromissoAgendamento { get; set; }

        [Column("idFuncionario_Agendamento")]
        public int IdFuncionario { get; set; }

        [Column("razaoSocial_Agendamento")]
        [MaxLength(250, ErrorMessage = "Permitido 250 Caracteres")]
        public string? RazaoSocialAgendamento { get; set; }

        
        [Column("funcionario_Agendamento")]
        [MaxLength(100, ErrorMessage = "Permitido 100 Caracteres")]
        public string FuncionarioAgendamento { get; set; }

        [Column("status_Agendamento")]
        public TipoAtendimento StatusAgendamento { get; set; }

        [Column("dataCadastro_Agendamento")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Agendamento")]
        public DateTime DataAlteracao { get; set; }

    }
}

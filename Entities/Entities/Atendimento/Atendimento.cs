using Entities.Entities.Empresa;
using Entities.Entities.Exame;
using Entities.Entities.Funcionario;
using Entities.Entities.Risco;
using Entities.Entities.Setor;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Atendimento
{
    [Table("Atendimento")]
    public class Atendimento : Notifies
    {
        [Column("id_Atendimento")]
        public int IdAtendimento { get; set; }

        [Column("Data_Atendimento")]
        public DateTime DataAtendimento { get; set; }

        [Column("HoraInicial_Atendimento")]
        public DateTime HoraInicialAtendimento { get; set; }

        [Column("HoraFinal_Atendimento")]
        public DateTime HoraFinalAtendimento { get; set; }

        [Column("HoraChegada_Atendimento")]
        public DateTime HoraChegadaAtendimento { get; set; }

        [Column("Compromisso_Atendimento")]
        public TipoExame CompromissoAtendimento { get; set; }

        [Column("TipoCompromisso_Atendimento")]
        public TipoCompromisso TipoCompromissoAtendimento { get; set; }

        [Column("RazaoSocial_Atendimento")]
        [MaxLength(250)]
        public string RazaoSocialAtendimento { get; set; }

        [Column("Funcionario_Atendimento")]
        [MaxLength(100)]
        public string FuncionarioAtendimento { get; set; }

        [Column("RG_Atendimento")]
        [MaxLength(20)]
        public string RGAtendimento { get; set; }

        [Column("CPF_Atendimento")]
        [MaxLength(20)]
        public string CPFAtendimento { get; set; }

        [Column("Matricula_Atendimento")]
        [MaxLength(30)]
        public string? MatriculaAtendimento { get; set; }

        [Column("Unidade_Atendimento")]
        [MaxLength(250)]
        public string UnidadeAtendimento { get; set; }

        [Column("Setor_Atendimento")]
        [MaxLength(100)]
        public string SetorAtendimento { get; set; }

        [Column("Cargo_Atendimento")]
        [MaxLength(100)]
        public string CargoAtendimento { get; set; }

        [Column("Atendimento_Atendimento")]
        [MaxLength(50)]
        public string AtendimentoAtendimento { get; set; }

        [Column("NomeUsuario_Atendimento")]
        [MaxLength(50)]
        public string NomeUsuarioAtendimento { get; set; }

        [Column("Exames_Atendimento")]
        public string ExamesAtendimento { get; set; }

        [Column("Riscos_Atendimento")]
        public string RiscosAtendimento { get; set; }

        [Column("Status_Atendimento")]        
        public TipoAtendimento StatusAtendimento { get; set; }
    }
}

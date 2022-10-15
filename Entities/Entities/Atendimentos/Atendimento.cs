using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Atendimentos
{
    [Table("Atendimento")]
    public class Atendimento : Notifies
    {
        [Column("id_Atendimento")]
        public int IdAtendimento { get; set; }

        [Column("data_Atendimento")]
        public DateTime DataAtendimento { get; set; }

        [Column("horaInicial_Atendimento")]
        public DateTime HoraInicialAtendimento { get; set; }

        [Column("horaFinal_Atendimento")]
        public DateTime? HoraFinalAtendimento { get; set; }

        [Column("horaChegada_Atendimento")]
        public DateTime? HoraChegadaAtendimento { get; set; }

        [Column("compromisso_Atendimento")]
        public TipoExame CompromissoAtendimento { get; set; }

        [Column("tipoCompromisso_Atendimento")]
        public TipoCompromisso TipoCompromissoAtendimento { get; set; }

        [Column("razaoSocial_Atendimento")]
        [MaxLength(250)]
        public string RazaoSocialAtendimento { get; set; }

        [Column("funcionario_Atendimento")]
        [MaxLength(100)]
        public string FuncionarioAtendimento { get; set; }

        [Column("rg_Atendimento")]
        [MaxLength(20)]
        public string RGAtendimento { get; set; }

        [Column("cpf_Atendimento")]
        [MaxLength(20)]
        public string CPFAtendimento { get; set; }

        [Column("matricula_Atendimento")]
        [MaxLength(30)]
        public string? MatriculaAtendimento { get; set; }

        [Column("unidade_Atendimento")]
        [MaxLength(250)]
        public string UnidadeAtendimento { get; set; }

        [Column("setor_Atendimento")]
        [MaxLength(100)]
        public string SetorAtendimento { get; set; }

        [Column("cargo_Atendimento")]
        [MaxLength(100)]
        public string CargoAtendimento { get; set; }

        [Column("atendimento_Atendimento")]
        [MaxLength(50)]
        public string? AtendimentoAtendimento { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdUsuarioAtendimento { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column("status_Atendimento")]        
        public TipoAtendimento StatusAtendimento { get; set; }

        [Column("dataCadastro_Atendimento")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Atendimento")]
        public DateTime DataAlteracao { get; set; }
    }
}

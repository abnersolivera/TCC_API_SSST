using Entities.Entities.Empresas;
using Entities.Entities.Exames;
using Entities.Entities.Funcionarios;
using Entities.Entities.Riscos;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Atendimentos
{
    [Table("Atendimento")]
    public class Atendimento
    {
        [Key()]
        [Column("id_Atendimento")]
        public int IdAtendimento { get; set; }

        [Column("data_Atendimento")]
        public DateTime DataAtendimento { get; set; }

        [Column("dataAgendamento_Atendimento")]
        public DateTime DataAgendamentoAtendimento { get; set; }

        [Column("horaInicial_Atendimento")]
        public DateTime HoraInicialAtendimento { get; set; }

        [Column("horaFinal_Atendimento")]
        public DateTime? HoraFinalAtendimento { get; set; }

        [Column("horaAgendada_Atendimento")]
        public DateTime? HoraAgendadaAtendimento { get; set; }

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

        public ICollection<AtendimentoEmpresa> AtendimentoEmpresa { get; set; }

        public ICollection<AtendimentoExames> AtendimentoExames { get; set; }

        public ICollection<AtendimentoFuncionario> AtendimentoFuncionario { get; set; }

        public ICollection<AtendimentoRiscos> AtendimentoRiscos { get; set; }
    }

    public class AtendimentoGeral
    {
        public Atendimento Atendimento { get; set; }

        public Empresa Empresa { get; set; }

        public Funcionario Funcionario { get; set; }

        public List<Exame> Exames { get; set; }

        public List<Risco> Riscos { get; set; }
    }
}

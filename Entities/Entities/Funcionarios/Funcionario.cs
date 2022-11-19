using Entities.Entities.Atendimentos;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using Entities.Entities.Exames;
using Entities.Entities.Riscos;
using Entities.Entities.Setores;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipes;

namespace Entities.Entities.Funcionarios
{
    [Table("Funcionario")]
    public class Funcionario : Notifies
    {
        [Key()]
        [Column("id_Funcionario")]
        public int IdFuncionario { get; set; }

        [Column("situacao_Funcionario")]
        public bool SituacaoFuncionario { get; set; }

        [Column("nome_Funcionario")]
        [MaxLength(100)]
        public string? NomeFuncionario { get; set; }

        [Column("dataNascimento_Funcionario")]
        public DateTime DataNascimentoFuncionario { get; set; }

        [Column("cpf_Funcionario")]
        [MaxLength(20)]
        public string? CpfFuncionario { get; set; }

        [Column("rg_Funcionario")]
        [MaxLength(20)]
        public string? RgFuncionario { get; set; }

        [Column("pis_Funcionario")]
        [MaxLength(20)]
        public string? PisFuncionario { get; set; }

        [Column("telefone_Funcionario")]
        [MaxLength(20)]
        public string? TelefoneFuncionario { get; set; }

        [Column("email_Funcionario")]
        [MaxLength(20)]
        public string? EmailFuncionario { get; set; }

        [Column("sexo_Funcionario")]
        public TipoSexo SexoFuncionario { get; set; }

        [Column("dataCadastro_Funcionario")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Funcionario")]
        public DateTime DataAlteracao { get; set; }

        [Column("dataAdmissao_Funcionario")]
        public DateTime DataAdmissao { get; set; }

        [Column("dataDemissao_Funcionario")]
        public DateTime? DataDemissao { get; set; }

        [ForeignKey("Cargo")]
        public int IdCargo { get; set; }
        public virtual Cargo Cargo { get; set; }

        [ForeignKey("Setor")]
        public int IdSetor { get; set; }
        public virtual Setor Setor { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        public ICollection<FuncionarioExames> FuncionarioExames { get; set; }

        public ICollection<FuncionarioRisco> FuncionarioRisco { get; set; }

        public ICollection<AtendimentoExames> AtendimentoExames { get; set; }

    }

    public class FuncionarioEmpresaCargoSetor
    {
        public int IdFuncionario { get; set; }

        public bool SituacaoFuncionario { get; set; }

        public string? NomeFuncionario { get; set; }

        public DateTime DataNascimentoFuncionario { get; set; }

        public string? CpfFuncionario { get; set; }

        public string? RgFuncionario { get; set; }

        public string? PisFuncionario { get; set; }

        public string? TelefoneFuncionario { get; set; }

        public string? EmailFuncionario { get; set; }

        public TipoSexo SexoFuncionario { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataAdmissao { get; set; }

        public DateTime? DataDemissao { get; set; }

        public Cargo CargoFun { get; set; }

        public Setor SetorFun { get; set; }

        public Empresa EmpresaFun { get; set; }

        public Unidade UnidadeFun { get; set; }
    }

    public class FuncionarioAtendimento
    {
        public int IdFuncionario { get; set; }

        public bool SituacaoFuncionario { get; set; }

        public string? NomeFuncionario { get; set; }

        public DateTime DataNascimentoFuncionario { get; set; }

        public string? CpfFuncionario { get; set; }

        public string? RgFuncionario { get; set; }

        public string? PisFuncionario { get; set; }

        public string? TelefoneFuncionario { get; set; }

        public string? EmailFuncionario { get; set; }

        public TipoSexo SexoFuncionario { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataAdmissao { get; set; }

        public DateTime? DataDemissao { get; set; }

        public Atendimento AtendimentoFun { get; set; }

        public Cargo CargoFun { get; set; }

        public Setor SetorFun { get; set; }

        public Empresa EmpresaFun { get; set; }

        public Unidade UnidadeFun { get; set; }

        public List<Exame> ExameFun { get; set; } = new List<Exame>();

        public List<Risco> RiscoFun { get; set; } = new List<Risco>(); 
    }
}

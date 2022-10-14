using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Funcionarios
{
    [Table("Funcionario")]
    public class Funcionario : Notifies
    {
        [Column("Id_Funcionario")]
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
        [MaxLength(20)]
        public TipoSexo SexoFuncionario { get; set; }

        [Column("dataCadastro_Funcionario")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Funcionario")]
        public DateTime DataAlteracao { get; set; }

        [Column("dataAdmissao_Funcionario")]
        public DateTime DataAdmissao { get; set; }

        [Column("dataDemissao_Funcionario")]
        public DateTime DataDemissao { get; set; }
    }
}

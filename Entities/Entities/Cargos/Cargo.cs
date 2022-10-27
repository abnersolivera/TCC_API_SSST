using Entities.Entities.Empresas;
using Entities.Entities.Funcionarios;
using Entities.Entities.Setores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Cargos
{
    [Table("Cargo")]
    public class Cargo : Notifies
    {
        [Key()]
        [Column("id_Cargo")]
        public int IdCargo { get; set; }

        [Column("situacao_Cargo")]
        public bool SituacaoCargo { get; set; }

        [Column("nome_Cargo")]
        [MaxLength(100)]
        public string NomeCargo { get; set; }

        [Column("descricao_Cargo")]
        [MaxLength(255)]
        public string? DescricaoCargo { get; set; }

        [Column("dataCadastro_Cargo")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Cargo")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

    }
}

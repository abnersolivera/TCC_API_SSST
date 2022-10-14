using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Cargos
{
    [Table("Cargo")]
    public class Cargo : Notifies
    {
        [Column("Id_Cargo")]
        public int IdCargo { get; set; }

        [Column("situacao_Cargo")]
        public bool SituacaoCargo { get; set; }

        [Column("nome_Cargo")]
        [MaxLength(100)]
        public string NomeCargo { get; set; }

        [Column("descricao_Cargo")]
        [MaxLength(255)]
        public string DescricaoCargo { get; set; }

        [Column("dataCadastro_Cargo")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Cargo")]
        public DateTime DataAlteracao { get; set; }
    }
}

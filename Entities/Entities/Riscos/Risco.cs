using Entities.Entities.Prestadores;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Riscos
{
    [Table("Risco")]
    public class Risco : Notifies
    {
        [Key()]
        [Column("id_Risco")]
        public int IdRisco { get; set; }

        [Column("situacao_Risco")]
        public bool SituacaoRisco { get; set; }

        [Column("nome_Risco")]
        [MaxLength(255)]
        public string NomeRisco { get; set; }

        [Column("tipo_Risco")]
        public TipoRisco TipoRisco { get; set; }

        [Column("dataCadastro_Risco")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Risco")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Prestador")]
        public int IdPrestador { get; set; }
        public virtual Prestador Prestador { get; set; }

        public ICollection<FuncionarioRisco> FuncionarioRisco { get; set; }
        public ICollection<AtendimentoRiscos> AtendimentoRiscos { get; set; }
    }
}

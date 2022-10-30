using Entities.Entities.Prestadores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Exames
{
    [Table("Exame")]
    public class Exame : Notifies
    {
        [Key()]
        [Column("id_Exame")]
        public int IdExame { get; set; }

        [Column("situacao_Exame")]
        public bool SituacaoExame { get; set; }

        [Column("nome_Exame")]
        [MaxLength(255)]
        public string NomeExame { get; set; }

        [Column("dataCadastro_Exame")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Exame")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Prestador")]
        public int IdPrestador { get; set; }
        public virtual Prestador Prestador { get; set; }
    }
}

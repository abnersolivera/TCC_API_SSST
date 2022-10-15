using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Riscos
{
    [Table("Risco")]
    public class Risco : Notifies
    {
        [Column("id_Risco")]
        public int IdRisco { get; set; }

        [Column("situacao_Risco")]
        public bool SituacaoRisco { get; set; }

        [Column("nome_Risco")]
        [MaxLength(255)]
        public string NomeRisco { get; set; }

        [Column("dataCadastro_Risco")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Risco")]
        public DateTime DataAlteracao { get; set; }
    }
}

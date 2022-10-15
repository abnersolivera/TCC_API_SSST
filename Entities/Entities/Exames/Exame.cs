using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Exames
{
    [Table("Exame")]
    public class Exame : Notifies
    {
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Setores
{
    [Table("Setor")]
    public class Setor : Notifies
    {
        [Column("Id_Setor")]
        public int IdSetor { get; set; }

        [Column("situacao_Setor")]
        public bool SituacaoSetor { get; set; }

        [Column("nome_Setor")]
        [MaxLength(100)]
        public string NomeSetor { get; set; }

        [Column("descricao_Setor")]
        [MaxLength(255)]
        public string DescricaoSetor { get; set; }

        [Column("dataCadastro_Setor")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Setor")]
        public DateTime DataAlteracao { get; set; }
    }
}

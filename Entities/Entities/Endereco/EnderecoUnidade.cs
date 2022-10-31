using Entities.Entities.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Endereco
{
    [Table("EnderecoUnidade")]
    public class EnderecoUnidade : Notifies
    {
        [Key()]
        [Column("id_EnderecoUnidade")]
        public int IdEnderecoUnidade { get; set; }

        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }

        [ForeignKey("Unidade")]
        public int IdUnidade { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}

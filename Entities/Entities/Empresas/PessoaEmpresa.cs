using Entities.Entities.Pessoas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Empresas
{
    [Table("PessoaEmpresa")]
    public class PessoaEmpresa : Notifies
    {
        [Column("id_PessoaEmpresa")]
        public int IdPessoaEmpresa { get; set; }

        [ForeignKey("Pessoa")]
        public int IdPessoas { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}

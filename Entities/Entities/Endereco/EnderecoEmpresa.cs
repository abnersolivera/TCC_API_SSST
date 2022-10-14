using Entities.Entities.Empresas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Endereco
{
    [Table("EnderecoEmpresa")]
    public class EnderecoEmpresa : Notifies
    {
        [Column("id_EnderecoEmpresa")]
        public int IdEnderecoEmpresa { get; set; }

        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}

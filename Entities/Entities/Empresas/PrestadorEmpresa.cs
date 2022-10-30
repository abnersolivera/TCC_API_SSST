using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Entities.Prestadores;

namespace Entities.Entities.Empresas
{
    [Table("PrestadorEmpresa")]
    public class PrestadorEmpresa : Notifies
    {
        [Key()]
        [Column("id_PrestadorEmpresa")]
        public int IdPrestadorEmpresa { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("Prestador")]
        public int IdPrestador { get; set; }
        public virtual Prestador Prestador { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Empresas
{
    [Table("UsuarioEmpresa")]
    public class UsuarioEmpresa : Notifies
    {
        [Column("id_UsuarioEmpresa")]
        public int IdUsuarioEmpresa { get; set; }

        [ForeignKey("ApplicationUser")]
        public string IdUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}

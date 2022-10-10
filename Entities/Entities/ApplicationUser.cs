using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("Status_Usuario")]
        public string CPF { get; set; }

        [Column("Tipo_Usuario")]
        public TipoUsuario? Tipo { get; set; }

        [Column("UltimoAcesso_Usuario")]
        public DateTime UltimoAcesso { get; set; }
    }
}

using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class UserViewModel
    {
        public string? CaminhoImagem { get; set; }

        public string? Nome { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public TipoUsuario? Tipo { get; set; }

        public DateTime? UltimoAcesso { get; set; }
    }

}

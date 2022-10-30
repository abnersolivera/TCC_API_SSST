using Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class UsuarioEmpresaViewModel
    {
        public int IdUsuarioEmpresa { get; set; }

        public string IdUser { get; set; }

        public int IdEmpresa { get; set; }
    }
}

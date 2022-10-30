using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class PrestadorEmpresaViewModel
    {
        public int IdPrestadorEmpresa { get; set; }

        public int IdEmpresa { get; set; }

        public int IdPrestador { get; set; }
    }
}

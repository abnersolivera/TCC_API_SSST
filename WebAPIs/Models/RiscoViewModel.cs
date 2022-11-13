using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace WebAPIs.Models
{
    public class RiscoViewModel
    {
        public string NomeRisco { get; set; }

        public TipoRisco TipoRisco { get; set; }

        public int IdPrestador { get; set; }
    }

    public class RiscoIdViewModel
    {
        public int IdRisco { get; set; }
    }
}

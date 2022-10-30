using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class RiscoViewModel
    {
        public int IdRisco { get; set; }

        public bool SituacaoRisco { get; set; }

        public string NomeRisco { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public int IdPrestador { get; set; }
    }
}

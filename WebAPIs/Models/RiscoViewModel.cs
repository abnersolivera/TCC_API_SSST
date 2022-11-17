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

    public class RiscoDTO
    {
        public int IdRisco { get; set; }

        public bool SituacaoRisco { get; set; }

        public string NomeRisco { get; set; }

        public TipoRisco TipoRisco { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public int IdPrestador { get; set; }
    }

    public class RiscoAtendimentoDTO
    {
        public int IdRisco { get; set; }

        public string NomeRisco { get; set; }

    }
}

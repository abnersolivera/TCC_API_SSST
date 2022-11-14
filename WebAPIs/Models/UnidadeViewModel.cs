using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class UnidadeViewModel
    {
        public string NomeAbreviadoUnidade { get; set; }

        public string RazaoSocialUnidade { get; set; }

        public string? CnpjUnidade { get; set; }

        public string? CpfUnidade { get; set; }

        public string? InscricaoEstadualUnidade { get; set; }

        public string? InscricaoMunicipalUnidade { get; set; }

        public string? CnoUnidade { get; set; }

        public DateTime? DataContratoUnidade { get; set; }

        public string? NumeroContratoUnidade { get; set; }

        public string? CnaeUnidade { get; set; }

        public string? CnaeLivreUnidade { get; set; }

        public string? CnaeSecundarioUnidade { get; set; }

        public string? GrauRiscoUnidade { get; set; }

        public string? DescricaoLocalUnidade { get; set; }

        public int IdEmpresa { get; set; }
    }

    public class UnidadeIdViewModel
    {
        public int IdUnidade { get; set; }
    }

    public class UnidadeDTO
    {
        public int IdUnidade { get; set; }

        public bool SituacaoUnidade { get; set; }

        public string NomeAbreviadoUnidade { get; set; }

        public string RazaoSocialUnidade { get; set; }

        public string? CnpjUnidade { get; set; }

        public string? CpfUnidade { get; set; }

        public string? InscricaoEstadualUnidade { get; set; }

        public string? InscricaoMunicipalUnidade { get; set; }

        public string? CnoUnidade { get; set; }

        public DateTime? DataContratoUnidade { get; set; }

        public string? NumeroContratoUnidade { get; set; }

        public string? CnaeUnidade { get; set; }

        public string? CnaeLivreUnidade { get; set; }

        public string? CnaeSecundarioUnidade { get; set; }

        public string? GrauRiscoUnidade { get; set; }

        public string? DescricaoLocalUnidade { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public int IdEmpresa { get; set; }
    }
}

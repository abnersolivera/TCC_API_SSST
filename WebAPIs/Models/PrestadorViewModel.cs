using Entities.Enums;

namespace WebAPIs.Models
{
    public class PrestadorViewModel
    {
        public int IdPrestador { get; set; }

        public TipoSegmento? TipoPrestador { get; set; }

        public bool SitucaoPrestador { get; set; }

        public TipoPessoa? TipoPessoa { get; set; }

        public string NomePrestador { get; set; }

        public string? RazaoSocialPrestador { get; set; }

        public string? EnderecoPrestador { get; set; }

        public int? NumeroPrestador { get; set; }

        public string? ComplementoPrestador { get; set; }

        public string? CidadePrestador { get; set; }

        public string? EstadoPrestador { get; set; }

        public string? CepPrestador { get; set; }

        public bool? AtendentePrestador { get; set; }

        public string? telefone_Prestador { get; set; }

        public string? telefoneCelular_Prestador { get; set; }

        public string? email_Prestador { get; set; }

        public string? cnpj_Prestador { get; set; }

        public string? cpf_Prestador { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
    public class PrestadorIdViewModel
    {
        public int IdPrestador { get; set; }
    }
}

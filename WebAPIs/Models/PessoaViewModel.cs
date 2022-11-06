using Entities.Enums;

namespace WebAPIs.Models
{
    public class PessoaViewModel
    {
        public int IdPessoas { get; set; }

        public bool StatusPessoas { get; set; }

        public string NomePessoas { get; set; }

        public string? EnderecoPessoas { get; set; }

        public int? NumeroPessoas { get; set; }

        public string? ComplementoPessoas { get; set; }

        public string? BairroPessoas { get; set; }

        public string? CidadePessoas { get; set; }

        public string? EstadoPessoas { get; set; }

        public string? CepPessoas { get; set; }

        public string? RGPessoas { get; set; }

        public string? CPFPessoas { get; set; }

        public string? EmailPessoas { get; set; }

        public string? PISPessoas { get; set; }

        public string? RQEPessoas { get; set; }

        public string? SiglaConselhoDeClassePessoas { get; set; }

        public string? ConselhoDeClassePessoas { get; set; }

        public string? ConselhoDeClasseEstadoPessoas { get; set; }

        public TipoEspecialidade? EspecialidadePessoas { get; set; }

        public string? TelelefoneCelularPessoas { get; set; }

        public TipoProfissional? TipoPessoas { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

    }

    public class PessoaIdViewModel
    {
        public int IdPessoas { get; set; }
    }
}

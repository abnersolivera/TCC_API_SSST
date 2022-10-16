using Entities.Enums;

namespace WebAPIs.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Status { get; set; }

        public string? Endereco { get; set; }

        public int? Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        public string? Cep { get; set; }

        public string? RG { get; set; }

        public string? CPF { get; set; }

        public string? Email { get; set; }

        public string? PIS { get; set; }

        public string? RQE { get; set; }

        public string? SiglaConselhoDeClasse { get; set; }

        public string? ConselhoDeClasse { get; set; }

        public string? ConselhoDeClasseEstado { get; set; }

        public TipoEspecialidade? Especialidade { get; set; }

        public string? TelelefoneCelular { get; set; }

        public TipoProfissional? Tipo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

    }
}

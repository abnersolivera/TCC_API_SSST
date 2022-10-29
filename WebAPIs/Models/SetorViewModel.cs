namespace WebAPIs.Models
{
    public class SetorViewModel
    {
        public int IdSetor { get; set; }

        public bool SituacaoSetor { get; set; }

        public string NomeSetor { get; set; }

        public string? DescricaoSetor { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public int IdEmpresa { get; set; }

    }
}

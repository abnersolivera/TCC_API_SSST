using Entities.Enums;

namespace WebAPIs.Models
{
    public class EnderecoViewModel
    {
        public TipoEndereco TipoEndereco { get; set; }

        public string EnderecoEndereco { get; set; }

        public int NumeroEndereco { get; set; }

        public string? ComplementoEndereco { get; set; }

        public string CidadeEndereco { get; set; }

        public string EstadoEndereco { get; set; }

        public string CepEndereco { get; set; }

        public string? CodigoMunicipioEndereco { get; set; }

        public string TelefoneEndereco { get; set; }

        public string EmailEndereco { get; set; }
    }

    public class EnderecoIdViewModel
    {
        public int IdEndereco { get; set; }
    }

}

using Entities.Entities.Endereco;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class EnderecoEmpresaViewModel
    {
        public int IdEnderecoEmpresa { get; set; }

        public int IdEndereco { get; set; }

        public int IdEmpresa { get; set; }
    }
}

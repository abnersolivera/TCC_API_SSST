using Entities.Entities.Endereco;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class EnderecoUnidadeViewModel
    {
        public int IdEnderecoUnidade { get; set; }

        public int IdEndereco { get; set; }

        public int IdUnidade { get; set; }
    }
}

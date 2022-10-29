using Entities.Entities.Funcionarios;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class CargoViewModel
    {
        public int IdCargo { get; set; }

        public bool SituacaoCargo { get; set; }

        public string NomeCargo { get; set; }

        public string? DescricaoCargo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public int IdEmpresa { get; set; }

    }
}

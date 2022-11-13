using Entities.Entities.Funcionarios;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class CargoViewModel
    {
        public string NomeCargo { get; set; }

        public string? DescricaoCargo { get; set; }

        public int IdEmpresa { get; set; }

    }

    public class CargoIdViewModel
    {
        public int IdCargo { get; set; }
    }
}

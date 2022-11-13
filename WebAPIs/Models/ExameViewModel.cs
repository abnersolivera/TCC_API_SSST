using Entities.Entities.Prestadores;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Entities;

namespace WebAPIs.Models
{
    public class ExameViewModel
    {
        public string NomeExame { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public int IdPrestador { get; set; }
    }

    public class ExameIdViewModel
    {
        public int IdExame { get; set; }
    }

    public class ExameDetailsViewModel
    {        
        public List<ExameViewModel> ExameViewModel { get; set; }
       
        public Details Details { get; set; }
    }
}

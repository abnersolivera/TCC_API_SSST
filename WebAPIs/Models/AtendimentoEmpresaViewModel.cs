using Entities.Entities.Empresas;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class AtendimentoEmpresaViewModel
    {
        public int IdAtendimentoEmpresa { get; set; }

        public int IdEmpresa { get; set; }

        public int IdAtendimento { get; set; }
    }
}

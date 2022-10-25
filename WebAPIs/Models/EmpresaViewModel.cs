using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class EmpresaViewModel
    {

        public int IdEmpresa { get; set; }

        public bool SituacaoEmpresa { get; set; }

        public TipoCliente? TipoCliente { get; set; }

        public string NomeAbreviadoEmpresa { get; set; }

        public string RazaoSocialEmpresa { get; set; }

        public string? CnpjEmpresa { get; set; }

        public string? CpfEmpresa { get; set; }

        public string? InscricaoEstadualEmpresa { get; set; }

        public string? InscricaoMunicipalEmpresa { get; set; }

        public DateTime? DataContratoEmpresa { get; set; }

        public string? NumeroContratoEmpresa { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}

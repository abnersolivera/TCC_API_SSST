using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIs.Models
{
    public class EmpresaViewModel
    {    
        public TipoCliente? TipoCliente { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NomeAbreviadoEmpresa { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RazaoSocialEmpresa { get; set; }
        
        public string? CnpjEmpresa { get; set; }

        public string? CpfEmpresa { get; set; }

        public string? InscricaoEstadualEmpresa { get; set; }

        public string? InscricaoMunicipalEmpresa { get; set; }

        public DateTime? DataContratoEmpresa { get; set; }

        public string? NumeroContratoEmpresa { get; set; }
    }

    public class EmpresaIdViewModel
    {
        public int IdEmpresa { get; set; }
    }

    public class EmpresaDTO
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

    public class EmpresaFuncionarioDTO
    {
        public string RazaoSocialEmpresa { get; set; }

    }
}

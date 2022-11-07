using Entities.Enums;

namespace WebAPIs.Models
{
    public class FuncionarioViewModel
    {
        public int IdFuncionario { get; set; }

        public bool SituacaoFuncionario { get; set; }

        public string? NomeFuncionario { get; set; }

        public DateTime DataNascimentoFuncionario { get; set; }

        public string? CpfFuncionario { get; set; }

        public string? RgFuncionario { get; set; }

        public string? PisFuncionario { get; set; }

        public string? TelefoneFuncionario { get; set; }

        public string? EmailFuncionario { get; set; }

        public TipoSexo SexoFuncionario { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataAdmissao { get; set; }

        public DateTime? DataDemissao { get; set; }

        public int IdCargo { get; set; }

        public int IdSetor { get; set; }

        public int IdEmpresa { get; set; }
    }

    public class FuncionarioIdViewModel
    {
        public int IdFuncionario { get; set; }
    }
}

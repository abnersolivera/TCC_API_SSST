using Entities.Entities.Empresas;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Pessoas
{
    [Table("Pessoa")]
    public class Pessoa : Notifies
    {
        [Key()]
        [Column("id_Pessoas")]
        public int IdPessoas { get; set; }

        [Column("status_Pessoas")]
        public bool StatusPessoas { get; set; }

        [Column("nome_Pessoas")]
        [MaxLength(100)]
        public string NomePessoas { get; set; }

        [Column("endereco_Pessoas")]
        [MaxLength(100)]
        public string? EnderecoPessoas { get; set; }

        [Column("numero_Pessoas")]
        public int NumeroPessoas { get; set; }

        [Column("complemento_Pessoas")]
        [MaxLength(100)]
        public string? ComplementoPessoas { get; set; }

        [Column("bairro_Pessoas")]
        [MaxLength(50)]
        public string? BairroPessoas { get; set; }

        [Column("cidade_Pessoas")]
        [MaxLength(100)]
        public string? CidadePessoas { get; set; }

        [Column("estado_Pessoas")]
        [MaxLength(50)]
        public string? EstadoPessoas { get; set; }

        [Column("cep_Pessoas")]
        [MaxLength(10)]
        public string? CepPessoas { get; set; }

        [Column("rg_Pessoas")]
        [MaxLength(25)]
        public string? RGPessoas { get; set; }

        [Column("cpf_Pessoas")]
        [MaxLength(25)]
        public string? CPFPessoas { get; set; }

        [Column("email_Pessoas")]
        [MaxLength(30)]
        public string? EmailPessoas { get; set; }

        [Column("pis_Pessoas")]
        [MaxLength(25)]
        public string? PISPessoas { get; set; }

        [Column("rqe_Pessoas")]
        [MaxLength(20)]
        public string? RQEPessoas { get; set; }

        [Column("siglaConselhoDeClasse_Pessoas")]
        [MaxLength(10)]
        public string? SiglaConselhoDeClassePessoas { get; set; }

        [Column("conselhoDeClasse_Pessoas")]
        [MaxLength(25)]
        public string? ConselhoDeClassePessoas { get; set; }

        [Column("conselhoDeClasseEstado_Pessoas")]
        [MaxLength(5)]
        public string? ConselhoDeClasseEstadoPessoas { get; set; }

        [Column("especialidade_Pessoas")]
        public TipoEspecialidade? EspecialidadePessoas { get; set; }

        [Column("telelefoneCelular_Pessoas")]
        [MaxLength(25)]
        public string? TelelefoneCelularPessoas { get; set; }

        [Column("tipo_Pessoas")]
        public TipoProfissional? TipoPessoas { get; set; }

        [Column("dataCadastro_Pessoas")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Pessoas")]
        public DateTime DataAlteracao { get; set; }

        public ICollection<PessoaEmpresa> PessoaEmpresa { get; set; }

    }
}

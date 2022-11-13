using Entities.Entities.Endereco;
using Entities.Entities.Pessoas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Empresas
{
    [Table("Unidade")]
    public class Unidade : Notifies
    {
        [Key()]
        [Column("id_Unidade")]
        public int IdUnidade { get; set; }

        [Column("situacao_Unidade")]
        public bool SituacaoUnidade { get; set; }

        [Column("nomeAbreviado_Unidade")]
        [MaxLength(255)]
        public string NomeAbreviadoUnidade { get; set; }

        [Column("razaoSocial_Unidade")]
        [MaxLength(255)]
        public string RazaoSocialUnidade { get; set; }

        [Column("cnpj_Unidade")]
        [MaxLength(20)]
        public string? CnpjUnidade { get; set; }

        [Column("cpf_Unidade")]
        [MaxLength(15)]
        public string? CpfUnidade { get; set; }

        [Column("inscricaoEstadual_Unidade")]
        [MaxLength(20)]
        public string? InscricaoEstadualUnidade { get; set; }

        [Column("inscricaoMunicipal_Unidade")]
        [MaxLength(20)]
        public string? InscricaoMunicipalUnidade { get; set; }

        [Column("cno_Unidade")]
        [MaxLength(20)]
        public string? CnoUnidade { get; set; }

        [Column("dataContrato_Unidade")]
        public DateTime? DataContratoUnidade { get; set; }

        [Column("numeroContrato_Unidade")]
        [MaxLength(20)]
        public string? NumeroContratoUnidade { get; set; }

        [Column("dataCadastro_Unidade")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Unidade")]
        public DateTime DataAlteracao { get; set; }

        [Column("cnae_Unidade")]
        [MaxLength(20)]
        public string? CnaeUnidade { get; set; }

        [Column("cnaeLivre_Unidade")]
        [MaxLength(20)]
        public string? CnaeLivreUnidade { get; set; }

        [Column("cnaeSecundario_Unidade")]
        [MaxLength(20)]
        public string? CnaeSecundarioUnidade { get; set; }

        [Column("grauRisco_Unidade")]
        [MaxLength(20)]
        public string? GrauRiscoUnidade { get; set; }

        [Column("descricaoLocal_Unidade")]
        [MaxLength(255)]
        public string? DescricaoLocalUnidade { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        public ICollection<EnderecoUnidade> EnderecoUnidade { get; set; }
    }
}

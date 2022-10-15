using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Pessoas
{
    [Table("Pessoa")]
    public class Pessoa : Notifies
    {
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
        public string? Estado_Pessoas { get; set; }

        [Column("cep_Pessoas")]
        [MaxLength(10)]
        public string? Cep_Pessoas { get; set; }

        [Column("rg_Pessoas")]
        [MaxLength(20)]
        public string? RG_Pessoas { get; set; }

        [Column("cpf_Pessoas")]
        [MaxLength(15)]
        public string? CPF_Pessoas { get; set; }

        [Column("email_Pessoas")]
        [MaxLength(30)]
        public string? Email_Pessoas { get; set; }

        [Column("pis_Pessoas")]
        [MaxLength(20)]
        public string? PIS_Pessoas { get; set; }

        [Column("rqe_Pessoas")]
        [MaxLength(20)]
        public string? RQE_Pessoas { get; set; }

        [Column("siglaConselhoDeClasse_Pessoas")]
        [MaxLength(10)]
        public string? SiglaConselhoDeClasse_Pessoas { get; set; }

        [Column("conselhoDeClasse_Pessoas")]
        [MaxLength(15)]
        public string? ConselhoDeClasse_Pessoas { get; set; }

        [Column("conselhoDeClasseEstado_Pessoas")]
        [MaxLength(5)]
        public string? ConselhoDeClasseEstado_Pessoas { get; set; }

        [Column("especialidade_Pessoas")]
        public TipoEspecialidade? Especialidade_Pessoas { get; set; }

        [Column("telelefoneCelular_Pessoas")]
        [MaxLength(15)]
        public string? TelelefoneCelular_Pessoas { get; set; }

        [Column("tipo_Pessoas")]
        public TipoProfissional? Tipo_Pessoas { get; set; }

        [Column("dataCadastro_Pessoas")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Pessoas")]
        public DateTime DataAlteracao { get; set; }

    }
}

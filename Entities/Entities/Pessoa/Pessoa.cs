using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Pessoa
{
    [Table("Pessoa")]
    public class Pessoa : Notifies
    {
        [Column("id_Pessoas")]
        public int IdPessoas { get; set; }

        [Column("Status_Pessoas")]
        public bool StatusPessoas { get; set; }

        [Column("Nome_Pessoas")]
        [MaxLength(100)]
        public string NomePessoas { get; set; }

        [Column("Endereco_Pessoas")]
        [MaxLength(100)]
        public string EnderecoPessoas { get; set; }

        [Column("Numero_Pessoas")]
        public int NumeroPessoas { get; set; }

        [Column("Complemento_Pessoas")]
        [MaxLength(100)]
        public string ComplementoPessoas { get; set; }

        [Column("Bairro_Pessoas")]
        [MaxLength(50)]
        public string BairroPessoas { get; set; }

        [Column("Cidade_Pessoas")]
        [MaxLength(100)]
        public string CidadePessoas { get; set; }

        [Column("Estado_Pessoas")]
        [MaxLength(50)]
        public string Estado_Pessoas { get; set; }

        [Column("Cep_Pessoas")]
        [MaxLength(10)]
        public string Cep_Pessoas { get; set; }

        [Column("RG_Pessoas")]
        [MaxLength(20)]
        public string RG_Pessoas { get; set; }

        [Column("CPF_Pessoas")]
        [MaxLength(15)]
        public string CPF_Pessoas { get; set; }

        [Column("E -mail_Pessoas")]
        [MaxLength(30)]
        public string mail_Pessoas { get; set; }

        [Column("PIS_Pessoas")]
        [MaxLength(20)]
        public string PIS_Pessoas { get; set; }

        [Column("RQE_Pessoas")]
        [MaxLength(20)]
        public string RQE_Pessoas { get; set; }

        [Column("SiglaConselhoDeClasse_Pessoas")]
        [MaxLength(10)]
        public string SiglaConselhoDeClasse_Pessoas { get; set; }

        [Column("ConselhoDeClasse_Pessoas")]
        [MaxLength(15)]
        public string ConselhoDeClasse_Pessoas { get; set; }

        [Column("ConselhoDeClasseEstado_Pessoas")]
        [MaxLength(5)]
        public string ConselhoDeClasseEstado_Pessoas { get; set; }

        [Column("Especialidade_Pessoas")]
        public TipoEspecialidade? Especialidade_Pessoas { get; set; }

        [Column("TelelefoneCelular_Pessoas")]
        [MaxLength(15)]
        public string TelelefoneCelular_Pessoas { get; set; }

        [Column("Tipo_Pessoas")]
        public TipoProfissional? Tipo_Pessoas { get; set; }

        [Column("DataCadastro_Pessoas")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao_Pessoas")]
        public DateTime DataAlteracao { get; set; }

    }
}

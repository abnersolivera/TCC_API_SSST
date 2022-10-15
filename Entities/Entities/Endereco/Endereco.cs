using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Endereco
{
    [Table("Endereco")]
    public class Endereco : Notifies
    {
        [Column("id_Endereco")]
        public int IdEndereco { get; set; }

        [Column("status_Endereco")]
        public bool StatusEndereco { get; set; }

        [Column("tipo_Endereco")]
        public TipoEndereco TipoEndereco { get; set; }

        [Column("endereco_Endereco")]
        [MaxLength(100)]
        public string EnderecoEndereco { get; set; }

        [Column("numero_Endereco")]
        public int NumeroEndereco { get; set; }

        [Column("complemento_Endereco")]
        [MaxLength(100)]
        public string? ComplementoEndereco { get; set; }

        [Column("cidade_Endereco")]
        [MaxLength(100)]
        public string CidadeEndereco { get; set; }

        [Column("estado_Endereco")]
        [MaxLength(50)]
        public string EstadoEndereco { get; set; }

        [Column("cep_Endereco")]
        [MaxLength(20)]
        public string CepEndereco { get; set; }

        [Column("codigoMunicipio_Endereco")]
        [MaxLength(20)]
        public string? CodigoMunicipioEndereco { get; set; }

        [Column("telefone_Endereco")]
        [MaxLength(15)]
        public string TelefoneEndereco { get; set; }

        [Column("email_Endereco")]
        [MaxLength(30)]
        public string EmailEndereco { get; set; }

        [Column("dataCadastro_Endereco")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Endereco")]
        public DateTime DataAlteracao { get; set; }
    }
}

﻿using Entities.Entities.Empresas;
using Entities.Entities.Exames;
using Entities.Entities.Riscos;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Prestadores
{
    [Table("Prestador")]
    public class Prestador : Notifies
    {
        [Key()]
        [Column("id_Prestador")]
        public int IdPrestador { get; set; }

        [Column("tipoPrestador_Prestador")]
        public TipoSegmento? TipoPrestador { get; set; }

        [Column("situcao_Prestador")]
        public bool SitucaoPrestador { get; set; }

        [Column("tipoPessoa_Prestador")]
        public TipoPessoa? TipoPessoa { get; set; }

        [Column("nome_Prestador")]
        [MaxLength(255)]
        public string NomePrestador { get; set; }

        [Column("razaoSocial_Prestador")]
        [MaxLength(255)]
        public string? RazaoSocialPrestador { get; set; }

        [Column("endereco_Prestador")]
        [MaxLength(100)]
        public string? EnderecoPrestador { get; set; }

        [Column("numero_Prestador")]
        public int? NumeroPrestador { get; set; }

        [Column("complemento_Prestador")]
        [MaxLength(100)]
        public string? ComplementoPrestador { get; set; }

        [Column("cidade_Prestador")]
        [MaxLength(100)]
        public string? CidadePrestador { get; set; }

        [Column("estado_Prestador")]
        [MaxLength(5)]
        public string? EstadoPrestador { get; set; }

        [Column("cep_Prestador")]
        [MaxLength(50)]
        public string? CepPrestador { get; set; }

        [Column("atendente_Prestador")]
        public bool? AtendentePrestador { get; set; }

        [Column("telefone_Prestador")]
        [MaxLength(50)]
        public string? telefone_Prestador { get; set; }

        [Column("telefoneCelular_Prestador")]
        [MaxLength(50)]
        public string? telefoneCelular_Prestador { get; set; }

        [Column("email_Prestador")]
        [MaxLength(50)]
        public string? email_Prestador { get; set; }

        [Column("cnpj_Prestador")]
        [MaxLength(50)]
        public string? cnpj_Prestador { get; set; }

        [Column("cpf_Prestador")]
        [MaxLength(50)]
        public string? cpf_Prestador { get; set; }

        [Column("dataCadastro_Prestador")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Prestador")]
        public DateTime DataAlteracao { get; set; }

        public ICollection<Exame> Exame { get; set; }

        public ICollection<Risco> Risco { get; set; }

        public ICollection<PrestadorEmpresa> PrestadorEmpresa { get; set; }
    }
}

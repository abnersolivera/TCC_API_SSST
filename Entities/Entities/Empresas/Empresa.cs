﻿using Entities.Entities.Cargos;
using Entities.Entities.Endereco;
using Entities.Entities.Funcionarios;
using Entities.Entities.Setores;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Empresas
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key()]
        [Column("id_Empresa")]
        public int IdEmpresa { get; set; }

        [Column("situacao_Empresa")]
        public bool SituacaoEmpresa { get; set; }

        [Column("tipoCliente_Empresa")]
        public TipoCliente? TipoCliente { get; set; }

        [Column("tipoPessoa_Empresa")]
        public TipoPessoa? TipoPessoa { get; set; }

        [Column("nomeAbreviado_Empresa")]
        [MaxLength(255)]
        public string NomeAbreviadoEmpresa { get; set; }

        [Column("razaoSocial_Empresa")]
        [MaxLength(255)]
        public string RazaoSocialEmpresa { get; set; }

        [Column("cnpj_Empresa")]
        [MaxLength(20)]
        public string? CnpjEmpresa { get; set; }

        [Column("cpf_Empresa")]
        [MaxLength(15)]
        public string? CpfEmpresa { get; set; }

        [Column("inscricaoEstadual_Empresa")]
        [MaxLength(20)]
        public string? InscricaoEstadualEmpresa { get; set; }

        [Column("inscricaoMunicipal_Empresa")]
        [MaxLength(20)]
        public string? InscricaoMunicipalEmpresa { get; set; }

        [Column("dataContrato_Empresa")]
        public DateTime? DataContratoEmpresa { get; set; }

        [Column("numeroContrato_Empresa")]
        [MaxLength(20)]
        public string? NumeroContratoEmpresa { get; set; }

        [Column("dataCadastro_Empresa")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Empresa")]
        public DateTime DataAlteracao { get; set; }

        public ICollection<Cargo> Cargo { get; set; }

        public ICollection<Setor> Setor { get; set; }

        public ICollection<PrestadorEmpresa> PrestadorEmpresa { get; set; }

        public ICollection<PessoaEmpresa> PessoaEmpresa { get; set; }

        public ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; }

        public ICollection<Unidade> Unidade { get; set; }

        public ICollection<EnderecoEmpresa> EnderecoEmpresa { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }

        public ICollection<AtendimentoEmpresa> AtendimentoEmpresa { get; set; }

    }
}

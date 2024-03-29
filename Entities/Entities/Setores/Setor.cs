﻿using Entities.Entities.Empresas;
using Entities.Entities.Funcionarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Setores
{
    [Table("Setor")]
    public class Setor : Notifies
    {
        [Key()]
        [Column("id_Setor")]
        public int IdSetor { get; set; }

        [Column("situacao_Setor")]
        public bool SituacaoSetor { get; set; }

        [Column("nome_Setor")]
        [MaxLength(100)]
        public string NomeSetor { get; set; }

        [Column("descricao_Setor")]
        [MaxLength(255)]
        public string? DescricaoSetor { get; set; }

        [Column("dataCadastro_Setor")]
        public DateTime DataCadastro { get; set; }

        [Column("dataAlteracao_Setor")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }

    }
}

﻿using Entities.Entities.Atendimentos;
using Entities.Entities.Empresas;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("Status_Usuario")]
        public bool StatusUsuario { get; set; }

        [Column("CaminhoImagem_Usuario")]
        [MaxLength(100)]
        public string? CaminhoImagem { get; set; }

        [Column("Nome_Usuario")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Column("Tipo_Usuario")]
        public TipoUsuario? Tipo { get; set; }

        [Column("UltimoAcesso_Usuario")]
        public DateTime? UltimoAcesso { get; set; }

        public ICollection<PessoaEmpresa> PessoaEmpresa { get; set; }
        public ICollection<Atendimento> Atendimento { get; set; }
    }
}

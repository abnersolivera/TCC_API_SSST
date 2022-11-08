using Entities.Entities.Atendimentos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Empresas
{
    [Table("AtendimentoEmpresa")]
    public class AtendimentoEmpresa : Notifies
    {
        [Key()]
        [Column("id_AtendimentoEmpresa")]
        public int IdAtendimentoEmpresa { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("Atendimento")]
        public int IdAtendimento { get; set; }
        public virtual Atendimento Atendimento { get; set; }
    }
}

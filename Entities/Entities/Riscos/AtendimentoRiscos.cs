using Entities.Entities.Atendimentos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Riscos
{
    [Table("AtendimentoRiscos")]
    public class AtendimentoRiscos : Notifies
    {
        [Key()]
        [Column("id_AtendimentoRiscos")]
        public int IdAtendimentoRiscos { get; set; }

        [ForeignKey("Risco")]
        public int IdRisco { get; set; }
        public virtual Risco Risco { get; set; }

        [ForeignKey("Atendimento")]
        public int IdAtendimento { get; set; }
        public virtual Atendimento Atendimento { get; set; }
    }
}

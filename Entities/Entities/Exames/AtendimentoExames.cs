using Entities.Entities.Atendimentos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Exames
{
    [Table("AtendimentoExames")]
    public class AtendimentoExames : Notifies
    {
        [Key()]
        [Column("id_AtendimentoEmpresa")]
        public int IdAtendimentoExames { get; set; }

        [ForeignKey("Exame")]
        public int IdExame { get; set; }
        public virtual Exame Exame { get; set; }

        [ForeignKey("Atendimento")]
        public int IdAtendimento { get; set; }
        public virtual Atendimento Atendimento { get; set; }
    }
}

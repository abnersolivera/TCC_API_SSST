using Entities.Entities.Atendimentos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Funcionarios
{
    [Table("AtendimentoFuncionario")]
    public class AtendimentoFuncionario : Notifies
    {
        [Key()]
        [Column("id_AtendimentoFuncionario")]
        public int IdAtendimentoFuncionario { get; set; }

        [ForeignKey("Atendimento")]
        public int IdAtendimento { get; set; }
        public virtual Atendimento Atendimento { get; set; }

        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}

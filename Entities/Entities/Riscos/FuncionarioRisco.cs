using Entities.Entities.Funcionarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Riscos
{
    [Table("FuncionarioRisco")]
    public class FuncionarioRisco : Notifies
    {
        [Key()]
        [Column("id_FuncionarioRisco")]
        public int IdFuncionarioExames { get; set; }

        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [ForeignKey("Risco")]
        public int IdRisco { get; set; }
        public virtual Risco Risco { get; set; }
    }
}

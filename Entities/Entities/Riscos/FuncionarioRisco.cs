using Entities.Entities.Funcionarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Riscos
{
    public class FuncionarioRisco : Notifies
    {
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

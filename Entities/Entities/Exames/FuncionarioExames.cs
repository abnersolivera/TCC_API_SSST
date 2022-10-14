using Entities.Entities.Funcionarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Exames
{
    public class FuncionarioExames : Notifies
    {
        [Column("id_FuncionarioExames")]
        public int IdFuncionarioExames { get; set; }

        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        [ForeignKey("Exame")]
        public int IdExame { get; set; }
        public virtual Exame Exame { get; set; }
    }
}

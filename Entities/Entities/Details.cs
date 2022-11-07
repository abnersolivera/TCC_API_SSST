using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Details
    {
        [NotMapped]
        public int Skip { get; set; }

        [NotMapped]
        public int Take { get; set; }

        [NotMapped]
        public int PageTotal { get; set; }

        [NotMapped]
        public int PageQuantity { get; set; }
    }
}

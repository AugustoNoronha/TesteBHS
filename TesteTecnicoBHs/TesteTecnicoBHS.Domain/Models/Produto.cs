using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoBHS.Domain.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public Boolean Status { get; set; }

    }
}

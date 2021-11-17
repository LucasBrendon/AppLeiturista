using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Leiturista : Base
    {
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public List<Leitura> Leituras { get; set; }
    }
}

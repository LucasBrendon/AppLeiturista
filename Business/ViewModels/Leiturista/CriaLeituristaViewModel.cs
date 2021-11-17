using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Leiturista
{
    public class CriaLeituristaViewModel
    {
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Leiturista
{
    public class ExibiLeituristaViewModel
    {
        public long Id { get; set; }
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}

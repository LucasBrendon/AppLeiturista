using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Ocorrencia
{
    public class ExibirOcorrenciaViewModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public bool PermiteLeitura { get; set; }
        public decimal Valor { get; set; }
    }
}

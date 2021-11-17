using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Leitura
{
    public class CriarLeituraViewModel
    {
        public long CodigoCliente { get; set; }
        public long LeituraAnterior { get; set; }
        public long LeituraAtual { get; set; }
        public long LeituristaId { get; set; }
        public long OcorrenciaId { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }

    }
}

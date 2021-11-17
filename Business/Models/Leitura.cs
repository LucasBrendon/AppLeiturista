using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Leitura : Base
    {
        public long CodigoCliente { get; set; }
        public long LeituraAnterior { get; set; }
        public long? LeituraAtual { get; set; }
        public long LeituristaId { get; set; }
        public Leiturista Leiturista { get; set; }
        public long OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public DateTime DataLeitura { get; set; }

    }
}

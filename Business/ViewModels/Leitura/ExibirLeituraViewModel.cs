using Business.ViewModels.Leiturista;
using Business.ViewModels.Ocorrencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Leitura
{
    public class ExibirLeituraViewModel
    {
        public long CodigoCliente { get; set; }
        public long LeituraAnterior { get; set; }
        public long LeituraAtual { get; set; }
        public ExibiLeituristaViewModel LeituristaId { get; set; }
        public ExibirOcorrenciaViewModel OcorrenciaId { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public DateTime DataLeitura { get; set; }
    }
}

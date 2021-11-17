using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface ILeituraRepository : IBaseRepository<Leitura>
    {
        Task<Leitura> BuscarPorCodigoCliente(long codigoCliente);
        Task<List<Leitura>> BuscarPorData(int mes);
        Task<bool> RetornaStatusAtivoLeiturista(long leituristaId);
        Task<bool> RetornaStatusOcorrenciaPermiteLeitura(long ocorrenciaId);
    }
}

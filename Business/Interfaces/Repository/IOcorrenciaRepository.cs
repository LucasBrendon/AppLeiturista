using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IOcorrenciaRepository : IBaseRepository<Ocorrencia>
    {
        Task<List<Ocorrencia>> BuscarPorDescricao(string descricao);
    }
}

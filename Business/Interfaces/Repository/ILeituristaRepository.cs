using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface ILeituristaRepository : IBaseRepository<Leiturista>
    {
        Task<Leiturista> BuscarPorMatricula(long matricula);
        Task<List<Leiturista>> BuscarPorNome(string nome);
        Task<List<Leiturista>> BuscarPorStatusAtivoOuInativo(bool status);
    }
}

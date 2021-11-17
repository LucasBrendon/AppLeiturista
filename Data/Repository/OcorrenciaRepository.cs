using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OcorrenciaRepository : BaseRepository<Ocorrencia>, IOcorrenciaRepository
    {
        private readonly MeuDbContext _context;

        public OcorrenciaRepository(MeuDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Ocorrencia>> BuscarPorDescricao(string descricao)
        {
            return await Buscar(x => x.Descricao.Contains(descricao));
        }
    }
}

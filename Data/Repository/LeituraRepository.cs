using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LeituraRepository : BaseRepository<Leitura>, ILeituraRepository
    {
        private readonly MeuDbContext _context;
        public LeituraRepository(MeuDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Leitura>> BuscarTodos()
        {
            return await _context.Leituras.AsNoTracking()
                .Include(x => x.Leiturista)
                .Include(x => x.Ocorrencia)
                .ToListAsync();
        }

        public override async Task<Leitura> BuscarPorId(long id)
        {
            return await _context.Leituras.AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Leiturista)
                .Include(x => x.Ocorrencia)
                .FirstOrDefaultAsync();
        }

        public async Task<Leitura> BuscarPorCodigoCliente(long codigoCliente)
        {
            return await _context.Leituras.AsNoTracking()
                .Where(x => x.CodigoCliente.Equals(codigoCliente))
                .Include(x => x.Leiturista)
                .Include(x => x.Ocorrencia)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Leitura>> BuscarPorData(int mes)
        {
            return await _context.Leituras.AsNoTracking()
               .Where(x => x.DataLeitura.Month.Equals(mes))
               .Include(x => x.Leiturista)
               .Include(x => x.Ocorrencia)
               .ToListAsync();
        }

        public async Task<bool> RetornaStatusAtivoLeiturista(long leituristaId)
        {
            var leiturista = await _context.Leituristas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(leituristaId));

            return leiturista.Ativo;
        }

        public async Task<bool> RetornaStatusOcorrenciaPermiteLeitura(long ocorrenciaId)
        {
            var ocorrencia = await _context.Ocorrencias.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(ocorrenciaId));

            return ocorrencia.PermiteLeitura;
        }
    }
}

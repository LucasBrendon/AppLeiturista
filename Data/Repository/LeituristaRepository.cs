using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LeituristaRepository : BaseRepository<Leiturista>, ILeituristaRepository
    {
        private readonly MeuDbContext _context;

        public LeituristaRepository(MeuDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Leiturista> BuscarPorMatricula(long matricula)
        {
            return await _context.Leituristas.AsNoTracking()
                .Where(x => x.Matricula.Equals(matricula))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Leiturista>> BuscarPorNome(string nome)
        {
            return await Buscar(x => x.Nome.Contains(nome));
        }

        public async Task<List<Leiturista>> BuscarPorStatusAtivoOuInativo(bool status)
        {
            return await Buscar(x => x.Ativo.Equals(status));
        }
    }
}

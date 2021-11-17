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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly MeuDbContext _context;

        public UsuarioRepository(MeuDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscaPorEmail(string email)
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
        }

    }
}

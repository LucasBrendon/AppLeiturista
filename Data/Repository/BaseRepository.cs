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
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly MeuDbContext _context;

        public BaseRepository(MeuDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> Buscar(Expression<Func<T, bool>> predicado)

        {
            return await _context.Set<T>().AsNoTracking().Where(predicado).ToListAsync();
        }

        public virtual async Task<List<T>> BuscarTodos()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> BuscarPorId(long id)
        {
            return await _context.Set<T>().AsNoTracking().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task Cadastrar(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Atualizar(T obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Deletar(T obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}

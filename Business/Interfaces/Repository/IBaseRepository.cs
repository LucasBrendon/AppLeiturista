using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<List<T>> Buscar(Expression<Func<T, bool>> predicado);
        Task<List<T>> BuscarTodos();
        Task<T> BuscarPorId(long id);
        Task Cadastrar(T obj);
        Task Atualizar(T obj);
        Task Deletar(T obj);    
    }
}

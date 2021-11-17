using Business.Models;
using Business.ViewModels.Leiturista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface ILeituristaService
    {
        Task<List<ExibiLeituristaViewModel>> BuscarTodos();
        Task<ExibiLeituristaViewModel> BuscarPorId(long id);
        Task<bool> Cadastrar(CriaLeituristaViewModel leiturista);
        Task<bool> Atualizar(CriaLeituristaViewModel leiturista);
        Task<bool> Deletar(long matricula);
        Task<ExibiLeituristaViewModel> BuscarPorMatricula(long matricula);
        Task<List<ExibiLeituristaViewModel>> BuscarPorNome(string nome);
        Task<List<ExibiLeituristaViewModel>> BuscarPorStatusAtivoOuInativo(bool status);
    }
}

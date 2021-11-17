using Business.Models;
using Business.ViewModels.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<ExibirUsuarioViewModel>> BuscarTodos();
        Task<ExibirUsuarioViewModel> BuscarPorId(long id);
        Task<bool> Cadastrar(CriarUsuarioViewModel usuario);
        Task<bool> Atualizar(EditarUsuarioViewModel usuario);
        Task<bool> Deletar(long id);
        Task<Usuario> login(LoginViewModel login);
    }
}

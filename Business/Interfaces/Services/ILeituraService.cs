using Business.ViewModels.Leitura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface ILeituraService
    {
        Task<List<ExibirLeituraViewModel>> BuscarTodos();
        Task<ExibirLeituraViewModel> BuscarPorId(long id);
        Task<ExibirLeituraViewModel> BuscarPorCodigoCliente(long codigoCliente);
        Task<List<ExibirLeituraViewModel>> BuscarPorData(int mes);
        Task<bool> Cadastrar(CriarLeituraViewModel leitura);
        Task<bool> Atualizar(EditarLeituraViewModel leitura);
        Task<bool> Deletar(long id);
        
    }
}

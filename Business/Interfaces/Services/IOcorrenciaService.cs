using Business.Models;
using Business.ViewModels.Ocorrencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IOcorrenciaService
    {
        Task<List<ExibirOcorrenciaViewModel>> BuscarTodos();
        Task<ExibirOcorrenciaViewModel> BuscarPorId(long id);
        Task<List<ExibirOcorrenciaViewModel>> BuscarPorDescricao(string descricao);
        Task<bool> Cadastrar(CriarOcorrenciaViewModel obj);
        Task<bool> Atualizar(ExibirOcorrenciaViewModel obj);
        Task<bool> Deletar(long id);
    }
}

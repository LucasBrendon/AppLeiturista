using AutoMapper;
using Business.Interfaces.Notification;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Business.Notifications;
using Business.Validations;
using Business.ViewModels.Leiturista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LeituristaService : NotificacaoService, ILeituristaService
    {
        private readonly ILeituristaRepository _leituristaRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public LeituristaService(ILeituristaRepository leituristaRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _leituristaRepository = leituristaRepository;
            _mapper = mapper;
            _notificador = notificador;
         }

        public async Task<List<ExibiLeituristaViewModel>> BuscarTodos()
        {
            return _mapper.Map<List<ExibiLeituristaViewModel>>(await _leituristaRepository.BuscarTodos());
        }

        public async Task<ExibiLeituristaViewModel> BuscarPorId(long id)
        {
            var leiturista = _mapper.Map<ExibiLeituristaViewModel>(await _leituristaRepository.BuscarPorId(id));

            if (leiturista == null)
            {
                _notificador.Adicionar(new Notificacao("Leiturista não encontrado"));
            }

            return leiturista;
        }

        public async Task<ExibiLeituristaViewModel> BuscarPorMatricula(long matricula)
        {
            var leiturista = _mapper.Map<ExibiLeituristaViewModel>(await _leituristaRepository.BuscarPorMatricula(matricula));

            if (leiturista == null)
            {
                _notificador.Adicionar(new Notificacao("Leiturista não encontrado"));
            }

            return leiturista;
        }

        public async Task<List<ExibiLeituristaViewModel>> BuscarPorNome(string nome)
        {
            var leituristas = _mapper.Map<List<ExibiLeituristaViewModel>>(await _leituristaRepository.BuscarPorNome(nome));

            if (leituristas.Count == 0)
            {
                _notificador.Adicionar(new Notificacao("Leiturista não encontrado"));
            }

            return leituristas;
        }

        public async Task<List<ExibiLeituristaViewModel>> BuscarPorStatusAtivoOuInativo(bool status)
        {
            var leituristas = _mapper.Map<List<ExibiLeituristaViewModel>>(await _leituristaRepository.BuscarPorStatusAtivoOuInativo(status));

            if(leituristas.Count == 0)
            {
                _notificador.Adicionar(new Notificacao("Nenhum leiturista com status ativo " + status + " encontrado"));
            }
            return leituristas;
        }

        public async Task<bool> Cadastrar(CriaLeituristaViewModel leiturista)
        {
            
            var leituristaExiste = await _leituristaRepository.BuscarPorMatricula(leiturista.Matricula);
            var leituristaMapeado = _mapper.Map<Leiturista>(leiturista);

            if (leituristaExiste != null)
            {
                _notificador.Adicionar(new Notificacao("Leiturista já cadastrado!"));
                return false;
            }

            if (!ExecutarValidacao(new LeituristaValidator(), leituristaMapeado))
            {
                return false;
            }

            await _leituristaRepository.Cadastrar(leituristaMapeado);
            return true;
        }

        public async Task<bool> Atualizar(CriaLeituristaViewModel leiturista)
        {
           var leituristaExiste = await _leituristaRepository.BuscarPorMatricula(leiturista.Matricula);

           if(leituristaExiste == null)
            {
                _notificador.Adicionar(new Notificacao("Leiturista não encontrado"));
                return false;
            }

            var leituristaMapeado = _mapper.Map<Leiturista>(leiturista);
            leituristaMapeado.Id = leituristaExiste.Id;

            if (!ExecutarValidacao(new LeituristaValidator(), leituristaMapeado))
            {
                return false;
            }

            await _leituristaRepository.Atualizar(leituristaMapeado);
            return true;
        }

        public async Task<bool> Deletar(long matricula)
        {
            var leiturista = await _leituristaRepository.BuscarPorMatricula(matricula);

            if(leiturista == null)
            {
                _notificador.Adicionar(new Notificacao("Leiturista não encontrado"));
                return false;
            }
            if (leiturista.Ativo)
            {
                _notificador.Adicionar(new Notificacao("Não é possível excluir um leiturista que esteja com status ativo"));
                return false;
            }

            await _leituristaRepository.Deletar(leiturista);
            return true;
        }
    }
}

using AutoMapper;
using Business.Interfaces.Notification;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Business.Notifications;
using Business.Validations;
using Business.ViewModels.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : NotificacaoService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _notificador = notificador;
        }

        public async Task<List<ExibirUsuarioViewModel>> BuscarTodos()
        {
            return _mapper.Map<List<ExibirUsuarioViewModel>>(await _usuarioRepository.BuscarTodos());
        }

        public async Task<ExibirUsuarioViewModel> BuscarPorId(long id)
        {
            var usuario =  _mapper.Map<ExibirUsuarioViewModel>(await _usuarioRepository.BuscarPorId(id));

            if(usuario == null)
            {
                _notificador.Adicionar(new Notificacao("Usuário não encontrado"));
            }

            return usuario;
        }

        public async Task<bool> Cadastrar(CriarUsuarioViewModel usuario)
        {
            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            if(!ExecutarValidacao(new UsuarioValidator(), usuarioMapeado))
            {
                return false;
            }

            await _usuarioRepository.Cadastrar(usuarioMapeado);
            return true;
        }

        public async Task<bool> Atualizar(EditarUsuarioViewModel usuario)
        {
            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            var usuarioExiste = await _usuarioRepository.BuscarPorId(usuarioMapeado.Id);

            if (usuarioExiste == null)
            {
                _notificador.Adicionar(new Notificacao("Usuário não existente"));
                return false;
            }

            if (!ExecutarValidacao(new UsuarioValidator(), usuarioMapeado))
            {
                return false;
            }

            await _usuarioRepository.Atualizar(usuarioMapeado);
            return true;
        }

        public async Task<bool> Deletar(long id)
        {
            var usuario = await _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                _notificador.Adicionar(new Notificacao("Usuário não encontrado"));
                return false;
            }

            await _usuarioRepository.Deletar(usuario);
            return true;
        }

        public async Task<Usuario> login(LoginViewModel login)
        {
            var usuario = await _usuarioRepository.BuscaPorEmail(login.Email);

            if(usuario !=  null && usuario.Senha.Equals(login.Senha))
            {
                var usuarioMapeado = _mapper.Map<Usuario>(login);
                usuarioMapeado.Id = usuario.Id;
                usuarioMapeado.Nome = usuario.Nome;
                usuarioMapeado.Cargo = usuario.Cargo;
                return usuarioMapeado;
            }

            return null;
        }
    }
}

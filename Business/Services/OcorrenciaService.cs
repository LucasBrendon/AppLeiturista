using AutoMapper;
using Business.Interfaces.Notification;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Business.Notifications;
using Business.Validations;
using Business.ViewModels.Ocorrencia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OcorrenciaService : NotificacaoService, IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
            _mapper = mapper;
            _notificador = notificador;
        }

        public async Task<List<ExibirOcorrenciaViewModel>> BuscarTodos()
        {
            return _mapper.Map<List<ExibirOcorrenciaViewModel>>(await _ocorrenciaRepository.BuscarTodos());
        }

        public async Task<ExibirOcorrenciaViewModel> BuscarPorId(long id)
        {
            var ocorrencia =  _mapper.Map<ExibirOcorrenciaViewModel>(await _ocorrenciaRepository.BuscarPorId(id));

            if (ocorrencia == null)
            {
                _notificador.Adicionar(new Notificacao("Nenhuma Ocorrência encontrada"));
            }

            return ocorrencia;
        }

        public async Task<List<ExibirOcorrenciaViewModel>> BuscarPorDescricao(string descricao)
        {
            var ocorrencia = _mapper.Map<List<ExibirOcorrenciaViewModel>>(await _ocorrenciaRepository.BuscarPorDescricao(descricao));

            if(ocorrencia.Count == 0)
            {
                _notificador.Adicionar(new Notificacao("Nenhuma Ocorrência encontrada"));
            }

            return ocorrencia;
        }

        public async Task<bool> Cadastrar(CriarOcorrenciaViewModel obj)
        {
            var ocorrencia = _mapper.Map<Ocorrencia>(obj);

            if(!ExecutarValidacao(new OcorrenciaValidator(), ocorrencia))
            {
                return false;
            }

            await _ocorrenciaRepository.Cadastrar(ocorrencia);
            return true;
        }

        public async Task<bool> Atualizar(ExibirOcorrenciaViewModel obj)
        {

            var ocorrenciaExiste = await _ocorrenciaRepository.BuscarPorId(obj.Id);
            var ocorrencia = _mapper.Map<Ocorrencia>(obj);

            if (ocorrenciaExiste == null)
            {
                _notificador.Adicionar(new Notificacao("Ocorrência não encontrada"));
            }

            if(!ExecutarValidacao(new OcorrenciaValidator(), ocorrencia))
            {
                return false;
            }
            
            await _ocorrenciaRepository.Atualizar(ocorrencia);
            return true;
        }

        public async Task<bool> Deletar(long id)
        {
            var ocorrencia = await _ocorrenciaRepository.BuscarPorId(id);

            if(ocorrencia == null)
            {
                _notificador.Adicionar(new Notificacao("Ocorrência não encontrada"));
                return false;
            }

            await _ocorrenciaRepository.Deletar(ocorrencia);
            return true;
        }
    }
}

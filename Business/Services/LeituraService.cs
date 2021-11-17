using AutoMapper;
using Business.Interfaces.Notification;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Business.Notifications;
using Business.Validator;
using Business.ViewModels.Leitura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LeituraService : NotificacaoService, ILeituraService
    {
        private readonly ILeituraRepository _leituraRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public LeituraService(ILeituraRepository leituraRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _leituraRepository = leituraRepository;
            _mapper = mapper;
            _notificador = notificador;
        }

        public async Task<List<ExibirLeituraViewModel>> BuscarTodos()
        {
            return _mapper.Map<List<ExibirLeituraViewModel>>(await _leituraRepository.BuscarTodos());
        }

        public async Task<ExibirLeituraViewModel> BuscarPorId(long id)
        {
            var leitura = _mapper.Map<ExibirLeituraViewModel>(await _leituraRepository.BuscarPorId(id));

            if(leitura == null)
            {
                _notificador.Adicionar(new Notificacao("Leitura não encontrada"));
            }

            return leitura;
        }

        public async Task<ExibirLeituraViewModel> BuscarPorCodigoCliente(long codigoCliente)
        {
            var leitura = _mapper.Map<ExibirLeituraViewModel>(await _leituraRepository.BuscarPorCodigoCliente(codigoCliente));

            if (leitura == null)
            {
                _notificador.Adicionar(new Notificacao("Leitura não encontrada"));
            }

            return leitura;
        }

        public async Task<List<ExibirLeituraViewModel>> BuscarPorData(int mes)
        {
            var leitura = _mapper.Map<List<ExibirLeituraViewModel>>(await _leituraRepository.BuscarPorData(mes));

            if(leitura.Count == 0)
            {
                _notificador.Adicionar(new Notificacao("Leitura não encontrada"));
            }

            return leitura;
        }

        public async Task<bool> Cadastrar(CriarLeituraViewModel leitura)
        {
            var leituristaAtivo = await _leituraRepository.RetornaStatusAtivoLeiturista(leitura.LeituristaId);
            var ocorrenciaPermiteLeitura = await _leituraRepository.RetornaStatusOcorrenciaPermiteLeitura(leitura.OcorrenciaId);

            var leituraMapeada = _mapper.Map<Leitura>(leitura);
            leituraMapeada.DataLeitura = DateTime.Now;
            
            if(!ExecutarValidacao(new LeituraValidator(), leituraMapeada))
            {
                return false;
            }

            if (!leituristaAtivo)
            {
                _notificador.Adicionar(new Notificacao("Impossível realizar leitura, leiturista encontra-se inativo"));
                return false;
            }

            if (!ocorrenciaPermiteLeitura)
            {
                leituraMapeada.LeituraAtual = null;
                await _leituraRepository.Cadastrar(leituraMapeada);
                _notificador.Adicionar(new Notificacao("Este tipo de ocorrência não permite leitura, sendo assim a leitura atual irá com valor nulo"));
                return true;
            }

            await _leituraRepository.Cadastrar(leituraMapeada);
            return true;
        }

        public async Task<bool> Atualizar(EditarLeituraViewModel leitura)
        {
            var leituraExiste = await _leituraRepository.BuscarPorId(leitura.Id);

            if (leituraExiste == null)
            {
                _notificador.Adicionar(new Notificacao("Leitura não encontrada"));
            }

            var leituristaAtivo = await _leituraRepository.RetornaStatusAtivoLeiturista(leitura.LeituristaId);
            var ocorrenciaPermiteLeitura = await _leituraRepository.RetornaStatusOcorrenciaPermiteLeitura(leitura.OcorrenciaId);

            var leituraMapeada = _mapper.Map<Leitura>(leitura);

            leituraMapeada.DataLeitura = leituraExiste.DataLeitura;

            if (!ExecutarValidacao(new LeituraValidator(), leituraMapeada))
            {
                return false;
            }

            if (!leituristaAtivo)
            {
                _notificador.Adicionar(new Notificacao("Impossível atualizar leitura, leiturista encontra-se inativo"));
                return false;
            }

            if (!ocorrenciaPermiteLeitura)
            {
                leituraMapeada.LeituraAtual = null;
                await _leituraRepository.Atualizar(leituraMapeada);
                throw new Exception("Este tipo de ocorrência não permite leitura, sendo assim a leitura atual irá com valor nulo");
            }

            await _leituraRepository.Atualizar(leituraMapeada);
            return true;
        }

        public async Task<bool> Deletar(long id)
        {
            var leitura = await _leituraRepository.BuscarPorId(id);

            if(leitura == null)
            {
                _notificador.Adicionar(new Notificacao("Leitura não encontrada"));
                return false;
            }

            await _leituraRepository.Deletar(leitura);
            return true;
        }
    }
}

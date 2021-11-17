using Business.Interfaces.Notification;
using Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace API.Controllers
{
    public abstract class NotificadorController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected NotificadorController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool ValidarOperacao()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult RespostaCustomizada(object resultado = null)
        {
            if (ValidarOperacao())
            {
                return Ok(new
                {
                    sucesso = true,
                    dados = resultado
                });
            }

            return BadRequest(new
            {
                sucesso = false,
                erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult RespostaCustomizada(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotificarErroModelInvalida(modelState);
            }

            return RespostaCustomizada();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach(var erro in erros)
            {
                var mensagemErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(mensagemErro);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Adicionar(new Notificacao(mensagem));
        }
    }
}

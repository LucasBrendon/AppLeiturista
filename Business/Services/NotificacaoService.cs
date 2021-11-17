using Business.Interfaces.Notification;
using Business.Models;
using Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Services
{
    public abstract class NotificacaoService 
    {
        private readonly INotificador _notificador;

        protected NotificacaoService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Adicionar(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<V,E>(V validacao, E entidade) where V : AbstractValidator<E> where E : Base
        {
            var validador = validacao.Validate(entidade);

            if (validador.IsValid)
            {
                return true;
            }

            Notificar(validador);

            return false;
        }
    }
}

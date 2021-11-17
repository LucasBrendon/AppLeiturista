using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class OcorrenciaValidator : AbstractValidator<Ocorrencia>
    {
        public OcorrenciaValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo Descricão não pode ser nulo ou vazio")
                .Length(5, 80)
                    .WithMessage("O campo Descrição de conter de 5 à 80 caracteres");

            RuleFor(x => x.PermiteLeitura)
                .NotNull()
                    .WithMessage("O campo Permite leitura não pode ser nulo ou vazio");

            RuleFor(x => x.Valor)
                .NotNull()
                    .WithMessage("O campo Valor não pode ser nulo ou vazio");
        }
    }
}

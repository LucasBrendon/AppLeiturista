using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator
{
    public class LeituraValidator : AbstractValidator<Leitura>
    {
        public LeituraValidator()
        {
            RuleFor(x => x.CodigoCliente)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo Código Cliente não pode ser nulo ou vazio");

            RuleFor(x => x.LeituraAnterior)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo Leitura Anterior não pode ser nulo ou vazio");

            RuleFor(x => x.LeituristaId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo LeituristaId não pode ser nulo ou vazio");

            RuleFor(x => x.OcorrenciaId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo OcorrenciaId não pode ser nulo ou vazio");

            RuleFor(x => x.OcorrenciaId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo OcorrenciaId não pode ser nulo ou vazio");

            RuleFor(x => x.Latitude)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo Latitude não pode ser nulo ou vazio");

            RuleFor(x => x.Longitude)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo Longitude não pode ser nulo ou vazio");
        }
    }
}

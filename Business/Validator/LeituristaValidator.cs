using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class LeituristaValidator : AbstractValidator<Leiturista>
    {
        public LeituristaValidator()
        {
            RuleFor(x => x.Matricula)
                .NotNull()
                    .WithMessage("O campo Matrícula não pode ser nulo ou vazio");

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo Nome não pode ser nulo ou vazio")
                .Length(5, 100)
                    .WithMessage("O campo Nome deve conter de 5 à 100 caracteres");

            RuleFor(x => x.Ativo)
                .NotNull()
                    .WithMessage("O campo Ativo não pode ser nulo");
        }
    }
}

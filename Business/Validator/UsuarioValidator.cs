using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo Nome não pode ser vazio ou nulo")
                .Length(5, 100)
                    .WithMessage("O campo Nome deve conter de 5 à 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo Email não pode ser vazio ou nulo")
                .Length(5, 100)
                    .WithMessage("O campo Email deve conter de 5 à 100 caracteres");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo Senha não pode ser vazio ou nulo")
                .Length(8, 32)
                    .WithMessage("O campo Senha deve conter de 8 à 32 caracteres");

            RuleFor(x => x.Cargo)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo Cargo não pode ser vazio ou nulo")
                .Length(5, 50)
                    .WithMessage("O campo Cargo deve conter de 5 à 50 caracteres");
        }
    }
}

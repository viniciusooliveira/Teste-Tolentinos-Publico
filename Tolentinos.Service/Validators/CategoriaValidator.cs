using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Service.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Você deve inserir um nome para a categoria.")
                .MaximumLength(50).WithMessage("O nome deve possuir no máximo 100 caracteres.");
        }
    }
}

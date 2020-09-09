using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Service.Validators
{
    public class MarcaValidator : AbstractValidator<Marca>
    {

        public MarcaValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("Você deve inserir um nome para a marca.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Service.Validators
{
    public class CarrinhoValidator : AbstractValidator<Carrinho>
    {
        public CarrinhoValidator()
        {
            RuleFor(m => m.IdUsuario)
                .GreaterThan(0).WithMessage("O carrinho deve pertencer a um usuário.");
        }
    }
}

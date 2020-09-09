using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Service.Validators
{
    public class ItemCarrinhoValidator : AbstractValidator<ItemCarrinho>
    {
        public ItemCarrinhoValidator()
        {
            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do produto deve ser igual ou superior a 1.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Service.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {

        public ProdutoValidator()
        {
            RuleFor(p => p.Cor)
                .NotEmpty().WithMessage("Você deve inserir uma cor para o produto.");

            RuleFor(p => p.Tamanho)
                .NotEmpty().WithMessage("Você deve inserir um tamanho para o produto.");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Você deve inserir um nome para o produto.")
                .MaximumLength(100).WithMessage("O nome deve possuir no máximo 100 caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("Você deve inserir uma descrição para o produto.");

            
        }

    }
}

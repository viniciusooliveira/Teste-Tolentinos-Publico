using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Service.Validators
{
    public class ImagemProdutoValidator : AbstractValidator<ImagemProduto>
    {
        public ImagemProdutoValidator() {
            RuleFor(i => i.Url)
                .NotEmpty().WithMessage("Você deve inserir a URL da imagem")
                .MaximumLength(255).WithMessage("A URL deve possuir no máximo 100 caracteres.");
        }
    }
}

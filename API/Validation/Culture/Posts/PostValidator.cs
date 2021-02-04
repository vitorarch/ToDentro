using API.Models.Culture.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Culture.Posts
{
    public class PostValidator : AbstractValidator<Post>
    {

        public PostValidator()
        {

            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Informe um título");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Informe o conteudo");

        }
    }
}

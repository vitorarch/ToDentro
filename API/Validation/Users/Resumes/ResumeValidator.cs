using API.Models.Users.Resumes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Users.Resumes
{
    public class ResumeValidator : AbstractValidator<Resume>
    {

        public ResumeValidator()
        {

            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(r => r.UserId)
               .NotEmpty()
               .WithMessage("Currículo não vinculado a um usuário");

        }
    }
}

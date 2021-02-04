using API.Models.Companies.Jobs.AdditionalInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Companies.Jobs.AdditionalInfo
{
    public class RequirementValidator : AbstractValidator<Requirement>
    {

        public RequirementValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(d => d.JobId)
                .NotEmpty()
                .WithMessage("Requisito não viculado a uma vaga");

            RuleFor(d => d.Requesite)
                .NotEmpty()
                .WithMessage("Adicione um requisito");
        }

    }
}

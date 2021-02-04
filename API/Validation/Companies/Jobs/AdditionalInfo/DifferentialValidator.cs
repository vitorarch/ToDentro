using API.Models.Companies.Jobs.AdditionalInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Companies.Jobs.AdditionalInfo
{
    public class DifferentialValidator : AbstractValidator<Differential>
    {

        public DifferentialValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(d => d.JobId)
                .NotEmpty()
                .WithMessage("Diferencial não viculado a uma vaga");

            RuleFor(d => d.Knowlegde)
                .NotEmpty()
                .WithMessage("Adicione um diferencial");
        }

    }
}

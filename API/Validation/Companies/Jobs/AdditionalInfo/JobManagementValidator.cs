using API.Models.Companies.Jobs.AdditionalInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Companies.Jobs.AdditionalInfo
{
    public class JobManagementValidator : AbstractValidator<JobManagement>
    {

        public JobManagementValidator()
        {
            RuleFor(d => d.UserId)
                .NotEmpty()
                .WithMessage("Diferencial não viculado a um usuário");

            RuleFor(d => d.JobId)
                .NotEmpty()
                .WithMessage("Diferencial não viculado a uma vaga");

        }
    }
}

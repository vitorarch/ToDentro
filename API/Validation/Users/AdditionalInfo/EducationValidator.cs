using API.Models.Users.AdditionalInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Users.AdditionalInfo
{
    public class EducationValidator : AbstractValidator<Education>
    {

        public EducationValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(e => e.UserId)
                .NotEmpty()
                .WithMessage("Educação não viculado a um usuário");

            RuleFor(e => e.ResumeId)
                .NotEmpty()
                .WithMessage("Educação não viculado a um currículo");

            RuleFor(e => e.Institution)
                .NotEmpty()
                .WithMessage("Informe uma instituição");

            RuleFor(e => e.Degree)
                .NotEmpty()
                .WithMessage("Informe uma graduação");

            RuleFor(e => e.FieldOfStudy)
                .NotEmpty()
                .WithMessage("Informe a área de estudo");

            RuleFor(e => e.StartDate)
                .NotEmpty()
                .WithMessage("Informe uma data")
                .Must(DateValidator)
                .WithMessage("Data inválida");

            RuleFor(e => e.EndDate)
                .NotEmpty()
                .WithMessage("Informe uma data")
                .Must(DateValidator)
                .WithMessage("Data inválida");
        }

        private bool DateValidator(string date)
        {
            DateTime.TryParse(date, out DateTime result);

            if (result == DateTime.MinValue) return false;
            else return true;
        }

    }
}

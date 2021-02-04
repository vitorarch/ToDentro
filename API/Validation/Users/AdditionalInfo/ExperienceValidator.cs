using API.Models.Users.AdditionalInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Users.AdditionalInfo
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {

        public ExperienceValidator()
        {

            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(e => e.UserId)
                .NotEmpty()
                .WithMessage("Experiência não viculada a um usuário");

            RuleFor(e => e.ResumeId)
                .NotEmpty()
                .WithMessage("Experiência não viculada a um currículo");

            RuleFor(e => e.Company)
                .NotEmpty()
                .WithMessage("Informe a empresa");

            RuleFor(e => e.Position)
                .NotEmpty()
                .WithMessage("Informe o cargo");

            RuleFor(e => e.EffectiveDate)
                .NotEmpty()
                .WithMessage("Informe uma data")
                .Must(DateValidator)
                .WithMessage("Data inválida");

            RuleFor(e => e.ResignationDate)
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

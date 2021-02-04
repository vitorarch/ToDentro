using API.Models.Users.AdditionalInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Users.AdditionalInfo
{
    public class SkillValidator : AbstractValidator<Skill>
    {

        public SkillValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(s => s.UserId)
                .NotEmpty()
                .WithMessage("CompetÊncia não viculado a um usuário");

            RuleFor(s => s.ResumeId)
                .NotEmpty()
                .WithMessage("CompetÊncia não viculado a um currículo");

            RuleFor(s => s.Knowledge)
                .NotEmpty()
                .WithMessage("Informe uma competÊncia");

        }

        private bool DateValidator(string date)
        {
            DateTime.TryParse(date, out DateTime result);

            if (result == DateTime.MinValue) return false;
            else return true;
        }
    }
}

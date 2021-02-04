using API.Models.Culture.Events;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Culture.Events
{
    public class EventValidator : AbstractValidator<Event>
    {

        public EventValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(e => e.Local)
                .NotEmpty()
                .WithMessage("Informe o local");

            RuleFor(e => e.Provider)
                .NotEmpty()
                .WithMessage("Informe o provedor");

            RuleFor(e => e.Category)
                .NotEmpty()
                .WithMessage("Informe a categoria");

            RuleFor(e => e.Subcategory)
                .NotEmpty()
                .WithMessage("Informe a sub-categoria ");

            RuleFor(e => e.Date)
                .NotEmpty()
                .WithMessage("Informe a data")
                .Must(DateValidator)
                .WithMessage("Data inválida");

            RuleFor(e => e.Contact)
                .NotEmpty()
                .WithMessage("Informe um telefone para contato");

        }

        private bool DateValidator(string date)
        {
            DateTime.TryParse(date, out DateTime result);

            if (result == DateTime.MinValue) return false;
            else return true;
        }

    }
}

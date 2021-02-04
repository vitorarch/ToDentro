using API.Models.Advertisements;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validation.Advertisements
{
    public class AdvertisementValidator : AbstractValidator<Advertisement>
    {

        public AdvertisementValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto");

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Informe um nome para o anúncio");

            RuleFor(a => a.StartDate)
                .NotEmpty()
                .WithMessage("Informe a data")
                .Must(DateValidator)
                .WithMessage("Data inválida");

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithMessage("Adicione uma descrição");
        }

        private bool DateValidator(string date)
        {
            DateTime.TryParse(date, out DateTime result);

            if (result == DateTime.MinValue) return false;
            else return true;
        }

    }
}

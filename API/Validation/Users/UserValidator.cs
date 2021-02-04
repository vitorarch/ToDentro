using API.DataAccess;
using API.Models.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API.Validation.Users
{
    public class UserValidator : AbstractValidator<User>
    {

        private readonly ToDentroContext _context;

        public UserValidator(ToDentroContext context)
        {
            _context = context;

            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Nome obrigatório")
                .Length(3, 70)
                .WithMessage("Tamanho de nome inválido");

            RuleFor(u => u.CPF)
               .NotEmpty()
               .WithMessage("Cpf obrigatório")
               .Must(CpfValidator)
               .WithMessage("Cpf inválido")
               .Must(VerifyingId)
               .WithMessage("Cpf já cadastrado");

            RuleFor(u => u.Email)
               .Must(EmailValidator)
               .WithMessage("Email inválido");

            RuleFor(u => u.BithDate)
               .NotEmpty()
               .WithMessage("Data de nascimento obrigatória")
               .Must(BithDateValidator)
               .WithMessage("Data inválida");

            RuleFor(u => u.Gender)
               .NotEmpty()
               .WithMessage("Sexo obrigatório");

            RuleFor(u => u.CEP)
               .NotEmpty()
               .WithMessage("Informe o cep");

            RuleFor(u => u.Adress)
               .NotEmpty()
               .WithMessage("Endereço obrigatório");

            RuleFor(u => u.Number)
               .NotEmpty()
               .WithMessage("Número obrigatório");

            RuleFor(u => u.Neighborhood)
              .NotEmpty()
              .WithMessage("Bairro obrigatório");

            RuleFor(u => u.City)
              .NotEmpty()
              .WithMessage("Cidade obrigatória");

            RuleFor(u => u.State)
               .NotEmpty()
               .WithMessage("Estado obrigatório");

            RuleFor(u => u.Password)
              .NotEmpty()
              .WithMessage("Senha obrigatória")
              .Length(6, 50)
              .WithMessage("Senha deve ter mais de 6 caracteres")
              .Must(SpecialCaracter)
              .WithMessage("Senha deve conter ao menos um caracter especial");

        }

        private bool VerifyingId(string cpf)
        {
            var validation = _context.Users.Find(cpf);

            if (validation == null) return true;
            return false;
        }

        private bool CpfValidator(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }

        private bool BithDateValidator(string birthDate)
        {
            DateTime.TryParse(birthDate, out DateTime result);

            if (result == DateTime.MinValue) return false;
            else return true;
        }

        private bool EmailValidator(string email)
        {
            if (!string.IsNullOrEmpty(email))
                if (Regex.IsMatch(email, "\\w+([@])\\w+.com")) return true;
                else return false;
            else return true;
        }

        private bool SpecialCaracter(string password)
        {
            string pattern = "[^0-9A-Za-z]";
            var result = Regex.IsMatch(password, pattern);
            if (result) return true;
            else return false;
        }
    }
}

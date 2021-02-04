using API.Models.Companies;
using FluentValidation;
using System;using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using API.DataAccess;

namespace API.Validation.Companies
{
    public class CompanyValidator : AbstractValidator<Company>
    {

        private readonly ToDentroContext _context;

        public CompanyValidator(ToDentroContext context)
        {
            _context = context;

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Erro ao criar objeto")
                .Must(VerifyingIdValidator)
                .WithMessage("Número de cpf/cnpj inválido")
                .Must(VerifyingId)
                .WithMessage("Número de cpf/cnpj já cadastrado");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Nome obrigatório");

            RuleFor(c => c.Phone)
                .NotEmpty()
                .WithMessage("Telefone de contato obrigatório");

            RuleFor(c => c.Email)
                .Must(EmailValidator)
                .WithMessage("Email inválido");

            RuleFor(c => c.Sector)
                .NotEmpty()
                .WithMessage("Ramo obrigatório");

            RuleFor(u => u.CEP)
              .NotEmpty()
              .WithMessage("Informe o cep");

            RuleFor(u => u.Adress)
               .NotEmpty()
               .WithMessage("Endereço obrigatório");

            RuleFor(u => u.Number)
               .NotEmpty()
               .WithMessage("Número obrigatóriO");

            RuleFor(u => u.Neighborhood)
              .NotEmpty()
              .WithMessage("Bairro obrigatório");

            RuleFor(u => u.City)
              .NotEmpty()
              .WithMessage("Cidade obrigatória");

            RuleFor(u => u.State)
               .NotEmpty()
               .WithMessage("Estado obrigatóriO");

            //RuleFor(u => u.Password)
            //  .NotEmpty()
            //  .WithMessage("Senha obrigatória")
            //  .Length(6, 50)
            //  .WithMessage("Senha deve ter mais de 6 caracteres")
            //  .Must(SpecialCaracter)
            //  .WithMessage("Senha deve conter ao menos um caracter especial");

        }

        private bool EmailValidator(string email)
        {
            if (!string.IsNullOrEmpty(email))
                if (Regex.IsMatch(email, "\\w+([@])\\w+.com")) return true;
                else return false;
            else return true;
        }

        private bool VerifyingId(string id)
        {
            var validation = _context.Companies.Find(id);

            if (validation == null) return true;
            return false;
        }

        private bool VerifyingIdValidator(string id)
        {
            bool result = false;
            if (id.Length == 11)
            {
                result = CpfValidator(id) ? true : false;
                return result;
            }
            else if (id.Length == 14)
            {
                result = CnpjValidator(id) ? true : false;
                return result;
            }
            else return result;
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

        private bool CnpjValidator(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
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

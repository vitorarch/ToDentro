using API.DataAccess;
using API.Interfaces.Companies;
using API.Models.Companies;
using API.Validation.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Companies
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly ToDentroContext _context;
        private readonly CompanyValidator _companyValidator;

        public CompanyRepository(ToDentroContext context)
        {
            _context = context;
            _companyValidator = new CompanyValidator(context);
        }
        public async Task<bool> DeleteCompanyProfile(string id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null) return false;
            else
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<dynamic> EditCompanyProfile(Company companyEdited)
        {
            var result = await _companyValidator.ValidateAsync(companyEdited);
            var company = await _context.Companies.FindAsync(companyEdited.Id);

            if (company == null) return null;
            else
            {
                if (result.IsValid)
                {
                    UpdatingCompanyProfile(company, companyEdited);
                    await _context.SaveChangesAsync();
                    return company;
                }
                else return result.Errors[0].ErrorMessage;
            }
        }

        public async Task<Company> GetCompanyProfile(string id)
        {
            var company = await _context.Companies.FindAsync(id);
            return company;
        }

        private void UpdatingCompanyProfile(Company company, Company companyEdited)
        {
            company.Adress = companyEdited.Adress;
            company.CEP = companyEdited.CEP;
            company.City = companyEdited.City;
            company.Complement = companyEdited.Complement;
            company.Email = companyEdited.Email;;
            company.Name = companyEdited.Name;
            company.Neighborhood = companyEdited.Neighborhood;
            company.Number = companyEdited.Number;
            company.Phone = companyEdited.Phone;
            company.Photo = companyEdited.Photo;
            company.Role = companyEdited.Role;
            company.State = companyEdited.State;
            company.Sector = companyEdited.Sector;
            company.Type = companyEdited.Type;
            company.Description = companyEdited.Observations;
        }

    }
}

using API.DataAccess;
using API.Interfaces.Access;
using API.Models.Companies;
using API.Models.Users;
using API.Validation.Access;
using API.Validation.Companies;
using API.Validation.Users;
using System.Threading.Tasks;

namespace API.Repositories.Access
{
    public class RegisterRepository : IRegisterRepository
    {

        private readonly ToDentroContext _context;
        private readonly UserValidator _userValidator;
        private readonly CompanyValidator _companyValidator;

        public RegisterRepository(ToDentroContext context)
        {
            _context = context;
            _userValidator = new UserValidator(context); 
            _companyValidator = new CompanyValidator(context);
        }

        public async Task<dynamic> SingingUp(User newUser)
        {
            var result = await _userValidator.ValidateAsync(newUser);
            if (result.IsValid)
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            } 
            else return result.Errors[0].ErrorMessage;
        }

        public async Task<dynamic> SingingUp(Company newCompany)
        {
            var result = await _companyValidator.ValidateAsync(newCompany);
            if (result.IsValid)
            {
                await _context.Companies.AddAsync(newCompany);
                await _context.SaveChangesAsync();
                return newCompany;
            }
            else return result.Errors[0].ErrorMessage;
        }

    }
}

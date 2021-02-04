using API.DataAccess;
using API.Interfaces.Access;
using API.Models.Users;
using API.Validation.Access;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Access
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ToDentroContext _context;
        private readonly LoginValidator _loginValidator;

        public LoginRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<User> SingingIn(string cpf, string password)
        {
            var _user = await _context.Users.FindAsync(cpf);
            if (_user == null) return null;
            else
            {
                var user = _user.Password == password ? _user : null;
                return user;
            
            }
        }

    }
}

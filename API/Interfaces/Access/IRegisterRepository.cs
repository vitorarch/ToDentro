using API.Models.Companies;
using API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Access
{
    public interface IRegisterRepository
    {

        public Task<dynamic> SingingUp(User user);
        public Task<dynamic> SingingUp(Company company);

    }
}

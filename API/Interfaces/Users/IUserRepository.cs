using API.Models.Companies.Jobs;
using API.Models.Culture.Events;
using API.Models.Culture.Posts;
using API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users
{
    public interface IUserRepository
    {
        public Task<User> GetUserProfile(string cpf);

        public Task<dynamic> EditUserProfile(User user);

        public Task<bool> DeleteUserProfile(string cpf);

    }
}

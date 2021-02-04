using API.DataAccess;
using API.Interfaces.Users;
using API.Models.Users;
using API.Validation.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDentroContext _context;
        private readonly UserValidator _userValidator;

        public UserRepository(ToDentroContext context)
        {
            _context = context;
            _userValidator = new UserValidator(context);
        }

        public async Task<User> GetUserProfile(string cpf)
        {
            var user = await _context.Users.FindAsync(cpf);
            return user;
        }

        public async Task<dynamic> EditUserProfile(User userEdited)
        {
            var result = await _userValidator.ValidateAsync(userEdited);
            var user = await _context.Users.FindAsync(userEdited.CPF);

            if (user == null) return null;
            else
            {
                if (result.IsValid)
                {
                    UpdatingUserProfile(user, userEdited);
                    await _context.SaveChangesAsync();
                    return user;
                }
                else return result.Errors[0].ErrorMessage;
            }
        }

        public async Task<bool> DeleteUserProfile(string cpf)
        {
            var user = await _context.Users.FindAsync(cpf);

            if (user == null) return false;
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        private void UpdatingUserProfile(User user, User editedUser)
        {
            user.Adress = editedUser.Adress;
            user.BithDate = editedUser.BithDate;
            user.CEP = editedUser.CEP;
            user.City = editedUser.City;
            user.Complement = editedUser.Complement;
            user.Email = editedUser.Email;
            user.Gender = editedUser.Gender;
            user.Name = editedUser.Name;
            user.Neighborhood = editedUser.Neighborhood;
            user.Number = editedUser.Number;
            user.Password = editedUser.Password;
            user.Phone = editedUser.Phone;
            user.Photo = editedUser.Photo;
            user.Role = editedUser.Role;
            user.State = editedUser.State;
        }

    }
}

using API.DataAccess;
using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using API.Validation.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.AdditionalInfo
{
    public class ExperienceRepository : IExperienceRepository
    {

        private readonly ToDentroContext _context;
        private readonly ExperienceValidator _experienceValidator;

        public ExperienceRepository(ToDentroContext context)
        {
            _context = context;
            _experienceValidator = new ExperienceValidator();
        }

        public Experience GetExperience(Guid id)
        {
            if (id == null) return null;
            else
            {
                var experience = _context.Experiences.Where(s => s.Id == id).FirstOrDefault();
                return experience;
            }
        }

        public IEnumerable<Experience> GetExperiences(string cpf)
        {
            if (cpf == null) return null;
            else
            {
                var experienceList = _context.Experiences.Where(s => s.UserId == cpf).ToList();
                return experienceList;
            }
        }

        public async Task<dynamic> AddExperience(Experience experience)
        {
            experience.Id = Guid.NewGuid();

            var result = await _experienceValidator.ValidateAsync(experience);
            if (result.IsValid)
            {
                experience.Id = Guid.NewGuid();

                await _context.Experiences.AddAsync(experience);
                await _context.SaveChangesAsync();
                return experience;
            }
            else return result.Errors[0].ErrorMessage;
        }

        public async Task<dynamic> EditExperience(Experience editedExperience)
        {
            var experience = await _context.Experiences.FindAsync(editedExperience.Id);
            var result = await _experienceValidator.ValidateAsync(editedExperience);

            if (experience == null) return null;
            else
            {
                if (result.IsValid)
                {
                    UpdatingExperience(experience, editedExperience);
                    await _context.SaveChangesAsync();
                    return editedExperience;
                }
                else return result.Errors[0].ErrorMessage;
            }
        }

        public async Task<bool> DeleteExperience(Guid id)
        {
            if (id == null) return false;
            else
            {
                var experience = await _context.Experiences.FindAsync(id);
                _context.Experiences.Remove(experience);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        private void UpdatingExperience(Experience experience, Experience editedExperience)
        {
            experience.Company = editedExperience.Company;
            experience.Position = editedExperience.Position;
            experience.EffectiveDate = editedExperience.EffectiveDate;
            experience.ResignationDate = editedExperience.ResignationDate;
        }

    }
}

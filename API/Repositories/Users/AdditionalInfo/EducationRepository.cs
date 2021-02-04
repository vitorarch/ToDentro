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
    public class EducationRepository : IEducationRepository
    {

        private readonly ToDentroContext _context;
        private readonly EducationValidator _educationValidator;

        public EducationRepository(ToDentroContext context)
        {
            _context = context;
            _educationValidator = new EducationValidator();
        }

        public Education GetEducation(Guid id)
        {
            if (id == null) return null;
            else
            {
                var education = _context.Education.Where(s => s.Id == id).FirstOrDefault();
                return education;
            }
        }

        public IEnumerable<Education> GetEducations(string cpf)
        {
            if (cpf == null) return null;
            else
            {
                var educationList = _context.Education.Where(s => s.UserId == cpf).ToList();
                return educationList;
            }
        }

        public async Task<dynamic> AddEducation(Education education)
        {
            education.Id = Guid.NewGuid();

            var result = await _educationValidator.ValidateAsync(education);
            if (result.IsValid)
            {
                education.Id = Guid.NewGuid();

                await _context.Education.AddAsync(education);
                await _context.SaveChangesAsync();
                return education;
            }
            else return result.Errors[0].ErrorMessage;
        }

        public async Task<dynamic> EditEducation(Education editedEducation)
        {
            var education = await _context.Education.FindAsync(editedEducation.Id);
            var result = await _educationValidator.ValidateAsync(editedEducation);

            if (education == null) return null;
            else
            {
                if (result.IsValid)
                {
                    UpdatingEducation(education, editedEducation);
                    await _context.SaveChangesAsync();
                    return editedEducation;
                }
                else return result.Errors[0].ErrorMessage;
            }
        }

        public async Task<bool> DeleteEducation(Guid id)
        {
            if (id == null) return false;
            else
            {
                var education = await _context.Education.FindAsync(id);
                _context.Education.Remove(education);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        private void UpdatingEducation(Education education, Education editedEducation)
        {
            education.Institution = editedEducation.Institution;
            education.Degree = editedEducation.Degree;
            education.FieldOfStudy = editedEducation.FieldOfStudy;
            education.StartDate = editedEducation.StartDate;
            education.EndDate = editedEducation.EndDate;
        }

    }
}

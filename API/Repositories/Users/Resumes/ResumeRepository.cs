using API.DataAccess;
using API.Interfaces.Users.Resumes;
using API.Models.Users;
using API.Models.Users.Resumes;
using API.Validation.Users.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.Resumes
{
    public class ResumeRepository : IResumeRepository
    {

        private readonly ToDentroContext _context;
        private readonly ResumeValidator _resumeValidator;

        public ResumeRepository(ToDentroContext context)
        {
            _context = context;
            _resumeValidator = new ResumeValidator();
        }

        public async Task<Resume> GetResume(Guid id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            return resume;
        }

        public async Task<dynamic> AddResume(Resume resume)
        {
            resume.Id = Guid.NewGuid();
            var result = await _resumeValidator.ValidateAsync(resume);

            if (result.IsValid)
            {
                await _context.Resumes.AddAsync(resume);
                await _context.SaveChangesAsync();
                return resume;
            }
            else return result.Errors[0].ErrorMessage;
        }

        public async Task<dynamic> EditResume(Resume editedResume)
        {
            var result = await _resumeValidator.ValidateAsync(editedResume);
            var resume = await _context.Resumes.FindAsync(editedResume.Id);

            if (resume == null) return null;
            else
            {
                if (result.IsValid)
                {
                    UpdatingResume(resume, editedResume);
                    await _context.SaveChangesAsync();
                    return resume;
                }
                else return result.Errors[0].ErrorMessage;
            }

        }

        private void UpdatingResume(Resume resume, Resume editedResume)
        {
            resume.Description = editedResume.Description;
        }


    }
}

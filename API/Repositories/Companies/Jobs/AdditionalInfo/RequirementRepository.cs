using API.DataAccess;
using API.Interfaces.Companies.Jobs.AdditionalInfo;
using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Companies.Job.AdditionalInfo
{
    public class RequirementRepository : IRequirementRepository
    {

        private readonly ToDentroContext _context;

        public RequirementRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Requirement> GetRequirementsByJob(Guid jobId)
        {
            // fluent validation
            if (jobId == null) return null;
            else
            {
                var requirementList = _context.Requirements.Where(r => r.JobId == jobId).ToList();
                return requirementList;
            }
        }

        public async Task<Requirement> GetRequirementById(Guid id)
        {
            // fluent validation
           
            var requirement = await _context.Requirements.FindAsync(id);
            return requirement;
        }

        public async Task<Requirement> AddRequirement(Requirement requirement)
        {
            // fluent validation
            if (requirement == null) return null;
            else
            {
                requirement.Id = Guid.NewGuid();

                await _context.Requirements.AddAsync(requirement);
                await _context.SaveChangesAsync();
                return requirement;
            }
        }

        public async Task<Requirement> EditRequirement(Requirement requirement)
        {
            // fluent validation
            if (requirement == null) return null;
            else
            {
                var _requirement = await _context.Requirements.FindAsync(requirement.Id);
                _requirement = requirement;

                _context.Entry(_requirement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return requirement;
            }
        }

        public async Task<bool> DeleteRequirement(Guid id)
        {
            // fluent validation
            if (id == null) return false;
            else
            {
                var requirement = await _context.Requirements.FindAsync(id);
                _context.Requirements.Remove(requirement);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}

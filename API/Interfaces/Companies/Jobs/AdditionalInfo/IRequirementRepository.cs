using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Companies.Jobs.AdditionalInfo
{
    public interface IRequirementRepository
    {

        public IEnumerable<Requirement> GetRequirementsByJob(Guid jobId);
        public Task<Requirement> GetRequirementById(Guid id);
        public Task<Requirement> AddRequirement(Requirement requirement);
        public Task<Requirement> EditRequirement(Requirement requirement);
        public Task<bool> DeleteRequirement(Guid id);

    }
}

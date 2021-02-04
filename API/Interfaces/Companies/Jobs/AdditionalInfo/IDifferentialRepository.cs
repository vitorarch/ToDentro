using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Companies.Jobs.AdditionalInfo
{
    public interface IDifferentialRepository
    {

        public IEnumerable<Differential> GetDifferentialsByJob(Guid jobId);
        public Task<Differential> GetDifferentialById(Guid id);
        public Task<Differential> AddDifferential(Differential differential);
        public Task<Differential> EditDifferential(Differential differential);
        public Task<bool> DeleteDifferential(Guid id);


    }
}

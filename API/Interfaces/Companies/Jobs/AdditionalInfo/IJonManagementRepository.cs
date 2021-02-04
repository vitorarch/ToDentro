using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Companies.Jobs.AdditionalInfo
{
    public interface IJobManagementRepository
    {

        public Task<JobManagement> ApplytoJob(JobManagement appliance);
        public IEnumerable<JobManagement> GetAppliancesByJob(Guid jobId);
        public IEnumerable<JobManagement> GetAppliancesByUser(string userId);

    }
}

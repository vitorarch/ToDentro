using API.DataAccess;
using API.Interfaces.Companies.Jobs.AdditionalInfo;
using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Companies.Job.AdditionalInfo
{
    public class JobManagementRepository : IJobManagementRepository
    {

        private readonly ToDentroContext _context;

        public JobManagementRepository(ToDentroContext context)
        {
            _context = context;
        }


        public async Task<JobManagement> ApplytoJob(JobManagement appliance)
        {
            await _context.JobManagements.AddAsync(appliance);
            await _context.SaveChangesAsync();
            return appliance;
        }

        public IEnumerable<JobManagement> GetAppliancesByJob(Guid jobId)
        {
            var appliancesToJob = _context.JobManagements.Where(j => j.JobId == jobId).ToList();
            return appliancesToJob;
        }

        public IEnumerable<JobManagement> GetAppliancesByUser(string userId)
        {
            var appliancesByUser = _context.JobManagements.Where(j => j.UserId == userId).ToList();
            return appliancesByUser;
        }
    }
}

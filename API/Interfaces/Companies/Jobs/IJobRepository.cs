using API.Models.Companies.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Companies.Jobs
{
    public interface IJobRepository
    {

        public Task<Job> GetJob(Guid id);

        public IEnumerable<Job> GetJobsByCompany(string id);

        public IEnumerable<Job> GetAllJobs();

        public Task<dynamic> AddJob(Job job);

        public Task<Job> EditJob(Job job);

        public Task<bool> DeleteJob(Guid id);


    }
}

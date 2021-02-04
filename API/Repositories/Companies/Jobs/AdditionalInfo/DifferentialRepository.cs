using API.DataAccess;
using API.Interfaces.Companies.Jobs.AdditionalInfo;
using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Companies.Jobs.AdditionalInfo
{
    public class DifferentialRepository : IDifferentialRepository
    {

        private readonly ToDentroContext _context;

        public DifferentialRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Differential> GetDifferentialsByJob(Guid jobId)
        {
            // fluent validation
            var differentialList = _context.Differentials.Where(d => d.JobId == jobId).ToList();
            return differentialList;
        }

        public async Task<Differential> GetDifferentialById(Guid id)
        {
            // fluent validation
            if (id == null) return null;
            else
            {
                var differential = await _context.Differentials.FindAsync(id);
                return differential;
            }
        }

        public async Task<Differential> AddDifferential(Differential differential)
        {
            // fluent validation - jobId nao pode ser nulo
            if (differential == null) return null;
            else
            {
                differential.Id = Guid.NewGuid();

                await _context.Differentials.AddAsync(differential);
                await _context.SaveChangesAsync();
                return differential;
            }
        }

        public async Task<Differential> EditDifferential(Differential differential)
        {
            // fluent validation
            if (differential == null) return null;
            else
            {
                var _differential = await _context.Differentials.FindAsync(differential.Id);
                _differential = differential;

                _context.Entry(_differential).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return differential;
            }
        }

        public async Task<bool> DeleteDifferential(Guid id)
        {
            // fluent validation
            if (id == null) return false;
            else
            {
                var differential = await _context.Differentials.FindAsync(id);
                _context.Differentials.Remove(differential);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}

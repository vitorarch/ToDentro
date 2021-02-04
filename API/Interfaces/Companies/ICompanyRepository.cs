using API.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Companies
{
    public interface ICompanyRepository
    {
        public Task<Company> GetCompanyProfile(string id);
        public Task<dynamic> EditCompanyProfile(Company company);
        public Task<bool> DeleteCompanyProfile(string id);

    }
}

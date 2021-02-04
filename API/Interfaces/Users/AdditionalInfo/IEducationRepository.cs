using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.AdditionalInfo
{
    public interface IEducationRepository
    {
        public Education GetEducation(Guid id);
        public IEnumerable<Education> GetEducations(string cpf);
        public Task<dynamic> AddEducation(Education education);
        public Task<dynamic> EditEducation(Education education);
        public Task<bool> DeleteEducation(Guid id);

    }
}

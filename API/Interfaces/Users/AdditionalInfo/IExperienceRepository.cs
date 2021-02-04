using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.AdditionalInfo
{
    public interface IExperienceRepository
    {

        public Experience GetExperience(Guid id);
        public IEnumerable<Experience> GetExperiences(string cpf);
        public Task<dynamic> AddExperience(Experience experience);
        public Task<dynamic> EditExperience(Experience experience);
        public Task<bool> DeleteExperience(Guid id);

    }
}

using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.AdditionalInfo
{
    public interface ISkillRepository
    {

        public Skill GetSkill(Guid id);
        public IEnumerable<Skill> GetSkills(string cpf);
        public Task<dynamic> AddSkill(Skill skill);
        public Task<dynamic> EditSkill(Skill skill);
        public Task<bool> DeleteSkill(Guid id);


    }
}

using API.DataAccess;
using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using API.Validation.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.AdditionalInfo
{
    public class SkillRepository : ISkillRepository
    {

        private readonly ToDentroContext _context;
        private readonly SkillValidator _skillValidator;

        public SkillRepository(ToDentroContext context)
        {
            _context = context;
            _skillValidator = new SkillValidator();
        }

        public Skill GetSkill(Guid id)
        {
            if (id == null) return null;
            else
            {
                var skill = _context.Skills.Where(s => s.Id == id).FirstOrDefault();
                return skill;
            }
        }

        public IEnumerable<Skill> GetSkills(string cpf)
        {
            if (cpf == null) return null;
            else
            {
                var skillList =  _context.Skills.Where(s => s.UserId == cpf).ToList();
                return skillList;
            }
        }

        public async Task<dynamic> AddSkill(Skill skill)
        {
            skill.Id = Guid.NewGuid();

            var result = await _skillValidator.ValidateAsync(skill);
            if (result.IsValid)
            {
                skill.Id = Guid.NewGuid();

                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
            else return result.Errors[0].ErrorMessage;
        }

        public async Task<dynamic> EditSkill(Skill editedSkill)
        {
            var skill = await _context.Skills.FindAsync(editedSkill.Id);
            var result = await _skillValidator.ValidateAsync(editedSkill);

            if (skill == null) return null;
            else
            {
                if (result.IsValid)
                {
                    UpdatingSkill(skill, editedSkill);
                    await _context.SaveChangesAsync();
                    return editedSkill;
                }
                else return result.Errors[0].ErrorMessage;
            }
        }

        public async Task<bool> DeleteSkill(Guid id)
        { 
            if (id == null) return false;
            else
            {
                var skill = await _context.Skills.FindAsync(id);
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        private void UpdatingSkill(Skill skill, Skill editedSkill)
        {
            skill.Knowledge = editedSkill.Knowledge;
        }

    }
}

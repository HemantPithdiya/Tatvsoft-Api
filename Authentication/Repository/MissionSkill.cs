using Authentication.Entities;
using Authentication.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository
{
    public class MissionSkill : IMissionSkill
    {
        private readonly AuthContext _authContext;
        public MissionSkill(AuthContext authContext)
        {
            _authContext = authContext;
        }
        public async Task<string> CreateMissionSkill(Skill model)
        {
            await _authContext.Skills.AddAsync(model);
            await _authContext.SaveChangesAsync();
            return "Mission skill created successfully.";
        }

        public async Task<string> DeleteMissionSkill(int id)
        {
            var skill = await _authContext.Skills.FindAsync(id);
            if (skill == null)
            {
                return "Mission skill not found.";
            }
            _authContext.Skills.Remove(skill);
            await _authContext.SaveChangesAsync();
            return "Mission skill deleted successfully.";
        }

        public async Task<List<Skill>> GetMissionSkill()
        {
            return await _authContext.Skills.ToListAsync();
        }

        public async Task<Skill> GetMissionSkillById(int SkillId)
        {
            return await _authContext.Skills.FindAsync(SkillId);
        }

        public async Task<string> UpdateMissionSkill(int SkillId, Skill model)
        {
            var existingSkill = await _authContext.Skills.FindAsync(SkillId);
            if (existingSkill == null)
            {
                return "Mission skill not found.";
            }

            existingSkill.SkillName = model.SkillName;
            existingSkill.Status = model.Status;

            _authContext.Skills.Update(existingSkill);
            await _authContext.SaveChangesAsync();
            return "Mission skill updated successfully.";
            throw new NotImplementedException();
        }
    }
}

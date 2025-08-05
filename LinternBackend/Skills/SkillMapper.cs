using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Skills
{
    public static class SkillMapper
    {
        public static Skill ToSkill(this SkillDto dto)
        {
            return new Skill
            {
                Name = dto.Name,
            };
        }

        public static ViewSkill FromSkill(this Skill skill)
        {
            return new ViewSkill
            {
                Id = skill.Id,
                Name = skill.Name,
            };
        }
    }
}
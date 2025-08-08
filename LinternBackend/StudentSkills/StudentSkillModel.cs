using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Skills;
using LinternBackend.Students;

namespace LinternBackend.StudentSkills
{
    public class StudentSkill
    {
        [Key]
        public Guid StudentSkillId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SkillId { get; set; }

        public Student? Student { get; set; }
        public Skill? Skill { get; set; }
    }

}
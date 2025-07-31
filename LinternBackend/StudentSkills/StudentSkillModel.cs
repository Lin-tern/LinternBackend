using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Skills;
using LinternBackend.Students;

namespace LinternBackend.StudentSkills
{
    public class StudentSkill
    {
        public int StudentId { get; set; }
        public int SkillId { get; set; }

        public Student Student { get; set; } = new Student();
        public Skill Skill { get; set; } = new Skill();
    }

}
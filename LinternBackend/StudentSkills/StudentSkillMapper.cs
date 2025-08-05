using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.StudentSkills
{
    public static class StudentSkillMapper
    {
        public static StudentSkill ToStudentSkill(this CreateStudentSkill create)
        {
            return new StudentSkill
            {
                StudentId = create.StudentId,
                SkillId = create.SkillId,
            };
        }

        public static ViewStudentSkill FromStudent(this StudentSkill studentSkill)
        {
            return new ViewStudentSkill
            {
                StudentSkillId = studentSkill.StudentSkillId,
                StudentId = studentSkill.StudentId,
                SkillId = studentSkill.SkillId,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.StudentSkills
{
    public class ViewStudentSkill
    {
        public Guid StudentSkillId {get; set;}
        public Guid StudentId { get; set; }
        public Guid SkillId { get; set; }
    }
}
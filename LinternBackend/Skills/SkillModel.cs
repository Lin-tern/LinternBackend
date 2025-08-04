using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.StudentSkills;

namespace LinternBackend.Skills
{
    public class Skill
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; // e.g., "C#", "UI/UX", "Data Analysis"
        public ICollection<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();
    }

}
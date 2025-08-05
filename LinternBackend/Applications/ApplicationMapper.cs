using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Applications
{
    public static class ApplicationMapper
    {
        public static Application ToApplication(this CreateApplication create)
        {
            return new Application
            {
                StudentId = create.StudentId,
                JobId = create.JobId,
                Status = create.Status,
                CoverLetter = create.CoverLetter,
                AppliedAt = DateTime.UtcNow,
            };
        }

        public static ViewApplication FromApplication(this Application app)
        {
            return new ViewApplication
            {
                Id = app.Id,
                StudentId = app.StudentId,
                JobId = app.JobId,
                Status = app.Status,
                CoverLetter = app.CoverLetter,
                AppliedAt = app.AppliedAt,
            };
        }
    }
}
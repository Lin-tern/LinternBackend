using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Resumes
{
    public static class ResumeMapper
    {
        public static Resume ToResume(this CreateResume create)
        {
            return new Resume
            {
                StudentId = create.StudentId,
                FileUrl = create.FileUrl,
                UploadedAt = DateTime.UtcNow,
            };
        }

        public static ViewResume FromResume(this Resume resume)
        {
            return new ViewResume
            {
                Id = resume.Id,
                StudentId = resume.StudentId,
                FileUrl = resume.FileUrl,
                UploadedAt = resume.UploadedAt,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Jobs
{
    public static class JobMapper
    {
        public static Job ToJob(this CreateJob create)
        {
            return new Job
            {
                OrganizationId = create.OrganizationId,
                Title = create.Title,
                Description = create.Description,
                Location = create.Location,
                Type = create.Type,
                StartDate = create.StartDate,
                EndDate = create.EndDate,
                IsPaid = create.IsPaid,
            };
        }

        public static ViewJob FromJob(this Job job)
        {
            return new ViewJob
            {
                Id = job.Id,
                OrganizationId = job.OrganizationId,
                Title = job.Title,
                Description = job.Description,
                Location = job.Description,
                Type = job.Type,
                StartDate = job.StartDate,
                EndDate = job.EndDate,
                IsPaid = job.IsPaid,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Jobs
{
    public interface IJobRepository
    {
        public Task<IEnumerable<Job>> GetAllJobsAsync();
        public Task<Job?> GetJobByIdAsync(Guid id);
        public Task<Job?> createJobAsync(Job job);
        public Task<Job?> updateJobAsync(Guid id, UpdateJob update);
        public Task<Job?> deleteJobAsync(Guid id);
    }
}
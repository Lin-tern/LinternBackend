using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Resumes
{
    public interface IResumeRepository
    {
        public Task<List<Resume>> GetAllAsync();
        public Task<Resume?> GetById(Guid id);
        public Task<Resume> createAsync(Resume resume);
        public Task<Resume?> updateAsync(Guid id, UpdateResume update);
        public Task<Resume?> deleteAsync(Guid id);
    }
}
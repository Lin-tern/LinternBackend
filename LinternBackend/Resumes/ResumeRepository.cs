using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace LinternBackend.Resumes
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly AppDbContext _context;
        public ResumeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Resume> createAsync(Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
            return resume;
        }

        public async Task<Resume?> deleteAsync(Guid id)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(x => x.Id == id);
            if (resume == null) return null;

            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();
            return resume;
        }

        public async Task<List<Resume>> GetAllAsync()
        {
            return await _context.Resumes.ToListAsync();
        }

        public async Task<Resume?> GetById(Guid id)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(x => x.Id == id);
            if (resume == null) return null;

            return resume;
        }

        public async Task<Resume?> updateAsync(Guid id, UpdateResume update)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(x => x.Id == id);
            if (resume == null) return null;
            update.FileUrl = resume.FileUrl;

            await _context.SaveChangesAsync();
            return resume;
        }
    }
}
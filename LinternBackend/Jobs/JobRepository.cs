using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace LinternBackend.Jobs
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;
        public JobRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Job?> createJobAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();

            return job;
        }

        public async Task<Job?> deleteJobAsync(Guid id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (job == null) return null;
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job?> GetJobByIdAsync(Guid id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (job == null) return null;

            return job;
        }

        public async Task<Job?> updateJobAsync(Guid id, UpdateJob update)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (job == null) return null;

            if (update.Title != null) job.Title = update.Title;
            if (update.Description != null) job.Description = update.Description;
            if (update.Location != null) job.Location = update.Location;
            if (update.Type != null) job.Type = update.Type;
            if (update.StartDate != job.StartDate) job.StartDate = update.StartDate;
            if (update.EndDate != job.EndDate) job.EndDate = update.EndDate;
            if (update.IsPaid != job.IsPaid) job.IsPaid = update.IsPaid;

            await _context.SaveChangesAsync();
            return job;
            

        }
    }
}
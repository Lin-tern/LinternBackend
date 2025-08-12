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

            if (!string.IsNullOrWhiteSpace(update.Title)) job.Title = update.Title;
            if (!string.IsNullOrWhiteSpace(update.Description)) job.Description = update.Description;
            if (!string.IsNullOrWhiteSpace(update.Location)) job.Location = update.Location;
            if (!string.IsNullOrWhiteSpace(update.Type)) job.Type = update.Type;
            if (update.StartDate.HasValue) job.StartDate = update.StartDate.Value;
            if (update.EndDate.HasValue) job.EndDate = update.EndDate.Value;
            if (update.IsPaid.HasValue) job.IsPaid = update.IsPaid.Value;

            await _context.SaveChangesAsync();
            return job;
            

        }
    }
}
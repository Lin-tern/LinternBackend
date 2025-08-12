using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace LinternBackend.Applications
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;
        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Application?> create(Application create)
        {
            await _context.Applications.AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<Application?> deleteById(Guid id)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(c => c.Id == id);
            if (application == null) return null;

            _context.Applications.Remove(application);
            return application;
        }

        public async Task<List<Application>> getAll()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application?> getById(Guid id)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(c => c.Id == id);
            if (application == null) return null;

            return application;
        }

        public async Task<Application?> update(Guid id, UpdateApplication update)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(c => c.Id == id);
            if (application == null) return null;

            if (!String.IsNullOrWhiteSpace(update.Status)) application.Status = update.Status;
            if (!String.IsNullOrWhiteSpace(update.CoverLetter)) application.CoverLetter = update.CoverLetter;

            await _context.SaveChangesAsync();
            return application;

        }
    }
}
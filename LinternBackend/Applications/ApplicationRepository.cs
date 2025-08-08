using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Data;

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
    }
}
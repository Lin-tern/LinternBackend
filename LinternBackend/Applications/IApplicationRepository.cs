using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Applications
{
    public interface IApplicationRepository
    {
        public Task<List<Application>> getAll();
        public Task<Application?> getById(Guid id);
        public Task<Application?> create(Application create);
    }
}
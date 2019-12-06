using Domain.Projects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Projects
{
    public sealed class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsDbContext _context;

        public ProjectRepository(ProjectsDbContext context)
        {
            _context = context;
        }

        public async Task<Project> Load(Guid id, CancellationToken cancellationToken = default) 
            => await _context.Projects
                .Include(p => p.Issues)
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

        public async Task Save(Project aggregate)
        {
            await _context.SaveChangesAsync();
        }
    }
}

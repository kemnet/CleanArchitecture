using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Users
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<User> Load(Guid id, CancellationToken cancellationToken = default) 
            => await _context.Users
                .Include(u => u.Projects)
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

        public async Task Save(User aggregate)
        {
            if (_context.Entry(aggregate).State == EntityState.Detached)
                await _context.AddAsync(aggregate);

            await _context.SaveChangesAsync();
        }
    }
}

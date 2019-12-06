using Application.Users.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Users.QueryHandlers
{
    public sealed class UsersQueriesHandler :
        IGetUserByIdQueryHandler,
        IGetUsersQueryHandler
    {
        private readonly UsersQueriesDbContext _context;

        public UsersQueriesHandler(UsersQueriesDbContext context)
        {
            _context = context;
        }

        public async Task<UserView> Handle(GetUserByIdQuery query)
        {
            return await _context.Users
                .Where(u => u.Id == query.UserId)
                .Select(u => new UserView
                {
                    Name = u.Name
                })
                .SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<UserReference>> Handle(GetUsersQuery query)
        {
            return await _context.Users
                .Select(u => new UserReference
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();
        }
    }
}

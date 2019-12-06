using System.Collections.Generic;

namespace Application.Users.Queries
{
    public interface IGetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserReference>> { }
}

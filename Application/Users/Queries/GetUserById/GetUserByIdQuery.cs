using System;

namespace Application.Users.Queries
{
    public sealed class GetUserByIdQuery : IQuery<UserView>
    {
        public Guid UserId { get; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

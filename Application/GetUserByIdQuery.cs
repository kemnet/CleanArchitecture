using System;

namespace Application
{
    public class GetUserByIdQuery
    {
        public Guid UserId { get; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
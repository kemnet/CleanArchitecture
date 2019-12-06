using System;
using Domain;

namespace Application
{
    public class GetUserByIdQueryHandler<T> : IHandleQuery<GetUserByIdQuery, User>
    {
        private readonly IStore store;

        public GetUserByIdQueryHandler(IStore store)
        {
            this.store = store;
        }

        public User HandleQuery(GetUserByIdQuery query)
        {
            var userKey = new SimpleKey(query.UserId.ToString());
            return store.Load<User>(userKey);
        }
    }
}
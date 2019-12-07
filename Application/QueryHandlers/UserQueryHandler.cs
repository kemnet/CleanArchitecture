using Domain;

namespace Application
{
    public class UserQueryHandler : IHandleQuery<GetByIdQuery, User>
    {
        private readonly IStore store;

        public UserQueryHandler(IStore store)
        {
            this.store = store;
        }

        public User HandleQuery(GetByIdQuery query)
        {
            var userKey = new SimpleKey(query.Id.ToString());
            return store.Load<User>(userKey);
        }
    }
}
using Domain;
using Persistance;

namespace Application
{
    public class UserQueryHandler : IHandleQuery<GetByIdQuery, User>
    {
        private readonly ISnapshotStore _snapshotStore;

        public UserQueryHandler(ISnapshotStore snapshotStore)
        {
            this._snapshotStore = snapshotStore;
        }

        public User HandleQuery(GetByIdQuery query)
        {
            var userKey = new SimpleKey(query.Id.ToString());
            return _snapshotStore.Load<User>(userKey);
        }
    }
}
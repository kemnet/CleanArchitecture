using Domain;
using Persistance;

namespace Application
{
    public class ProjectQueryHandler : IHandleQuery<GetByIdQuery, Project>
    {
        private readonly ISnapshotStore _snapshotStore;

        public ProjectQueryHandler(ISnapshotStore snapshotStore)
        {
            this._snapshotStore = snapshotStore;
        }

        public Project HandleQuery(GetByIdQuery query)
        {
            var projectKey = new SimpleKey(query.Id.ToString());
            return _snapshotStore.Load<Project>(projectKey);
        }
    }
}
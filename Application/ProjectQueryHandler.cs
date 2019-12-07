using Domain;

namespace Application
{
    public class ProjectQueryHandler : IHandleQuery<GetByIdQuery, Project>
    {
        private readonly IStore store;

        public ProjectQueryHandler(IStore store)
        {
            this.store = store;
        }

        public Project HandleQuery(GetByIdQuery query)
        {
            var projectKey = new SimpleKey(query.Id.ToString());
            return store.Load<Project>(projectKey);
        }
    }
}
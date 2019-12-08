using System;
using Domain;
using Persistance;
using SimpleInjector;

namespace Application
{
    public class Application
    {
        private Container container  = new Container();

        public Application()
        {
            container.RegisterSingleton<ISnapshotStore>(() => new InMemorySnapshotStore.SnapshotStore());
            container.Register(typeof(IHandleCommand<>), typeof(IHandleCommand<>).Assembly);
            container.Register(typeof(IHandleQuery<,>), typeof(IHandleQuery<,>).Assembly);
        }
        
        public Project CreateProject(User user, string projectName)
        {
            var projectId = Guid.NewGuid();
            HandleCommand(new CreateProjectCommand(projectId, projectName, user.Id));
            
            return HandleQuery<GetByIdQuery, Project>(new GetByIdQuery(projectId));
        }

        public User CreateUser(string userName)
        {
            var userId = Guid.NewGuid();
            HandleCommand(new CreateUserCommand(userId, userName));

            return GetUser(userId);
        }

        public User GetUser(Guid userId)
        {
            var store = container.GetInstance<ISnapshotStore>();
            
            var query = new GetByIdQuery(userId);
            return new UserQueryHandler(store).HandleQuery(query);
        }
        
        private void HandleCommand<T>(T command) where T : ICommand
        {
            container.GetInstance<IHandleCommand<T>>().HandleCommand(command);
        }
        
        private TResponse HandleQuery<TQuery, TResponse>(TQuery query) where TQuery : IQuery
        {
            return container.GetInstance<IHandleQuery<TQuery, TResponse>>().HandleQuery(query);
        }

    }
}
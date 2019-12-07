using System;
using Domain;

namespace Application
{
    public class Application
    {
        private readonly IStore store = new InMemoryStore.Store();
        
        public Project CreateProject(User user, string projectName)
        {
            var projectId = Guid.NewGuid();
            var command = new CreateProjectCommand(projectId, projectName, user.Id);
            new CreateProjectCommandHandler(store).HandleCommand(command);
            var query = new GetByIdQuery(projectId);
            
            return new ProjectQueryHandler(store).HandleQuery(query);
        }

        public User CreateUser(string userName)
        {
            var userId = Guid.NewGuid();
            var command = new CreateUserCommand(userId, userName);
            new CreateUserCommandHandler(store).HandleCommand(command);

            return GetUser(userId);
        }

        public User GetUser(Guid userId)
        {
            var query = new GetByIdQuery(userId);
            return new UserQueryHandler(store).HandleQuery(query);
        }
    }
}
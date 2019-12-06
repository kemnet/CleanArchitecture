using System;
using Domain;

namespace Application
{
    public class Application
    {
        private readonly IStore store = new InMemoryStore.Store();
        
        public void CreateProject(Guid userId, string projectName)
        {
            var command = new CreateProjectCommand(projectName, userId);
            new CreateProjectCommandHandler(store).HandleCommand(command);
        }

        public void CreateUser(Guid userId, string userName)
        {
            var command = new CreateUserCommand(userId, userName);
            new CreateUserCommandHandler(store).HandleCommand(command);
        }

        public User GetUser(Guid userId)
        {
            var query = new GetUserByIdQuery(userId);
            return new GetUserByIdQueryHandler<User>(store).HandleQuery(query);
        }
    }
}
using System;
using Domain;

namespace Application
{
    public class CreateProjectCommandHandler : IHandleCommand<CreateProjectCommand>
    {
        private readonly IStore store;

        public CreateProjectCommandHandler(IStore store)
        {
            this.store = store;
        }

        public void HandleCommand(CreateProjectCommand command)
        {
            if (string.IsNullOrEmpty(command.ProjectName)) {
                throw new Exception("Project is now alloed to have empty name");
            }
            if (command.UserId == Guid.Empty) {
                throw new Exception("User is not allowed to have empty Key");
            }

            var userKey = new SimpleKey(command.UserId.ToString());
            var userBeforeUpdate = store.Load<User>(userKey);
            var user = store.Load<User>(userKey);
            
            if (user.ProjectCount >= 5) {
                throw new Exception("User is not allowed to have more than 5 projects");
            }
            
            var projectKey = new SimpleKey(command.ProjectId.ToString());
            try {
                var project = store.Create(projectKey, new Project(command.ProjectName, command.UserId));
                user.AddProject();
            }
            catch (Exception) {
                store.Update(userKey, userBeforeUpdate);
                store.Delete<Project>(projectKey);
                    
                throw new Exception($"Failed to apply {nameof(CreateProjectCommand)}");
            }
        }
    }
}
using System;
using Domain;
using Persistance;

namespace Application
{
    public class CreateProjectCommandHandler : IHandleCommand<CreateProjectCommand>
    {
        private readonly ISnapshotStore _snapshotStore;

        public CreateProjectCommandHandler(ISnapshotStore snapshotStore)
        {
            this._snapshotStore = snapshotStore;
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
            var userBeforeUpdate = _snapshotStore.Load<User>(userKey);
            var user = _snapshotStore.Load<User>(userKey);
            
            if (user.ProjectCount >= 5) {
                throw new Exception("User is not allowed to have more than 5 projects");
            }
            
            var projectKey = new SimpleKey(command.ProjectId.ToString());
            try {
                var project = _snapshotStore.Create(projectKey, new Project(command.ProjectName, command.UserId));
                user.AddProject();
            }
            catch (Exception) {
                _snapshotStore.Update(userKey, userBeforeUpdate);
                _snapshotStore.Delete<Project>(projectKey);
                    
                throw new Exception($"Failed to apply {nameof(CreateProjectCommand)}");
            }
        }
    }
}
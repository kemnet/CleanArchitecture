using Domain;
using Persistance;

namespace Application
{
    public class CreateUserCommandHandler : IHandleCommand<CreateUserCommand>
    {
        private readonly ISnapshotStore _snapshotStore;

        public CreateUserCommandHandler(ISnapshotStore snapshotStore)
        {
            this._snapshotStore = snapshotStore;
        }

        public void HandleCommand(CreateUserCommand command)
        {
            var userKey = new SimpleKey(command.UserId.ToString());
            _snapshotStore.Create(userKey, new User(command.UserName, command.UserId));
        }
    }
}
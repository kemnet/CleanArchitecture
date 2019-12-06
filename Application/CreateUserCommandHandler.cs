using System;
using Domain;

namespace Application
{
    public class CreateUserCommandHandler : IHandleCommand<CreateUserCommand>
    {
        private readonly IStore store;

        public CreateUserCommandHandler(IStore store)
        {
            this.store = store;
        }

        public void HandleCommand(CreateUserCommand command)
        {
            var userKey = new SimpleKey(command.UserId.ToString());
            store.Create(userKey, new User(command.UserName));
        }
    }
}
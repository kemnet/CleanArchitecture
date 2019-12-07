using System;

namespace Domain
{
    public class CreateUserCommand : ICommand
    {
        public readonly Guid UserId;
        public readonly string UserName;

        public CreateUserCommand(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
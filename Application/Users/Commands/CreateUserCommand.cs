using System;

namespace Application.Users
{
    public class CreateUserCommand
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
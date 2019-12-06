using System;
using System.Threading.Tasks;
using Domain.Users;

namespace Application.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand cmd)
        {
            //TODO: validate cmd

            var user = await _repository.Load(cmd.UserId);
            if (user != null)
            {
                if (user.Name != cmd.UserName)
                    throw new InvalidOperationException("User with same ID already exists");

                return;
            }

            user = new User(cmd.UserId, cmd.UserName);

            await _repository.Save(user);
        }
    }
}
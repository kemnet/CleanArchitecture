using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Users;

namespace Application.Users
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand>
    {
        private readonly IUserRepository _repository;

        public CreateProjectCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProjectCommand cmd)
        {
            //TODO: validate cmd
            var user = await _repository.Load(cmd.UserId);
            if (user == null)
                throw new InvalidOperationException($"User with ID {cmd.UserId} not found");

            var project = user.Projects.FirstOrDefault(p => p.Id == cmd.ProjectId);
            if (project != null)
            { 
                if (project.Title != cmd.ProjectTitle)
                    throw new InvalidOperationException($"Project with same ID already exists");

                return;
            }

            user.CreateProject(cmd.ProjectId, cmd.ProjectTitle);

            await _repository.Save(user);
        }
    }
}
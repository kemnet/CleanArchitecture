using Domain.Projects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Projects
{
    public sealed class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        private readonly IProjectRepository _repository;

        public CreateIssueCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateIssueCommand cmd)
        {
            var project = await _repository.Load(cmd.ProjectId);
            if (project == null)
                throw new InvalidOperationException($"Project with ID {cmd.ProjectId} not found");

            var issue = project.Issues.FirstOrDefault(i => i.Id == cmd.IssueId);
            if (issue != null)
            {
                if (issue.Title != cmd.IssueTitle)
                    throw new InvalidOperationException("Issue with same ID already exists");

                return;
            }

            project.CreateIssue(cmd.IssueId, cmd.IssueTitle);

            await _repository.Save(project);
        }
    }
}
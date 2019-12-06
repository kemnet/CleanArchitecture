using System;

namespace Application.Users
{
    public class CreateProjectCommand : ICommand
    {
        public readonly Guid UserId;
        public readonly Guid ProjectId;
        public readonly string ProjectTitle;

        public CreateProjectCommand(Guid userId, Guid projectId, string projectName)
        {
            UserId = userId;
            ProjectId = projectId;
            ProjectTitle = projectName;
        }
    }
}
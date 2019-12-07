using System;

namespace Domain
{
    public class CreateProjectCommand : ICommand
    {
        public readonly Guid UserId;
        public readonly Guid ProjectId;
        public readonly string ProjectName;

        public CreateProjectCommand(Guid projectId, string projectName, Guid userId)
        {
            ProjectName = projectName;
            UserId = userId;
            ProjectId = projectId;
        }
    }
}
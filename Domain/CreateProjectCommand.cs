using System;

namespace Domain
{
    public class CreateProjectCommand : ICommand
    {
        public readonly Guid UserId;
        public readonly string ProjectName;

        public CreateProjectCommand(string projectName, Guid userId)
        {
            ProjectName = projectName;
            UserId = userId;
        }
    }
}
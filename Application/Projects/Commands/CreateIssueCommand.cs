using System;

namespace Application.Projects
{
    public class CreateIssueCommand : ICommand
    {
        public readonly Guid ProjectId;
        public readonly Guid IssueId;
        public readonly string IssueTitle;

        public CreateIssueCommand(Guid projectId, Guid issueId, string issueTitle)
        {
            ProjectId = projectId;
            IssueId = issueId;
            IssueTitle = issueTitle;
        }
    }
}
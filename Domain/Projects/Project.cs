using System;
using System.Collections.Generic;

namespace Domain.Projects
{
    public sealed class Project : IAggregateRoot
    {
        private readonly ICollection<Issue> _issues;

        private Project() 
        {
            _issues = new List<Issue>();
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public IEnumerable<Issue> Issues { get; private set; }

        internal Guid _concurrencyToken;

        public void CreateIssue(Guid id, string title)
        {
            if (_issues.Count > 100)
                throw new IssuesLimitReachedException();

            _issues.Add(new Issue(id, title));

            _concurrencyToken = Guid.NewGuid();
        }
    }
}

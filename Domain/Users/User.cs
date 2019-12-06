using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    public sealed class User : IAggregateRoot
    {
        private readonly ICollection<Project> _projects;
        private User() { } //need for EF
        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
            _projects = new List<Project>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Project> Projects => _projects;

        internal Guid _concurrencyToken;

        public void CreateProject(Guid id, string title)
        {
            if (_projects.Count() > 4)
                throw new ProjectsLimitReachedException();

            _projects.Add(new Project(id, title));

            _concurrencyToken = new Guid();
        }
    }
}
using System;

namespace Domain
{
    public class User
    {
        public readonly Guid Id;
        public readonly string Name;
        public int ProjectCount { get; private set; }

        public User(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public void AddProject()
        {
            ProjectCount = ProjectCount + 1;
        }
    }
}
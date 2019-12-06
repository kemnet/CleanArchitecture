using System;
using System.Collections;

namespace Domain
{
    public class Project
    {
        public readonly string Name;
        public readonly Guid UserId;

        public Project(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
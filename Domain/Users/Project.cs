using System;

namespace Domain.Users
{
    public sealed class Project : IEntity
    {
        private Project() { } //need for EF
        internal Project(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
    }
}
using System;

namespace Domain.Projects
{
    public sealed class Issue : IEntity
    {
        private Issue() { }

        internal Issue(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
    }
}

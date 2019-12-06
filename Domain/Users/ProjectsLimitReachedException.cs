using System;

namespace Domain.Users
{
    public sealed class ProjectsLimitReachedException : Exception
    {
        public ProjectsLimitReachedException()
        {
        }
    }
}
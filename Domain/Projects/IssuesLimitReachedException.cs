using System;

namespace Domain.Projects
{
    internal class IssuesLimitReachedException : Exception
    {
        public IssuesLimitReachedException()
        {
        }
    }
}
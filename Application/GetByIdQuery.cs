using System;

namespace Application
{
    public class GetByIdQuery
    {
        public Guid Id { get; }

        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
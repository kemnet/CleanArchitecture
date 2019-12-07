using System;

namespace Application
{
    public class GetByIdQuery : IQuery
    {
        public Guid Id { get; }

        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
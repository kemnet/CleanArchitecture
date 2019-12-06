using System.Threading.Tasks;

namespace Application
{
    public interface IQueryHandler<TQuery, TView>
        where TQuery : IQuery<TView>
    {
        Task<TView> Handle(TQuery query);
    }
}

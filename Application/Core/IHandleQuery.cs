namespace Application
{
    public interface IHandleQuery<TQuery, TResponse>
    {
        TResponse HandleQuery(TQuery query);
    }
}
using Application;

namespace Persistance
{
    public interface ISnapshotStore
    {
        T Create<T>(IKey key, T item);

        T Load<T>(IKey key);

        T Update<T>(IKey key, T item);

        bool Delete<T>(IKey key);
    }
}
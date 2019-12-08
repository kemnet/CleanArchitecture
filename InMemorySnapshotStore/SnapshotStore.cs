using System;
using System.Collections.Concurrent;
using Application;
using Persistance;

namespace InMemorySnapshotStore
{
    public class SnapshotStore : ISnapshotStore
    {
        private ConcurrentDictionary<string, object> store = new ConcurrentDictionary<string, object>();

        public T Create<T>(IKey key, T item)
        {
            if (store.ContainsKey(key.Key))
            {
                throw new Exception($"Item with key {key} already exists");
            }

            store[key.Key] = item;

            return item;
        }
        
        public T Load<T>(IKey key)
        {
            if (!store.ContainsKey(key.Key))
            {
                throw new Exception($"Item with key {key} not found");
            }

            return (T) store[key.Key];
        }
        
        public T Update<T>(IKey key, T item)
        {
            if (!store.ContainsKey(key.Key))
            {
                throw new Exception($"Item with key {key} not found");
            }

            store[key.Key] = item;

            return item;
        }
        
        public bool Delete<T>(IKey key)
        {
            if (!store.ContainsKey(key.Key))
            {
                throw new Exception($"Item with key {key} not found");
            }

            return store.TryRemove(key.Key, out var removed);
        }
    }
}
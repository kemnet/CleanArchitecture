using System;

namespace Application
{
    public interface IHasKey
    {
        IKey Key { get; }
    }

    public interface IKey
    {
        string Key { get; }
    }

    public class SimpleKey : IKey
    {
        public SimpleKey(string value)
        {
            Key = value;
        }

        public string Key { get; }
    }
}
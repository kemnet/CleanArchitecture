namespace Application
{
    public interface IHandleCommand<T>
    {
        void HandleCommand(T command);
    }
}
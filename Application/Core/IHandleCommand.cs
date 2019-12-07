using Domain;

namespace Application
{
    public interface IHandleCommand<in T> where T : ICommand
    {
        void HandleCommand(T command);
    }
}
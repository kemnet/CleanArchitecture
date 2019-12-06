using System.Threading.Tasks;

namespace Application
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
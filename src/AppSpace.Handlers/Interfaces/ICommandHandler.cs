using System;
using System.Threading.Tasks;

namespace AppSpace.Handlers.Interfaces
{
    public interface ICommandHandler<T, V> where T : ICommand
    {
        Task<V> HandleAsync(T command);
    }
}

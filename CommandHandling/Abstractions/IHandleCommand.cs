using System.Threading.Tasks;

namespace CommandHandling.Abstractions
{
    public interface IHandleCommand<in TCommand> where TCommand : Acommand
    {
        Task Handle(TCommand command);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandling.Abstractions
{
    public interface ICommandPipelineBehavior<Tcommand>where Tcommand:Acommand
    {
        public Task Handle(Tcommand command, CancellationToken Token, Func<Task> next);
    }
}

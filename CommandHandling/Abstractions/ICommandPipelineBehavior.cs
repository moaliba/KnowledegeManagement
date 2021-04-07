using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandling.Abstractions
{
    public interface ICommandPipelineBehavior<Tcommand>where Tcommand:Acommand
    {
        public Task Handle(Tcommand command, Func<Task> next, CancellationToken Token);
    }
}

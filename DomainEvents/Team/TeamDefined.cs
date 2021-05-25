using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHandling.Abstractions;

namespace DomainEvents
{
    public record  TeamDefined(Guid TeamId,string Title) : AnEvent(TeamId);
}

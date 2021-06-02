using EventHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Tag
{
    public record TagStatusChanged(Guid Id,bool Status) : AnEvent(Id);
    
}

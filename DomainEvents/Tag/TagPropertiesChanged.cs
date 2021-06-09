using EventHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Tag
{
    public record TagPropertiesChanged(Guid Id,string Title, Guid? CategoryId,bool IsActive) : AnEvent(Id);
   
}

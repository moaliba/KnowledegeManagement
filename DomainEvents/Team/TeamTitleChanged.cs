﻿using EventHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Team
{
    public record TeamTitleChanged(Guid TeamId, string Title) : AnEvent(TeamId);


}

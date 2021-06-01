using EventHandling.Abstractions;
using System;

namespace KnowledgeManagement
{
    public record CategoryDefined(Guid id, string title): AnEvent(id);
}
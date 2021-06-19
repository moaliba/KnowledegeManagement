using CommandHandling.Abstractions;
using System;

namespace Commands.CategoryCommands
{
    public record ChangeCategoryPropertiesCommand(Guid Id, string Title, bool IsActive) : Acommand(Id)
    {
        public static ChangeCategoryPropertiesCommand Create(Guid Id, string Title, bool IsActive)
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new Exception("Title must be not null and empty.");
            return new ChangeCategoryPropertiesCommand(Id, Title, IsActive);
        }
    }
}

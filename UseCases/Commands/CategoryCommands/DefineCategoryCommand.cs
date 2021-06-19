using CommandHandling.Abstractions;
using System;

namespace Commands.CategoryCommands
{
    public record DefineCategoryCommand(Guid Id, string Title, bool IsActive) : Acommand(Id)
    {
        public static DefineCategoryCommand Create(Guid Id, string Title, bool IsActive)
        {
            if (Title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new DefineCategoryCommand(Id, Title, IsActive);
        }
    }
}

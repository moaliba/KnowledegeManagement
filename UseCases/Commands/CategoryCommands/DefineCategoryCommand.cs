using CommandHandling.Abstractions;
using System;

namespace Commands.CategoryCommands
{
    public record DefineCategoryCommand(Guid Id, string Title) : Acommand(Id)
    {
        public static DefineCategoryCommand Create(Guid Id, string Title)
        {
            if (Title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new DefineCategoryCommand(Id, Title);
        }
    }
}

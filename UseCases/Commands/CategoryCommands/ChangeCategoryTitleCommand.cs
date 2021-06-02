using CommandHandling.Abstractions;
using System;

namespace Commands.CategoryCommands
{
    public record ChangeCategoryTitleCommand(Guid Id, string Title) : Acommand(Id)
    {
        public static ChangeCategoryTitleCommand Create(Guid Id, string Title)
        {
            if (Title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new ChangeCategoryTitleCommand(Id, Title);
        }
    }
}

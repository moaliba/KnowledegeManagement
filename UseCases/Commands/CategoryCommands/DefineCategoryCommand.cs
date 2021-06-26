using CommandHandling.Abstractions;
using System;
using UseCases.Exceptions;

namespace Commands.CategoryCommands
{
    public record DefineCategoryCommand(Guid Id, string Title, bool IsActive) : Acommand(Id)
    {
        public static DefineCategoryCommand Create(Guid Id, string Title, bool IsActive)
        {
            if (string.IsNullOrEmpty(Title))
                throw new BadRequestException("Title must be not null and empty!!!");
            return new DefineCategoryCommand(Id, Title, IsActive);
        }
    }
}

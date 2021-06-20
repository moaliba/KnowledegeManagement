using CommandHandling.Abstractions;
using System;

namespace UseCases.Commands.CategoryCommands
{
    public record DeleteCategoryCommand(Guid id) : Acommand(id)
    {
        public static DeleteCategoryCommand Create(Guid id)
        => new(id);
    }
}

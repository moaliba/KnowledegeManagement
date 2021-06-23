using CommandHandling.Abstractions;
using System;

namespace UseCases.Commands.CategoryCommands
{
    public record CategoryChangeStatusCommand(Guid Id, bool IsActive):Acommand(Id);
    //{
    //    public static CategoryChangeStatusCommand Create(Guid Id, bool IsActive)
    //    => new(Id, IsActive);
    //}
}

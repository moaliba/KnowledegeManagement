using CommandHandling.Abstractions;
using System;


namespace UseCases.Commands.TagCommands
{
    public record ChangeTagStatusCommand(Guid Id,bool isActive) : Acommand(Id);
   
}

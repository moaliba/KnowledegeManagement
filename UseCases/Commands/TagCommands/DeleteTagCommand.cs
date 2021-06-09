using CommandHandling.Abstractions;
using System;


namespace UseCases.Commands.TagCommands
{
    public record DeleteTagCommand(Guid Id) : Acommand(Id);
    
}

using CommandHandling.Abstractions;
using System;


namespace UseCases.Commands.TagCommands
{
    public record DefineTagCommand(Guid Id,string Title,Guid? CategoryId, bool DefinedFormPost) : Acommand(Id)
    {
        public static DefineTagCommand Create(Guid id, string title, Guid? categoryId, bool DefinedFormPost)
        {
            if (title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new DefineTagCommand(id, title,categoryId, DefinedFormPost);
        }
    }
    
}

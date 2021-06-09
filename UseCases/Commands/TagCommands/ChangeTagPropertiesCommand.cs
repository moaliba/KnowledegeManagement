using CommandHandling.Abstractions;
using System;

namespace UseCases.CommandHandlers.TagCommands
{
    public record ChangeTagPropertiesCommand(Guid Id,string Title,Guid? CategoryId,bool IsActive) : Acommand(Id)
    {
        public static ChangeTagPropertiesCommand Create(Guid id, string title, Guid? categoryId, bool isActive)
        {
            if (title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new ChangeTagPropertiesCommand(id, title, categoryId,isActive);
        }
    }
    
}
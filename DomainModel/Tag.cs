using System;
using DomainModel;
using DomainEvents.Tag;


namespace DomainModel
{
    public class Tag : AggregateRoot
    {
        public string  Title { get; private set; }
        public Guid CategoryId { get; private set; }

        [Obsolete]
        Tag(){ }

        public static Tag DefineTag(Guid id, string title, Guid categoryId)
        => new(id,title,categoryId);
       

        Tag(Guid id, string title, Guid categoryId) :base(id)
        =>  RecordThat(new TagDefined(id, title, categoryId));

        void On(TagDefined e)
        {
            Title = e.Title;
            CategoryId = e.CategoryId;
        }

    }
}
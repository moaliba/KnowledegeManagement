using System;
using DomainEvents.Tag;


namespace DomainModel
{
    public class Tag : AggregateRoot
    {
        public string  Title { get; private set; }

        public bool IsActive { get; set; } = true;

        public Guid? CategoryId { get; private set; }

        [Obsolete]
        Tag(){ }

        public static Tag DefineTag(Guid id, string title, Guid? categoryId)
        => new(id,title,categoryId);
       
        Tag(Guid id, string title, Guid? categoryId) :base(id)
        =>  RecordThat(new TagDefined(id, title, categoryId));

        public void ChangeTagStatus(Guid id,bool status)
        => RecordThat(new TagStatusChanged(id,status));

        void On(TagDefined e)
        {
            Title = e.Title;
            CategoryId = e.CategoryId;
        }

        void On(TagStatusChanged e)
        {
            IsActive = e.Status;
        }
    }
}
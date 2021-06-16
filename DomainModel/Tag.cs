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

        public static Tag DefineTag(Guid id, string title, Guid? categoryId, bool DefinedFromPost)
        => new(id,title,categoryId, DefinedFromPost);
       
        Tag(Guid id, string title, Guid? categoryId, bool DefinedFormPost) :base(id)
        =>  RecordThat(new TagDefined(id, title, categoryId, DefinedFormPost));

        public void ChangeTagStatus(Guid id,bool isActive)
        => RecordThat(new TagStatusChanged(id, isActive));
        public void ChangeTagProperties(Guid id, string title, Guid? categoryId, bool isActive)
        => RecordThat(new TagPropertiesChanged(id,title,categoryId,isActive));

        public void Remove()
            => RecordThat(new TagDeleted(Id));

        void On(TagDefined e)
        {
            Title = e.Title;
            CategoryId = e.CategoryId;
        }

        void On(TagPropertiesChanged e)
        {
            Title = e.Title;
            CategoryId = CategoryId;
            IsActive = e.IsActive;
        }
        void On(TagStatusChanged e)
        {
            IsActive = e.IsActive;
        }

        void On(TagDeleted e) { }
       
    }
}
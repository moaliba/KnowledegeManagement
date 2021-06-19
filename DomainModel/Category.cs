using System;
using DomainEvents.Category;

namespace DomainModel
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }

        public bool IsActive { get; set; } = true;

        Category(Guid id, string title) : base(id)
        => RecordThat(new Categorydefined(id, title));

        public static Category DefineCategory(Guid id, string title)
        => new(id, title);

        public void ChangeStatus(Guid Id, bool isActive)
        => RecordThat(new CategoryStatusChanged(Id, isActive));

        public void ChangeProperties(Guid Id, string Title, bool IsActive)
        => RecordThat(new CategoryPropertiesChanged(Id, Title, IsActive));

        [Obsolete]
        Category()
        {
        }

        void On(Categorydefined e)
        => Title = e.CategoryTitle;

        void On(CategoryPropertiesChanged e)
        {
            Title = e.CategoryTitle;
            IsActive = e.IsActive;
        }

        void On(CategoryStatusChanged e)
        => IsActive = e.IsActive;
    }
}
using System;
using DomainEvents.Category;

namespace DomainModel
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }

        public bool IsActive { get; set; } = true;

        Category(Guid id, string title, bool IsActive) : base(id)
        => RecordThat(new Categorydefined(id, title, IsActive));

        public static Category DefineCategory(Guid id, string title, bool IsActive)
        => new(id, title, IsActive);

        public void ChangeStatus(Guid Id, bool isActive)
        => RecordThat(new CategoryStatusChanged(Id, isActive));

        public void ChangeProperties(Guid Id, string Title, bool IsActive)
        => RecordThat(new CategoryPropertiesChanged(Id, Title, IsActive));

        public void DeleteCategory(Guid Id)
        => RecordThat(new CategoryDeleted(Id));

        [Obsolete]
        Category()
        {
        }

        void On(Categorydefined e)
        {
            Title = e.CategoryTitle;
            IsActive = e.CategotyIsActive;
        }

        void On(CategoryPropertiesChanged e)
        {
            Title = e.CategoryTitle;
            IsActive = e.IsActive;
        }

        void On(CategoryStatusChanged e)
        => IsActive = e.IsActive;

        void On(CategoryDeleted e) { }
    }
}
using System;
using DomainEvents.Category;

namespace DomainModel
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }

        public Category(Guid id, string title) : base(id)
        => RecordThat(new Categorydefined(id, title));

        public static Category DefineCategory(Guid id, string title)
        => new(id, title);

        [Obsolete]
        Category()
        {
        }

        void On(Categorydefined e)
        => Title = e.title;
    }
}
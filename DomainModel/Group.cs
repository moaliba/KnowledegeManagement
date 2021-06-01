using System;
using DomainEvents.Group;

namespace DomainModel
{
    public class Group : AggregateRoot
    {
        public string Title { get; private set; }

        Group(Guid id, Guid adminId, string title) : base(id)
        {
            RecordThat(new GroupCreated(id, title));
            RecordThat(new GroupMemberSetAsGroupAdmin(id, adminId));
        }

        public static Group AddNewGroup(Guid id, Guid adminId, string title)
        => new(id, adminId, title);

        void On(GroupCreated e)
        => Title = e.Title;

        [Obsolete("For EF use")]
        Group() { }

    }
}
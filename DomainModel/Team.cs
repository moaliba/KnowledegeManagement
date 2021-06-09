using System;
using System.ComponentModel.DataAnnotations;
using DomainEvents;
using DomainEvents.Team;

namespace DomainModel
{
    public sealed class Team : AggregateRoot
    {
        //[Key]
        //public Guid TeamId { get; private set; }

        public string Title { get; private set; }

        public static Team Create(Guid TeamId, string Title)
            => new(TeamId, Title);

        [Obsolete("For EF use")]
        Team() { }

        Team(Guid Id, string Title) : base(Id)
            =>  RecordThat(new TeamDefined(Id, Title));

        public void Rename(string Title)
            => RecordThat(new TeamTitleChanged(Id, Title));

        public void Remove()
            => RecordThat(new TeamDeleted(Id));

        void On(TeamDefined e)
        {
            Title = e.Title;
        }

        void On(TeamTitleChanged e)
        {
            Title = e.Title;
        }

        void On(TeamDeleted e) { }
        



    }
}

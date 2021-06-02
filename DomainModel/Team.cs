using System;
using System.ComponentModel.DataAnnotations;
using DomainEvents;
using DomainEvents.Team;

namespace DomainModel
{
    public sealed class Team : AggregateRoot
    {
        [Key]
        public Guid TeamId { get; private set; }

        public string Title { get; private set; }

        [Obsolete("For EF use")]
        Team() { }

        public Team(Guid TeamId, string Title) : base(TeamId)
           => RecordThat(new TeamDefined(TeamId, Title));

        public static Team Create(Guid TeamId, string Title)
            => new(TeamId, Title);

        public void Rename(string Title)
            => RecordThat(new TeamTitleChanged(TeamId, Title));

        public void Remove()
            => RecordThat(new TeamDeleted(TeamId));

        void On(TeamDefined e)
        {
            TeamId = e.TeamId;
            Title = e.Title;
        }

        void On(TeamTitleChanged e)
        {
            TeamId = e.TeamId;
            Title = e.Title;
        }

        void On(TeamDeleted e)
        {
            TeamId = e.TeamId;
        }
    }
}

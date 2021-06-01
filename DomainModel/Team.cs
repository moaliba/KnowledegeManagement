using System;
using System.ComponentModel.DataAnnotations;
using DomainEvents;

namespace DomainModel
{
    public sealed class Team : AggregateRoot
    {
        [Key]
        public Guid TeamId { get; private set; }

        public string Title { get; private set; }

        public static Team Create(Guid TeamId, string Title)
            => new(TeamId, Title);

        //public static Team DefineTeam(Guid teamId, string title)
        //=> new(teamId, title);

        Team(Guid teamId, string title) : base(teamId)
        {
            RecordThat(new TeamDefined(teamId, title));
        }

        void On(TeamDefined e)
        {
            TeamId = e.TeamId;
            Title = e.Title;
        }

        [Obsolete("For EF use")]
        Team() { }


        public void Rename(string title)
        {
            this.Title = title;
        }


        //void On(TeamDefined @event)
        //{
        //    TeamId = @event.TeamId;
        //    Title = @event.Title;
        //}
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public sealed class Team
    {
        [Key]
        public Guid TeamId { get; set; }

        public string Title { get; set; }

        public static Team Create(Guid TeamId, string Title)
            => new(TeamId, Title);

        //public static Team DefineTeam(Guid teamId, string title)
        //=> new(teamId, title);

         Team(Guid TeamId, string Title)
        {
            this.TeamId = TeamId;
            this.Title = Title;
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

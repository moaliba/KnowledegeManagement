using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public sealed class Team
    {
        [Key]
        public Guid TeamId { get; }

        public string Title { get; }

        public static Team Add(Guid TeamId, string Title)
            => new(TeamId, Title);

        Team(Guid TeamId, string Title)
        {
            this.TeamId = TeamId;
            this.Title = Title;
        }
    }
}

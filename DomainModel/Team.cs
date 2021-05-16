using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public sealed class Team
    {
        [Key]
        public Guid TeamId { get; set; }

        public string Title { get; set; }

        public static Team Add(Guid TeamId, string Title)
            => new(TeamId, Title);

        public Team(Guid TeamId, string Title)
        {
            this.TeamId = TeamId;
            this.Title = Title;
        }
    }
}

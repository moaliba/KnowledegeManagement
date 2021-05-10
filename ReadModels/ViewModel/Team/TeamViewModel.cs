using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel.Team
{
    public class TeamViewModel
    {
        [Key]
        public Guid TeamId { get; set; }

        public string Title { get; set; }
    }
}

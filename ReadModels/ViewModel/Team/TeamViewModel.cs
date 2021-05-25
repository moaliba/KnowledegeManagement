using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel.Team
{
    public class TeamViewModel : IAmAViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}

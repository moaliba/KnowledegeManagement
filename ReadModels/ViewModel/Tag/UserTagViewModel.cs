using System;
using System.ComponentModel.DataAnnotations;


namespace ReadModels.ViewModel.Tag
{
    public class UserTagViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}

using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ReadModels.ViewModel.Tag
{
    public class TagViewModel : IAmAViewModel  
    {
        [Key]
        public Guid Id { get; set; }
        public string  Title { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; } = true;
        public int UsedCount { get; set; } = 0;
        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}

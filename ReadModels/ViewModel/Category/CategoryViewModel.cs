using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel
{
    public class CategoryViewModel:IAmAViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}

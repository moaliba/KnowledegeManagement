using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel
{
    public class CategoryViewModel:IAmAViewModel
    {
        [Key]
        public Guid CategoryId { get; set; }

        public string CategoryTitle { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}

using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel.Post
{
    public class PostViewModel: IAmAViewModel
    {
        [Key]
        public Guid PostId { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public Guid CategoryID { get; set; }

        public Guid UserID { get; set; }

        public string Tags { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}

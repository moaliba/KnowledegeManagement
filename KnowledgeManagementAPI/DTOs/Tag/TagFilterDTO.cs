using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs
{
    public class TagFilterDTO :FilterModelBase
    {
        public string Title { get; set; }
        public Guid? CategoryId { get; set; }

        // if it is neeeded to set default values for this model
      //  public TagFilterDTO() : base()
      //   => this.PageSize = 10;
    }
}

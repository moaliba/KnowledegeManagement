using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs
{
    public class TeamFilterDTO : FilterModelBase
    {
        public string Title { get; set; }

        public TeamFilterDTO() :base()
        => this.PageSize = 10;
        
    }
}

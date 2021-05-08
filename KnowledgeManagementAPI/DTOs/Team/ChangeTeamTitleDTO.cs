using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs
{
    public class ChangeTeamTitleDTO
    {
        public Guid TeamId { get; set; }

    [System.ComponentModel.Description("عنوان تیم")]
        public string NewTitle { get; set; }
    }
}

using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs
{
    public class TeamDefinitionDTO
    {
        [Description("عنوان تیم")]
        public string Title { get; set; }
    }
}

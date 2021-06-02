
namespace KnowledgeManagementAPI.DTOs
{
    public class TeamFilterDTO : FilterModelBase
    {
        public string Title { get; set; }

        public TeamFilterDTO() :base()
        => this.PageSize = 10;
    }
}

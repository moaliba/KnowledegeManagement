using Xunit;
using FluentAssertions;
using KnowledgeManagement;

namespace KnowledgeManagement
{
    public class AddsnewcategorySpec
    {
        [Fact]
        public void Addsnewcategory()
        {
            var category = Category.Definecategory("1", "Programming");
            category.Events.Should().ContainEquivalentOf(
                    new Categorydefined("1", "Programming")
                );
        }
    }
}
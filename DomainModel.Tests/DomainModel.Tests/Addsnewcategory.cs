using Xunit;
using FluentAssertions;
using System;
using DomainModel;

namespace KnowledgeManagement
{
    public class AddsnewcategorySpec
    {
        [Theory]
        [InlineData("Programming")]
        [InlineData("Cooking")]
        public void AddsNewCategory(string title)
        {
            Guid id = Guid.NewGuid();
            var category = Category.DefineCategory(id, title);
            category.Events.Should().ContainEquivalentOf(
                    new CategoryDefined(id, title)
                );
        }
    }
}
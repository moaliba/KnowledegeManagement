using Xunit;
using FluentAssertions;
using System;
using DomainModel;
using DomainEvents.Category;

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
                    new Categorydefined(id, title)
                );
        }
    }
}
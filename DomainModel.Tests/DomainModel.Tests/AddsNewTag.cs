using Xunit;
using FluentAssertions;
using System;
using EventHandling.Abstractions;
using DomainEvents.Tag;
using DomainModel;

namespace KnowledgeManagement
{
    public class AddsnewtagSpec
    {
        [Theory]
        [InlineData("C#")]
        [InlineData("React")]
        public void Addsnewtag(string title)
        {
            var id = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var tag = Tag.DefineTag(id, title, categoryId);
            tag.Events.Should().ContainEquivalentOf(
                    new TagDefined(id, title, categoryId)
              );
        }
    }


}

  
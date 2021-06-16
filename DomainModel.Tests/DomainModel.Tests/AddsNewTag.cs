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
        [InlineData("C#", true)]
        [InlineData("React", false)]
        public void Addsnewtag(string title, bool DefinedFromPost)
        {
            var id = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var tag = Tag.DefineTag(id, title, categoryId, DefinedFromPost);
            tag.Events.Should().ContainEquivalentOf(
                    new TagDefined(id, title, categoryId, DefinedFromPost)
              );
        }
    }


}

  
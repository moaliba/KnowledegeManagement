using Xunit;
using FluentAssertions;
using System;
using DomainEvents.Group;
using DomainModel;

namespace KnowledgeManagement
{
    public class GroupTests
    {
        [Theory]
        [InlineData("Supply")]
        [InlineData("Budget")]
        public void AddsNewGroup(string title)
        {
            var id = Guid.NewGuid();
            var group = Group.AddNewGroup(id, Guid.NewGuid(), title);
            group.Events.Should().ContainEquivalentOf(new GroupCreated(id, title));
        }

        [Fact]
        public void SetsTheGroupAdmin()
        {
            var groupId = Guid.NewGuid();
            var adminId = Guid.NewGuid();
            var group = Group.AddNewGroup(groupId, adminId, "Supply");
            group.Events.Should().ContainEquivalentOf(
                    new GroupMemberSetAsGroupAdmin(groupId, adminId)
                );
        }
    }
}
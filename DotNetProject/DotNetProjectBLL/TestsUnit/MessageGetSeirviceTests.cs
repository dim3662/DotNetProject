using System;
using System.Threading.Tasks;
using AutoFixture;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectBLL.Implementations;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using Moq;
using NUnit.Framework;
using FluentAssertions;
namespace DotNetProject.DotNetProjectBLL.TestsUnit
{
    [TestFixture]
    public class MessageGetSeirviceTests
    {
        [Test]
        public async Task ValidateAsync_MessageExists_DoesNothing()
        {
            // Arrange
            var MessageContainer = new Mock<IMessageContainer>();

            var Message = new Message("test");
            var MessageDataAccess = new Mock<IMessageDataAccess>();
            MessageDataAccess.Setup(x => x.GetByAsync(MessageContainer.Object)).ReturnsAsync(Message);

            var departmentGetService = new MessageGetService(MessageDataAccess.Object);

            // Act
            var action = new Func<Task>(() => departmentGetService.ValidateAsync(MessageContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_MessageNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var MessageContainer = new Mock<IMessageContainer>();
            MessageContainer.Setup(x => x.MessageId).Returns(id);

            var Message = new Message("test");
            var MessageDataAccess = new Mock<IMessageDataAccess>();
            MessageDataAccess.Setup(x => x.GetByAsync(MessageContainer.Object)).ReturnsAsync((Message) null);

            var departmentGetService = new MessageGetService(MessageDataAccess.Object);

            // Act
            var action = new Func<Task>(() => departmentGetService.ValidateAsync(MessageContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Department not found by id {id}");
        }
    }
}
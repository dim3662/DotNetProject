using System;
using System.Threading.Tasks;
using AutoFixture;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectBLL.Implementations;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace DotNetProject.DotNetProjectBLL.TestsUnit
{
    public class SecretGetServiceTests
    {
        [Test]
        public async Task CreateAsync_SecretValidationSucceed_CreatesEmployee()
        {
            // Arrange
            var secret = new SecretUpdateModel();
            var expected = new Secret();
            
            var messageGetService = new Mock<IMessageGetService>();
            messageGetService.Setup(x => x.ValidateAsync(secret));

            var secretDataAccess = new Mock<ISecretDataAccess>();
            secretDataAccess.Setup(x => x.InsertAsync(secret)).ReturnsAsync(expected);

            var secretGetService = new SecretCreateService(secretDataAccess.Object, messageGetService.Object);
            
            // Act
            var result = await secretGetService.CreateAsync(secret);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_SecretValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var secret = new SecretUpdateModel();
            var expected = fixture.Create<string>();
            
            var messageGetService = new Mock<IMessageGetService>();
            messageGetService
                .Setup(x => x.ValidateAsync(secret))
                .Throws(new InvalidOperationException(expected));

            var secretDataAccess = new Mock<ISecretDataAccess>();

            var secretGetService = new SecretCreateService(secretDataAccess.Object, messageGetService.Object);
            
            // Act
            var action = new Func<Task>(() => secretGetService.CreateAsync(secret));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            secretDataAccess.Verify(x => x.InsertAsync(secret), Times.Never);
        }
    }
}
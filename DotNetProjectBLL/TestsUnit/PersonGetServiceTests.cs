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
    public class PersonGetServiceTests
    {
        [Test]
        public async Task CreateAsync_PersonValidationSucceed_CreatesEmployee()
        {
            // Arrange
            var person = new PersonUpdateModel();
            var expected = new Person();

            var secretGetService = new Mock<ISecretGetService>();
            secretGetService.Setup(x => x.ValidateAsync(person));

            var personDataAccess = new Mock<IPersonDataAccess>();
            personDataAccess.Setup(x => x.InsertAsync(person)).ReturnsAsync(expected);

            var personGetService = new PersonCreateService(personDataAccess.Object, secretGetService.Object);

            // Act
            var result = await personGetService.CreateAsync(person);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_PersonValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var person = new PersonUpdateModel();
            var expected = fixture.Create<string>();

            var secretGetService = new Mock<ISecretGetService>();
            secretGetService
                .Setup(x => x.ValidateAsync(person))
                .Throws(new InvalidOperationException(expected));

            var personDataAccess = new Mock<IPersonDataAccess>();

            var personGetService = new PersonCreateService(personDataAccess.Object, secretGetService.Object);

            // Act
            var action = new Func<Task>(() => personGetService.CreateAsync(person));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            personDataAccess.Verify(x => x.InsertAsync(person), Times.Never);
        }
    }
}
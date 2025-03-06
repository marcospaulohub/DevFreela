using FluentAssertions;
using Moq;
using NSubstitute;
using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.UnitTests.Fakes;

namespace DevFreela.UnitTests.Application
{
    public class InsertProjectHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Insert_Success_NSubstitute()
        {
            // Arrante
            const int ID = 1;
            var repository = Substitute.For<IProjectRepository>();
            repository.Add(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var command = FakeDataHelper.CreateFakeInsertProjectCommand();

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());


            // Assert
            //xUnit
            Assert.True(result.IsSuccess);
            //FluentAssertions
            result.IsSuccess.Should().BeTrue();

            //xUnit
            Assert.Equal(ID, result.Data);
            //FluentAssertions
            result.Data.Should().Be(ID);


            await repository.Received(1).Add(Arg.Any<Project>());
        }

        [Fact]
        public async Task InputDataAreOk_Insert_Success_Moq()
        {
            // Arrante
            const int ID = 1;

            //opção 1
            //var mock = new Mock<IProjectRepository>();
            //mock.Setup(r => r.Add(It.IsAny<Project>())).ReturnsAsync(ID);

            //opção 2
            var repository = Mock.Of<IProjectRepository>(r => r.Add(It.IsAny<Project>()) == Task.FromResult(ID));

            var command = FakeDataHelper.CreateFakeInsertProjectCommand();

            //opção 1
            //var handler = new InsertProjectHandler(mock.Object);

            //opção 2
            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);

            //opção 1
            //mock.Verify(m => m.Add(It.IsAny<Project>()), Times.Once);

            //opção 2
            Mock.Get(repository).Verify(m => m.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}

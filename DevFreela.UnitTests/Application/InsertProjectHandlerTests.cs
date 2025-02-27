using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using NSubstitute;

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


            var command = new InsertProjectCommand("Project A", "Descrição do Projeto", 1, 2, 1000);

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data); 
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

            var command = new InsertProjectCommand("Project A", "Descrição do Projeto", 1, 2, 1000);

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

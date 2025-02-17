﻿using DevFreela.Application.Commands.Projects.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application
{
    public class DeleteProjectHandlerTests
    {
        [Fact]
        public async Task ProjectExists_Delete_Success_NSubstitute()
        {
            // Arrange 
            const int ID = 1;
            var project = new Project("Projeto A", "Descrição do Projeto", 1, 2, 20000);

            var repository = Substitute.For<IProjectRepository>();
            repository.GetById(1).Returns(Task.FromResult((Project?)project));
            repository.Update(Arg.Any<Project>()).Returns(Task.CompletedTask);
            
            var handler = new DeleteProjectHandler(repository);

            var command = new DeleteProjectCommand(ID);

            // Act 
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            await repository.Received(1).GetById(ID);
            await repository.Received(1).Update(Arg.Any<Project>());
        }

        [Fact]
        public async Task ProjectDoesNotExist_Delete_Error_NSubstitute()
        {
            // Arrange 
            var repository = Substitute.For<IProjectRepository>();
            repository.GetById(Arg.Any<int>()).Returns(Task.FromResult((Project?)null));

            var handler = new DeleteProjectHandler(repository);

            var command = new DeleteProjectCommand(1);

            // Act 
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ProjectMsgs.GetProjectNotExist(), result.Message);

            await repository.Received(1).GetById(Arg.Any<int>());
            await repository.DidNotReceive().Update(Arg.Any<Project>());

        }
    }
}

using DevFreela.Application.Commands.Projects.InsertComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application
{
    public class InsertCommentHandlerTests
    {
        [Fact]
        public async Task ProjectDoesNotExist_Error_NSubstitute()
        {
            // Arrange
            var repository = Substitute.For<IProjectRepository>();
            repository.AddComment(Arg.Any<ProjectComment>()).Returns(Task.FromResult);

            var command = new InsertCommentCommand("Comentário", 1, 1);
            var handler = new InsertCommentHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ProjectMsgs.GetProjectNotExist(), result.Message);
        }
    }
}

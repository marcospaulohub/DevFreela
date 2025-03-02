using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.UnitTests.Fakes;
using FluentAssertions;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIsCreated_Ok_Success()
        {
            // Arrange + Act
            var project = FakeDataHelper.CreateFakeProject();

            // Assert

            //xUnit
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            //FluentAssertions
            project.Status.Should().Be(ProjectStatusEnum.Created);

            //xUnit
            Assert.Null(project.StartedAt);
            //FluentAssertions
            project.StartedAt.Should().BeNull();

            Assert.True(project.Status == ProjectStatusEnum.Created);
            Assert.True(project.StartedAt is null);
            Assert.True(project.Comments.Count == 0);
        }

        [Fact]
        public void ProjectIsCreatedAndStart_Ok_Success()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();

            // Act
            project.Start();

            // Assert
            //xUnit
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            //FluentAssertions
            project.Status.Should().Be(ProjectStatusEnum.InProgress);

            //xUnit
            Assert.NotNull(project.StartedAt);
            //FluentAssertions
            project.StartedAt.Should().NotBeNull();

            Assert.True(project.Comments.Count == 0);
        }

        [Fact]
        public void ProjectIsCreatedAndStartAndComplet_Ok_Success()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();

            // Act
            project.Start();
            project.Complete();

            // Assert
            Assert.True(project.CreatedAt.Date == DateTime.Now.Date);
            Assert.True(project.StartedAt.GetValueOrDefault().Date ==  DateTime.Now.Date);
            Assert.True(project.CompletedAt.GetValueOrDefault().Date == DateTime.Now.Date);
        }

        [Fact]
        public void Update_ProjectAndDataAreOk_Success()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();

            var newTitle = "New Title";
            var newDescription = "New Description";
            var newTotalCost = 20000m;

            // Act
            project.Update(newTitle, newDescription, newTotalCost);

            // Assert
            Assert.Equal(newTitle, project.Title);
            Assert.Equal(newDescription, project.Description);
            Assert.Equal(newTotalCost, project.TotalCost);
        }

        [Fact]
        public void ProjectIsCreatedAndClintAndFreelance_Ok_Success()
        {
            // Arrange
            var client = FakeDataHelper.CreateFakeUserClient();
            var freelance = FakeDataHelper.CreateFakeUserFreelancer();

            // Act
            var project = new Project("Projeto A", "Descrição do Projeto", client.Id, freelance.Id, 10000);

            // Assert
            Assert.True(project.IdClient == client.Id);
            Assert.True(project.IdFreelancer == freelance.Id);
        }

        [Fact]
        public void ProjectIsCreated_Start_Success()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();

            // Act
            project.Start();

            // Assert
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            Assert.True(project.Status == ProjectStatusEnum.InProgress);
            Assert.False(project.StartedAt is null);
        }

        [Fact]
        public void ProjectIsCreatedAndAddComment_Ok_Success()
        {
            // Arrange
            var user = FakeDataHelper.CreateFakeUserClient();
            var project = FakeDataHelper.CreateFakeProject();
            var projectComment = new ProjectComment("comment", project.Id, user.Id);

            // Act
            project.Comments.Add(projectComment);

            // Assert
            Assert.True(project.Comments.Count == 1);
            Assert.True(project.Comments[0].IdProject == project.Id);
            Assert.True(project.Comments[0].IdUser == user.Id);
            Assert.True(project.Comments.Count(c => c.Content == projectComment.Content) == 1);
        }

        [Fact]
        public void ProjectIsInvalidState_Start_TrowsException()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();
            project.Start();

            // Act + Assert 
            Action? start = project.Start;
            var exception = Assert.Throws<InvalidOperationException>(start);
                 
            //xUnit
            Assert.Equal(ProjectMsgs.GetProjectInvalidState(), exception.Message);

            //FluentAssertions
            start.Should()
                .Throw<InvalidOperationException>()
                .WithMessage(ProjectMsgs.GetProjectInvalidState());
        }

        [Fact]
        public void ProjectIsInvalidState_Cancel_TrowsException()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();
            project.Start();
            project.Cancel();

            // Act + Assert 
            Action? cancel = project.Cancel;

            var exception = Assert.Throws<InvalidOperationException>(cancel);
            Assert.Equal(ProjectMsgs.GetProjectInvalidState(), exception.Message);
        }

        [Fact]
        public void ProjectIsInvalidState_Complete_TrowsException()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();
            project.Start();
            project.Cancel();

            // Act + Assert 
            Action? cancel = project.Complete;

            var exception = Assert.Throws<InvalidOperationException>(cancel);
            Assert.Equal(ProjectMsgs.GetProjectInvalidState(), exception.Message);
        }
    }
}

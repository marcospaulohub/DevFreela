using NSubstitute;
using DevFreela.Application.Commands.Users.InsertUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.UnitTests.Fakes;

namespace DevFreela.UnitTests.Application
{
    public class InsertUserHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Insert_Success_NSubstitute()
        {
            // Arrange 
            const int ID = 1;
            var repository = Substitute.For<IUserRepository>();
            var authService = Substitute.For<IAuthService>();

            repository.Add(Arg.Any<User>()).Returns(Task.FromResult(ID));

            var command = FakeDataHelper.CreateFakerInsertClientUserCommand();

            var handler = new InsertUserHandler(repository, authService);

            // Act
            var result = await handler.Handle(command, new CancellationToken());


            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);
        }

        [Fact]
        public async Task InputDataAreOk_Insert_Duplicate_Error_NSubstitute()
        {
            // Arrange 
            var user = FakeDataHelper.CreateFakeUserClient();
            var repository = Substitute.For<IUserRepository>();
            var authService = Substitute.For<IAuthService>();

            repository
                .GetByEmail(user.Email)
                .Returns(user);

            var command = FakeDataHelper.CreateFakerInsertClientUserCommand();
            command.Email = user.Email;

            var handler = new InsertUserHandler(repository, authService);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Usuário já existe.", result.Message);
        }
    }
}

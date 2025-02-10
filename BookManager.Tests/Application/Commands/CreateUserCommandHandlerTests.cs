using BookManager.Application.Commands.CreateUser;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using Moq;

namespace BookManager.Tests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnOk()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();

            var userCommand = new CreateUserCommand()
            {
                Email = "Teste@gmail.com",
                Name = "Testando"
            };

            var userHandler = new CreateUserCommandHandler(userRepositoryMock.Object);

            //Act
            var response = userHandler.Handle(userCommand, new CancellationToken());

            //Assert
            Assert.True(response.Id >= 0);
            userRepositoryMock.Verify(pr => pr.CreateUser(It.IsAny<UserEntity>()), Times.Once);
        }
    }
}

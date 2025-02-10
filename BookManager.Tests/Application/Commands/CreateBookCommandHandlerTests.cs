using BookManager.Application.Commands.CreateBook;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using Moq;

namespace BookManager.Tests.Application.Commands
{
    public class CreateBookCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnOk_()
        {
            //Arrange

            var bookRepository = new Mock<IBookRepository>();

            var createBookCommand = new CreateBookCommand
            {
                Author = "Marcos",
                Isbn = "asdas",
                Title = "Hogwarts",
                Year = 2000
            };

            var createBookCommandHandler = new CreateBookCommandHandler(bookRepository.Object);

            //Act
            var id = await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);
            bookRepository.Verify(pr => pr.CreateBook(It.IsAny<BookEntity>()), Times.Once);
        }
    }
}
